using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpeechFileUpdater.Forms
{
    public partial class PopUpForm : Form
    {
        public PopUpForm(string title, string label, bool smallForm=false)
        {
            InitializeComponent();

            richTextBox1.Text = label;
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;

            this.Text = title;

            this.Width = tableLayoutPanel1.Width;
            this.Height = tableLayoutPanel1.Height;

            if (smallForm)
            {
                this.Height = (int)Math.Ceiling(this.Height * 0.75);
                tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[2].Height = 50.0F;
                tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[0].Height = 11.0F;

                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
