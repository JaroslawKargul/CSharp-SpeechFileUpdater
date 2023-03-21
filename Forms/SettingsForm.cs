using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechFileUpdater.Utils;

namespace SpeechFileUpdater.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(string side)
        {
            InitializeComponent();

            List<string> fonts = new List<string>();
            foreach (FontFamily font in FontFamily.Families)
            {
                fonts.Add(font.Name);
            }
            comboBoxFontFamily.Items.AddRange(fonts.ToArray());

            comboBoxFontSize.Items.Add(8F);
            comboBoxFontSize.Items.Add(8.5F);
            comboBoxFontSize.Items.Add(9F);
            comboBoxFontSize.Items.Add(9.5F);
            comboBoxFontSize.Items.Add(10F);
            comboBoxFontSize.Items.Add(10.5F);
            comboBoxFontSize.Items.Add(11F);
            comboBoxFontSize.Items.Add(11.5F);

            if (side == "left")
            {
                this.Text = this.Text + " (Left Table)";
                comboBoxFontFamily.SelectedItem = Globals.editorTableFontLeft.Name;
                comboBoxFontSize.SelectedItem = Globals.editorTableFontLeft.Size;
                labelSampleText.Font = Globals.editorTableFontLeft;

                if (String.IsNullOrEmpty(Globals.leftFilePath))
                {
                    label1.Enabled = false;
                    label2.Enabled = false;
                    label3.Enabled = false;
                    comboBoxFontFamily.Enabled = false;
                    comboBoxFontSize.Enabled = false;
                    labelSampleText.Enabled = false;
                }
            }
            else
            {
                this.Text = this.Text + " (Right Table)";
                comboBoxFontFamily.SelectedItem = Globals.editorTableFontRight.Name;
                comboBoxFontSize.SelectedItem = Globals.editorTableFontRight.Size;
                labelSampleText.Font = Globals.editorTableFontRight;

                if (String.IsNullOrEmpty(Globals.rightFilePath))
                {
                    label1.Enabled = false;
                    label2.Enabled = false;
                    label3.Enabled = false;
                    comboBoxFontFamily.Enabled = false;
                    comboBoxFontSize.Enabled = false;
                    labelSampleText.Enabled = false;
                }
            }

            if (Globals.editorChatGPTEnabled)
            {
                checkBoxUseChatGPT.Checked = true;
            }
            else
            {
                checkBoxUseChatGPT.Checked = false;
            }

            if (Globals.emptyLinesToTableBottom)
            {
                checkBoxEmptyLines.Checked = true;
            }
            else
            {
                checkBoxEmptyLines.Checked = false;
            }

            formSide = side;
        }

        static string formSide;

        private void comboBox_SelectedItemChanged(object sender, EventArgs e)
        {
            if (comboBoxFontFamily.SelectedItem == null || comboBoxFontSize.SelectedItem == null)
            {
                return;
            }

            FontFamily fontFamily = FontFamily.Families
                     .Where(c => c.Name == (string)comboBoxFontFamily.SelectedItem)
                     .FirstOrDefault();

            labelSampleText.Font = new Font(fontFamily, (float)comboBoxFontSize.SelectedItem, GraphicsUnit.Point);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (checkBoxUseChatGPT.Checked)
            {
                Globals.editorChatGPTEnabled = true;
            }
            else
            {
                Globals.editorChatGPTEnabled = false;
            }

            if (checkBoxEmptyLines.Checked)
            {
                Globals.emptyLinesToTableBottom = true;
            }
            else
            {
                Globals.emptyLinesToTableBottom = false;
            }

            if (formSide == "left")
            {
                FontFamily fontFamily = FontFamily.Families
                     .Where(c => c.Name == (string)comboBoxFontFamily.SelectedItem)
                     .FirstOrDefault();
                Globals.editorTableFontLeft = new Font(fontFamily, (float)comboBoxFontSize.SelectedItem, GraphicsUnit.Point);
            }
            else
            {
                FontFamily fontFamily = FontFamily.Families
                     .Where(c => c.Name == (string)comboBoxFontFamily.SelectedItem)
                     .FirstOrDefault();
                Globals.editorTableFontRight = new Font(fontFamily, (float)comboBoxFontSize.SelectedItem, GraphicsUnit.Point);
            }
        }
    }
}
