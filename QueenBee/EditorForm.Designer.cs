using System.Drawing;
using System.Windows.Forms;

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
            this.tabs = new TabControl();
            this.tabPak = new TabPage();
            this.splitPak = new SplitContainer();
            this.lstPakContents = new ListView();
            this.hdrPakFilename = new ColumnHeader();
            this.hdrPakFullFilename = new ColumnHeader();
            this.hdrPakPosition = new ColumnHeader();
            this.hdrPakLength = new ColumnHeader();
            this.hdrType = new ColumnHeader();
            this.imgList = new ImageList(this.components);
            this.btnTestQbFile = new Button();
            this.btnTestSize = new Button();
            this.btnInfo = new Button();
            this.gboOpenPak = new GroupBox();
            this.btnDebugFile = new Button();
            this.txtDebugFile = new TextBox();
            this.label3 = new Label();
            this.btnPabFile = new Button();
            this.txtPabFile = new TextBox();
            this.lblPabFile = new Label();
            this.lblFormatType = new Label();
            this.cboFormatType = new ComboBox();
            this.chkBackup = new CheckBox();
            this.btnLoadPak = new Button();
            this.btnPakFile = new Button();
            this.txtPakFile = new TextBox();
            this.lblPakFile = new Label();
            this.tabSearch = new TabPage();
            this.splitSearch = new SplitContainer();
            this.gboNumberSearch = new GroupBox();
            this.label2 = new Label();
            this.btnNumberSearch = new Button();
            this.txtNumberSearch = new TextBox();
            this.lblNumberSearch = new Label();
            this.gboQbKeySearch = new GroupBox();
            this.lblQbKeyText = new Label();
            this.btnQbKeySearch = new Button();
            this.txtQbKeySearch = new TextBox();
            this.lblQbKeySearch = new Label();
            this.gboStringSearch = new GroupBox();
            this.lblStringBlank = new Label();
            this.btnStringSearch = new Button();
            this.txtStringSearch = new TextBox();
            this.lblStringSearch = new Label();
            this.lstSearchResults = new ListView();
            this.hdrSearchItem = new ColumnHeader();
            this.hdrSearchFile = new ColumnHeader();
            this.hdrSearchPos = new ColumnHeader();
            this.hdrSearchType = new ColumnHeader();
            this.tabQb = new TabPage();
            this.splitQb = new SplitContainer();
            this.lstQbItems = new ListView();
            this.hdrItem = new ColumnHeader();
            this.hdrDebugName = new ColumnHeader();
            this.hdrValue = new ColumnHeader();
            this.hdrPosition = new ColumnHeader();
            this.hdrLength = new ColumnHeader();
            this.hdrDataType = new ColumnHeader();
            this.gboEdit = new GroupBox();
            this.btnSavePak = new Button();
            this.status = new StatusStrip();
            this.tlblPakFileInfo = new ToolStripStatusLabel();
            this.tlblQbFileInfo = new ToolStripStatusLabel();
            this.tlblLink = new ToolStripStatusLabel();
            this.mnuContext = new ContextMenuStrip(this.components);
            this.mnuReplaceFile = new ToolStripMenuItem();
            this.mnuExtractFile = new ToolStripMenuItem();
            this.mnuExtractAll = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripSeparator();
            this.mnuNewFile = new ToolStripMenuItem();
            this.mnuAddFile = new ToolStripMenuItem();
            this.mnuRenameFile = new ToolStripMenuItem();
            this.mnuRemoveFile = new ToolStripMenuItem();
            this.toolStripMenuItem4 = new ToolStripSeparator();
            this.mnuEditQBFile = new ToolStripMenuItem();
            this.mnuTestAllQbFiles = new ToolStripMenuItem();
            this.saveQb = new SaveFileDialog();
            this.openQb = new OpenFileDialog();
            this.browseQb = new FolderBrowserDialog();
            this.err = new ErrorProvider(this.components);
            this.openInput = new OpenFileDialog();
            this.mnuSearchFilter = new ContextMenuStrip(this.components);
            this.filterOnToolStripMenuItem = new ToolStripMenuItem();
            this.mnuFOnItem = new ToolStripMenuItem();
            this.mnuFOnFilename = new ToolStripMenuItem();
            this.mnuFOnDataType = new ToolStripMenuItem();
            this.toolStripMenuItem2 = new ToolStripSeparator();
            this.filterOutToolStripMenuItem = new ToolStripMenuItem();
            this.mnuFOutItem = new ToolStripMenuItem();
            this.mnuFOutFilename = new ToolStripMenuItem();
            this.mnuFOutDataType = new ToolStripMenuItem();
            this.mnuQbEdit = new ContextMenuStrip(this.components);
            this.mnuAddChild = new ToolStripMenuItem();
            this.mnuInsertSibling = new ToolStripMenuItem();
            this.mnuAddSibling = new ToolStripMenuItem();
            this.mnuRemoveSibling = new ToolStripMenuItem();
            this.toolStripMenuItem3 = new ToolStripSeparator();
            this.mnuCopyItems = new ToolStripMenuItem();
            this.mnuPasteItems = new ToolStripMenuItem();
            this.mnuPasteAddChild = new ToolStripMenuItem();
            this.mnuPasteInsertSibling = new ToolStripMenuItem();
            this.mnuPasteAddSibling = new ToolStripMenuItem();
            this.tabs.SuspendLayout();
            this.tabPak.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitPak).BeginInit();
            this.splitPak.Panel1.SuspendLayout();
            this.splitPak.Panel2.SuspendLayout();
            this.splitPak.SuspendLayout();
            this.gboOpenPak.SuspendLayout();
            this.tabSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitSearch).BeginInit();
            this.splitSearch.Panel1.SuspendLayout();
            this.splitSearch.Panel2.SuspendLayout();
            this.splitSearch.SuspendLayout();
            this.gboNumberSearch.SuspendLayout();
            this.gboQbKeySearch.SuspendLayout();
            this.gboStringSearch.SuspendLayout();
            this.tabQb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitQb).BeginInit();
            this.splitQb.Panel1.SuspendLayout();
            this.splitQb.Panel2.SuspendLayout();
            this.splitQb.SuspendLayout();
            this.status.SuspendLayout();
            this.mnuContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.err).BeginInit();
            this.mnuSearchFilter.SuspendLayout();
            this.mnuQbEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tabs.Controls.Add(this.tabPak);
            this.tabs.Controls.Add(this.tabSearch);
            this.tabs.Controls.Add(this.tabQb);
            this.tabs.Location = new Point(0, 5);
            this.tabs.Margin = new Padding(4, 3, 4, 3);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new Size(892, 530);
            this.tabs.TabIndex = 0;
            this.tabs.Deselecting += this.tabs_Deselecting;
            // 
            // tabPak
            // 
            this.tabPak.Controls.Add(this.splitPak);
            this.tabPak.Location = new Point(4, 24);
            this.tabPak.Margin = new Padding(4, 3, 4, 3);
            this.tabPak.Name = "tabPak";
            this.tabPak.Size = new Size(884, 502);
            this.tabPak.TabIndex = 1;
            this.tabPak.Text = "PAK File";
            this.tabPak.UseVisualStyleBackColor = true;
            // 
            // splitPak
            // 
            this.splitPak.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.splitPak.Location = new Point(0, 0);
            this.splitPak.Margin = new Padding(4, 3, 4, 3);
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
            this.splitPak.Size = new Size(883, 500);
            this.splitPak.SplitterDistance = 526;
            this.splitPak.SplitterWidth = 5;
            this.splitPak.TabIndex = 0;
            this.splitPak.SplitterMoved += this.splitPak_SplitterMoved;
            // 
            // lstPakContents
            // 
            this.lstPakContents.AllowColumnReorder = true;
            this.lstPakContents.Columns.AddRange(new ColumnHeader[] { this.hdrPakFilename, this.hdrPakFullFilename, this.hdrPakPosition, this.hdrPakLength, this.hdrType });
            this.lstPakContents.Dock = DockStyle.Fill;
            this.lstPakContents.FullRowSelect = true;
            this.lstPakContents.Location = new Point(0, 0);
            this.lstPakContents.Margin = new Padding(4, 3, 4, 3);
            this.lstPakContents.MultiSelect = false;
            this.lstPakContents.Name = "lstPakContents";
            this.lstPakContents.Size = new Size(526, 500);
            this.lstPakContents.SmallImageList = this.imgList;
            this.lstPakContents.TabIndex = 0;
            this.lstPakContents.UseCompatibleStateImageBehavior = false;
            this.lstPakContents.View = View.Details;
            this.lstPakContents.ColumnClick += this.lstPakContents_ColumnClick;
            this.lstPakContents.DoubleClick += this.lstPakContents_DoubleClick;
            this.lstPakContents.KeyDown += this.lstPakContents_KeyDown;
            this.lstPakContents.MouseClick += this.lstPakContents_MouseClick;
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
            // hdrType
            // 
            this.hdrType.Text = "Type";
            // 
            // imgList
            // 
            this.imgList.ColorDepth = ColorDepth.Depth8Bit;
            this.imgList.ImageStream = (ImageListStreamer)resources.GetObject("imgList.ImageStream");
            this.imgList.TransparentColor = Color.Transparent;
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
            this.btnTestQbFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnTestQbFile.Location = new Point(13, 430);
            this.btnTestQbFile.Margin = new Padding(4, 3, 4, 3);
            this.btnTestQbFile.Name = "btnTestQbFile";
            this.btnTestQbFile.Size = new Size(88, 27);
            this.btnTestQbFile.TabIndex = 4;
            this.btnTestQbFile.Text = "Test QB File";
            this.btnTestQbFile.UseVisualStyleBackColor = true;
            this.btnTestQbFile.Visible = false;
            this.btnTestQbFile.Click += this.btnTestQbFile_Click;
            // 
            // btnTestSize
            // 
            this.btnTestSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnTestSize.Location = new Point(13, 464);
            this.btnTestSize.Margin = new Padding(4, 3, 4, 3);
            this.btnTestSize.Name = "btnTestSize";
            this.btnTestSize.Size = new Size(88, 27);
            this.btnTestSize.TabIndex = 3;
            this.btnTestSize.Text = "Test Size";
            this.btnTestSize.UseVisualStyleBackColor = true;
            this.btnTestSize.Visible = false;
            this.btnTestSize.Click += this.btnTestSize_Click;
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnInfo.Location = new Point(255, 464);
            this.btnInfo.Margin = new Padding(4, 3, 4, 3);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new Size(88, 27);
            this.btnInfo.TabIndex = 2;
            this.btnInfo.Text = "Info...";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += this.btnInfo_Click;
            this.btnInfo.MouseDown += this.btnInfo_MouseDown;
            // 
            // gboOpenPak
            // 
            this.gboOpenPak.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            this.gboOpenPak.Location = new Point(4, 9);
            this.gboOpenPak.Margin = new Padding(4, 3, 4, 3);
            this.gboOpenPak.Name = "gboOpenPak";
            this.gboOpenPak.Padding = new Padding(4, 3, 4, 3);
            this.gboOpenPak.Size = new Size(344, 185);
            this.gboOpenPak.TabIndex = 0;
            this.gboOpenPak.TabStop = false;
            this.gboOpenPak.Text = "Input Settings";
            // 
            // btnDebugFile
            // 
            this.btnDebugFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnDebugFile.Location = new Point(303, 110);
            this.btnDebugFile.Margin = new Padding(4, 3, 4, 3);
            this.btnDebugFile.Name = "btnDebugFile";
            this.btnDebugFile.Size = new Size(28, 25);
            this.btnDebugFile.TabIndex = 10;
            this.btnDebugFile.Text = "...";
            this.btnDebugFile.UseVisualStyleBackColor = true;
            this.btnDebugFile.Click += this.btnDebugFile_Click;
            // 
            // txtDebugFile
            // 
            this.txtDebugFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtDebugFile.Location = new Point(89, 111);
            this.txtDebugFile.Margin = new Padding(4, 3, 4, 3);
            this.txtDebugFile.Name = "txtDebugFile";
            this.txtDebugFile.Size = new Size(214, 23);
            this.txtDebugFile.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(14, 114);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(63, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Debug File";
            // 
            // btnPabFile
            // 
            this.btnPabFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnPabFile.Location = new Point(303, 81);
            this.btnPabFile.Margin = new Padding(4, 3, 4, 3);
            this.btnPabFile.Name = "btnPabFile";
            this.btnPabFile.Size = new Size(28, 25);
            this.btnPabFile.TabIndex = 7;
            this.btnPabFile.Text = "...";
            this.btnPabFile.UseVisualStyleBackColor = true;
            this.btnPabFile.Click += this.btnPabFile_Click;
            // 
            // txtPabFile
            // 
            this.txtPabFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtPabFile.Location = new Point(89, 82);
            this.txtPabFile.Margin = new Padding(4, 3, 4, 3);
            this.txtPabFile.Name = "txtPabFile";
            this.txtPabFile.Size = new Size(214, 23);
            this.txtPabFile.TabIndex = 6;
            // 
            // lblPabFile
            // 
            this.lblPabFile.AutoSize = true;
            this.lblPabFile.Location = new Point(14, 85);
            this.lblPabFile.Margin = new Padding(4, 0, 4, 0);
            this.lblPabFile.Name = "lblPabFile";
            this.lblPabFile.Size = new Size(49, 15);
            this.lblPabFile.TabIndex = 5;
            this.lblPabFile.Text = "PAB File";
            // 
            // lblFormatType
            // 
            this.lblFormatType.AutoSize = true;
            this.lblFormatType.Location = new Point(14, 27);
            this.lblFormatType.Margin = new Padding(4, 0, 4, 0);
            this.lblFormatType.Name = "lblFormatType";
            this.lblFormatType.Size = new Size(45, 15);
            this.lblFormatType.TabIndex = 0;
            this.lblFormatType.Text = "Format";
            // 
            // cboFormatType
            // 
            this.cboFormatType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cboFormatType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboFormatType.FormattingEnabled = true;
            this.cboFormatType.Location = new Point(89, 23);
            this.cboFormatType.Margin = new Padding(4, 3, 4, 3);
            this.cboFormatType.Name = "cboFormatType";
            this.cboFormatType.Size = new Size(242, 23);
            this.cboFormatType.TabIndex = 1;
            this.cboFormatType.SelectedIndexChanged += this.cboPakType_SelectedIndexChanged;
            // 
            // chkBackup
            // 
            this.chkBackup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.chkBackup.AutoSize = true;
            this.chkBackup.Checked = true;
            this.chkBackup.CheckState = CheckState.Checked;
            this.chkBackup.Location = new Point(172, 147);
            this.chkBackup.Margin = new Padding(4, 3, 4, 3);
            this.chkBackup.Name = "chkBackup";
            this.chkBackup.Size = new Size(65, 19);
            this.chkBackup.TabIndex = 11;
            this.chkBackup.Text = "Backup";
            this.chkBackup.UseVisualStyleBackColor = true;
            // 
            // btnLoadPak
            // 
            this.btnLoadPak.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnLoadPak.Location = new Point(244, 142);
            this.btnLoadPak.Margin = new Padding(4, 3, 4, 3);
            this.btnLoadPak.Name = "btnLoadPak";
            this.btnLoadPak.Size = new Size(88, 27);
            this.btnLoadPak.TabIndex = 12;
            this.btnLoadPak.Text = "Load";
            this.btnLoadPak.UseVisualStyleBackColor = true;
            this.btnLoadPak.Click += this.btnLoadPak_Click;
            // 
            // btnPakFile
            // 
            this.btnPakFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnPakFile.Location = new Point(303, 52);
            this.btnPakFile.Margin = new Padding(4, 3, 4, 3);
            this.btnPakFile.Name = "btnPakFile";
            this.btnPakFile.Size = new Size(28, 25);
            this.btnPakFile.TabIndex = 4;
            this.btnPakFile.Text = "...";
            this.btnPakFile.UseVisualStyleBackColor = true;
            this.btnPakFile.Click += this.btnPakFile_Click;
            // 
            // txtPakFile
            // 
            this.txtPakFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtPakFile.Location = new Point(89, 53);
            this.txtPakFile.Margin = new Padding(4, 3, 4, 3);
            this.txtPakFile.Name = "txtPakFile";
            this.txtPakFile.Size = new Size(214, 23);
            this.txtPakFile.TabIndex = 3;
            // 
            // lblPakFile
            // 
            this.lblPakFile.AutoSize = true;
            this.lblPakFile.Location = new Point(14, 57);
            this.lblPakFile.Margin = new Padding(4, 0, 4, 0);
            this.lblPakFile.Name = "lblPakFile";
            this.lblPakFile.Size = new Size(49, 15);
            this.lblPakFile.TabIndex = 2;
            this.lblPakFile.Text = "PAK File";
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.splitSearch);
            this.tabSearch.Location = new Point(4, 24);
            this.tabSearch.Margin = new Padding(4, 3, 4, 3);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new Size(884, 502);
            this.tabSearch.TabIndex = 2;
            this.tabSearch.Text = "QB Item Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // splitSearch
            // 
            this.splitSearch.Dock = DockStyle.Fill;
            this.splitSearch.Location = new Point(0, 0);
            this.splitSearch.Margin = new Padding(4, 3, 4, 3);
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
            this.splitSearch.Size = new Size(884, 502);
            this.splitSearch.SplitterDistance = 347;
            this.splitSearch.SplitterWidth = 5;
            this.splitSearch.TabIndex = 0;
            this.splitSearch.SplitterMoved += this.splitSearch_SplitterMoved;
            // 
            // gboNumberSearch
            // 
            this.gboNumberSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.gboNumberSearch.Controls.Add(this.label2);
            this.gboNumberSearch.Controls.Add(this.btnNumberSearch);
            this.gboNumberSearch.Controls.Add(this.txtNumberSearch);
            this.gboNumberSearch.Controls.Add(this.lblNumberSearch);
            this.gboNumberSearch.Location = new Point(1, 234);
            this.gboNumberSearch.Margin = new Padding(4, 3, 4, 3);
            this.gboNumberSearch.Name = "gboNumberSearch";
            this.gboNumberSearch.Padding = new Padding(4, 3, 4, 3);
            this.gboNumberSearch.Size = new Size(343, 88);
            this.gboNumberSearch.TabIndex = 2;
            this.gboNumberSearch.TabStop = false;
            this.gboNumberSearch.Text = "Number Search";
            // 
            // label2
            // 
            this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(42, 58);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(183, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Example: 10 (all) or 10.0 (decimal)";
            // 
            // btnNumberSearch
            // 
            this.btnNumberSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnNumberSearch.Location = new Point(242, 52);
            this.btnNumberSearch.Margin = new Padding(4, 3, 4, 3);
            this.btnNumberSearch.Name = "btnNumberSearch";
            this.btnNumberSearch.Size = new Size(74, 25);
            this.btnNumberSearch.TabIndex = 2;
            this.btnNumberSearch.Text = "Search";
            this.btnNumberSearch.UseVisualStyleBackColor = true;
            this.btnNumberSearch.Click += this.btnNumberSearch_Click;
            // 
            // txtNumberSearch
            // 
            this.txtNumberSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtNumberSearch.Location = new Point(51, 22);
            this.txtNumberSearch.Margin = new Padding(4, 3, 4, 3);
            this.txtNumberSearch.Name = "txtNumberSearch";
            this.txtNumberSearch.Size = new Size(263, 23);
            this.txtNumberSearch.TabIndex = 1;
            this.txtNumberSearch.KeyDown += this.txtNumberSearch_KeyDown;
            this.txtNumberSearch.Validating += this.txtNumberSearch_Validating;
            // 
            // lblNumberSearch
            // 
            this.lblNumberSearch.AutoSize = true;
            this.lblNumberSearch.Location = new Point(7, 25);
            this.lblNumberSearch.Margin = new Padding(4, 0, 4, 0);
            this.lblNumberSearch.Name = "lblNumberSearch";
            this.lblNumberSearch.Size = new Size(26, 15);
            this.lblNumberSearch.TabIndex = 0;
            this.lblNumberSearch.Text = "No.";
            // 
            // gboQbKeySearch
            // 
            this.gboQbKeySearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.gboQbKeySearch.Controls.Add(this.lblQbKeyText);
            this.gboQbKeySearch.Controls.Add(this.btnQbKeySearch);
            this.gboQbKeySearch.Controls.Add(this.txtQbKeySearch);
            this.gboQbKeySearch.Controls.Add(this.lblQbKeySearch);
            this.gboQbKeySearch.Location = new Point(4, 119);
            this.gboQbKeySearch.Margin = new Padding(4, 3, 4, 3);
            this.gboQbKeySearch.Name = "gboQbKeySearch";
            this.gboQbKeySearch.Padding = new Padding(4, 3, 4, 3);
            this.gboQbKeySearch.Size = new Size(343, 88);
            this.gboQbKeySearch.TabIndex = 1;
            this.gboQbKeySearch.TabStop = false;
            this.gboQbKeySearch.Text = "QB Key Search";
            // 
            // lblQbKeyText
            // 
            this.lblQbKeyText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblQbKeyText.AutoSize = true;
            this.lblQbKeyText.Location = new Point(84, 58);
            this.lblQbKeyText.Margin = new Padding(4, 0, 4, 0);
            this.lblQbKeyText.Name = "lblQbKeyText";
            this.lblQbKeyText.Size = new Size(136, 15);
            this.lblQbKeyText.TabIndex = 3;
            this.lblQbKeyText.Text = "Enter Hex QB Key or Text";
            // 
            // btnQbKeySearch
            // 
            this.btnQbKeySearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnQbKeySearch.Location = new Point(242, 52);
            this.btnQbKeySearch.Margin = new Padding(4, 3, 4, 3);
            this.btnQbKeySearch.Name = "btnQbKeySearch";
            this.btnQbKeySearch.Size = new Size(74, 25);
            this.btnQbKeySearch.TabIndex = 2;
            this.btnQbKeySearch.Text = "Search";
            this.btnQbKeySearch.UseVisualStyleBackColor = true;
            this.btnQbKeySearch.Click += this.btnQbKeySearch_Click;
            // 
            // txtQbKeySearch
            // 
            this.txtQbKeySearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtQbKeySearch.Location = new Point(51, 22);
            this.txtQbKeySearch.Margin = new Padding(4, 3, 4, 3);
            this.txtQbKeySearch.Name = "txtQbKeySearch";
            this.txtQbKeySearch.Size = new Size(263, 23);
            this.txtQbKeySearch.TabIndex = 1;
            this.txtQbKeySearch.KeyDown += this.txtQbKeySearch_KeyDown;
            this.txtQbKeySearch.Validating += this.txtQbKeySearch_Validating;
            // 
            // lblQbKeySearch
            // 
            this.lblQbKeySearch.AutoSize = true;
            this.lblQbKeySearch.Location = new Point(7, 25);
            this.lblQbKeySearch.Margin = new Padding(4, 0, 4, 0);
            this.lblQbKeySearch.Name = "lblQbKeySearch";
            this.lblQbKeySearch.Size = new Size(38, 15);
            this.lblQbKeySearch.TabIndex = 0;
            this.lblQbKeySearch.Text = "String";
            // 
            // gboStringSearch
            // 
            this.gboStringSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.gboStringSearch.Controls.Add(this.lblStringBlank);
            this.gboStringSearch.Controls.Add(this.btnStringSearch);
            this.gboStringSearch.Controls.Add(this.txtStringSearch);
            this.gboStringSearch.Controls.Add(this.lblStringSearch);
            this.gboStringSearch.Location = new Point(4, 3);
            this.gboStringSearch.Margin = new Padding(4, 3, 4, 3);
            this.gboStringSearch.Name = "gboStringSearch";
            this.gboStringSearch.Padding = new Padding(4, 3, 4, 3);
            this.gboStringSearch.Size = new Size(343, 88);
            this.gboStringSearch.TabIndex = 0;
            this.gboStringSearch.TabStop = false;
            this.gboStringSearch.Text = "String Search";
            // 
            // lblStringBlank
            // 
            this.lblStringBlank.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblStringBlank.AutoSize = true;
            this.lblStringBlank.Location = new Point(98, 58);
            this.lblStringBlank.Margin = new Padding(4, 0, 4, 0);
            this.lblStringBlank.Name = "lblStringBlank";
            this.lblStringBlank.Size = new Size(134, 15);
            this.lblStringBlank.TabIndex = 2;
            this.lblStringBlank.Text = "Blank will find all strings";
            // 
            // btnStringSearch
            // 
            this.btnStringSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnStringSearch.Location = new Point(242, 52);
            this.btnStringSearch.Margin = new Padding(4, 3, 4, 3);
            this.btnStringSearch.Name = "btnStringSearch";
            this.btnStringSearch.Size = new Size(74, 25);
            this.btnStringSearch.TabIndex = 3;
            this.btnStringSearch.Text = "Search";
            this.btnStringSearch.UseVisualStyleBackColor = true;
            this.btnStringSearch.Click += this.btnStringSearch_Click;
            // 
            // txtStringSearch
            // 
            this.txtStringSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.err.SetIconPadding(this.txtStringSearch, 4);
            this.txtStringSearch.Location = new Point(51, 22);
            this.txtStringSearch.Margin = new Padding(4, 3, 4, 3);
            this.txtStringSearch.Name = "txtStringSearch";
            this.txtStringSearch.Size = new Size(263, 23);
            this.txtStringSearch.TabIndex = 1;
            this.txtStringSearch.KeyDown += this.txtStringSearch_KeyDown;
            // 
            // lblStringSearch
            // 
            this.lblStringSearch.AutoSize = true;
            this.lblStringSearch.Location = new Point(7, 25);
            this.lblStringSearch.Margin = new Padding(4, 0, 4, 0);
            this.lblStringSearch.Name = "lblStringSearch";
            this.lblStringSearch.Size = new Size(38, 15);
            this.lblStringSearch.TabIndex = 0;
            this.lblStringSearch.Text = "String";
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.Activation = ItemActivation.OneClick;
            this.lstSearchResults.AllowColumnReorder = true;
            this.lstSearchResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.lstSearchResults.Columns.AddRange(new ColumnHeader[] { this.hdrSearchItem, this.hdrSearchFile, this.hdrSearchPos, this.hdrSearchType });
            this.lstSearchResults.FullRowSelect = true;
            this.lstSearchResults.Location = new Point(0, 0);
            this.lstSearchResults.Margin = new Padding(4, 3, 4, 3);
            this.lstSearchResults.MultiSelect = false;
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new Size(531, 501);
            this.lstSearchResults.SmallImageList = this.imgList;
            this.lstSearchResults.TabIndex = 0;
            this.lstSearchResults.UseCompatibleStateImageBehavior = false;
            this.lstSearchResults.View = View.Details;
            this.lstSearchResults.ColumnClick += this.lstSearchResults_ColumnClick;
            this.lstSearchResults.DoubleClick += this.lstSearchResults_DoubleClick;
            this.lstSearchResults.MouseClick += this.lstSearchResults_MouseClick;
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
            this.tabQb.Location = new Point(4, 24);
            this.tabQb.Margin = new Padding(4, 3, 4, 3);
            this.tabQb.Name = "tabQb";
            this.tabQb.Padding = new Padding(4, 3, 4, 3);
            this.tabQb.Size = new Size(884, 502);
            this.tabQb.TabIndex = 0;
            this.tabQb.Text = "QB File";
            this.tabQb.UseVisualStyleBackColor = true;
            // 
            // splitQb
            // 
            this.splitQb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.splitQb.Location = new Point(0, 0);
            this.splitQb.Margin = new Padding(0);
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
            this.splitQb.Size = new Size(883, 500);
            this.splitQb.SplitterDistance = 551;
            this.splitQb.SplitterWidth = 5;
            this.splitQb.TabIndex = 0;
            this.splitQb.SplitterMoved += this.splitQb_SplitterMoved;
            // 
            // lstQbItems
            // 
            this.lstQbItems.AllowColumnReorder = true;
            this.lstQbItems.Columns.AddRange(new ColumnHeader[] { this.hdrItem, this.hdrDebugName, this.hdrValue, this.hdrPosition, this.hdrLength, this.hdrDataType });
            this.lstQbItems.Dock = DockStyle.Fill;
            this.lstQbItems.FullRowSelect = true;
            this.lstQbItems.Location = new Point(0, 0);
            this.lstQbItems.Margin = new Padding(4, 3, 4, 3);
            this.lstQbItems.MultiSelect = false;
            this.lstQbItems.Name = "lstQbItems";
            this.lstQbItems.Size = new Size(551, 500);
            this.lstQbItems.SmallImageList = this.imgList;
            this.lstQbItems.TabIndex = 0;
            this.lstQbItems.UseCompatibleStateImageBehavior = false;
            this.lstQbItems.View = View.Details;
            this.lstQbItems.ItemSelectionChanged += this.lstItems_ItemSelectionChanged;
            this.lstQbItems.MouseUp += this.lstQbItems_MouseUp;
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
            this.gboEdit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.gboEdit.Location = new Point(2, 0);
            this.gboEdit.Margin = new Padding(4, 3, 4, 3);
            this.gboEdit.Name = "gboEdit";
            this.gboEdit.Padding = new Padding(4, 3, 4, 3);
            this.gboEdit.Size = new Size(321, 458);
            this.gboEdit.TabIndex = 0;
            this.gboEdit.TabStop = false;
            this.gboEdit.Text = "Edit Items";
            // 
            // btnSavePak
            // 
            this.btnSavePak.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnSavePak.Enabled = false;
            this.btnSavePak.Location = new Point(222, 465);
            this.btnSavePak.Margin = new Padding(4, 3, 4, 3);
            this.btnSavePak.Name = "btnSavePak";
            this.btnSavePak.Size = new Size(98, 27);
            this.btnSavePak.TabIndex = 1;
            this.btnSavePak.Text = "Save to Disk";
            this.btnSavePak.UseVisualStyleBackColor = true;
            this.btnSavePak.Click += this.btnSavePak_Click;
            // 
            // status
            // 
            this.status.Items.AddRange(new ToolStripItem[] { this.tlblPakFileInfo, this.tlblQbFileInfo, this.tlblLink });
            this.status.Location = new Point(0, 541);
            this.status.Name = "status";
            this.status.Padding = new Padding(1, 0, 16, 0);
            this.status.Size = new Size(892, 22);
            this.status.TabIndex = 1;
            // 
            // tlblPakFileInfo
            // 
            this.tlblPakFileInfo.Name = "tlblPakFileInfo";
            this.tlblPakFileInfo.Size = new Size(0, 17);
            // 
            // tlblQbFileInfo
            // 
            this.tlblQbFileInfo.Name = "tlblQbFileInfo";
            this.tlblQbFileInfo.Size = new Size(0, 17);
            // 
            // tlblLink
            // 
            this.tlblLink.IsLink = true;
            this.tlblLink.Name = "tlblLink";
            this.tlblLink.Size = new Size(875, 17);
            this.tlblLink.Spring = true;
            this.tlblLink.Tag = "https://github.com/Nanook/Queen-Bee";
            this.tlblLink.Text = "Code";
            this.tlblLink.TextAlign = ContentAlignment.MiddleRight;
            this.tlblLink.Click += this.tlblLink_Click;
            // 
            // mnuContext
            // 
            this.mnuContext.Items.AddRange(new ToolStripItem[] { this.mnuReplaceFile, this.mnuExtractFile, this.mnuExtractAll, this.toolStripMenuItem1, this.mnuNewFile, this.mnuAddFile, this.mnuRenameFile, this.mnuRemoveFile, this.toolStripMenuItem4, this.mnuEditQBFile, this.mnuTestAllQbFiles });
            this.mnuContext.Name = "mnuContext";
            this.mnuContext.Size = new Size(158, 214);
            // 
            // mnuReplaceFile
            // 
            this.mnuReplaceFile.Name = "mnuReplaceFile";
            this.mnuReplaceFile.Size = new Size(157, 22);
            this.mnuReplaceFile.Text = "Replace File...";
            this.mnuReplaceFile.Click += this.mnuReplaceFile_Click;
            // 
            // mnuExtractFile
            // 
            this.mnuExtractFile.Name = "mnuExtractFile";
            this.mnuExtractFile.Size = new Size(157, 22);
            this.mnuExtractFile.Text = "Extract File...";
            this.mnuExtractFile.Click += this.mnuExtractFile_Click;
            // 
            // mnuExtractAll
            // 
            this.mnuExtractAll.Name = "mnuExtractAll";
            this.mnuExtractAll.Size = new Size(157, 22);
            this.mnuExtractAll.Text = "Extract All...";
            this.mnuExtractAll.Click += this.mnuExtractAll_Click;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(154, 6);
            // 
            // mnuNewFile
            // 
            this.mnuNewFile.Name = "mnuNewFile";
            this.mnuNewFile.Size = new Size(157, 22);
            this.mnuNewFile.Text = "New File...";
            this.mnuNewFile.Click += this.mnuNewFile_Click;
            // 
            // mnuAddFile
            // 
            this.mnuAddFile.Name = "mnuAddFile";
            this.mnuAddFile.Size = new Size(157, 22);
            this.mnuAddFile.Text = "Add File...";
            this.mnuAddFile.Click += this.mnuAddFile_Click;
            // 
            // mnuRenameFile
            // 
            this.mnuRenameFile.Name = "mnuRenameFile";
            this.mnuRenameFile.Size = new Size(157, 22);
            this.mnuRenameFile.Text = "Rename File...";
            this.mnuRenameFile.Click += this.mnuRenameFile_Click;
            // 
            // mnuRemoveFile
            // 
            this.mnuRemoveFile.Name = "mnuRemoveFile";
            this.mnuRemoveFile.Size = new Size(157, 22);
            this.mnuRemoveFile.Text = "Remove File";
            this.mnuRemoveFile.Click += this.mnuRemoveFile_Click;
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new Size(154, 6);
            // 
            // mnuEditQBFile
            // 
            this.mnuEditQBFile.Name = "mnuEditQBFile";
            this.mnuEditQBFile.Size = new Size(157, 22);
            this.mnuEditQBFile.Text = "Edit QB File";
            this.mnuEditQBFile.Click += this.mnuEditQBFile_Click;
            // 
            // mnuTestAllQbFiles
            // 
            this.mnuTestAllQbFiles.Name = "mnuTestAllQbFiles";
            this.mnuTestAllQbFiles.Size = new Size(157, 22);
            this.mnuTestAllQbFiles.Text = "Test All QB Files";
            this.mnuTestAllQbFiles.Click += this.mnuTestAllQbFiles_Click;
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
            this.mnuSearchFilter.Items.AddRange(new ToolStripItem[] { this.filterOnToolStripMenuItem, this.mnuFOnItem, this.mnuFOnFilename, this.mnuFOnDataType, this.toolStripMenuItem2, this.filterOutToolStripMenuItem, this.mnuFOutItem, this.mnuFOutFilename, this.mnuFOutDataType });
            this.mnuSearchFilter.Name = "mnuSearchFilter";
            this.mnuSearchFilter.Size = new Size(164, 186);
            // 
            // filterOnToolStripMenuItem
            // 
            this.filterOnToolStripMenuItem.Enabled = false;
            this.filterOnToolStripMenuItem.Font = new Font("Tahoma", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            this.filterOnToolStripMenuItem.Name = "filterOnToolStripMenuItem";
            this.filterOnToolStripMenuItem.Size = new Size(163, 22);
            this.filterOnToolStripMenuItem.Text = "Filter On";
            // 
            // mnuFOnItem
            // 
            this.mnuFOnItem.Name = "mnuFOnItem";
            this.mnuFOnItem.Size = new Size(163, 22);
            this.mnuFOnItem.Text = "Item";
            this.mnuFOnItem.Click += this.mnuSearchFilter_Click;
            // 
            // mnuFOnFilename
            // 
            this.mnuFOnFilename.Name = "mnuFOnFilename";
            this.mnuFOnFilename.Size = new Size(163, 22);
            this.mnuFOnFilename.Text = "QB Full Filename";
            this.mnuFOnFilename.Click += this.mnuSearchFilter_Click;
            // 
            // mnuFOnDataType
            // 
            this.mnuFOnDataType.Name = "mnuFOnDataType";
            this.mnuFOnDataType.Size = new Size(163, 22);
            this.mnuFOnDataType.Text = "Type";
            this.mnuFOnDataType.Click += this.mnuSearchFilter_Click;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(160, 6);
            // 
            // filterOutToolStripMenuItem
            // 
            this.filterOutToolStripMenuItem.Enabled = false;
            this.filterOutToolStripMenuItem.Font = new Font("Tahoma", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            this.filterOutToolStripMenuItem.Name = "filterOutToolStripMenuItem";
            this.filterOutToolStripMenuItem.Size = new Size(163, 22);
            this.filterOutToolStripMenuItem.Text = "Filter Out";
            // 
            // mnuFOutItem
            // 
            this.mnuFOutItem.Name = "mnuFOutItem";
            this.mnuFOutItem.Size = new Size(163, 22);
            this.mnuFOutItem.Text = "Item";
            this.mnuFOutItem.Click += this.mnuSearchFilter_Click;
            // 
            // mnuFOutFilename
            // 
            this.mnuFOutFilename.Name = "mnuFOutFilename";
            this.mnuFOutFilename.Size = new Size(163, 22);
            this.mnuFOutFilename.Text = "QB Full Filename";
            this.mnuFOutFilename.Click += this.mnuSearchFilter_Click;
            // 
            // mnuFOutDataType
            // 
            this.mnuFOutDataType.Name = "mnuFOutDataType";
            this.mnuFOutDataType.Size = new Size(163, 22);
            this.mnuFOutDataType.Text = "Type";
            this.mnuFOutDataType.Click += this.mnuSearchFilter_Click;
            // 
            // mnuQbEdit
            // 
            this.mnuQbEdit.Items.AddRange(new ToolStripItem[] { this.mnuAddChild, this.mnuInsertSibling, this.mnuAddSibling, this.mnuRemoveSibling, this.toolStripMenuItem3, this.mnuCopyItems, this.mnuPasteItems });
            this.mnuQbEdit.Name = "mnuQbEdit";
            this.mnuQbEdit.Size = new Size(143, 142);
            // 
            // mnuAddChild
            // 
            this.mnuAddChild.Name = "mnuAddChild";
            this.mnuAddChild.Size = new Size(142, 22);
            this.mnuAddChild.Text = "Add Child";
            // 
            // mnuInsertSibling
            // 
            this.mnuInsertSibling.Name = "mnuInsertSibling";
            this.mnuInsertSibling.Size = new Size(142, 22);
            this.mnuInsertSibling.Text = "Insert Sibling";
            // 
            // mnuAddSibling
            // 
            this.mnuAddSibling.Name = "mnuAddSibling";
            this.mnuAddSibling.Size = new Size(142, 22);
            this.mnuAddSibling.Text = "Add Sibling";
            // 
            // mnuRemoveSibling
            // 
            this.mnuRemoveSibling.Name = "mnuRemoveSibling";
            this.mnuRemoveSibling.Size = new Size(142, 22);
            this.mnuRemoveSibling.Text = "Remove";
            this.mnuRemoveSibling.Click += this.qbRemoveItem;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new Size(139, 6);
            // 
            // mnuCopyItems
            // 
            this.mnuCopyItems.Name = "mnuCopyItems";
            this.mnuCopyItems.Size = new Size(142, 22);
            this.mnuCopyItems.Text = "Copy";
            this.mnuCopyItems.Click += this.mnuCopyItems_Click;
            // 
            // mnuPasteItems
            // 
            this.mnuPasteItems.DropDownItems.AddRange(new ToolStripItem[] { this.mnuPasteAddChild, this.mnuPasteInsertSibling, this.mnuPasteAddSibling });
            this.mnuPasteItems.Name = "mnuPasteItems";
            this.mnuPasteItems.Size = new Size(142, 22);
            this.mnuPasteItems.Text = "Paste";
            // 
            // mnuPasteAddChild
            // 
            this.mnuPasteAddChild.Name = "mnuPasteAddChild";
            this.mnuPasteAddChild.Size = new Size(142, 22);
            this.mnuPasteAddChild.Text = "Add Child";
            this.mnuPasteAddChild.Click += this.mnuPasteAddChild_Click;
            // 
            // mnuPasteInsertSibling
            // 
            this.mnuPasteInsertSibling.Name = "mnuPasteInsertSibling";
            this.mnuPasteInsertSibling.Size = new Size(142, 22);
            this.mnuPasteInsertSibling.Text = "Insert Sibling";
            this.mnuPasteInsertSibling.Click += this.mnuPasteInsertSibling_Click;
            // 
            // mnuPasteAddSibling
            // 
            this.mnuPasteAddSibling.Name = "mnuPasteAddSibling";
            this.mnuPasteAddSibling.Size = new Size(142, 22);
            this.mnuPasteAddSibling.Text = "Add Sibling";
            this.mnuPasteAddSibling.Click += this.mnuPasteAddSibling_Click;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(892, 563);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tabs);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(4, 3, 4, 3);
            this.Name = "EditorForm";
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Queen Bee (PAK / QB Explorer, Editor)";
            this.ResizeEnd += this.editorForm_Resize_Move;
            this.SizeChanged += this.editorForm_Resize_Move;
            this.Move += this.editorForm_Resize_Move;
            this.tabs.ResumeLayout(false);
            this.tabPak.ResumeLayout(false);
            this.splitPak.Panel1.ResumeLayout(false);
            this.splitPak.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitPak).EndInit();
            this.splitPak.ResumeLayout(false);
            this.gboOpenPak.ResumeLayout(false);
            this.gboOpenPak.PerformLayout();
            this.tabSearch.ResumeLayout(false);
            this.splitSearch.Panel1.ResumeLayout(false);
            this.splitSearch.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitSearch).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)this.splitQb).EndInit();
            this.splitQb.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.mnuContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.err).EndInit();
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