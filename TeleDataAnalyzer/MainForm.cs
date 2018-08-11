using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TeleDataAnalyzerLib;
using TeleDataAnalyzerLib.Tasks;
using TeleDataAnalyzerLib.Tasks.Analyse;

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
            if(!File.Exists(FileName))
            {
                MessageBox.Show($"File \"{FileName}\" not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            new ProgressDialog(
                new List<ParseTask>()
                {
                    new ParseJSONTask(FileName),
                    new ParseMessagesTask(),
                    new PostProcessTask()
                }, 
                parser
            ).ShowDialog();

            panelTotal.Enabled = true;

            listBoxChatdataSelectChat.Items.Clear();
            listBoxChatdataSelectChat.Items.AddRange(
                parser.Chats.Select(p => p.ToString()).ToArray());
            listBoxChatdataSelectChat.SelectedIndex = 0;

            checkedListBoxUserDataSelectChats.Items.Clear();
            checkedListBoxUserDataSelectChats.Items.AddRange(
                parser.Chats.Select(p => p.ToString()).ToArray());

            listBoxUserDataSelectUser.Items.Clear();
            listBoxUserDataSelectUser.Items.AddRange(
                parser.GlobalUsers.ToArray());
        }

        private void buttonChatdata_Click(object sender, EventArgs e)
        {
            try
            {
                using (var package = new ExcelPackage(new System.IO.FileInfo("output.xlsx")))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(DateTime.Now.ToString());

                    ExcelWriter writer = new ExcelWriter()
                    {
                        chat = parser.Chats[listBoxChatdataSelectChat.SelectedIndex],
                        worksheet = worksheet
                    };

                    worksheet.DefaultRowHeight = 14;
                    worksheet.Column(1).Width = 44;
                    worksheet.Column(2).Width = 33;

                    writer.WriteString("Имя чата", writer.chat.Name);
                    writer.WriteString("Тип чата", writer.chat.Type.ToString());
                    writer.WriteString("Кол-во участников чата", writer.chat.Participants.Count);

                    using (var range = worksheet.Cells[1, 1, 3, 3])
                    {
                        range.Style.Font.Bold = true;
                    }

                    writer.WriteString();

                    new ProgressDialog(
                         new List<ParseTask>()
                         {
                            new GroupGeneralInfo(writer),
                            new GroupUsersTable(writer),
                            new DayUsageTask(writer),
                            new HoursUsageTask(writer),
                            new MonthUsageTask(writer),
                            new TextStatisticsTask(writer),
                            new LinkUsageTask(writer)
                         },
                         parser
                     ).ShowDialog();

                    package.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxChatdataSelectChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chat = parser.Chats[listBoxChatdataSelectChat.SelectedIndex];

            checkedListBoxChatdataSelectUsers.Items.Clear();
            checkedListBoxChatdataSelectUsers.Items.AddRange(chat.Participants.ToArray());
        }

        private void listBoxUserDataSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = parser.GlobalUsers[listBoxUserDataSelectUser.SelectedIndex];

            checkedListBoxUserDataSelectChats.Items.Clear();
            checkedListBoxUserDataSelectChats.Items.AddRange(parser.Chats
                .FindAll(p => p.Participants.Contains(user))
                .Select(p => p.ToString())
                .ToArray());
        }
    }
}
