namespace TeleDataAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBoxChatdataSelectData = new System.Windows.Forms.CheckedListBox();
            this.textBoxInputFilename = new System.Windows.Forms.TextBox();
            this.buttonPickFilename = new System.Windows.Forms.Button();
            this.labelSourceJson = new System.Windows.Forms.Label();
            this.panelChatData = new System.Windows.Forms.Panel();
            this.labelChatdataSelectData = new System.Windows.Forms.Label();
            this.labelChatdataSelectChat = new System.Windows.Forms.Label();
            this.buttonChatdata = new System.Windows.Forms.Button();
            this.listBoxChatdataSelectChat = new System.Windows.Forms.ListBox();
            this.radioButtonChatdata = new System.Windows.Forms.RadioButton();
            this.radioButtonUserData = new System.Windows.Forms.RadioButton();
            this.panelUserData = new System.Windows.Forms.Panel();
            this.labelUserDataSelectData = new System.Windows.Forms.Label();
            this.labelUserDataSelectChats = new System.Windows.Forms.Label();
            this.labelUserDataSelectUser = new System.Windows.Forms.Label();
            this.checkedListBoxUserDataSelectChats = new System.Windows.Forms.CheckedListBox();
            this.buttonUserData = new System.Windows.Forms.Button();
            this.listBoxUserDataSelectUser = new System.Windows.Forms.ListBox();
            this.checkedListBoxUserDataSelectData = new System.Windows.Forms.CheckedListBox();
            this.openFileDialogPickFile = new System.Windows.Forms.OpenFileDialog();
            this.buttonParse = new System.Windows.Forms.Button();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.panelChatData.SuspendLayout();
            this.panelUserData.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxChatdataSelectData
            // 
            this.checkedListBoxChatdataSelectData.FormattingEnabled = true;
            this.checkedListBoxChatdataSelectData.Items.AddRange(new object[] {
            "Общая инфа по чату",
            "Таблица пользователей",
            "Временная статистика чата",
            "Таблица Аудио",
            "Таблица ссылок",
            "Таблица Стикеров"});
            this.checkedListBoxChatdataSelectData.Location = new System.Drawing.Point(206, 35);
            this.checkedListBoxChatdataSelectData.Name = "checkedListBoxChatdataSelectData";
            this.checkedListBoxChatdataSelectData.Size = new System.Drawing.Size(291, 154);
            this.checkedListBoxChatdataSelectData.TabIndex = 1;
            // 
            // textBoxInputFilename
            // 
            this.textBoxInputFilename.Location = new System.Drawing.Point(106, 15);
            this.textBoxInputFilename.Name = "textBoxInputFilename";
            this.textBoxInputFilename.Size = new System.Drawing.Size(343, 20);
            this.textBoxInputFilename.TabIndex = 2;
            this.textBoxInputFilename.Text = "input.txt";
            // 
            // buttonPickFilename
            // 
            this.buttonPickFilename.Location = new System.Drawing.Point(455, 15);
            this.buttonPickFilename.Name = "buttonPickFilename";
            this.buttonPickFilename.Size = new System.Drawing.Size(75, 23);
            this.buttonPickFilename.TabIndex = 3;
            this.buttonPickFilename.Text = "...";
            this.buttonPickFilename.UseVisualStyleBackColor = true;
            this.buttonPickFilename.Click += new System.EventHandler(this.buttonPickFilename_Click);
            // 
            // labelSourceJson
            // 
            this.labelSourceJson.AutoSize = true;
            this.labelSourceJson.Location = new System.Drawing.Point(12, 17);
            this.labelSourceJson.Name = "labelSourceJson";
            this.labelSourceJson.Size = new System.Drawing.Size(88, 13);
            this.labelSourceJson.TabIndex = 4;
            this.labelSourceJson.Text = "Source JSON file";
            // 
            // panelChatData
            // 
            this.panelChatData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChatData.Controls.Add(this.labelChatdataSelectData);
            this.panelChatData.Controls.Add(this.labelChatdataSelectChat);
            this.panelChatData.Controls.Add(this.buttonChatdata);
            this.panelChatData.Controls.Add(this.listBoxChatdataSelectChat);
            this.panelChatData.Controls.Add(this.checkedListBoxChatdataSelectData);
            this.panelChatData.Location = new System.Drawing.Point(7, 33);
            this.panelChatData.Name = "panelChatData";
            this.panelChatData.Size = new System.Drawing.Size(590, 205);
            this.panelChatData.TabIndex = 5;
            // 
            // labelChatdataSelectData
            // 
            this.labelChatdataSelectData.AutoSize = true;
            this.labelChatdataSelectData.Location = new System.Drawing.Point(203, 19);
            this.labelChatdataSelectData.Name = "labelChatdataSelectData";
            this.labelChatdataSelectData.Size = new System.Drawing.Size(107, 13);
            this.labelChatdataSelectData.TabIndex = 5;
            this.labelChatdataSelectData.Text = "Select data to collect";
            // 
            // labelChatdataSelectChat
            // 
            this.labelChatdataSelectChat.AutoSize = true;
            this.labelChatdataSelectChat.Location = new System.Drawing.Point(9, 17);
            this.labelChatdataSelectChat.Name = "labelChatdataSelectChat";
            this.labelChatdataSelectChat.Size = new System.Drawing.Size(61, 13);
            this.labelChatdataSelectChat.TabIndex = 4;
            this.labelChatdataSelectChat.Text = "Select chat";
            // 
            // buttonChatdata
            // 
            this.buttonChatdata.Location = new System.Drawing.Point(503, 166);
            this.buttonChatdata.Name = "buttonChatdata";
            this.buttonChatdata.Size = new System.Drawing.Size(75, 23);
            this.buttonChatdata.TabIndex = 3;
            this.buttonChatdata.Text = "Collect";
            this.buttonChatdata.UseVisualStyleBackColor = true;
            this.buttonChatdata.Click += new System.EventHandler(this.buttonChatdata_Click);
            // 
            // listBoxChatdataSelectChat
            // 
            this.listBoxChatdataSelectChat.FormattingEnabled = true;
            this.listBoxChatdataSelectChat.Location = new System.Drawing.Point(12, 33);
            this.listBoxChatdataSelectChat.Name = "listBoxChatdataSelectChat";
            this.listBoxChatdataSelectChat.Size = new System.Drawing.Size(178, 160);
            this.listBoxChatdataSelectChat.TabIndex = 2;
            // 
            // radioButtonChatdata
            // 
            this.radioButtonChatdata.AutoSize = true;
            this.radioButtonChatdata.Checked = true;
            this.radioButtonChatdata.Location = new System.Drawing.Point(7, 10);
            this.radioButtonChatdata.Name = "radioButtonChatdata";
            this.radioButtonChatdata.Size = new System.Drawing.Size(71, 17);
            this.radioButtonChatdata.TabIndex = 6;
            this.radioButtonChatdata.TabStop = true;
            this.radioButtonChatdata.Text = "Chat data";
            this.radioButtonChatdata.UseVisualStyleBackColor = true;
            this.radioButtonChatdata.CheckedChanged += new System.EventHandler(this.radioButtonChatdata_CheckedChanged);
            // 
            // radioButtonUserData
            // 
            this.radioButtonUserData.AutoSize = true;
            this.radioButtonUserData.Location = new System.Drawing.Point(7, 244);
            this.radioButtonUserData.Name = "radioButtonUserData";
            this.radioButtonUserData.Size = new System.Drawing.Size(71, 17);
            this.radioButtonUserData.TabIndex = 7;
            this.radioButtonUserData.Text = "User data";
            this.radioButtonUserData.UseVisualStyleBackColor = true;
            this.radioButtonUserData.CheckedChanged += new System.EventHandler(this.radioButtonUserData_CheckedChanged);
            // 
            // panelUserData
            // 
            this.panelUserData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserData.Controls.Add(this.labelUserDataSelectData);
            this.panelUserData.Controls.Add(this.labelUserDataSelectChats);
            this.panelUserData.Controls.Add(this.labelUserDataSelectUser);
            this.panelUserData.Controls.Add(this.checkedListBoxUserDataSelectChats);
            this.panelUserData.Controls.Add(this.buttonUserData);
            this.panelUserData.Controls.Add(this.listBoxUserDataSelectUser);
            this.panelUserData.Controls.Add(this.checkedListBoxUserDataSelectData);
            this.panelUserData.Enabled = false;
            this.panelUserData.Location = new System.Drawing.Point(7, 267);
            this.panelUserData.Name = "panelUserData";
            this.panelUserData.Size = new System.Drawing.Size(590, 205);
            this.panelUserData.TabIndex = 6;
            // 
            // labelUserDataSelectData
            // 
            this.labelUserDataSelectData.AutoSize = true;
            this.labelUserDataSelectData.Location = new System.Drawing.Point(323, 24);
            this.labelUserDataSelectData.Name = "labelUserDataSelectData";
            this.labelUserDataSelectData.Size = new System.Drawing.Size(107, 13);
            this.labelUserDataSelectData.TabIndex = 6;
            this.labelUserDataSelectData.Text = "Select data to collect";
            // 
            // labelUserDataSelectChats
            // 
            this.labelUserDataSelectChats.AutoSize = true;
            this.labelUserDataSelectChats.Location = new System.Drawing.Point(140, 20);
            this.labelUserDataSelectChats.Name = "labelUserDataSelectChats";
            this.labelUserDataSelectChats.Size = new System.Drawing.Size(66, 13);
            this.labelUserDataSelectChats.TabIndex = 7;
            this.labelUserDataSelectChats.Text = "Select chats";
            // 
            // labelUserDataSelectUser
            // 
            this.labelUserDataSelectUser.AutoSize = true;
            this.labelUserDataSelectUser.Location = new System.Drawing.Point(10, 20);
            this.labelUserDataSelectUser.Name = "labelUserDataSelectUser";
            this.labelUserDataSelectUser.Size = new System.Drawing.Size(60, 13);
            this.labelUserDataSelectUser.TabIndex = 6;
            this.labelUserDataSelectUser.Text = "Select user";
            // 
            // checkedListBoxUserDataSelectChats
            // 
            this.checkedListBoxUserDataSelectChats.FormattingEnabled = true;
            this.checkedListBoxUserDataSelectChats.Location = new System.Drawing.Point(143, 39);
            this.checkedListBoxUserDataSelectChats.Name = "checkedListBoxUserDataSelectChats";
            this.checkedListBoxUserDataSelectChats.Size = new System.Drawing.Size(174, 154);
            this.checkedListBoxUserDataSelectChats.TabIndex = 4;
            // 
            // buttonUserData
            // 
            this.buttonUserData.Location = new System.Drawing.Point(503, 170);
            this.buttonUserData.Name = "buttonUserData";
            this.buttonUserData.Size = new System.Drawing.Size(75, 23);
            this.buttonUserData.TabIndex = 3;
            this.buttonUserData.Text = "Collect";
            this.buttonUserData.UseVisualStyleBackColor = true;
            // 
            // listBoxUserDataSelectUser
            // 
            this.listBoxUserDataSelectUser.FormattingEnabled = true;
            this.listBoxUserDataSelectUser.Location = new System.Drawing.Point(12, 46);
            this.listBoxUserDataSelectUser.Name = "listBoxUserDataSelectUser";
            this.listBoxUserDataSelectUser.Size = new System.Drawing.Size(125, 147);
            this.listBoxUserDataSelectUser.TabIndex = 2;
            // 
            // checkedListBoxUserDataSelectData
            // 
            this.checkedListBoxUserDataSelectData.FormattingEnabled = true;
            this.checkedListBoxUserDataSelectData.Items.AddRange(new object[] {
            "Общая инфа по чату",
            "Таблица пользователей",
            "Временная статистика чата",
            "Таблица Аудио",
            "Таблица ссылок",
            "Таблица Стикеров"});
            this.checkedListBoxUserDataSelectData.Location = new System.Drawing.Point(323, 39);
            this.checkedListBoxUserDataSelectData.Name = "checkedListBoxUserDataSelectData";
            this.checkedListBoxUserDataSelectData.Size = new System.Drawing.Size(174, 154);
            this.checkedListBoxUserDataSelectData.TabIndex = 1;
            // 
            // openFileDialogPickFile
            // 
            this.openFileDialogPickFile.FileName = "result.json";
            this.openFileDialogPickFile.Filter = "JSON Files|*.json|TXT Files|*.txt|All files|*.*";
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(537, 13);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(75, 23);
            this.buttonParse.TabIndex = 8;
            this.buttonParse.Text = "Parse";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // panelTotal
            // 
            this.panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotal.Controls.Add(this.panelUserData);
            this.panelTotal.Controls.Add(this.radioButtonUserData);
            this.panelTotal.Controls.Add(this.radioButtonChatdata);
            this.panelTotal.Controls.Add(this.panelChatData);
            this.panelTotal.Enabled = false;
            this.panelTotal.Location = new System.Drawing.Point(12, 46);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(604, 483);
            this.panelTotal.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 539);
            this.Controls.Add(this.buttonParse);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.labelSourceJson);
            this.Controls.Add(this.buttonPickFilename);
            this.Controls.Add(this.textBoxInputFilename);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelChatData.ResumeLayout(false);
            this.panelChatData.PerformLayout();
            this.panelUserData.ResumeLayout(false);
            this.panelUserData.PerformLayout();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxChatdataSelectData;
        private System.Windows.Forms.TextBox textBoxInputFilename;
        private System.Windows.Forms.Button buttonPickFilename;
        private System.Windows.Forms.Label labelSourceJson;
        private System.Windows.Forms.Panel panelChatData;
        private System.Windows.Forms.Label labelChatdataSelectData;
        private System.Windows.Forms.Label labelChatdataSelectChat;
        private System.Windows.Forms.Button buttonChatdata;
        private System.Windows.Forms.ListBox listBoxChatdataSelectChat;
        private System.Windows.Forms.RadioButton radioButtonChatdata;
        private System.Windows.Forms.RadioButton radioButtonUserData;
        private System.Windows.Forms.Panel panelUserData;
        private System.Windows.Forms.Label labelUserDataSelectData;
        private System.Windows.Forms.Label labelUserDataSelectChats;
        private System.Windows.Forms.Label labelUserDataSelectUser;
        private System.Windows.Forms.CheckedListBox checkedListBoxUserDataSelectChats;
        private System.Windows.Forms.Button buttonUserData;
        private System.Windows.Forms.ListBox listBoxUserDataSelectUser;
        private System.Windows.Forms.CheckedListBox checkedListBoxUserDataSelectData;
        private System.Windows.Forms.OpenFileDialog openFileDialogPickFile;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.Panel panelTotal;
    }
}

