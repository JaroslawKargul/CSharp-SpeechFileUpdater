
namespace SpeechFileUpdater.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonExportLeft = new System.Windows.Forms.Button();
            this.buttonMarkDiffLeft = new System.Windows.Forms.Button();
            this.buttonCopyMisKeysLeft = new System.Windows.Forms.Button();
            this.buttonSettingsLeft = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonImportLeft = new System.Windows.Forms.Button();
            this.buttonChatGPTLeft = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFilterLeft = new System.Windows.Forms.Button();
            this.labelFileNameLeft = new System.Windows.Forms.Label();
            this.textBoxFilterLeft = new System.Windows.Forms.TextBox();
            this.buttonClearFilterLeft = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonImportRight = new System.Windows.Forms.Button();
            this.buttonSettingsRight = new System.Windows.Forms.Button();
            this.buttonExportRight = new System.Windows.Forms.Button();
            this.buttonCopyMisKeysRight = new System.Windows.Forms.Button();
            this.buttonMarkDiffRight = new System.Windows.Forms.Button();
            this.buttonChatGPTRight = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFilterRight = new System.Windows.Forms.Button();
            this.labelFileNameRight = new System.Windows.Forms.Label();
            this.textBoxFilterRight = new System.Windows.Forms.TextBox();
            this.buttonClearFilterRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExportLeft
            // 
            this.buttonExportLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonExportLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExportLeft.Location = new System.Drawing.Point(134, 15);
            this.buttonExportLeft.Name = "buttonExportLeft";
            this.buttonExportLeft.Size = new System.Drawing.Size(125, 54);
            this.buttonExportLeft.TabIndex = 2;
            this.buttonExportLeft.Text = "Export";
            this.buttonExportLeft.UseVisualStyleBackColor = true;
            this.buttonExportLeft.Click += new System.EventHandler(this.buttonExportLeft_Click);
            // 
            // buttonMarkDiffLeft
            // 
            this.buttonMarkDiffLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonMarkDiffLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMarkDiffLeft.Location = new System.Drawing.Point(265, 15);
            this.buttonMarkDiffLeft.Name = "buttonMarkDiffLeft";
            this.buttonMarkDiffLeft.Size = new System.Drawing.Size(125, 54);
            this.buttonMarkDiffLeft.TabIndex = 3;
            this.buttonMarkDiffLeft.Text = "Mark differences";
            this.buttonMarkDiffLeft.UseVisualStyleBackColor = true;
            this.buttonMarkDiffLeft.Click += new System.EventHandler(this.buttonMarkDiffLeft_Click);
            // 
            // buttonCopyMisKeysLeft
            // 
            this.buttonCopyMisKeysLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCopyMisKeysLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCopyMisKeysLeft.Location = new System.Drawing.Point(396, 15);
            this.buttonCopyMisKeysLeft.Name = "buttonCopyMisKeysLeft";
            this.buttonCopyMisKeysLeft.Size = new System.Drawing.Size(125, 54);
            this.buttonCopyMisKeysLeft.TabIndex = 4;
            this.buttonCopyMisKeysLeft.Text = "Copy missing keys";
            this.buttonCopyMisKeysLeft.UseVisualStyleBackColor = true;
            this.buttonCopyMisKeysLeft.Click += new System.EventHandler(this.buttonCopyMisKeysLeft_Click);
            // 
            // buttonSettingsLeft
            // 
            this.buttonSettingsLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonSettingsLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSettingsLeft.Location = new System.Drawing.Point(527, 15);
            this.buttonSettingsLeft.Name = "buttonSettingsLeft";
            this.buttonSettingsLeft.Size = new System.Drawing.Size(125, 54);
            this.buttonSettingsLeft.TabIndex = 5;
            this.buttonSettingsLeft.Text = "Settings";
            this.buttonSettingsLeft.UseVisualStyleBackColor = true;
            this.buttonSettingsLeft.Click += new System.EventHandler(this.buttonFontLeft_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Size = new System.Drawing.Size(1610, 598);
            this.splitContainer1.SplitterDistance = 805;
            this.splitContainer1.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.010101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.9899F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(805, 598);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(11, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(791, 430);
            this.dataGridView1.TabIndex = 104;
            this.dataGridView1.TabStop = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.HeaderText = "Key";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66933F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.buttonImportLeft, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonSettingsLeft, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonExportLeft, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonCopyMisKeysLeft, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonMarkDiffLeft, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonChatGPTLeft, 5, 1);
            this.tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(11, 511);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(791, 84);
            this.tableLayoutPanel2.TabIndex = 106;
            // 
            // buttonImportLeft
            // 
            this.buttonImportLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonImportLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImportLeft.Location = new System.Drawing.Point(3, 15);
            this.buttonImportLeft.Name = "buttonImportLeft";
            this.buttonImportLeft.Size = new System.Drawing.Size(125, 54);
            this.buttonImportLeft.TabIndex = 0;
            this.buttonImportLeft.Text = "Import";
            this.buttonImportLeft.UseVisualStyleBackColor = true;
            this.buttonImportLeft.Click += new System.EventHandler(this.buttonImportLeft_Click);
            // 
            // buttonChatGPTLeft
            // 
            this.buttonChatGPTLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonChatGPTLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonChatGPTLeft.Location = new System.Drawing.Point(658, 15);
            this.buttonChatGPTLeft.Name = "buttonChatGPTLeft";
            this.buttonChatGPTLeft.Size = new System.Drawing.Size(130, 54);
            this.buttonChatGPTLeft.TabIndex = 6;
            this.buttonChatGPTLeft.Text = "ChatGPT";
            this.buttonChatGPTLeft.UseVisualStyleBackColor = true;
            this.buttonChatGPTLeft.Click += new System.EventHandler(this.buttonChatGPTLeft_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.buttonFilterLeft, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelFileNameLeft, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxFilterLeft, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonClearFilterLeft, 1, 1);
            this.tableLayoutPanel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(11, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(791, 66);
            this.tableLayoutPanel3.TabIndex = 100;
            // 
            // buttonFilterLeft
            // 
            this.buttonFilterLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonFilterLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFilterLeft.Location = new System.Drawing.Point(635, 3);
            this.buttonFilterLeft.Name = "buttonFilterLeft";
            this.buttonFilterLeft.Size = new System.Drawing.Size(153, 27);
            this.buttonFilterLeft.TabIndex = 12;
            this.buttonFilterLeft.Text = "Filter";
            this.buttonFilterLeft.UseVisualStyleBackColor = true;
            this.buttonFilterLeft.Click += new System.EventHandler(this.buttonFilterLeft_Click);
            // 
            // labelFileNameLeft
            // 
            this.labelFileNameLeft.AutoSize = true;
            this.labelFileNameLeft.BackColor = System.Drawing.Color.Transparent;
            this.labelFileNameLeft.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelFileNameLeft.Location = new System.Drawing.Point(3, 46);
            this.labelFileNameLeft.Name = "labelFileNameLeft";
            this.labelFileNameLeft.Size = new System.Drawing.Size(626, 20);
            this.labelFileNameLeft.TabIndex = 99;
            this.labelFileNameLeft.Text = "No file loaded";
            // 
            // textBoxFilterLeft
            // 
            this.textBoxFilterLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFilterLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFilterLeft.Location = new System.Drawing.Point(3, 3);
            this.textBoxFilterLeft.MaxLength = 100;
            this.textBoxFilterLeft.MinimumSize = new System.Drawing.Size(2, 2);
            this.textBoxFilterLeft.Name = "textBoxFilterLeft";
            this.textBoxFilterLeft.Size = new System.Drawing.Size(626, 27);
            this.textBoxFilterLeft.TabIndex = 11;
            this.textBoxFilterLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFilterLeft_KeyPress);
            // 
            // buttonClearFilterLeft
            // 
            this.buttonClearFilterLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearFilterLeft.Location = new System.Drawing.Point(635, 36);
            this.buttonClearFilterLeft.Name = "buttonClearFilterLeft";
            this.buttonClearFilterLeft.Size = new System.Drawing.Size(153, 27);
            this.buttonClearFilterLeft.TabIndex = 13;
            this.buttonClearFilterLeft.Text = "Clear Filter";
            this.buttonClearFilterLeft.UseVisualStyleBackColor = true;
            this.buttonClearFilterLeft.Click += new System.EventHandler(this.buttonClearFilterLeft_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel4.Controls.Add(this.dataGridView2, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(801, 598);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView2.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.Location = new System.Drawing.Point(3, 75);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 32;
            this.dataGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.Size = new System.Drawing.Size(786, 430);
            this.dataGridView2.TabIndex = 105;
            this.dataGridView2.TabStop = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Key";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66933F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.Controls.Add(this.buttonImportRight, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonSettingsRight, 4, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonExportRight, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonCopyMisKeysRight, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonMarkDiffRight, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonChatGPTRight, 5, 1);
            this.tableLayoutPanel5.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 511);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(786, 84);
            this.tableLayoutPanel5.TabIndex = 107;
            // 
            // buttonImportRight
            // 
            this.buttonImportRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonImportRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImportRight.Location = new System.Drawing.Point(3, 15);
            this.buttonImportRight.Name = "buttonImportRight";
            this.buttonImportRight.Size = new System.Drawing.Size(124, 54);
            this.buttonImportRight.TabIndex = 6;
            this.buttonImportRight.Text = "Import";
            this.buttonImportRight.UseVisualStyleBackColor = true;
            this.buttonImportRight.Click += new System.EventHandler(this.buttonImportRight_Click);
            // 
            // buttonSettingsRight
            // 
            this.buttonSettingsRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonSettingsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSettingsRight.Location = new System.Drawing.Point(523, 15);
            this.buttonSettingsRight.Name = "buttonSettingsRight";
            this.buttonSettingsRight.Size = new System.Drawing.Size(125, 54);
            this.buttonSettingsRight.TabIndex = 10;
            this.buttonSettingsRight.Text = "Settings";
            this.buttonSettingsRight.UseVisualStyleBackColor = true;
            this.buttonSettingsRight.Click += new System.EventHandler(this.buttonFontRight_Click);
            // 
            // buttonExportRight
            // 
            this.buttonExportRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonExportRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExportRight.Location = new System.Drawing.Point(133, 15);
            this.buttonExportRight.Name = "buttonExportRight";
            this.buttonExportRight.Size = new System.Drawing.Size(124, 54);
            this.buttonExportRight.TabIndex = 7;
            this.buttonExportRight.Text = "Export";
            this.buttonExportRight.UseVisualStyleBackColor = true;
            this.buttonExportRight.Click += new System.EventHandler(this.buttonExportRight_Click);
            // 
            // buttonCopyMisKeysRight
            // 
            this.buttonCopyMisKeysRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCopyMisKeysRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCopyMisKeysRight.Location = new System.Drawing.Point(393, 15);
            this.buttonCopyMisKeysRight.Name = "buttonCopyMisKeysRight";
            this.buttonCopyMisKeysRight.Size = new System.Drawing.Size(124, 54);
            this.buttonCopyMisKeysRight.TabIndex = 9;
            this.buttonCopyMisKeysRight.Text = "Copy missing keys";
            this.buttonCopyMisKeysRight.UseVisualStyleBackColor = true;
            this.buttonCopyMisKeysRight.Click += new System.EventHandler(this.buttonCopyMisKeysRight_Click);
            // 
            // buttonMarkDiffRight
            // 
            this.buttonMarkDiffRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonMarkDiffRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMarkDiffRight.Location = new System.Drawing.Point(263, 15);
            this.buttonMarkDiffRight.Name = "buttonMarkDiffRight";
            this.buttonMarkDiffRight.Size = new System.Drawing.Size(124, 54);
            this.buttonMarkDiffRight.TabIndex = 8;
            this.buttonMarkDiffRight.Text = "Mark differences";
            this.buttonMarkDiffRight.UseVisualStyleBackColor = true;
            this.buttonMarkDiffRight.Click += new System.EventHandler(this.buttonMarkDiffRight_Click);
            // 
            // buttonChatGPTRight
            // 
            this.buttonChatGPTRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonChatGPTRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonChatGPTRight.Location = new System.Drawing.Point(654, 15);
            this.buttonChatGPTRight.Name = "buttonChatGPTRight";
            this.buttonChatGPTRight.Size = new System.Drawing.Size(129, 54);
            this.buttonChatGPTRight.TabIndex = 11;
            this.buttonChatGPTRight.Text = "ChatGPT";
            this.buttonChatGPTRight.UseVisualStyleBackColor = true;
            this.buttonChatGPTRight.Click += new System.EventHandler(this.buttonChatGPTRight_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Controls.Add(this.buttonFilterRight, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelFileNameRight, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.textBoxFilterRight, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonClearFilterRight, 1, 1);
            this.tableLayoutPanel6.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(786, 66);
            this.tableLayoutPanel6.TabIndex = 102;
            // 
            // buttonFilterRight
            // 
            this.buttonFilterRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonFilterRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFilterRight.Location = new System.Drawing.Point(631, 3);
            this.buttonFilterRight.Name = "buttonFilterRight";
            this.buttonFilterRight.Size = new System.Drawing.Size(152, 27);
            this.buttonFilterRight.TabIndex = 15;
            this.buttonFilterRight.Text = "Filter";
            this.buttonFilterRight.UseVisualStyleBackColor = true;
            this.buttonFilterRight.Click += new System.EventHandler(this.buttonFilterRight_Click);
            // 
            // labelFileNameRight
            // 
            this.labelFileNameRight.AutoSize = true;
            this.labelFileNameRight.BackColor = System.Drawing.Color.Transparent;
            this.labelFileNameRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelFileNameRight.Location = new System.Drawing.Point(3, 46);
            this.labelFileNameRight.Name = "labelFileNameRight";
            this.labelFileNameRight.Size = new System.Drawing.Size(622, 20);
            this.labelFileNameRight.TabIndex = 101;
            this.labelFileNameRight.Text = "No file loaded";
            // 
            // textBoxFilterRight
            // 
            this.textBoxFilterRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilterRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFilterRight.Location = new System.Drawing.Point(3, 3);
            this.textBoxFilterRight.MaxLength = 100;
            this.textBoxFilterRight.MinimumSize = new System.Drawing.Size(2, 2);
            this.textBoxFilterRight.Name = "textBoxFilterRight";
            this.textBoxFilterRight.Size = new System.Drawing.Size(622, 27);
            this.textBoxFilterRight.TabIndex = 14;
            this.textBoxFilterRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFilterRight_KeyPress);
            // 
            // buttonClearFilterRight
            // 
            this.buttonClearFilterRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearFilterRight.Location = new System.Drawing.Point(631, 36);
            this.buttonClearFilterRight.Name = "buttonClearFilterRight";
            this.buttonClearFilterRight.Size = new System.Drawing.Size(152, 27);
            this.buttonClearFilterRight.TabIndex = 16;
            this.buttonClearFilterRight.Text = "Clear Filter";
            this.buttonClearFilterRight.UseVisualStyleBackColor = true;
            this.buttonClearFilterRight.Click += new System.EventHandler(this.buttonClearFilterRight_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1610, 598);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Don\'t Starve Speech File Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonExportLeft;
        private System.Windows.Forms.Button buttonMarkDiffLeft;
        private System.Windows.Forms.Button buttonCopyMisKeysLeft;
        private System.Windows.Forms.Button buttonSettingsLeft;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonImportLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelFileNameLeft;
        private System.Windows.Forms.TextBox textBoxFilterLeft;
        private System.Windows.Forms.Button buttonFilterLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonImportRight;
        private System.Windows.Forms.Button buttonSettingsRight;
        private System.Windows.Forms.Button buttonExportRight;
        private System.Windows.Forms.Button buttonCopyMisKeysRight;
        private System.Windows.Forms.Button buttonMarkDiffRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button buttonFilterRight;
        private System.Windows.Forms.Label labelFileNameRight;
        private System.Windows.Forms.TextBox textBoxFilterRight;
        private System.Windows.Forms.Button buttonClearFilterLeft;
        private System.Windows.Forms.Button buttonClearFilterRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button buttonChatGPTLeft;
        private System.Windows.Forms.Button buttonChatGPTRight;
    }
}

