namespace YoutubeComments
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.textBoxVideoId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.listBoxComments = new System.Windows.Forms.ListBox();
            this.listBoxSuperChat = new System.Windows.Forms.ListBox();
            this.listBoxMarked = new System.Windows.Forms.ListBox();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonBig = new System.Windows.Forms.Button();
            this.buttonSmall = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "API KEY";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(72, 18);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(376, 23);
            this.textBoxApiKey.TabIndex = 1;
            this.textBoxApiKey.TextChanged += new System.EventHandler(this.textBoxApiKey_TextChanged);
            // 
            // textBoxVideoId
            // 
            this.textBoxVideoId.Location = new System.Drawing.Point(72, 47);
            this.textBoxVideoId.Name = "textBoxVideoId";
            this.textBoxVideoId.Size = new System.Drawing.Size(376, 23);
            this.textBoxVideoId.TabIndex = 3;
            this.textBoxVideoId.TextChanged += new System.EventHandler(this.textBoxVideoId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "VIDEO ID";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(280, 85);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(373, 85);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxMain
            // 
            this.textBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMain.Location = new System.Drawing.Point(18, 270);
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.Size = new System.Drawing.Size(496, 172);
            this.textBoxMain.TabIndex = 4;
            this.textBoxMain.TextChanged += new System.EventHandler(this.textBoxMain_TextChanged);
            // 
            // listBoxComments
            // 
            this.listBoxComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxComments.FormattingEnabled = true;
            this.listBoxComments.ItemHeight = 15;
            this.listBoxComments.Location = new System.Drawing.Point(520, 18);
            this.listBoxComments.Name = "listBoxComments";
            this.listBoxComments.Size = new System.Drawing.Size(268, 424);
            this.listBoxComments.TabIndex = 7;
            this.listBoxComments.SelectedIndexChanged += new System.EventHandler(this.listBoxComments_SelectedIndexChanged);
            // 
            // listBoxSuperChat
            // 
            this.listBoxSuperChat.FormattingEnabled = true;
            this.listBoxSuperChat.ItemHeight = 15;
            this.listBoxSuperChat.Location = new System.Drawing.Point(18, 98);
            this.listBoxSuperChat.Name = "listBoxSuperChat";
            this.listBoxSuperChat.Size = new System.Drawing.Size(234, 154);
            this.listBoxSuperChat.TabIndex = 8;
            this.listBoxSuperChat.SelectedIndexChanged += new System.EventHandler(this.listBoxSuperChat_SelectedIndexChanged);
            // 
            // listBoxMarked
            // 
            this.listBoxMarked.FormattingEnabled = true;
            this.listBoxMarked.ItemHeight = 15;
            this.listBoxMarked.Location = new System.Drawing.Point(330, 128);
            this.listBoxMarked.Name = "listBoxMarked";
            this.listBoxMarked.Size = new System.Drawing.Size(184, 124);
            this.listBoxMarked.TabIndex = 9;
            this.listBoxMarked.SelectedIndexChanged += new System.EventHandler(this.listBoxMarked_SelectedIndexChanged);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(258, 141);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(66, 48);
            this.buttonRight.TabIndex = 10;
            this.buttonRight.Text = ">>";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(258, 212);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(66, 23);
            this.buttonLeft.TabIndex = 11;
            this.buttonLeft.Text = "<<";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonBig
            // 
            this.buttonBig.Location = new System.Drawing.Point(258, 241);
            this.buttonBig.Name = "buttonBig";
            this.buttonBig.Size = new System.Drawing.Size(24, 23);
            this.buttonBig.TabIndex = 12;
            this.buttonBig.Text = "大";
            this.buttonBig.UseVisualStyleBackColor = true;
            this.buttonBig.Click += new System.EventHandler(this.buttonBig_Click);
            // 
            // buttonSmall
            // 
            this.buttonSmall.Location = new System.Drawing.Point(300, 241);
            this.buttonSmall.Name = "buttonSmall";
            this.buttonSmall.Size = new System.Drawing.Size(24, 23);
            this.buttonSmall.TabIndex = 13;
            this.buttonSmall.Text = "小";
            this.buttonSmall.UseVisualStyleBackColor = true;
            this.buttonSmall.Click += new System.EventHandler(this.buttonSmall_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(88, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Super Chat";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSmall);
            this.Controls.Add(this.buttonBig);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.listBoxMarked);
            this.Controls.Add(this.listBoxSuperChat);
            this.Controls.Add(this.listBoxComments);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textBoxMain);
            this.Controls.Add(this.textBoxVideoId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxApiKey);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "YoutubeComments";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBoxApiKey;
        private TextBox textBoxVideoId;
        private Label label2;
        private Button buttonStop;
        private Button buttonStart;
        private TextBox textBoxMain;
        private ListBox listBoxComments;
        private ListBox listBoxSuperChat;
        private ListBox listBoxMarked;
        private Button buttonRight;
        private Button buttonLeft;
        private Button buttonBig;
        private Button buttonSmall;
        private Label label3;
    }
}