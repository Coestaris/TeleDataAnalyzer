using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TeleDataAnalyzerLib;
using TeleDataAnalyzerLib.Tasks;

namespace TeleDataAnalyzer
{
    public partial class MainForm : Form
    {
        private string FileName;
        private Parser parser;

        public MainForm()
        {
            InitializeComponent();
            FileName = textBoxInputFilename.Text;
            openFileDialogPickFile.InitialDirectory = Environment.CurrentDirectory;
            parser = new Parser();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
        }

        private void buttonPickFilename_Click(object sender, EventArgs e)
        {
            if(openFileDialogPickFile.ShowDialog() == DialogResult.OK)
            {
                textBoxInputFilename.Text = openFileDialogPickFile.FileName;
                FileName = textBoxInputFilename.Text;
            }
        }

        private void radioButtonChatdata_CheckedChanged(object sender, EventArgs e)
        {
            panelChatData.Enabled = radioButtonChatdata.Checked;
        }

        private void radioButtonUserData_CheckedChanged(object sender, EventArgs e)
        {
            panelUserData.Enabled = radioButtonUserData.Checked;
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            new ProgressDialog(
                new List<ParseTask>()
                {
                    new ParseJSONTask(FileName),
                    new ParseMessagesTask()
                }, 
                parser
            ).ShowDialog();

            panelTotal.Enabled = true;

            listBoxChatdataSelectChat.Items.Clear();
            listBoxChatdataSelectChat.Items.AddRange(
                parser.Chats.Select(p => p.ToString()).ToArray());

            checkedListBoxUserDataSelectChats.Items.Clear();
            checkedListBoxUserDataSelectChats.Items.AddRange(
                parser.Chats.Select(p => p.ToString()).ToArray());

            listBoxUserDataSelectUser.Items.Clear();
            listBoxUserDataSelectUser.Items.AddRange(
                parser.GlobalUsers.ToArray());
        }
    }
}
