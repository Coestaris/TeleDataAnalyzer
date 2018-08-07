using System;
using System.Windows.Forms;
using TeleDataAnalyzerLib;

namespace TeleDataAnalyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Parser("input.txt");
        }
    }
}
