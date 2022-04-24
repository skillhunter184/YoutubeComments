using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;

using Google.Apis.YouTube.v3.Data;

namespace YoutubeComments
{
    class YoutubeAPI
    {
        public delegate void YoutubeComment(LiveChatMessage liveChat);
        public delegate void ErrorFunction(string error);

        bool mStopFlag;
        YoutubeComment mYoutubeComment;
        ErrorFunction mErrorFunction;

        /// <summary>
        /// Live Chatの監視を開始する
        /// </summary>
        /// <param name="videoId">YoutubeのビデオID</param>
        /// <param name="apiKey">Google Cloud PlatformのAPI ID</param>
        /// <param name="youtubeComment">Live Chatメッセージ毎に呼ぶコールバック</param>
        /// <param name="errorFunction">エラー時に呼ぶコールバック</param>
        /// <returns></returns>
        public bool Start(string videoId, string apiKey, YoutubeComment youtubeComment, ErrorFunction errorFunction)
        {
            mYoutubeComment = youtubeComment;
            mErrorFunction = errorFunction;
            mStopFlag = false;

            if (videoId == "" || apiKey == "")
            {
                return false;
            }

            Action action = delegate { Task task = MainLoop(videoId, apiKey); };
            Task.Run(action);

            return true;
        }

        /// <summary>
        /// 停止する
        /// </summary>
        public void Stop()
        {
            mStopFlag = true;
        }

        /// <summary>
        /// メインループ
        /// </summary>
        /// <returns></returns>
        async Task MainLoop(string videoId, string apiKey)
        {
            YouTubeService youtubeService = null;
            string activeLiveChatId = "";

            // Live ChatのIDを取得する
            try
            {
                youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = apiKey
                });

                var liveStreamingDetailds = youtubeService.Videos.List("LiveStreamingDetails");
                liveStreamingDetailds.Id = videoId;

                var videoListResponse = liveStreamingDetailds.Execute();

                if (videoListResponse.Items.Count > 0)
                {
                    activeLiveChatId = videoListResponse.Items[0].LiveStreamingDetails.ActiveLiveChatId;
                }
            }
            catch (Exception e)
            {
                mErrorFunction.Invoke(e.ToString());
            }

            if(activeLiveChatId == "" || youtubeService == null)
            {
                mErrorFunction.Invoke("Not Found \"Active live chat ID\".");
                return;
            }


            // Live Chatの取得を開始する
            string nextPageToken = null;

            while (!mStopFlag)
            {
                var authorDetails = youtubeService.LiveChatMessages.List(activeLiveChatId, "snippet,authorDetails");
                authorDetails.PageToken = nextPageToken;

                var liveChatMessageListResponse = await authorDetails.ExecuteAsync();

                if (mStopFlag)
                {
                    return;
                }

                foreach (var liveChatMessage in liveChatMessageListResponse.Items)
                {
                    try
                    {
                        mYoutubeComment.Invoke(liveChatMessage);
                    }
                    catch(Exception e)
                    {
                        mErrorFunction.Invoke(e.ToString());
                    }
                }

                if (liveChatMessageListResponse.PollingIntervalMillis != null)
                {
                    await Task.Delay((int)liveChatMessageListResponse.PollingIntervalMillis);
                }

                nextPageToken = liveChatMessageListResponse.NextPageToken;
            }
        }
    }
}
