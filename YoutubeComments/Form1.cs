using Google.Apis.YouTube.v3.Data;

namespace YoutubeComments
{
    public partial class Form1 : Form
    {
        YoutubeAPI mYoutubeAPI = new YoutubeAPI();
        List<LiveChatMessage> mLiveChatMes = new List<LiveChatMessage>();
        List<LiveChatMessage> mSuperChatMes = new List<LiveChatMessage>();
        List<LiveChatMessage> mMarkedChatMes = new List<LiveChatMessage>();
        int mFontSize = 9;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        void Init()
        {
            mLiveChatMes.Clear();
            mSuperChatMes.Clear();
            mMarkedChatMes.Clear();
            listBoxSuperChat.Items.Clear();
            listBoxComments.Items.Clear();
            listBoxMarked.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBoxApiKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxVideoId_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxMain_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 開始する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Init();

            bool success = mYoutubeAPI.Start(textBoxVideoId.Text, textBoxApiKey.Text, MessageCallbackFunc, ErrofCallbackFunc);

            if (!success)
            {
                textBoxMain.Text = "初期化に失敗しました。";
            }
        }

        /// <summary>
        /// 停止する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            mYoutubeAPI.Stop();
        }

        /// <summary>
        /// メッセージを受信したときに呼ばれる
        /// </summary>
        /// <param name="liveChat">受信メッセージ</param>
        void MessageCallbackFunc(LiveChatMessage liveChat)
        {
            if (liveChat.Snippet.Type == "superChatEvent" || liveChat.Snippet.Type == "superStickerEvent")
            {
                WriteTextSafeSuperChat(liveChat);
            }
            else
            {
                WriteTextSafeChat(liveChat);
            }
        }

        /// <summary>
        /// ListBoxにメッセージを追加（通常チャット）
        /// 安全なタイミングになるまで再帰的に呼ぶ。
        /// </summary>
        /// <param name="liveChat"></param>
        void WriteTextSafeChat(LiveChatMessage liveChat)
        {
            if (listBoxComments.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { WriteTextSafeChat(liveChat); };
                listBoxComments.Invoke(safeWrite);
            }
            else
            {
                WriteTextChat(liveChat);
            }
        }

        /// <summary>
        /// ListBoxにメッセージを追加（通常チャット）
        /// 安全なタイミングになるまで再帰的に呼ぶ。
        /// </summary>
        /// <param name="liveChat"></param>
        void WriteTextSafeSuperChat(LiveChatMessage liveChat)
        {
            if (listBoxSuperChat.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { WriteTextSafeSuperChat(liveChat); };
                listBoxSuperChat.Invoke(safeWrite);
            }
            else
            {
                WriteTextSuperChat(liveChat);
            }
        }

        /// <summary>
        /// ListBoxにメッセージを追加（通常チャット）
        /// </summary>
        /// <param name="liveChat"></param>
        void WriteTextChat(LiveChatMessage liveChat)
        {
            string text = $"{liveChat.AuthorDetails.DisplayName} : {liveChat.Snippet.DisplayMessage}";

            if (mLiveChatMes.Count > 1000)
            {
                listBoxComments.Items.RemoveAt(mLiveChatMes.Count - 1);
                mLiveChatMes.RemoveAt(mLiveChatMes.Count - 1);
            }

            listBoxComments.Items.Insert(0, text);
            mLiveChatMes.Insert(0, liveChat);
        }

        /// <summary>
        /// ListBoxにメッセージを追加（通常チャット）
        /// </summary>
        /// <param name="liveChat"></param>
        void WriteTextSuperChat(LiveChatMessage liveChat)
        {
            listBoxSuperChat.Items.Add(liveChat.Snippet.DisplayMessage);
            mSuperChatMes.Add(liveChat);
        }

