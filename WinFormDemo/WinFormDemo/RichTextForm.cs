using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class RichTextForm : Form
    {
        public RichTextForm()
        {
            InitializeComponent();
        }

        private void RichTextForm_Load(object sender, EventArgs e)
        {
            CreateRichTextBox();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        public void CreateRichTextBox()
        {
            RichTextBox rtbData = new RichTextBox();
            rtbData.Dock = DockStyle.Bottom;
            rtbData.LoadFile("MyData.rtf");
            rtbData.Find("RichTextBox", RichTextBoxFinds.MatchCase);
            rtbData.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
            rtbData.SelectionColor = Color.Red;
            rtbData.SelectionBackColor = Color.Green;
            rtbData.SaveFile("MyData.rtf", RichTextBoxStreamType.RichText);
            this.Controls.Add(rtbData);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
