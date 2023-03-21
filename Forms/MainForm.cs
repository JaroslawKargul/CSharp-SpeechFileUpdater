using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo.IronLua;
using SpeechFileUpdater.Utils;
using static SpeechFileUpdater.Utils.MainFormUtils;
using static SpeechFileUpdater.Utils.DataGridWrangler;

namespace SpeechFileUpdater.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            EnableLeftsideControls(false);
            EnableRightsideControls(false);

            string currentDir = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            Globals.appParentDir = Path.GetDirectoryName(currentDir);
        }

        public void EnableLeftsideControls(bool enable=true)
        {
            buttonClearFilterLeft.Enabled = enable;
            buttonExportLeft.Enabled = enable;
            buttonFilterLeft.Enabled = enable;
            buttonClearFilterLeft.Enabled = enable;
            textBoxFilterLeft.Enabled = enable;

            if (enable == true && !String.IsNullOrEmpty(Globals.rightFilePath))
            {
                buttonCopyMisKeysLeft.Enabled = true;
                buttonMarkDiffLeft.Enabled = true;
                buttonCopyMisKeysRight.Enabled = true;
                buttonMarkDiffRight.Enabled = true;
            }
            else
            {
                buttonCopyMisKeysLeft.Enabled = false;
                buttonMarkDiffLeft.Enabled = false;
            }
        }

        public void EnableRightsideControls(bool enable=true)
        {
            buttonClearFilterRight.Enabled = enable;
            buttonExportRight.Enabled = enable;
            buttonFilterRight.Enabled = enable;
            buttonClearFilterRight.Enabled = enable;
            textBoxFilterRight.Enabled = enable;

            if (enable == true && !String.IsNullOrEmpty(Globals.leftFilePath))
            {
                buttonCopyMisKeysRight.Enabled = true;
                buttonMarkDiffRight.Enabled = true;
                buttonCopyMisKeysLeft.Enabled = true;
                buttonMarkDiffLeft.Enabled = true;
            }
            else
            {
                buttonCopyMisKeysRight.Enabled = false;
                buttonMarkDiffRight.Enabled = false;
            }
        }

        private void textBoxFilterLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                buttonFilterLeft_Click(sender, e);
            }
        }

        private void textBoxFilterRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                buttonFilterRight_Click(sender, e);
            }
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 2)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.chatGPT_icon.Width - 1;
                var h = Properties.Resources.chatGPT_icon.Height - 1;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                if (((DataGridView)sender).Rows[e.RowIndex].Cells[2].ReadOnly)
                {
                    e.Graphics.DrawImage(Properties.Resources.chatGPT_icon_disabled, new Rectangle(x, y, w, h));
                }
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.chatGPT_icon, new Rectangle(x, y, w, h));
                }

                e.Handled = true;
            }
        }

        private async void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewColumn dataGridViewColumn = null;
            try
            {
                dataGridViewColumn = dataGridView.Columns["chatgpt_column"];
            }
            catch
            {
                return;
            }

            if (dataGridViewColumn != null && e.ColumnIndex == dataGridViewColumn.Index)
            {
                DataGridViewCell button = dataGridView.Rows[e.RowIndex].Cells[2];

                if (button.ReadOnly)
                {
                    return;
                }

                string keyValue = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                
                string apiKey = "";
                string prompt = "";
                float randomness = 0F;

                if (dataGridView.Name == "dataGridView1")
                {
                    apiKey = Globals.chatGPTApiKeyLeft;
                    if (!String.IsNullOrEmpty(Globals.chatGPTPromptLeft))
                    {
                        prompt = Globals.chatGPTPromptLeft.Replace("<KEY>", keyValue);
                    }
                    randomness = Globals.chatGPTResponseRandomnessLeft;
                }
                else
                {
                    apiKey = Globals.chatGPTApiKeyRight;
                    if (!String.IsNullOrEmpty(Globals.chatGPTPromptRight))
                    {
                        prompt = Globals.chatGPTPromptRight.Replace("<KEY>", keyValue);
                    }
                    randomness = Globals.chatGPTResponseRandomnessRight;
                }

                if (prompt != null && String.IsNullOrEmpty(prompt) || String.IsNullOrEmpty(prompt.Trim()))
                {
                    MessageBox.Show(this, "Enter a ChatGPT prompt before sending an API call.", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                button.ReadOnly = true;
                dataGridView.Refresh();

                string response = null;
                try
                {
                    response = await Task.Run(() => ChatGptTalker.GetChatGptResponseForPrompt(
                        apiKey,
                        prompt,
                        randomness));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    button.ReadOnly = false;
                    dataGridView.Refresh();
                }

                if (response == null || String.IsNullOrEmpty(response) || String.IsNullOrEmpty(response.Trim()))
                {
                    return;
                }

                dataGridView.Rows[e.RowIndex].Cells[1].Value = response;
            }
        }

        public void LoadLuaTableFromFile(string luaFilePath, DataGridView dataGridView)
        {
            LuaTable luaTable = null;
            try
            {
                using (Lua runtime = new Lua())
                {
                    LuaGlobal environment = runtime.CreateEnvironment();
                    LuaResult executionResults = environment.DoChunk(luaFilePath);
                    luaTable = (LuaTable)executionResults[0];
                }
            }
            catch(Exception ex)
            {
                ShowPopUp(this, "File Import Error", "Failed to load the file.\nThis may be due to errors in the code.\nPlease verify the file and try again.");

                if (dataGridView.Name == "dataGridView1")
                {
                    labelFileNameLeft.Text = "No file loaded";
                    Globals.leftFilePath = String.Empty;
                }
                else
                {
                    labelFileNameRight.Text = "No file loaded";
                    Globals.rightFilePath = String.Empty;
                }

                return;
            }

            DataGridView virtualDataGrid = new DataGridView();
            virtualDataGrid.AllowUserToAddRows = false;
            virtualDataGrid.Rows.Clear();

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                virtualDataGrid.Columns.Add((DataGridViewColumn)col.Clone());
            }

            ParseLuaTable(luaTable, virtualDataGrid);

            DataGridViewRow[] theRows = new DataGridViewRow[virtualDataGrid.Rows.Count];
            for (int i = 0; i < virtualDataGrid.Rows.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)virtualDataGrid.Rows[i].Clone();
                for (int j = 0; j < virtualDataGrid.Columns.Count; j++)
                {
                    row.Cells[j].Value = virtualDataGrid.Rows[i].Cells[j].Value;
                }
                theRows[i] = row;
            }

            foreach (DataGridViewRow row in theRows)
            {
                dataGridView.Rows.Add(row);
            }

            virtualDataGrid.Dispose();

            dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Ascending);
            dataGridView.Columns[0].ReadOnly = true;

            if (dataGridView.Columns.Count < 3)
            {
                DataGridViewButtonColumn chatGptColumn = new DataGridViewButtonColumn();
                chatGptColumn.Name = "chatgpt_column";
                chatGptColumn.Text = "ChatGPT";
                dataGridView.Columns.Insert(2, chatGptColumn);
                dataGridView.CellPainting += grid_CellPainting;
                dataGridView.CellClick += dataGridView_CellClick;
            }

            dataGridView.Columns[0].FillWeight = 47.5F;
            dataGridView.Columns[1].FillWeight = 47.5F;
            dataGridView.Columns[2].FillWeight = 5;

            if (!Globals.editorChatGPTEnabled)
            {
                dataGridView.Columns[2].Visible = false;
            }

            if (Globals.emptyLinesToTableBottom)
            {
                PutEmptyLinesOnTheBottom(dataGridView);
            }

            if (dataGridView.Name == "dataGridView1")
            {
                EnableLeftsideControls(true);
            }
            else
            {
                EnableRightsideControls(true);
            }
        }

        private void buttonImportLeft_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = NewLuaOpenFileDialog(Globals.lastSearchedPath);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Globals.leftFilePath = openFileDialog.FileName;
                Globals.lastSearchedPath = Path.GetDirectoryName(openFileDialog.FileName);

                string title = "File Import Warning";
                string label = $"File \"{Globals.leftFilePath}\" might contain malicious code.\nAre you sure you want to load it into the program?";
                if (VerifyIfFileDangerous(Globals.leftFilePath) && ShowYesNoPopUp(this, title, label) != DialogResult.Yes)
                {
                    Globals.leftFilePath = String.Empty;
                    return;
                }

                UpdateFileLabelText(labelFileNameLeft, Globals.leftFilePath);
                dataGridView1.Rows.Clear();
                LoadLuaTableFromFile(Globals.leftFilePath, dataGridView1);
            }
        }

        private void buttonImportRight_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = NewLuaOpenFileDialog(Globals.lastSearchedPath);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Globals.rightFilePath = openFileDialog.FileName;
                Globals.lastSearchedPath = Path.GetDirectoryName(openFileDialog.FileName);

                string title = "File Import Warning";
                string label = $"File \"{Globals.rightFilePath}\" might contain malicious code.\nAre you sure you want to load it into the program?";
                if (VerifyIfFileDangerous(Globals.rightFilePath) && ShowYesNoPopUp(this, title, label) != DialogResult.Yes)
                {
                    Globals.rightFilePath = String.Empty;
                    return;
                }

                UpdateFileLabelText(labelFileNameRight, Globals.rightFilePath);
                dataGridView2.Rows.Clear();
                LoadLuaTableFromFile(Globals.rightFilePath, dataGridView2);
            }
        }

        private void buttonExportLeft_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Globals.leftFilePath))
            {
                return;
            }

            SaveFileDialog saveFileDialog = NewLuaSaveFileDialog(Globals.leftFilePath);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Globals.leftFilePath = saveFileDialog.FileName;
                Globals.lastSearchedPath = Path.GetDirectoryName(saveFileDialog.FileName);
                UpdateFileLabelText(labelFileNameLeft, Globals.leftFilePath);
                SaveDataGridAsLuaTable(Globals.leftFilePath, dataGridView1);
            }
        }

        private void buttonExportRight_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Globals.rightFilePath))
            {
                return;
            }

            SaveFileDialog saveFileDialog = NewLuaSaveFileDialog(Globals.rightFilePath);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Globals.rightFilePath = saveFileDialog.FileName;
                Globals.lastSearchedPath = Path.GetDirectoryName(saveFileDialog.FileName);
                UpdateFileLabelText(labelFileNameRight, Globals.rightFilePath);
                SaveDataGridAsLuaTable(Globals.rightFilePath, dataGridView2);
            }
        }

        private void buttonMarkDiffLeft_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Globals.leftFilePath) || String.IsNullOrEmpty(Globals.rightFilePath))
            {
                return;
            }
            // Missing in left DataGridView compared to the right one
            Dictionary<string, int> matchCounts = CompareDataGridViewsAndMarkDifferences(dataGridView1, dataGridView2, this);
           
            string titleText = "Mark Differences";
            string labelText = $"Compared and marked following amounts of rows in left table:\n- Exact same rows as in right table (yellow): {matchCounts["same_keyvaluepair_yellow"]}\n- Rows not existing in right table (red): {matchCounts["key_not_found_red"]}";
            ShowPopUp(this, titleText, labelText);
        }

        private void buttonMarkDiffRight_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Globals.leftFilePath) || String.IsNullOrEmpty(Globals.rightFilePath))
            {
                return;
            }
            // Missing in right DataGridView compared to the left one
            Dictionary<string, int> matchCounts = CompareDataGridViewsAndMarkDifferences(dataGridView2, dataGridView1, this);
            
            string labelText = $"Compared and marked following amounts of rows in right table:\n- Exact same rows as in left table (yellow): {matchCounts["same_keyvaluepair_yellow"]}\n- Rows not existing in left table (red): {matchCounts["key_not_found_red"]}";
            string titleText = "Mark Differences";
            ShowPopUp(this, titleText, labelText);
        }

        private void buttonFilterLeft_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Globals.leftFilePath))
            {
                return;
            }

            if (String.IsNullOrEmpty(textBoxFilterLeft.Text))
            {
                buttonClearFilterLeft.PerformClick();
            }

            HideNotMatchingDataGridViewRows(dataGridView1, textBoxFilterLeft.Text);
        }

        private void buttonClearFilterLeft_Click(object sender, EventArgs e)
        {
            textBoxFilterLeft.Text = "";

            DataGridViewRow[] theRows = new DataGridViewRow[dataGridView1.Rows.Count];
            dataGridView1.Rows.CopyTo(theRows, 0);
            dataGridView1.Rows.Clear();
            for (int loop = 0; loop < theRows.Length; loop++)
            {
                theRows[loop].Visible = true;
                theRows[loop].DefaultCellStyle.BackColor = Color.White;
            }
            dataGridView1.Rows.AddRange(theRows);
        }

        private void buttonFilterRight_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Globals.rightFilePath))
            {
                return;
            }

            if (String.IsNullOrEmpty(textBoxFilterRight.Text))
            {
                buttonClearFilterRight.PerformClick();
            }

            HideNotMatchingDataGridViewRows(dataGridView2, textBoxFilterRight.Text);
        }

        private void buttonClearFilterRight_Click(object sender, EventArgs e)
        {
            textBoxFilterRight.Text = "";

            DataGridViewRow[] theRows = new DataGridViewRow[dataGridView2.Rows.Count];
            dataGridView2.Rows.CopyTo(theRows, 0);
            dataGridView2.Rows.Clear();
            for (int loop = 0; loop < theRows.Length; loop++)
            {
                theRows[loop].Visible = true;
                theRows[loop].DefaultCellStyle.BackColor = Color.White;
            }
            dataGridView2.Rows.AddRange(theRows);
        }

        private void buttonCopyMisKeysLeft_Click(object sender, EventArgs e)
        {
            CopyMissingKeysBetweenDataGrids(this, dataGridView2, dataGridView1);
        }

        private void EnableChatGPT(bool enable)
        {
            if (!enable)
            {
                if (dataGridView1.Columns.Count >= 3)
                {
                    dataGridView1.Columns[2].Visible = false;
                }

                if (dataGridView2.Columns.Count >= 3)
                {
                    dataGridView2.Columns[2].Visible = false;
                }
               
                buttonChatGPTLeft.Visible = false;
                buttonChatGPTRight.Visible = false;

                tableLayoutPanel2.ColumnCount = 5;
                tableLayoutPanel5.ColumnCount = 5;
            }
            else
            {
                if (dataGridView1.Columns.Count >= 3)
                {
                    dataGridView1.Columns[2].Visible = true;
                }

                if (dataGridView2.Columns.Count >= 3)
                {
                    dataGridView2.Columns[2].Visible = true;
                }

                buttonChatGPTLeft.Visible = true;
                buttonChatGPTRight.Visible = true;

                tableLayoutPanel2.ColumnCount = 6;
                tableLayoutPanel5.ColumnCount = 6;
            }
        }

        private void buttonFontLeft_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm("left");
            DialogResult settingEditResult = settingsForm.ShowDialog(this);

            if (settingEditResult != DialogResult.OK)
            {
                return;
            }

            if (!Globals.editorChatGPTEnabled)
            {
                EnableChatGPT(false);
            }
            else
            {
                EnableChatGPT(true);
            }

            foreach (DataGridViewRow dataRow in dataGridView1.Rows)
            {
                dataRow.DefaultCellStyle.Font = Globals.editorTableFontLeft;
            }
        }

        private void buttonFontRight_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm("right");
            DialogResult settingEditResult = settingsForm.ShowDialog(this);

            if (settingEditResult != DialogResult.OK)
            {
                return;
            }

            if (!Globals.editorChatGPTEnabled)
            {
                EnableChatGPT(false);
            }
            else
            {
                EnableChatGPT(true);
            }

            foreach (DataGridViewRow dataRow in dataGridView2.Rows)
            {
                dataRow.DefaultCellStyle.Font = Globals.editorTableFontRight;
            }
        }

        private void buttonCopyMisKeysRight_Click(object sender, EventArgs e)
        {
            CopyMissingKeysBetweenDataGrids(this, dataGridView1, dataGridView2);
        }

        private void buttonChatGPTLeft_Click(object sender, EventArgs e)
        {
            ChatGPTForm chatGptForm = new ChatGPTForm("left");
            chatGptForm.ShowDialog(this);
        }

        private void buttonChatGPTRight_Click(object sender, EventArgs e)
        {
            ChatGPTForm chatGptForm = new ChatGPTForm("right");
            chatGptForm.ShowDialog(this);
        }
    }
}
