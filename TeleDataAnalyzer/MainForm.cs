using System;
using System.Windows.Forms;
using TeleDataAnalyzerLib;

namespace TeleDataAnalyzer
{
    public partial class MainForm : Form
    {
        private string FileName;

        public MainForm()
        {
            InitializeComponent();
            FileName = textBoxInputFilename.Text;
            openFileDialogPickFile.InitialDirectory = Environment.CurrentDirectory;
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
    }
}
