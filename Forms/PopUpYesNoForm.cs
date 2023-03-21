using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpeechFileUpdater.Forms
{
    public partial class PopUpYesNoForm : Form
    {
        public PopUpYesNoForm(string title, string label)
        {
            InitializeComponent();

            richTextBox1.Text = label;
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;

            this.Text = title;

            this.Width = tableLayoutPanel1.Width;
            this.Height = tableLayoutPanel1.Height;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
