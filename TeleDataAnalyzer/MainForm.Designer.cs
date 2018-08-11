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
            this.labelUserDataSelectChats = new System.Windows.Forms.Label();
            this.labelUserDataSelectUser = new System.Windows.Forms.Label();
            this.checkedListBoxUserDataSelectChats = new System.Windows.Forms.CheckedListBox();
            this.buttonUserData = new System.Windows.Forms.Button();
            this.listBoxUserDataSelectUser = new System.Windows.Forms.ListBox();
            this.openFileDialogPickFile = new System.Windows.Forms.OpenFileDialog();
            this.buttonParse = new System.Windows.Forms.Button();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.checkedListBoxChatdataSelectUsers = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panelChatData.SuspendLayout();
            this.panelUserData.SuspendLayout();
            this.panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxInputFilename
            // 
            this.textBoxInputFilename.Location = new System.Drawing.Point(106, 15);
            this.textBoxInputFilename.Name = "textBoxInputFilename";
            this.textBoxInputFilename.Size = new System.Drawing.Size(325, 20);
            this.textBoxInputFilename.TabIndex = 2;
            this.textBoxInputFilename.Text = "input.txt";
            // 
            // buttonPickFilename
            // 
            this.buttonPickFilename.Location = new System.Drawing.Point(437, 13);
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
            this.panelChatData.Controls.Add(this.splitContainer2);
            this.panelChatData.Controls.Add(this.buttonChatdata);
            this.panelChatData.Location = new System.Drawing.Point(7, 33);
            this.panelChatData.Name = "panelChatData";
            this.panelChatData.Size = new System.Drawing.Size(561, 205);
            this.panelChatData.TabIndex = 5;
            // 
            // labelChatdataSelectData
            // 
            this.labelChatdataSelectData.AutoSize = true;
            this.labelChatdataSelectData.Location = new System.Drawing.Point(-3, 1);
            this.labelChatdataSelectData.Name = "labelChatdataSelectData";
            this.labelChatdataSelectData.Size = new System.Drawing.Size(89, 13);
            this.labelChatdataSelectData.TabIndex = 5;
            this.labelChatdataSelectData.Text = "Select chat users";
            // 
            // labelChatdataSelectChat
            // 
            this.labelChatdataSelectChat.AutoSize = true;
            this.labelChatdataSelectChat.Location = new System.Drawing.Point(5, 1);
            this.labelChatdataSelectChat.Name = "labelChatdataSelectChat";
            this.labelChatdataSelectChat.Size = new System.Drawing.Size(61, 13);
            this.labelChatdataSelectChat.TabIndex = 4;
            this.labelChatdataSelectChat.Text = "Select chat";
            // 
            // buttonChatdata
            // 
            this.buttonChatdata.Location = new System.Drawing.Point(469, 177);
            this.buttonChatdata.Name = "buttonChatdata";
            this.buttonChatdata.Size = new System.Drawing.Size(75, 23);
            this.buttonChatdata.TabIndex = 3;
            this.buttonChatdata.Text = "Collect";
            this.buttonChatdata.UseVisualStyleBackColor = true;
            this.buttonChatdata.Click += new System.EventHandler(this.buttonChatdata_Click);
            // 
            // listBoxChatdataSelectChat
            // 
            this.listBoxChatdataSelectChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxChatdataSelectChat.FormattingEnabled = true;
            this.listBoxChatdataSelectChat.Location = new System.Drawing.Point(0, 17);
            this.listBoxChatdataSelectChat.Name = "listBoxChatdataSelectChat";
            this.listBoxChatdataSelectChat.Size = new System.Drawing.Size(177, 121);
            this.listBoxChatdataSelectChat.TabIndex = 2;
            this.listBoxChatdataSelectChat.SelectedIndexChanged += new System.EventHandler(this.listBoxChatdataSelectChat_SelectedIndexChanged);
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
            this.panelUserData.Controls.Add(this.splitContainer1);
            this.panelUserData.Controls.Add(this.buttonUserData);
            this.panelUserData.Enabled = false;
            this.panelUserData.Location = new System.Drawing.Point(7, 267);
            this.panelUserData.Name = "panelUserData";
            this.panelUserData.Size = new System.Drawing.Size(561, 219);
            this.panelUserData.TabIndex = 6;
            // 
            // labelUserDataSelectChats
            // 
            this.labelUserDataSelectChats.AutoSize = true;
            this.labelUserDataSelectChats.Location = new System.Drawing.Point(3, 2);
            this.labelUserDataSelectChats.Name = "labelUserDataSelectChats";
            this.labelUserDataSelectChats.Size = new System.Drawing.Size(66, 13);
            this.labelUserDataSelectChats.TabIndex = 7;
            this.labelUserDataSelectChats.Text = "Select chats";
            // 
            // labelUserDataSelectUser
            // 
            this.labelUserDataSelectUser.AutoSize = true;
            this.labelUserDataSelectUser.Location = new System.Drawing.Point(3, 3);
            this.labelUserDataSelectUser.Name = "labelUserDataSelectUser";
            this.labelUserDataSelectUser.Size = new System.Drawing.Size(60, 13);
            this.labelUserDataSelectUser.TabIndex = 6;
            this.labelUserDataSelectUser.Text = "Select user";
            // 
            // checkedListBoxUserDataSelectChats
            // 
            this.checkedListBoxUserDataSelectChats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkedListBoxUserDataSelectChats.FormattingEnabled = true;
            this.checkedListBoxUserDataSelectChats.Location = new System.Drawing.Point(0, 18);
            this.checkedListBoxUserDataSelectChats.Name = "checkedListBoxUserDataSelectChats";
            this.checkedListBoxUserDataSelectChats.Size = new System.Drawing.Size(350, 139);
            this.checkedListBoxUserDataSelectChats.TabIndex = 4;
            // 
            // buttonUserData
            // 
            this.buttonUserData.Location = new System.Drawing.Point(469, 189);
            this.buttonUserData.Name = "buttonUserData";
            this.buttonUserData.Size = new System.Drawing.Size(75, 23);
            this.buttonUserData.TabIndex = 3;
            this.buttonUserData.Text = "Collect";
            this.buttonUserData.UseVisualStyleBackColor = true;
            // 
            // listBoxUserDataSelectUser
            // 
            this.listBoxUserDataSelectUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxUserDataSelectUser.FormattingEnabled = true;
            this.listBoxUserDataSelectUser.Location = new System.Drawing.Point(0, 23);
            this.listBoxUserDataSelectUser.Name = "listBoxUserDataSelectUser";
            this.listBoxUserDataSelectUser.Size = new System.Drawing.Size(177, 134);
            this.listBoxUserDataSelectUser.TabIndex = 2;
            this.listBoxUserDataSelectUser.SelectedIndexChanged += new System.EventHandler(this.listBoxUserDataSelectUser_SelectedIndexChanged);
            // 
            // openFileDialogPickFile
            // 
            this.openFileDialogPickFile.FileName = "result.json";
            this.openFileDialogPickFile.Filter = "JSON Files|*.json|TXT Files|*.txt|All files|*.*";
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(515, 13);
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
            this.panelTotal.Size = new System.Drawing.Size(578, 495);
            this.panelTotal.TabIndex = 9;
            // 
            // checkedListBoxChatdataSelectUsers
            // 
            this.checkedListBoxChatdataSelectUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkedListBoxChatdataSelectUsers.FormattingEnabled = true;
            this.checkedListBoxChatdataSelectUsers.Location = new System.Drawing.Point(0, 14);
            this.checkedListBoxChatdataSelectUsers.Name = "checkedListBoxChatdataSelectUsers";
            this.checkedListBoxChatdataSelectUsers.Size = new System.Drawing.Size(350, 124);
            this.checkedListBoxChatdataSelectUsers.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(13, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxUserDataSelectUser);
            this.splitContainer1.Panel1.Controls.Add(this.labelUserDataSelectUser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkedListBoxUserDataSelectChats);
            this.splitContainer1.Panel2.Controls.Add(this.labelUserDataSelectChats);
            this.splitContainer1.Size = new System.Drawing.Size(531, 157);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 8;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(13, 33);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBoxChatdataSelectChat);
            this.splitContainer2.Panel1.Controls.Add(this.labelChatdataSelectChat);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.checkedListBoxChatdataSelectUsers);
            this.splitContainer2.Panel2.Controls.Add(this.labelChatdataSelectData);
            this.splitContainer2.Size = new System.Drawing.Size(531, 138);
            this.splitContainer2.SplitterDistance = 177;
            this.splitContainer2.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 553);
            this.Controls.Add(this.buttonParse);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.labelSourceJson);
            this.Controls.Add(this.buttonPickFilename);
            this.Controls.Add(this.textBoxInputFilename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeleDataAnalyzer";
            this.panelChatData.ResumeLayout(false);
            this.panelUserData.ResumeLayout(false);
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label labelUserDataSelectChats;
        private System.Windows.Forms.Label labelUserDataSelectUser;
        private System.Windows.Forms.CheckedListBox checkedListBoxUserDataSelectChats;
        private System.Windows.Forms.Button buttonUserData;
        private System.Windows.Forms.ListBox listBoxUserDataSelectUser;
        private System.Windows.Forms.OpenFileDialog openFileDialogPickFile;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.CheckedListBox checkedListBoxChatdataSelectUsers;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

