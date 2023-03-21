using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpeechFileUpdater.Utils;

namespace SpeechFileUpdater.Forms
{
    public partial class ChatGPTForm : Form
    {
        public ChatGPTForm(string side)
        {
            InitializeComponent();

            formSide = side;

            if (side == "left")
            {
                this.Text = "ChatGPT Settings (Left Table)";
                trackBar1.Value = (int)Math.Round(Globals.chatGPTResponseRandomnessLeft * 10);
            }
            else
            {
                this.Text = "ChatGPT Settings (Right Table)";
                trackBar1.Value = (int)Math.Round(Globals.chatGPTResponseRandomnessRight * 10);
            }

            if (side == "left" && !String.IsNullOrEmpty(Globals.chatGPTApiKeyLeft))
            {
                textBox1.Text = Globals.chatGPTApiKeyLeft;
            }
            if (side == "left" && !String.IsNullOrEmpty(Globals.chatGPTPromptLeft))
            {
                textBox2.Text = Globals.chatGPTPromptLeft;
            }

            if (side == "right" && !String.IsNullOrEmpty(Globals.chatGPTApiKeyRight))
            {
                textBox1.Text = Globals.chatGPTApiKeyRight;
            }
            if (side == "right" && !String.IsNullOrEmpty(Globals.chatGPTPromptRight))
            {
                textBox2.Text = Globals.chatGPTPromptRight;
            }
        }

        private static string formSide;
        private const int maxLines = 4;

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Lines.Length >= maxLines && e.KeyChar == '\r')
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Lines.Length > maxLines)
            {
                textBox2.Undo();
                textBox2.ClearUndo();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formSide == "left")
            {
                Globals.chatGPTApiKeyLeft = textBox1.Text;
                Globals.chatGPTPromptLeft = textBox2.Text;
                if (String.IsNullOrEmpty(Globals.chatGPTApiKeyRight))
                {
                    Globals.chatGPTApiKeyRight = Globals.chatGPTApiKeyLeft;
                }
                Globals.chatGPTResponseRandomnessLeft = (float)trackBar1.Value / 10;
            }
            else
            {
                Globals.chatGPTApiKeyRight = textBox1.Text;
                Globals.chatGPTPromptRight = textBox2.Text;
                if (String.IsNullOrEmpty(Globals.chatGPTApiKeyLeft))
                {
                    Globals.chatGPTApiKeyLeft = Globals.chatGPTApiKeyRight;
                }
                Globals.chatGPTResponseRandomnessRight = (float)trackBar1.Value / 10;
            }

            this.Close();
        }


    }
}
