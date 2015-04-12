namespace Gotcha
{
    partial class GotchaWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCustomFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBrainTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToleranceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BaseGridView = new System.Windows.Forms.DataGridView();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.TempOpenFIle = new System.Windows.Forms.OpenFileDialog();
            this.CalculateWorker = new System.ComponentModel.BackgroundWorker();
            this.APIWorker = new System.ComponentModel.BackgroundWorker();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1201, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCustomFileToolStripMenuItem,
            this.openFIleToolStripMenuItem,
            this.loadBrainTreeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openCustomFileToolStripMenuItem
            // 
            this.openCustomFileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openCustomFileToolStripMenuItem.Name = "openCustomFileToolStripMenuItem";
            this.openCustomFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openCustomFileToolStripMenuItem.Size = new System.Drawing.Size(293, 36);
            this.openCustomFileToolStripMenuItem.Text = "Open Custom File";
            this.openCustomFileToolStripMenuItem.Click += new System.EventHandler(this.openCustomFileToolStripMenuItem_Click);
            // 
            // openFIleToolStripMenuItem
            // 
            this.openFIleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFIleToolStripMenuItem.Name = "openFIleToolStripMenuItem";
            this.openFIleToolStripMenuItem.Size = new System.Drawing.Size(293, 36);
            this.openFIleToolStripMenuItem.Text = "Open Braintree FIle";
            this.openFIleToolStripMenuItem.Click += new System.EventHandler(this.openFIleToolStripMenuItem_Click);
            // 
            // loadBrainTreeToolStripMenuItem
            // 
            this.loadBrainTreeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadBrainTreeToolStripMenuItem.Name = "loadBrainTreeToolStripMenuItem";
            this.loadBrainTreeToolStripMenuItem.Size = new System.Drawing.Size(293, 36);
            this.loadBrainTreeToolStripMenuItem.Text = "Load BrainTree API";
            this.loadBrainTreeToolStripMenuItem.Click += new System.EventHandler(this.loadBrainTreeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(293, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToleranceToolStripMenuItem,
            this.smileToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // changeToleranceToolStripMenuItem
            // 
            this.changeToleranceToolStripMenuItem.Enabled = false;
            this.changeToleranceToolStripMenuItem.Name = "changeToleranceToolStripMenuItem";
            this.changeToleranceToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.changeToleranceToolStripMenuItem.Text = "Change Tolerance";
            this.changeToleranceToolStripMenuItem.Click += new System.EventHandler(this.changeToleranceToolStripMenuItem_Click);
            // 
            // smileToolStripMenuItem
            // 
            this.smileToolStripMenuItem.Name = "smileToolStripMenuItem";
            this.smileToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.smileToolStripMenuItem.Text = "smile!";
            this.smileToolStripMenuItem.Click += new System.EventHandler(this.smileToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 853);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1201, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BaseGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1201, 820);
            this.panel1.TabIndex = 2;
            // 
            // BaseGridView
            // 
            this.BaseGridView.AllowUserToAddRows = false;
            this.BaseGridView.AllowUserToDeleteRows = false;
            this.BaseGridView.AllowUserToOrderColumns = true;
            this.BaseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BaseGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.DateColumn,
            this.NameColumn,
            this.GrossColumn,
            this.SubjectColumn,
            this.TypeColumn});
            this.BaseGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseGridView.Location = new System.Drawing.Point(0, 0);
            this.BaseGridView.Name = "BaseGridView";
            this.BaseGridView.ReadOnly = true;
            this.BaseGridView.RowTemplate.Height = 28;
            this.BaseGridView.Size = new System.Drawing.Size(1201, 820);
            this.BaseGridView.TabIndex = 1;
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Location = new System.Drawing.Point(585, 0);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(292, 28);
            this.FilterComboBox.TabIndex = 0;
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // TempOpenFIle
            // 
            this.TempOpenFIle.FileName = "openFileDialog1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // DateColumn
            // 
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // GrossColumn
            // 
            this.GrossColumn.HeaderText = "Gross Amount";
            this.GrossColumn.Name = "GrossColumn";
            this.GrossColumn.ReadOnly = true;
            // 
            // SubjectColumn
            // 
            this.SubjectColumn.HeaderText = "Currency";
            this.SubjectColumn.Name = "SubjectColumn";
            this.SubjectColumn.ReadOnly = true;
            // 
            // TypeColumn
            // 
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            // 
            // GotchaWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 878);
            this.Controls.Add(this.FilterComboBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GotchaWindow";
            this.Text = "Gotcha";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BaseGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog TempOpenFIle;
        private System.ComponentModel.BackgroundWorker CalculateWorker;
        private System.ComponentModel.BackgroundWorker APIWorker;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.DataGridView BaseGridView;
        private System.Windows.Forms.ToolStripMenuItem loadBrainTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeToleranceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCustomFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smileToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
    }
}