        /// <summary>
        ///  YoutubeAPIエラーを受け取ったときに呼ばれる
        /// </summary>
        /// <param name="error"></param>
        void ErrofCallbackFunc(string error)
        {
            if (textBoxMain.InvokeRequired)
            {
                Action safeWrite = delegate { ErrofCallbackFunc(error); };
                textBoxMain.Invoke(safeWrite);
            }
            else
            {
                textBoxMain.Text = error;
            }
        }

        /// <summary>
        /// 通常コメントにカーソルを合わせたときに呼ばれる。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxComments.SelectedIndex < 0 || mLiveChatMes.Count <= listBoxComments.SelectedIndex)
            {
                return;
            }

            LiveChatMessage liveChat = mLiveChatMes[listBoxComments.SelectedIndex];
            WriteMainTextChat(liveChat);
        }

        void WriteMainTextChat(LiveChatMessage liveChat)
        {
            if (liveChat.Snippet.Type == "superChatEvent" || liveChat.Snippet.Type == "superStickerEvent")
            {
                if (liveChat.Snippet.Type == "superChatEvent")
                {
                    textBoxMain.Text = liveChat.AuthorDetails.DisplayName + "\r\n";
                    textBoxMain.Text += liveChat.Snippet.SuperChatDetails.AmountDisplayString + "\r\n";
                    textBoxMain.Text += liveChat.Snippet.SuperChatDetails.UserComment;
                }
                else
                {
                    textBoxMain.Text = liveChat.AuthorDetails.DisplayName + "\r\n";
                    textBoxMain.Text += "superStickerEvent\r\n";
                    textBoxMain.Text += liveChat.Snippet.DisplayMessage;
                }
            }
            else
            {
                textBoxMain.Text = liveChat.AuthorDetails.DisplayName + "\r\n";
                textBoxMain.Text += liveChat.Snippet.DisplayMessage;
            }
        }

        private void listBoxSuperChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSuperChat.SelectedIndex < 0 || mSuperChatMes.Count <= listBoxSuperChat.SelectedIndex)
            {
                return;
            }

            LiveChatMessage liveChat = mSuperChatMes[listBoxSuperChat.SelectedIndex];
            WriteMainTextChat(liveChat);

        }

        private void listBoxMarked_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMarked.SelectedIndex < 0 || mMarkedChatMes.Count <= listBoxMarked.SelectedIndex)
            {
                return;
            }

            LiveChatMessage liveChat = mMarkedChatMes[listBoxMarked.SelectedIndex];
            WriteMainTextChat(liveChat);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (listBoxSuperChat.SelectedIndex < 0 || mSuperChatMes.Count <= listBoxSuperChat.SelectedIndex)
            {
                return;
            }

            mMarkedChatMes.Insert(0, mSuperChatMes[listBoxSuperChat.SelectedIndex]);
            mSuperChatMes.RemoveAt(listBoxSuperChat.SelectedIndex);

            listBoxMarked.Items.Insert(0, listBoxSuperChat.Items[listBoxSuperChat.SelectedIndex]);
            listBoxSuperChat.Items.RemoveAt(listBoxSuperChat.SelectedIndex);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (listBoxMarked.SelectedIndex < 0 || mMarkedChatMes.Count <= listBoxMarked.SelectedIndex)
            {
                return;
            }

            mSuperChatMes.Insert(0, mMarkedChatMes[listBoxMarked.SelectedIndex]);
            mMarkedChatMes.RemoveAt(listBoxMarked.SelectedIndex);

            listBoxSuperChat.Items.Insert(0, listBoxMarked.Items[listBoxMarked.SelectedIndex]);
            listBoxMarked.Items.RemoveAt(listBoxMarked.SelectedIndex);
        }

        private void buttonBig_Click(object sender, EventArgs e)
        {
            mFontSize++;
            textBoxMain.Font = new Font("MS UI Gothic", mFontSize);
        }

        private void buttonSmall_Click(object sender, EventArgs e)
        {
            mFontSize--;

            if (mFontSize < 8)
            {
                mFontSize = 8;
            }

            textBoxMain.Font = new Font("MS UI Gothic", mFontSize);
        }
    }
}