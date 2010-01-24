namespace Nanook.QueenBee
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPak = new System.Windows.Forms.TabPage();
            this.splitPak = new System.Windows.Forms.SplitContainer();
            this.lstPakContents = new System.Windows.Forms.ListView();
            this.hdrPakFilename = new System.Windows.Forms.ColumnHeader();
            this.hdrPakFullFilename = new System.Windows.Forms.ColumnHeader();
            this.hdrPakPosition = new System.Windows.Forms.ColumnHeader();
            this.hdrPakLength = new System.Windows.Forms.ColumnHeader();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnTestQbFile = new System.Windows.Forms.Button();
            this.btnTestSize = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.gboOpenPak = new System.Windows.Forms.GroupBox();
            this.btnDebugFile = new System.Windows.Forms.Button();
            this.txtDebugFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPabFile = new System.Windows.Forms.Button();
            this.txtPabFile = new System.Windows.Forms.TextBox();
            this.lblPabFile = new System.Windows.Forms.Label();
            this.lblFormatType = new System.Windows.Forms.Label();
            this.cboFormatType = new System.Windows.Forms.ComboBox();
            this.chkBackup = new System.Windows.Forms.CheckBox();
            this.btnLoadPak = new System.Windows.Forms.Button();
            this.btnPakFile = new System.Windows.Forms.Button();
            this.txtPakFile = new System.Windows.Forms.TextBox();
            this.lblPakFile = new System.Windows.Forms.Label();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.splitSearch = new System.Windows.Forms.SplitContainer();
            this.gboNumberSearch = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNumberSearch = new System.Windows.Forms.Button();
            this.txtNumberSearch = new System.Windows.Forms.TextBox();
            this.lblNumberSearch = new System.Windows.Forms.Label();
            this.gboQbKeySearch = new System.Windows.Forms.GroupBox();
            this.lblQbKeyText = new System.Windows.Forms.Label();
            this.btnQbKeySearch = new System.Windows.Forms.Button();
            this.txtQbKeySearch = new System.Windows.Forms.TextBox();
            this.lblQbKeySearch = new System.Windows.Forms.Label();
            this.gboStringSearch = new System.Windows.Forms.GroupBox();
            this.lblStringBlank = new System.Windows.Forms.Label();
            this.btnStringSearch = new System.Windows.Forms.Button();
            this.txtStringSearch = new System.Windows.Forms.TextBox();
            this.lblStringSearch = new System.Windows.Forms.Label();
            this.lstSearchResults = new System.Windows.Forms.ListView();
            this.hdrSearchItem = new System.Windows.Forms.ColumnHeader();
            this.hdrSearchFile = new System.Windows.Forms.ColumnHeader();
            this.hdrSearchPos = new System.Windows.Forms.ColumnHeader();
            this.hdrSearchType = new System.Windows.Forms.ColumnHeader();
            this.tabQb = new System.Windows.Forms.TabPage();
            this.splitQb = new System.Windows.Forms.SplitContainer();
            this.lstQbItems = new System.Windows.Forms.ListView();
            this.hdrItem = new System.Windows.Forms.ColumnHeader();
            this.hdrDebugName = new System.Windows.Forms.ColumnHeader();
            this.hdrValue = new System.Windows.Forms.ColumnHeader();
            this.hdrPosition = new System.Windows.Forms.ColumnHeader();
            this.hdrLength = new System.Windows.Forms.ColumnHeader();
            this.hdrDataType = new System.Windows.Forms.ColumnHeader();
            this.gboEdit = new System.Windows.Forms.GroupBox();
            this.btnSavePak = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.tlblPakFileInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblQbFileInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuReplaceFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExtractFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExtractAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRenameFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditQBFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestAllQbFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.saveQb = new System.Windows.Forms.SaveFileDialog();
            this.openQb = new System.Windows.Forms.OpenFileDialog();
            this.browseQb = new System.Windows.Forms.FolderBrowserDialog();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.openInput = new System.Windows.Forms.OpenFileDialog();
            this.mnuSearchFilter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFOnItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFOnFilename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFOnDataType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.filterOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFOutFilename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFOutDataType = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQbEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddChild = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertSibling = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddSibling = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveSibling = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCopyItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPasteItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPasteAddChild = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPasteInsertSibling = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPasteAddSibling = new System.Windows.Forms.ToolStripMenuItem();
            this.hdrType = new System.Windows.Forms.ColumnHeader();
            this.tabs.SuspendLayout();
            this.tabPak.SuspendLayout();
            this.splitPak.Panel1.SuspendLayout();
            this.splitPak.Panel2.SuspendLayout();
            this.splitPak.SuspendLayout();
            this.gboOpenPak.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.splitSearch.Panel1.SuspendLayout();
            this.splitSearch.Panel2.SuspendLayout();
            this.splitSearch.SuspendLayout();
            this.gboNumberSearch.SuspendLayout();
            this.gboQbKeySearch.SuspendLayout();
            this.gboStringSearch.SuspendLayout();
            this.tabQb.SuspendLayout();
            this.splitQb.Panel1.SuspendLayout();
            this.splitQb.Panel2.SuspendLayout();
            this.splitQb.SuspendLayout();
            this.status.SuspendLayout();
            this.mnuContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.mnuSearchFilter.SuspendLayout();
            this.mnuQbEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabPak);
            this.tabs.Controls.Add(this.tabSearch);
            this.tabs.Controls.Add(this.tabQb);
            this.tabs.Location = new System.Drawing.Point(0, 4);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(765, 459);
            this.tabs.TabIndex = 0;
            this.tabs.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabs_Deselecting);
            // 
            // tabPak
            // 
            this.tabPak.Controls.Add(this.splitPak);
            this.tabPak.Location = new System.Drawing.Point(4, 22);
            this.tabPak.Name = "tabPak";
            this.tabPak.Size = new System.Drawing.Size(757, 433);
            this.tabPak.TabIndex = 1;
            this.tabPak.Text = "PAK File";
            this.tabPak.UseVisualStyleBackColor = true;
            // 
            // splitPak
            // 
            this.splitPak.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitPak.Location = new System.Drawing.Point(0, 0);
            this.splitPak.Name = "splitPak";
            // 
            // splitPak.Panel1
            // 
            this.splitPak.Panel1.Controls.Add(this.lstPakContents);
            // 
            // splitPak.Panel2
            // 
            this.splitPak.Panel2.Controls.Add(this.btnTestQbFile);
            this.splitPak.Panel2.Controls.Add(this.btnTestSize);
            this.splitPak.Panel2.Controls.Add(this.btnInfo);
            this.splitPak.Panel2.Controls.Add(this.gboOpenPak);
            this.splitPak.Size = new System.Drawing.Size(757, 433);
            this.splitPak.SplitterDistance = 451;
            this.splitPak.TabIndex = 0;
            this.splitPak.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitPak_SplitterMoved);
            // 
            // lstPakContents
            // 
            this.lstPakContents.AllowColumnReorder = true;
            this.lstPakContents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrPakFilename,
            this.hdrPakFullFilename,
            this.hdrPakPosition,
            this.hdrPakLength,
            this.hdrType});
            this.lstPakContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPakContents.FullRowSelect = true;
            this.lstPakContents.HideSelection = false;
            this.lstPakContents.Location = new System.Drawing.Point(0, 0);
            this.lstPakContents.MultiSelect = false;
            this.lstPakContents.Name = "lstPakContents";
            this.lstPakContents.Size = new System.Drawing.Size(451, 433);
            this.lstPakContents.SmallImageList = this.imgList;
            this.lstPakContents.TabIndex = 0;
            this.lstPakContents.UseCompatibleStateImageBehavior = false;
            this.lstPakContents.View = System.Windows.Forms.View.Details;
            this.lstPakContents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstPakContents_MouseClick);
            this.lstPakContents.DoubleClick += new System.EventHandler(this.lstPakContents_DoubleClick);
            this.lstPakContents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstPakContents_ColumnClick);
            this.lstPakContents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstPakContents_KeyDown);
            // 
            // hdrPakFilename
            // 
            this.hdrPakFilename.Text = "Filename";
            this.hdrPakFilename.Width = 157;
            // 
            // hdrPakFullFilename
            // 
            this.hdrPakFullFilename.Text = "Full Filename";
            this.hdrPakFullFilename.Width = 291;
            // 
            // hdrPakPosition
            // 
            this.hdrPakPosition.Text = "Position";
            this.hdrPakPosition.Width = 113;
            // 
            // hdrPakLength
            // 
            this.hdrPakLength.Text = "Length";
            this.hdrPakLength.Width = 70;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "Array.ico");
            this.imgList.Images.SetKeyName(1, "Float.ico");
            this.imgList.Images.SetKeyName(2, "Int.ico");
            this.imgList.Images.SetKeyName(3, "QbKey.ico");
            this.imgList.Images.SetKeyName(4, "Script.ico");
            this.imgList.Images.SetKeyName(5, "String.ico");
            this.imgList.Images.SetKeyName(6, "Struct.ico");
            this.imgList.Images.SetKeyName(7, "UInt.ico");
            this.imgList.Images.SetKeyName(8, "Unknown.ico");
            this.imgList.Images.SetKeyName(9, "QbFile.ico");
            this.imgList.Images.SetKeyName(10, "Debug.ico");
            this.imgList.Images.SetKeyName(11, "Picture.ico");
            this.imgList.Images.SetKeyName(12, "File.ico");
            this.imgList.Images.SetKeyName(13, "Midi.ico");
            // 
            // btnTestQbFile
            // 
            this.btnTestQbFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestQbFile.Location = new System.Drawing.Point(11, 373);
            this.btnTestQbFile.Name = "btnTestQbFile";
            this.btnTestQbFile.Size = new System.Drawing.Size(75, 23);
            this.btnTestQbFile.TabIndex = 4;
            this.btnTestQbFile.Text = "Test QB File";
            this.btnTestQbFile.UseVisualStyleBackColor = true;
            this.btnTestQbFile.Visible = false;
            this.btnTestQbFile.Click += new System.EventHandler(this.btnTestQbFile_Click);
            // 
            // btnTestSize
            // 
            this.btnTestSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestSize.Location = new System.Drawing.Point(11, 402);
            this.btnTestSize.Name = "btnTestSize";
            this.btnTestSize.Size = new System.Drawing.Size(75, 23);
            this.btnTestSize.TabIndex = 3;
            this.btnTestSize.Text = "Test Size";
            this.btnTestSize.UseVisualStyleBackColor = true;
            this.btnTestSize.Visible = false;
            this.btnTestSize.Click += new System.EventHandler(this.btnTestSize_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.Location = new System.Drawing.Point(219, 402);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 2;
            this.btnInfo.Text = "Info...";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            this.btnInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnInfo_MouseDown);
            // 
            // gboOpenPak
            // 
            this.gboOpenPak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboOpenPak.Controls.Add(this.btnDebugFile);
            this.gboOpenPak.Controls.Add(this.txtDebugFile);
            this.gboOpenPak.Controls.Add(this.label3);
            this.gboOpenPak.Controls.Add(this.btnPabFile);
            this.gboOpenPak.Controls.Add(this.txtPabFile);
            this.gboOpenPak.Controls.Add(this.lblPabFile);
            this.gboOpenPak.Controls.Add(this.lblFormatType);
            this.gboOpenPak.Controls.Add(this.cboFormatType);
            this.gboOpenPak.Controls.Add(this.chkBackup);
            this.gboOpenPak.Controls.Add(this.btnLoadPak);
            this.gboOpenPak.Controls.Add(this.btnPakFile);
            this.gboOpenPak.Controls.Add(this.txtPakFile);
            this.gboOpenPak.Controls.Add(this.lblPakFile);
            this.gboOpenPak.Location = new System.Drawing.Point(0, 8);
            this.gboOpenPak.Name = "gboOpenPak";
            this.gboOpenPak.Size = new System.Drawing.Size(295, 160);
            this.gboOpenPak.TabIndex = 0;
            this.gboOpenPak.TabStop = false;
            this.gboOpenPak.Text = "Input Settings";
            // 
            // btnDebugFile
            // 
            this.btnDebugFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebugFile.Location = new System.Drawing.Point(260, 95);
            this.btnDebugFile.Name = "btnDebugFile";
            this.btnDebugFile.Size = new System.Drawing.Size(24, 22);
            this.btnDebugFile.TabIndex = 10;
            this.btnDebugFile.Text = "...";
            this.btnDebugFile.UseVisualStyleBackColor = true;
            this.btnDebugFile.Click += new System.EventHandler(this.btnDebugFile_Click);
            // 
            // txtDebugFile
            // 
            this.txtDebugFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugFile.Location = new System.Drawing.Point(76, 96);
            this.txtDebugFile.Name = "txtDebugFile";
            this.txtDebugFile.Size = new System.Drawing.Size(184, 20);
            this.txtDebugFile.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Debug File";
            // 
            // btnPabFile
            // 
            this.btnPabFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPabFile.Location = new System.Drawing.Point(260, 70);
            this.btnPabFile.Name = "btnPabFile";
            this.btnPabFile.Size = new System.Drawing.Size(24, 22);
            this.btnPabFile.TabIndex = 7;
            this.btnPabFile.Text = "...";
            this.btnPabFile.UseVisualStyleBackColor = true;
            this.btnPabFile.Click += new System.EventHandler(this.btnPabFile_Click);
            // 
            // txtPabFile
            // 
            this.txtPabFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPabFile.Location = new System.Drawing.Point(76, 71);
            this.txtPabFile.Name = "txtPabFile";
            this.txtPabFile.Size = new System.Drawing.Size(184, 20);
            this.txtPabFile.TabIndex = 6;
            // 
            // lblPabFile
            // 
            this.lblPabFile.AutoSize = true;
            this.lblPabFile.Location = new System.Drawing.Point(12, 74);
            this.lblPabFile.Name = "lblPabFile";
            this.lblPabFile.Size = new System.Drawing.Size(47, 13);
            this.lblPabFile.TabIndex = 5;
            this.lblPabFile.Text = "PAB File";
            // 
            // lblFormatType
            // 
            this.lblFormatType.AutoSize = true;
            this.lblFormatType.Location = new System.Drawing.Point(12, 23);
            this.lblFormatType.Name = "lblFormatType";
            this.lblFormatType.Size = new System.Drawing.Size(39, 13);
            this.lblFormatType.TabIndex = 0;
            this.lblFormatType.Text = "Format";
            // 
            // cboFormatType
            // 
            this.cboFormatType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFormatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormatType.FormattingEnabled = true;
            this.cboFormatType.Location = new System.Drawing.Point(76, 20);
            this.cboFormatType.Name = "cboFormatType";
            this.cboFormatType.Size = new System.Drawing.Size(208, 21);
            this.cboFormatType.TabIndex = 1;
            this.cboFormatType.SelectedIndexChanged += new System.EventHandler(this.cboPakType_SelectedIndexChanged);
            // 
            // chkBackup
            // 
            this.chkBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBackup.AutoSize = true;
            this.chkBackup.Checked = true;
            this.chkBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBackup.Location = new System.Drawing.Point(140, 127);
            this.chkBackup.Name = "chkBackup";
            this.chkBackup.Size = new System.Drawing.Size(63, 17);
            this.chkBackup.TabIndex = 11;
            this.chkBackup.Text = "Backup";
            this.chkBackup.UseVisualStyleBackColor = true;
            // 
            // btnLoadPak
            // 
            this.btnLoadPak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPak.Location = new System.Drawing.Point(209, 123);
            this.btnLoadPak.Name = "btnLoadPak";
            this.btnLoadPak.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPak.TabIndex = 12;
            this.btnLoadPak.Text = "Load";
            this.btnLoadPak.UseVisualStyleBackColor = true;
            this.btnLoadPak.Click += new System.EventHandler(this.btnLoadPak_Click);
            // 
            // btnPakFile
            // 
            this.btnPakFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPakFile.Location = new System.Drawing.Point(260, 45);
            this.btnPakFile.Name = "btnPakFile";
            this.btnPakFile.Size = new System.Drawing.Size(24, 22);
            this.btnPakFile.TabIndex = 4;
            this.btnPakFile.Text = "...";
            this.btnPakFile.UseVisualStyleBackColor = true;
            this.btnPakFile.Click += new System.EventHandler(this.btnPakFile_Click);
            // 
            // txtPakFile
            // 
            this.txtPakFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPakFile.Location = new System.Drawing.Point(76, 46);
            this.txtPakFile.Name = "txtPakFile";
            this.txtPakFile.Size = new System.Drawing.Size(184, 20);
            this.txtPakFile.TabIndex = 3;
            // 
            // lblPakFile
            // 
            this.lblPakFile.AutoSize = true;
            this.lblPakFile.Location = new System.Drawing.Point(12, 49);
            this.lblPakFile.Name = "lblPakFile";
            this.lblPakFile.Size = new System.Drawing.Size(47, 13);
            this.lblPakFile.TabIndex = 2;
            this.lblPakFile.Text = "PAK File";
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.splitSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(757, 433);
            this.tabSearch.TabIndex = 2;
            this.tabSearch.Text = "QB Item Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // splitSearch
            // 
            this.splitSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSearch.Location = new System.Drawing.Point(0, 0);
            this.splitSearch.Name = "splitSearch";
            // 
            // splitSearch.Panel1
            // 
            this.splitSearch.Panel1.Controls.Add(this.gboNumberSearch);
            this.splitSearch.Panel1.Controls.Add(this.gboQbKeySearch);
            this.splitSearch.Panel1.Controls.Add(this.gboStringSearch);
            // 
            // splitSearch.Panel2
            // 
            this.splitSearch.Panel2.Controls.Add(this.lstSearchResults);
            this.splitSearch.Size = new System.Drawing.Size(757, 433);
            this.splitSearch.SplitterDistance = 298;
            this.splitSearch.TabIndex = 0;
            this.splitSearch.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitSearch_SplitterMoved);
            // 
            // gboNumberSearch
            // 
            this.gboNumberSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboNumberSearch.Controls.Add(this.label2);
            this.gboNumberSearch.Controls.Add(this.btnNumberSearch);
            this.gboNumberSearch.Controls.Add(this.txtNumberSearch);
            this.gboNumberSearch.Controls.Add(this.lblNumberSearch);
            this.gboNumberSearch.Location = new System.Drawing.Point(1, 203);
            this.gboNumberSearch.Name = "gboNumberSearch";
            this.gboNumberSearch.Size = new System.Drawing.Size(295, 76);
            this.gboNumberSearch.TabIndex = 2;
            this.gboNumberSearch.TabStop = false;
            this.gboNumberSearch.Text = "Number Search";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Example: 10 (all) or 10.0 (decimal)";
            // 
            // btnNumberSearch
            // 
            this.btnNumberSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNumberSearch.Location = new System.Drawing.Point(208, 45);
            this.btnNumberSearch.Name = "btnNumberSearch";
            this.btnNumberSearch.Size = new System.Drawing.Size(63, 22);
            this.btnNumberSearch.TabIndex = 2;
            this.btnNumberSearch.Text = "Search";
            this.btnNumberSearch.UseVisualStyleBackColor = true;
            this.btnNumberSearch.Click += new System.EventHandler(this.btnNumberSearch_Click);
            // 
            // txtNumberSearch
            // 
            this.txtNumberSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumberSearch.Location = new System.Drawing.Point(44, 19);
            this.txtNumberSearch.Name = "txtNumberSearch";
            this.txtNumberSearch.Size = new System.Drawing.Size(227, 20);
            this.txtNumberSearch.TabIndex = 1;
            this.txtNumberSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumberSearch_KeyDown);
            this.txtNumberSearch.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumberSearch_Validating);
            // 
            // lblNumberSearch
            // 
            this.lblNumberSearch.AutoSize = true;
            this.lblNumberSearch.Location = new System.Drawing.Point(6, 22);
            this.lblNumberSearch.Name = "lblNumberSearch";
            this.lblNumberSearch.Size = new System.Drawing.Size(24, 13);
            this.lblNumberSearch.TabIndex = 0;
            this.lblNumberSearch.Text = "No.";
            // 
            // gboQbKeySearch
            // 
            this.gboQbKeySearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboQbKeySearch.Controls.Add(this.lblQbKeyText);
            this.gboQbKeySearch.Controls.Add(this.btnQbKeySearch);
            this.gboQbKeySearch.Controls.Add(this.txtQbKeySearch);
            this.gboQbKeySearch.Controls.Add(this.lblQbKeySearch);
            this.gboQbKeySearch.Location = new System.Drawing.Point(3, 103);
            this.gboQbKeySearch.Name = "gboQbKeySearch";
            this.gboQbKeySearch.Size = new System.Drawing.Size(295, 76);
            this.gboQbKeySearch.TabIndex = 1;
            this.gboQbKeySearch.TabStop = false;
            this.gboQbKeySearch.Text = "QB Key Search";
            // 
            // lblQbKeyText
            // 
            this.lblQbKeyText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQbKeyText.AutoSize = true;
            this.lblQbKeyText.Location = new System.Drawing.Point(73, 50);
            this.lblQbKeyText.Name = "lblQbKeyText";
            this.lblQbKeyText.Size = new System.Drawing.Size(129, 13);
            this.lblQbKeyText.TabIndex = 3;
            this.lblQbKeyText.Text = "Enter Hex QB Key or Text";
            // 
            // btnQbKeySearch
            // 
            this.btnQbKeySearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQbKeySearch.Location = new System.Drawing.Point(208, 45);
            this.btnQbKeySearch.Name = "btnQbKeySearch";
            this.btnQbKeySearch.Size = new System.Drawing.Size(63, 22);
            this.btnQbKeySearch.TabIndex = 2;
            this.btnQbKeySearch.Text = "Search";
            this.btnQbKeySearch.UseVisualStyleBackColor = true;
            this.btnQbKeySearch.Click += new System.EventHandler(this.btnQbKeySearch_Click);
            // 
            // txtQbKeySearch
            // 
            this.txtQbKeySearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQbKeySearch.Location = new System.Drawing.Point(44, 19);
            this.txtQbKeySearch.Name = "txtQbKeySearch";
            this.txtQbKeySearch.Size = new System.Drawing.Size(227, 20);
            this.txtQbKeySearch.TabIndex = 1;
            this.txtQbKeySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQbKeySearch_KeyDown);
            this.txtQbKeySearch.Validating += new System.ComponentModel.CancelEventHandler(this.txtQbKeySearch_Validating);
            // 
            // lblQbKeySearch
            // 
            this.lblQbKeySearch.AutoSize = true;
            this.lblQbKeySearch.Location = new System.Drawing.Point(6, 22);
            this.lblQbKeySearch.Name = "lblQbKeySearch";
            this.lblQbKeySearch.Size = new System.Drawing.Size(34, 13);
            this.lblQbKeySearch.TabIndex = 0;
            this.lblQbKeySearch.Text = "String";
            // 
            // gboStringSearch
            // 
            this.gboStringSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboStringSearch.Controls.Add(this.lblStringBlank);
            this.gboStringSearch.Controls.Add(this.btnStringSearch);
            this.gboStringSearch.Controls.Add(this.txtStringSearch);
            this.gboStringSearch.Controls.Add(this.lblStringSearch);
            this.gboStringSearch.Location = new System.Drawing.Point(3, 3);
            this.gboStringSearch.Name = "gboStringSearch";
            this.gboStringSearch.Size = new System.Drawing.Size(295, 76);
            this.gboStringSearch.TabIndex = 0;
            this.gboStringSearch.TabStop = false;
            this.gboStringSearch.Text = "String Search";
            // 
            // lblStringBlank
            // 
            this.lblStringBlank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStringBlank.AutoSize = true;
            this.lblStringBlank.Location = new System.Drawing.Point(85, 50);
            this.lblStringBlank.Name = "lblStringBlank";
            this.lblStringBlank.Size = new System.Drawing.Size(117, 13);
            this.lblStringBlank.TabIndex = 2;
            this.lblStringBlank.Text = "Blank will find all strings";
            // 
            // btnStringSearch
            // 
            this.btnStringSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStringSearch.Location = new System.Drawing.Point(208, 45);
            this.btnStringSearch.Name = "btnStringSearch";
            this.btnStringSearch.Size = new System.Drawing.Size(63, 22);
            this.btnStringSearch.TabIndex = 3;
            this.btnStringSearch.Text = "Search";
            this.btnStringSearch.UseVisualStyleBackColor = true;
            this.btnStringSearch.Click += new System.EventHandler(this.btnStringSearch_Click);
            // 
            // txtStringSearch
            // 
            this.txtStringSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.err.SetIconPadding(this.txtStringSearch, 4);
            this.txtStringSearch.Location = new System.Drawing.Point(44, 19);
            this.txtStringSearch.Name = "txtStringSearch";
            this.txtStringSearch.Size = new System.Drawing.Size(227, 20);
            this.txtStringSearch.TabIndex = 1;
            this.txtStringSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStringSearch_KeyDown);
            // 
            // lblStringSearch
            // 
            this.lblStringSearch.AutoSize = true;
            this.lblStringSearch.Location = new System.Drawing.Point(6, 22);
            this.lblStringSearch.Name = "lblStringSearch";
            this.lblStringSearch.Size = new System.Drawing.Size(34, 13);
            this.lblStringSearch.TabIndex = 0;
            this.lblStringSearch.Text = "String";
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstSearchResults.AllowColumnReorder = true;
            this.lstSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrSearchItem,
            this.hdrSearchFile,
            this.hdrSearchPos,
            this.hdrSearchType});
            this.lstSearchResults.FullRowSelect = true;
            this.lstSearchResults.HideSelection = false;
            this.lstSearchResults.Location = new System.Drawing.Point(0, 0);
            this.lstSearchResults.MultiSelect = false;
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(455, 433);
            this.lstSearchResults.SmallImageList = this.imgList;
            this.lstSearchResults.TabIndex = 0;
            this.lstSearchResults.UseCompatibleStateImageBehavior = false;
            this.lstSearchResults.View = System.Windows.Forms.View.Details;
            this.lstSearchResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstSearchResults_MouseClick);
            this.lstSearchResults.DoubleClick += new System.EventHandler(this.lstSearchResults_DoubleClick);
            this.lstSearchResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstSearchResults_ColumnClick);
            // 
            // hdrSearchItem
            // 
            this.hdrSearchItem.Text = "Item";
            this.hdrSearchItem.Width = 184;
            // 
            // hdrSearchFile
            // 
            this.hdrSearchFile.Text = "QB Full Filename";
            this.hdrSearchFile.Width = 344;
            // 
            // hdrSearchPos
            // 
            this.hdrSearchPos.Text = "Item Position";
            this.hdrSearchPos.Width = 103;
            // 
            // hdrSearchType
            // 
            this.hdrSearchType.Text = "Type";
            this.hdrSearchType.Width = 112;
            // 
            // tabQb
            // 
            this.tabQb.Controls.Add(this.splitQb);
            this.tabQb.Location = new System.Drawing.Point(4, 22);
            this.tabQb.Name = "tabQb";
            this.tabQb.Padding = new System.Windows.Forms.Padding(3);
            this.tabQb.Size = new System.Drawing.Size(757, 433);
            this.tabQb.TabIndex = 0;
            this.tabQb.Text = "QB File";
            this.tabQb.UseVisualStyleBackColor = true;
            // 
            // splitQb
            // 
            this.splitQb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitQb.Location = new System.Drawing.Point(0, 0);
            this.splitQb.Margin = new System.Windows.Forms.Padding(0);
            this.splitQb.Name = "splitQb";
            // 
            // splitQb.Panel1
            // 
            this.splitQb.Panel1.Controls.Add(this.lstQbItems);
            // 
            // splitQb.Panel2
            // 
            this.splitQb.Panel2.Controls.Add(this.gboEdit);
            this.splitQb.Panel2.Controls.Add(this.btnSavePak);
            this.splitQb.Size = new System.Drawing.Size(757, 433);
            this.splitQb.SplitterDistance = 473;
            this.splitQb.TabIndex = 0;
            this.splitQb.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitQb_SplitterMoved);
            // 
            // lstQbItems
            // 
            this.lstQbItems.AllowColumnReorder = true;
            this.lstQbItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrItem,
            this.hdrDebugName,
            this.hdrValue,
            this.hdrPosition,
            this.hdrLength,
            this.hdrDataType});
            this.lstQbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstQbItems.FullRowSelect = true;
            this.lstQbItems.HideSelection = false;
            this.lstQbItems.Location = new System.Drawing.Point(0, 0);
            this.lstQbItems.MultiSelect = false;
            this.lstQbItems.Name = "lstQbItems";
            this.lstQbItems.Size = new System.Drawing.Size(473, 433);
            this.lstQbItems.SmallImageList = this.imgList;
            this.lstQbItems.TabIndex = 0;
            this.lstQbItems.UseCompatibleStateImageBehavior = false;
            this.lstQbItems.View = System.Windows.Forms.View.Details;
            this.lstQbItems.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstQbItems_MouseUp);
            this.lstQbItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstItems_ItemSelectionChanged);
            // 
            // hdrItem
            // 
            this.hdrItem.Text = "Item";
            this.hdrItem.Width = 220;
            // 
            // hdrDebugName
            // 
            this.hdrDebugName.Text = "Id";
            this.hdrDebugName.Width = 121;
            // 
            // hdrValue
            // 
            this.hdrValue.Text = "Value";
            this.hdrValue.Width = 112;
            // 
            // hdrPosition
            // 
            this.hdrPosition.Text = "Position";
            this.hdrPosition.Width = 113;
            // 
            // hdrLength
            // 
            this.hdrLength.Text = "Length";
            this.hdrLength.Width = 49;
            // 
            // hdrDataType
            // 
            this.hdrDataType.Text = "Data Type";
            this.hdrDataType.Width = 94;
            // 
            // gboEdit
            // 
            this.gboEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboEdit.Location = new System.Drawing.Point(1, 0);
            this.gboEdit.Name = "gboEdit";
            this.gboEdit.Size = new System.Drawing.Size(275, 397);
            this.gboEdit.TabIndex = 0;
            this.gboEdit.TabStop = false;
            this.gboEdit.Text = "Edit Items";
            // 
            // btnSavePak
            // 
            this.btnSavePak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePak.Enabled = false;
            this.btnSavePak.Location = new System.Drawing.Point(190, 403);
            this.btnSavePak.Name = "btnSavePak";
            this.btnSavePak.Size = new System.Drawing.Size(84, 23);
            this.btnSavePak.TabIndex = 1;
            this.btnSavePak.Text = "Save to Disk";
            this.btnSavePak.UseVisualStyleBackColor = true;
            this.btnSavePak.Click += new System.EventHandler(this.btnSavePak_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblPakFileInfo,
            this.tlblQbFileInfo,
            this.tlblLink});
            this.status.Location = new System.Drawing.Point(0, 466);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(765, 22);
            this.status.TabIndex = 1;
            // 
            // tlblPakFileInfo
            // 
            this.tlblPakFileInfo.Name = "tlblPakFileInfo";
            this.tlblPakFileInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // tlblQbFileInfo
            // 
            this.tlblQbFileInfo.Name = "tlblQbFileInfo";
            this.tlblQbFileInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // tlblLink
            // 
            this.tlblLink.IsLink = true;
            this.tlblLink.Name = "tlblLink";
            this.tlblLink.Size = new System.Drawing.Size(750, 17);
            this.tlblLink.Spring = true;
            this.tlblLink.Tag = "http://www.myspace.com/salutetothesun666";
            this.tlblLink.Text = "Listen to this great Death Metal band: Salute To The Sun";
            this.tlblLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tlblLink.Click += new System.EventHandler(this.tlblLink_Click);
            // 
            // mnuContext
            // 
            this.mnuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReplaceFile,
            this.mnuExtractFile,
            this.mnuExtractAll,
            this.toolStripMenuItem1,
            this.mnuNewFile,
            this.mnuAddFile,
            this.mnuRenameFile,
            this.mnuRemoveFile,
            this.toolStripMenuItem4,
            this.mnuEditQBFile,
            this.mnuTestAllQbFiles});
            this.mnuContext.Name = "mnuContext";
            this.mnuContext.Size = new System.Drawing.Size(162, 214);
            // 
            // mnuReplaceFile
            // 
            this.mnuReplaceFile.Name = "mnuReplaceFile";
            this.mnuReplaceFile.Size = new System.Drawing.Size(161, 22);
            this.mnuReplaceFile.Text = "Replace File...";
            this.mnuReplaceFile.Click += new System.EventHandler(this.mnuReplaceFile_Click);
            // 
            // mnuExtractFile
            // 
            this.mnuExtractFile.Name = "mnuExtractFile";
            this.mnuExtractFile.Size = new System.Drawing.Size(161, 22);
            this.mnuExtractFile.Text = "Extract File...";
            this.mnuExtractFile.Click += new System.EventHandler(this.mnuExtractFile_Click);
            // 
            // mnuExtractAll
            // 
            this.mnuExtractAll.Name = "mnuExtractAll";
            this.mnuExtractAll.Size = new System.Drawing.Size(161, 22);
            this.mnuExtractAll.Text = "Extract All...";
            this.mnuExtractAll.Click += new System.EventHandler(this.mnuExtractAll_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // mnuNewFile
            // 
            this.mnuNewFile.Name = "mnuNewFile";
            this.mnuNewFile.Size = new System.Drawing.Size(161, 22);
            this.mnuNewFile.Text = "New File...";
            this.mnuNewFile.Click += new System.EventHandler(this.mnuNewFile_Click);
            // 
            // mnuAddFile
            // 
            this.mnuAddFile.Name = "mnuAddFile";
            this.mnuAddFile.Size = new System.Drawing.Size(161, 22);
            this.mnuAddFile.Text = "Add File...";
            this.mnuAddFile.Click += new System.EventHandler(this.mnuAddFile_Click);
            // 
            // mnuRenameFile
            // 
            this.mnuRenameFile.Name = "mnuRenameFile";
            this.mnuRenameFile.Size = new System.Drawing.Size(161, 22);
            this.mnuRenameFile.Text = "Rename File...";
            this.mnuRenameFile.Click += new System.EventHandler(this.mnuRenameFile_Click);
            // 
            // mnuRemoveFile
            // 
            this.mnuRemoveFile.Name = "mnuRemoveFile";
            this.mnuRemoveFile.Size = new System.Drawing.Size(161, 22);
            this.mnuRemoveFile.Text = "Remove File";
            this.mnuRemoveFile.Click += new System.EventHandler(this.mnuRemoveFile_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(158, 6);
            // 
            // mnuEditQBFile
            // 
            this.mnuEditQBFile.Name = "mnuEditQBFile";
            this.mnuEditQBFile.Size = new System.Drawing.Size(161, 22);
            this.mnuEditQBFile.Text = "Edit QB File";
            this.mnuEditQBFile.Click += new System.EventHandler(this.mnuEditQBFile_Click);
            // 
            // mnuTestAllQbFiles
            // 
            this.mnuTestAllQbFiles.Name = "mnuTestAllQbFiles";
            this.mnuTestAllQbFiles.Size = new System.Drawing.Size(161, 22);
            this.mnuTestAllQbFiles.Text = "Test All QB Files";
            this.mnuTestAllQbFiles.Click += new System.EventHandler(this.mnuTestAllQbFiles_Click);
            // 
            // saveQb
            // 
            this.saveQb.AddExtension = false;
            // 
            // openQb
            // 
            this.openQb.Title = "Open QB to Replace in PAK";
            // 
            // browseQb
            // 
            this.browseQb.Description = "Select a folder to extract and overwrite all QB files:";
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // mnuSearchFilter
            // 
            this.mnuSearchFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterOnToolStripMenuItem,
            this.mnuFOnItem,
            this.mnuFOnFilename,
            this.mnuFOnDataType,
            this.toolStripMenuItem2,
            this.filterOutToolStripMenuItem,
            this.mnuFOutItem,
            this.mnuFOutFilename,
            this.mnuFOutDataType});
            this.mnuSearchFilter.Name = "mnuSearchFilter";
            this.mnuSearchFilter.Size = new System.Drawing.Size(164, 186);
            // 
            // filterOnToolStripMenuItem
            // 
            this.filterOnToolStripMenuItem.Enabled = false;
            this.filterOnToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterOnToolStripMenuItem.Name = "filterOnToolStripMenuItem";
            this.filterOnToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.filterOnToolStripMenuItem.Text = "Filter On";
            // 
            // mnuFOnItem
            // 
            this.mnuFOnItem.Name = "mnuFOnItem";
            this.mnuFOnItem.Size = new System.Drawing.Size(163, 22);
            this.mnuFOnItem.Text = "Item";
            this.mnuFOnItem.Click += new System.EventHandler(this.mnuSearchFilter_Click);
            // 
            // mnuFOnFilename
            // 
            this.mnuFOnFilename.Name = "mnuFOnFilename";
            this.mnuFOnFilename.Size = new System.Drawing.Size(163, 22);
            this.mnuFOnFilename.Text = "QB Full Filename";
            this.mnuFOnFilename.Click += new System.EventHandler(this.mnuSearchFilter_Click);
            // 
            // mnuFOnDataType
            // 
            this.mnuFOnDataType.Name = "mnuFOnDataType";
            this.mnuFOnDataType.Size = new System.Drawing.Size(163, 22);
            this.mnuFOnDataType.Text = "Type";
            this.mnuFOnDataType.Click += new System.EventHandler(this.mnuSearchFilter_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 6);
            // 
            // filterOutToolStripMenuItem
            // 
            this.filterOutToolStripMenuItem.Enabled = false;
            this.filterOutToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterOutToolStripMenuItem.Name = "filterOutToolStripMenuItem";
            this.filterOutToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.filterOutToolStripMenuItem.Text = "Filter Out";
            // 
            // mnuFOutItem
            // 
            this.mnuFOutItem.Name = "mnuFOutItem";
            this.mnuFOutItem.Size = new System.Drawing.Size(163, 22);
            this.mnuFOutItem.Text = "Item";
            this.mnuFOutItem.Click += new System.EventHandler(this.mnuSearchFilter_Click);
            // 
            // mnuFOutFilename
            // 
            this.mnuFOutFilename.Name = "mnuFOutFilename";
            this.mnuFOutFilename.Size = new System.Drawing.Size(163, 22);
            this.mnuFOutFilename.Text = "QB Full Filename";
            this.mnuFOutFilename.Click += new System.EventHandler(this.mnuSearchFilter_Click);
            // 
            // mnuFOutDataType
            // 
            this.mnuFOutDataType.Name = "mnuFOutDataType";
            this.mnuFOutDataType.Size = new System.Drawing.Size(163, 22);
            this.mnuFOutDataType.Text = "Type";
            this.mnuFOutDataType.Click += new System.EventHandler(this.mnuSearchFilter_Click);
            // 
            // mnuQbEdit
            // 
            this.mnuQbEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddChild,
            this.mnuInsertSibling,
            this.mnuAddSibling,
            this.mnuRemoveSibling,
            this.toolStripMenuItem3,
            this.mnuCopyItems,
            this.mnuPasteItems});
            this.mnuQbEdit.Name = "mnuQbEdit";
            this.mnuQbEdit.Size = new System.Drawing.Size(148, 142);
            // 
            // mnuAddChild
            // 
            this.mnuAddChild.Name = "mnuAddChild";
            this.mnuAddChild.Size = new System.Drawing.Size(147, 22);
            this.mnuAddChild.Text = "Add Child";
            // 
            // mnuInsertSibling
            // 
            this.mnuInsertSibling.Name = "mnuInsertSibling";
            this.mnuInsertSibling.Size = new System.Drawing.Size(147, 22);
            this.mnuInsertSibling.Text = "Insert Sibling";
            // 
            // mnuAddSibling
            // 
            this.mnuAddSibling.Name = "mnuAddSibling";
            this.mnuAddSibling.Size = new System.Drawing.Size(147, 22);
            this.mnuAddSibling.Text = "Add Sibling";
            // 
            // mnuRemoveSibling
            // 
            this.mnuRemoveSibling.Name = "mnuRemoveSibling";
            this.mnuRemoveSibling.Size = new System.Drawing.Size(147, 22);
            this.mnuRemoveSibling.Text = "Remove";
            this.mnuRemoveSibling.Click += new System.EventHandler(this.qbRemoveItem);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(144, 6);
            // 
            // mnuCopyItems
            // 
            this.mnuCopyItems.Name = "mnuCopyItems";
            this.mnuCopyItems.Size = new System.Drawing.Size(147, 22);
            this.mnuCopyItems.Text = "Copy";
            this.mnuCopyItems.Click += new System.EventHandler(this.mnuCopyItems_Click);
            // 
            // mnuPasteItems
            // 
            this.mnuPasteItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPasteAddChild,
            this.mnuPasteInsertSibling,
            this.mnuPasteAddSibling});
            this.mnuPasteItems.Name = "mnuPasteItems";
            this.mnuPasteItems.Size = new System.Drawing.Size(147, 22);
            this.mnuPasteItems.Text = "Paste";
            // 
            // mnuPasteAddChild
            // 
            this.mnuPasteAddChild.Name = "mnuPasteAddChild";
            this.mnuPasteAddChild.Size = new System.Drawing.Size(147, 22);
            this.mnuPasteAddChild.Text = "Add Child";
            this.mnuPasteAddChild.Click += new System.EventHandler(this.mnuPasteAddChild_Click);
            // 
            // mnuPasteInsertSibling
            // 
            this.mnuPasteInsertSibling.Name = "mnuPasteInsertSibling";
            this.mnuPasteInsertSibling.Size = new System.Drawing.Size(147, 22);
            this.mnuPasteInsertSibling.Text = "Insert Sibling";
            this.mnuPasteInsertSibling.Click += new System.EventHandler(this.mnuPasteInsertSibling_Click);
            // 
            // mnuPasteAddSibling
            // 
            this.mnuPasteAddSibling.Name = "mnuPasteAddSibling";
            this.mnuPasteAddSibling.Size = new System.Drawing.Size(147, 22);
            this.mnuPasteAddSibling.Text = "Add Sibling";
            this.mnuPasteAddSibling.Click += new System.EventHandler(this.mnuPasteAddSibling_Click);
            // 
            // hdrType
            // 
            this.hdrType.Text = "Type";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 488);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Queen Bee (PAK / QB Explorer, Editor)";
            this.SizeChanged += new System.EventHandler(this.EditorForm_Resize_Move);
            this.Move += new System.EventHandler(this.EditorForm_Resize_Move);
            this.ResizeEnd += new System.EventHandler(this.EditorForm_Resize_Move);
            this.tabs.ResumeLayout(false);
            this.tabPak.ResumeLayout(false);
            this.splitPak.Panel1.ResumeLayout(false);
            this.splitPak.Panel2.ResumeLayout(false);
            this.splitPak.ResumeLayout(false);
            this.gboOpenPak.ResumeLayout(false);
            this.gboOpenPak.PerformLayout();
            this.tabSearch.ResumeLayout(false);
            this.splitSearch.Panel1.ResumeLayout(false);
            this.splitSearch.Panel2.ResumeLayout(false);
            this.splitSearch.ResumeLayout(false);
            this.gboNumberSearch.ResumeLayout(false);
            this.gboNumberSearch.PerformLayout();
            this.gboQbKeySearch.ResumeLayout(false);
            this.gboQbKeySearch.PerformLayout();
            this.gboStringSearch.ResumeLayout(false);
            this.gboStringSearch.PerformLayout();
            this.tabQb.ResumeLayout(false);
            this.splitQb.Panel1.ResumeLayout(false);
            this.splitQb.Panel2.ResumeLayout(false);
            this.splitQb.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.mnuContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.mnuSearchFilter.ResumeLayout(false);
            this.mnuQbEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabQb;
        private System.Windows.Forms.SplitContainer splitQb;
        private System.Windows.Forms.ListView lstQbItems;
        private System.Windows.Forms.ColumnHeader hdrItem;
        private System.Windows.Forms.ColumnHeader hdrDebugName;
        private System.Windows.Forms.ColumnHeader hdrPosition;
        private System.Windows.Forms.ColumnHeader hdrLength;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ColumnHeader hdrDataType;
        private System.Windows.Forms.TabPage tabPak;
        private System.Windows.Forms.SplitContainer splitPak;
        private System.Windows.Forms.ListView lstPakContents;
        private System.Windows.Forms.Button btnPakFile;
        private System.Windows.Forms.TextBox txtPakFile;
        private System.Windows.Forms.Label lblPakFile;
        private System.Windows.Forms.GroupBox gboOpenPak;
        private System.Windows.Forms.Button btnLoadPak;
        private System.Windows.Forms.ColumnHeader hdrPakFilename;
        private System.Windows.Forms.ColumnHeader hdrPakFullFilename;
        private System.Windows.Forms.ColumnHeader hdrPakPosition;
        private System.Windows.Forms.ColumnHeader hdrPakLength;
        private System.Windows.Forms.GroupBox gboEdit;
        private System.Windows.Forms.Button btnSavePak;
        private System.Windows.Forms.CheckBox chkBackup;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel tlblPakFileInfo;
        private System.Windows.Forms.ToolStripStatusLabel tlblQbFileInfo;
        private System.Windows.Forms.ToolStripStatusLabel tlblLink;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.ContextMenuStrip mnuContext;
        private System.Windows.Forms.ToolStripMenuItem mnuTestAllQbFiles;
        private System.Windows.Forms.ToolStripMenuItem mnuExtractFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExtractAll;
        private System.Windows.Forms.ToolStripMenuItem mnuReplaceFile;
        private System.Windows.Forms.SaveFileDialog saveQb;
        private System.Windows.Forms.OpenFileDialog openQb;
        private System.Windows.Forms.FolderBrowserDialog browseQb;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuEditQBFile;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.SplitContainer splitSearch;
        private System.Windows.Forms.ListView lstSearchResults;
        private System.Windows.Forms.ColumnHeader hdrSearchItem;
        private System.Windows.Forms.ColumnHeader hdrSearchFile;
        private System.Windows.Forms.ColumnHeader hdrSearchPos;
        private System.Windows.Forms.ColumnHeader hdrSearchType;
        private System.Windows.Forms.GroupBox gboStringSearch;
        private System.Windows.Forms.Button btnStringSearch;
        private System.Windows.Forms.TextBox txtStringSearch;
        private System.Windows.Forms.Label lblStringSearch;
        private System.Windows.Forms.GroupBox gboQbKeySearch;
        private System.Windows.Forms.Button btnQbKeySearch;
        private System.Windows.Forms.TextBox txtQbKeySearch;
        private System.Windows.Forms.Label lblQbKeySearch;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Label lblStringBlank;
        private System.Windows.Forms.ComboBox cboFormatType;
        private System.Windows.Forms.Label lblFormatType;
        private System.Windows.Forms.Button btnDebugFile;
        private System.Windows.Forms.TextBox txtDebugFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPabFile;
        private System.Windows.Forms.TextBox txtPabFile;
        private System.Windows.Forms.Label lblPabFile;
        private System.Windows.Forms.OpenFileDialog openInput;
        private System.Windows.Forms.Button btnTestSize;
        private System.Windows.Forms.Button btnTestQbFile;
        private System.Windows.Forms.Label lblQbKeyText;
        private System.Windows.Forms.ContextMenuStrip mnuSearchFilter;
        private System.Windows.Forms.ToolStripMenuItem filterOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFOnItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFOnFilename;
        private System.Windows.Forms.ToolStripMenuItem mnuFOnDataType;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem filterOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFOutItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFOutFilename;
        private System.Windows.Forms.ToolStripMenuItem mnuFOutDataType;
        private System.Windows.Forms.ContextMenuStrip mnuQbEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuAddChild;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertSibling;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSibling;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveSibling;
        private System.Windows.Forms.GroupBox gboNumberSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNumberSearch;
        private System.Windows.Forms.TextBox txtNumberSearch;
        private System.Windows.Forms.Label lblNumberSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyItems;
        private System.Windows.Forms.ToolStripMenuItem mnuPasteItems;
        private System.Windows.Forms.ToolStripMenuItem mnuPasteAddChild;
        private System.Windows.Forms.ToolStripMenuItem mnuPasteInsertSibling;
        private System.Windows.Forms.ToolStripMenuItem mnuPasteAddSibling;
        private System.Windows.Forms.ColumnHeader hdrValue;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuAddFile;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNewFile;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameFile;
        private System.Windows.Forms.ColumnHeader hdrType;
    }
}