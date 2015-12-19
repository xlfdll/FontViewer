namespace FontViewer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fontListBox = new System.Windows.Forms.ListBox();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.fontNameToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fontFolderLinkToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fontCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.copyrightToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchImageList = new System.Windows.Forms.ImageList(this.components);
            this.searchComboBox = new System.Windows.Forms.ComboBox();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fontListBox
            // 
            resources.ApplyResources(this.fontListBox, "fontListBox");
            this.fontListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fontListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.fontListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fontListBox.FormattingEnabled = true;
            this.fontListBox.MultiColumn = true;
            this.fontListBox.Name = "fontListBox";
            this.fontListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.fontListControl_DrawItem);
            this.fontListBox.SelectedIndexChanged += new System.EventHandler(this.fontListBox_SelectedIndexChanged);
            this.fontListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fontListBox_KeyDown);
            this.fontListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fontListBox_MouseDoubleClick);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontNameToolStripStatusLabel,
            this.fontFolderLinkToolStripStatusLabel,
            this.fontCountToolStripStatusLabel,
            this.copyrightToolStripStatusLabel});
            resources.ApplyResources(this.mainStatusStrip, "mainStatusStrip");
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // fontNameToolStripStatusLabel
            // 
            this.fontNameToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.fontNameToolStripStatusLabel.Name = "fontNameToolStripStatusLabel";
            resources.ApplyResources(this.fontNameToolStripStatusLabel, "fontNameToolStripStatusLabel");
            this.fontNameToolStripStatusLabel.Spring = true;
            // 
            // fontFolderLinkToolStripStatusLabel
            // 
            this.fontFolderLinkToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.fontFolderLinkToolStripStatusLabel.IsLink = true;
            this.fontFolderLinkToolStripStatusLabel.Name = "fontFolderLinkToolStripStatusLabel";
            resources.ApplyResources(this.fontFolderLinkToolStripStatusLabel, "fontFolderLinkToolStripStatusLabel");
            this.fontFolderLinkToolStripStatusLabel.Click += new System.EventHandler(this.fontFolderLinkToolStripStatusLabel_Click);
            // 
            // fontCountToolStripStatusLabel
            // 
            this.fontCountToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.fontCountToolStripStatusLabel.Name = "fontCountToolStripStatusLabel";
            resources.ApplyResources(this.fontCountToolStripStatusLabel, "fontCountToolStripStatusLabel");
            // 
            // copyrightToolStripStatusLabel
            // 
            this.copyrightToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.copyrightToolStripStatusLabel.Name = "copyrightToolStripStatusLabel";
            resources.ApplyResources(this.copyrightToolStripStatusLabel, "copyrightToolStripStatusLabel");
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.BackColor = System.Drawing.SystemColors.Window;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.GrayText;
            this.searchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.searchButton.ForeColor = System.Drawing.SystemColors.Window;
            this.searchButton.ImageList = this.searchImageList;
            this.searchButton.Name = "searchButton";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchImageList
            // 
            this.searchImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("searchImageList.ImageStream")));
            this.searchImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.searchImageList.Images.SetKeyName(0, "Find.png");
            this.searchImageList.Images.SetKeyName(1, "Clear.png");
            // 
            // searchComboBox
            // 
            resources.ApplyResources(this.searchComboBox, "searchComboBox");
            this.searchComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.searchComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.searchComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.searchComboBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchComboBox.FormattingEnabled = true;
            this.searchComboBox.Name = "searchComboBox";
            this.searchComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.fontListControl_DrawItem);
            this.searchComboBox.TextChanged += new System.EventHandler(this.searchComboBox_TextChanged);
            this.searchComboBox.Enter += new System.EventHandler(this.searchComboBox_Enter);
            this.searchComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchComboBox_KeyDown);
            this.searchComboBox.Leave += new System.EventHandler(this.searchComboBox_Leave);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchComboBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.fontListBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fontListBox;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel copyrightToolStripStatusLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ImageList searchImageList;
        private System.Windows.Forms.ComboBox searchComboBox;
        private System.Windows.Forms.ToolStripStatusLabel fontFolderLinkToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel fontNameToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel fontCountToolStripStatusLabel;
    }
}

