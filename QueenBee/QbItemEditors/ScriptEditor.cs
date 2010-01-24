using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Nanook.QueenBee.Parser;

namespace Nanook.QueenBee
{
    internal class ScriptEditor : QbItemEditorBase
    {
        private System.Windows.Forms.Button btnUpdate;
        private GenericQbEditItem eiItemQbKey;
        private GenericQbEditItem eiUnknown;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabString;
        private System.Windows.Forms.TabPage tabUncompressedScript;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.ErrorProvider err;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.TextBox txtWarning;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog export;
        private System.Windows.Forms.OpenFileDialog import;
        private System.Windows.Forms.TextBox txtScript;
    
        public ScriptEditor() : base()
        {
            InitializeComponent();
        }

        private void ScriptEditor_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            try
            {
                _qbItem = (base.QbItem as QbItemScript);
                if (_qbItem == null)
                    throw new Exception("Error");

                eiItemQbKey.SetData(new GenericQbItem("Item QB Key", _qbItem.ItemQbKey, typeof(string), false, false, QbItemType.SectionScript, "ItemQbKey"));
                eiUnknown.SetData(new GenericQbItem("Unknown", _qbItem.Unknown, typeof(byte[]), false, false, QbItemType.SectionScript, "Unknown"));

                int w = (eiItemQbKey.LabelWidth > eiUnknown.LabelWidth ? eiItemQbKey.LabelWidth : eiUnknown.LabelWidth) + 6;
                eiItemQbKey.TextBoxLeft = w;
                eiUnknown.TextBoxLeft = w;

                txtScript.Text = bytesToHexAsciiString(_qbItem.ScriptData);

                _preventUpdate = false;

                loadStringList();
            }
            catch (Exception ex)
            {
                base.ShowException("Script Load Item Error", ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                GenericQbEditItem ei;
                foreach (Control un in this.Controls)
                {
                    if ((ei = (un as GenericQbEditItem)) != null)
                    {
                        if (!ei.IsValid)
                        {
                            base.ShowError("Error", "QB cannot be updated while data is invalid.");
                            return;
                        }
                    }
                }

                _qbItem.ItemQbKey = eiItemQbKey.GenericQbItem.ToQbKey();
                _qbItem.Unknown = eiUnknown.GenericQbItem.ToUInt32();

                byte[] script = _qbItem.ScriptData;
                for (int i = 0; i < lstItems.Items.Count; i++)
                    _qbItem.Strings[i].Text = (string)lstItems.Items[i];

                _qbItem.UpdateStrings();

                //if QbKey, check to see if it's in the debug file, if not then add it to the user defined list
                base.AddQbKeyToUserDebugFile(base.QbItem.ItemQbKey);

                loadStringList();
                txtScript.Text = bytesToHexAsciiString(_qbItem.ScriptData);

                base.UpdateQbItem();
            }
            catch (Exception ex)
            {
                base.ShowException("Script Update Item Error", ex);
            }
        }

        private string bytesToHexAsciiString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            //char[] ch = new char[cl];

            for (int i = 0; i < bytes.Length; i++)
            {

                sb.Append(bytes[i].ToString("X").PadLeft(2, '0'));
                sb.Append(" ");

                if (i % _cl == _cl - 1)
                {
                    sb.Append(": ");
                    for (int j = i - (_cl - 1); j <= i; j++)
                        sb.Append(byteToPrintableChar(bytes[j]));
                    sb.Append(Environment.NewLine);
                }
            }


            if (bytes.Length % _cl != 0)
            {
                for (int i = 0; i < _cl - (bytes.Length % _cl); i++)
                    sb.Append("   ");

                sb.Append(": ");

                for (int j = bytes.Length - (bytes.Length % _cl); j < bytes.Length; j++)
                    sb.Append(byteToPrintableChar(bytes[j]));

                for (int i = 0; i < _cl - (bytes.Length % _cl); i++)
                    sb.Append(" ");

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        private char byteToPrintableChar(byte b)
        {
            char c = (char)b;
            //if (b != 0x09 && (Char.IsSymbol(c) || Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c) || Char.IsPunctuation(c)))
            if (b != 0x09 && !Char.IsControl(c))
                return c;
            else
                return '.';
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clearError();
                refreshEditValue(getSelectedItem());
            }
            catch (Exception ex)
            {
                base.ShowException("Script Select Item Error", ex);
            }
        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
                btnSet_Click(this, new EventArgs());
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                string errMsg = GenericQbItem.ValidateText(typeof(string), typeof(string), txtItem.Text);
                if (errMsg.Length != 0)
                    err.SetError(txtItem, errMsg);
                else
                {
                    try
                    {
                        lstItems.BeginUpdate();
                        int idx = getSelectedItem();
                        _preventUpdate = true;
                        lstItems.Items[idx] = ""; //force item to update, if only case has changed it won't update
                        lstItems.Items[idx] = txtItem.Text;

                    }
                    finally
                    {
                        _preventUpdate = false;
                        lstItems.EndUpdate();
                    }
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Script Set Item Error", ex);
            }
        }

        private int getSelectedItem()
        {
            int idx = lstItems.SelectedIndex;
            if (idx == -1)
                idx = 0;

            return idx;
        }
        
        private void refreshEditValue(int index)
        {
            if (!_preventUpdate && index != -1)
            {
                txtItem.MaxLength = _qbItem.Strings[index].Length;
                txtItem.Text = (string)lstItems.Items[index];

            }
        }

        private void clearError()
        {
            err.SetError(txtItem, string.Empty);
        }

        private void loadStringList()
        {
            txtItem.Text = string.Empty;
            lstItems.Items.Clear();
            foreach (ScriptString ss in _qbItem.Strings)
                lstItems.Items.Add(ss.Text);

            bool hasStrings = (lstItems.Items.Count != 0);
            if (hasStrings)
                lstItems.SelectedIndex = 0;

            lstItems.Enabled = hasStrings;
            txtItem.Enabled = hasStrings;
            btnSet.Enabled = hasStrings;


        }

        private string getBestFullFilename(string fullFilename)
        {
            if (fullFilename == null)
                return string.Empty;
            else if (fullFilename.Trim().Length == 0)
                return string.Empty;

            string pth = fullFilename;
            FileInfo fi = new FileInfo(pth);
            if (!fi.Exists)
            {
                DirectoryInfo di = fi.Directory;
                while (!di.Exists)
                {
                    di = di.Parent;
                    if (di == null)
                        break;
                }
                if (di != null)
                    pth = di.FullName;
                else
                    pth = string.Empty;

                pth = Path.Combine(pth, fi.Name);
            }
            return pth;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = string.Format("{0}_{1}.{2}", _qbItem.Root.Filename.Replace('\\', '#').Replace('/', '#').Replace('.', '#'), _qbItem.ItemQbKey.Crc.ToString("X").PadLeft(8, '0'), _fileExt);

                if (AppState.LastScriptPath.Length == 0)
                    fname = Path.Combine(AppState.LastScriptPath, fname);

                fname = getBestFullFilename(fname);

                export.Filter = string.Format("{0} (*.{0})|*.{0}|All files (*.*)|*.*", _fileExt);
                export.Title = string.Format("Export {0} file", _fileExt);
                export.OverwritePrompt = true;
                export.FileName = fname;

                if (export.ShowDialog(this) != DialogResult.Cancel)
                {
                    fname = export.FileName;
                    if (File.Exists(fname))
                        File.Delete(fname);

                    AppState.LastScriptPath = (new FileInfo(fname)).DirectoryName;

                    File.WriteAllBytes(fname, _qbItem.ScriptData);
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Script Export Error", ex);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = string.Format("{0}_{1}.{2}", _qbItem.Root.Filename.Replace('\\', '#').Replace('/', '#').Replace('.', '#'), _qbItem.ItemQbKey.Crc.ToString("X").PadLeft(8, '0'), _fileExt);

                if (AppState.LastScriptPath.Length == 0)
                    fname = Path.Combine(AppState.LastScriptPath, fname);

                fname = getBestFullFilename(fname);


                import.Filter = string.Format("{0} (*.{0})|*.{0}|All files (*.*)|*.*", _fileExt);
                import.Title = string.Format("Import {0} file", _fileExt);
                import.CheckFileExists = true;
                import.CheckPathExists = true;
                import.FileName = fname;

                if (import.ShowDialog(this) != DialogResult.Cancel)
                {
                    fname = import.FileName;
                    _qbItem.ScriptData = File.ReadAllBytes(fname);
                    txtScript.Text = bytesToHexAsciiString(_qbItem.ScriptData);

                    AppState.LastScriptPath = (new FileInfo(fname)).DirectoryName;

                    loadStringList();
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Script Import Error", ex);
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AppState.ScriptActiveTab = tabs.SelectedIndex;
            }
            catch (Exception ex)
            {
                base.ShowException("Script Tab Select Error", ex);
            }
        }

        public int SelectedTabIndex
        {
            get { return tabs.SelectedIndex; }
            set { tabs.SelectedIndex = value; }
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptEditor));
            this.txtScript = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.eiItemQbKey = new Nanook.QueenBee.GenericQbEditItem();
            this.eiUnknown = new Nanook.QueenBee.GenericQbEditItem();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabString = new System.Windows.Forms.TabPage();
            this.txtWarning = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.tabUncompressedScript = new System.Windows.Forms.TabPage();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.export = new System.Windows.Forms.SaveFileDialog();
            this.import = new System.Windows.Forms.OpenFileDialog();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabString.SuspendLayout();
            this.tabUncompressedScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScript
            // 
            this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScript.BackColor = System.Drawing.SystemColors.Window;
            this.txtScript.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScript.HideSelection = false;
            this.txtScript.Location = new System.Drawing.Point(0, 1);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ReadOnly = true;
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScript.Size = new System.Drawing.Size(303, 336);
            this.txtScript.TabIndex = 0;
            this.txtScript.WordWrap = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(240, 431);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // eiItemQbKey
            // 
            this.eiItemQbKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eiItemQbKey.Location = new System.Drawing.Point(-4, 9);
            this.eiItemQbKey.Name = "eiItemQbKey";
            this.eiItemQbKey.Size = new System.Drawing.Size(322, 24);
            this.eiItemQbKey.TabIndex = 0;
            this.eiItemQbKey.TextBoxLeft = 66;
            // 
            // eiUnknown
            // 
            this.eiUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eiUnknown.Location = new System.Drawing.Point(-4, 32);
            this.eiUnknown.Name = "eiUnknown";
            this.eiUnknown.Size = new System.Drawing.Size(322, 24);
            this.eiUnknown.TabIndex = 1;
            this.eiUnknown.TextBoxLeft = 66;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabString);
            this.tabs.Controls.Add(this.tabUncompressedScript);
            this.tabs.Location = new System.Drawing.Point(3, 62);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(312, 363);
            this.tabs.TabIndex = 2;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // tabString
            // 
            this.tabString.Controls.Add(this.txtWarning);
            this.tabString.Controls.Add(this.btnSet);
            this.tabString.Controls.Add(this.txtItem);
            this.tabString.Controls.Add(this.lstItems);
            this.tabString.Location = new System.Drawing.Point(4, 22);
            this.tabString.Name = "tabString";
            this.tabString.Padding = new System.Windows.Forms.Padding(3);
            this.tabString.Size = new System.Drawing.Size(304, 337);
            this.tabString.TabIndex = 0;
            this.tabString.Text = "Strings";
            this.tabString.UseVisualStyleBackColor = true;
            // 
            // txtWarning
            // 
            this.txtWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWarning.Location = new System.Drawing.Point(2, 259);
            this.txtWarning.Multiline = true;
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.ReadOnly = true;
            this.txtWarning.Size = new System.Drawing.Size(300, 78);
            this.txtWarning.TabIndex = 3;
            this.txtWarning.Text = resources.GetString("txtWarning.Text");
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Location = new System.Drawing.Point(249, 229);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(35, 21);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtItem
            // 
            this.txtItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.err.SetIconPadding(this.txtItem, 37);
            this.txtItem.Location = new System.Drawing.Point(0, 229);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(249, 20);
            this.txtItem.TabIndex = 1;
            this.txtItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.IntegralHeight = false;
            this.lstItems.Location = new System.Drawing.Point(0, 0);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(304, 223);
            this.lstItems.TabIndex = 0;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // tabUncompressedScript
            // 
            this.tabUncompressedScript.Controls.Add(this.txtScript);
            this.tabUncompressedScript.Location = new System.Drawing.Point(4, 22);
            this.tabUncompressedScript.Name = "tabUncompressedScript";
            this.tabUncompressedScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabUncompressedScript.Size = new System.Drawing.Size(304, 337);
            this.tabUncompressedScript.TabIndex = 1;
            this.tabUncompressedScript.Text = "Uncompressed Script";
            this.tabUncompressedScript.UseVisualStyleBackColor = true;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // export
            // 
            this.export.AddExtension = false;
            // 
            // import
            // 
            this.import.Title = "Open QB to Replace in PAK";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(3, 431);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.Location = new System.Drawing.Point(84, 431);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import...";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.eiItemQbKey);
            this.Controls.Add(this.eiUnknown);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnUpdate);
            this.Name = "ScriptEditor";
            this.Size = new System.Drawing.Size(318, 461);
            this.Load += new System.EventHandler(this.ScriptEditor_Load);
            this.tabs.ResumeLayout(false);
            this.tabString.ResumeLayout(false);
            this.tabString.PerformLayout();
            this.tabUncompressedScript.ResumeLayout(false);
            this.tabUncompressedScript.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);

        }

        private bool _preventUpdate;
        private const int _cl = 16; //chars per line
        private const string _fileExt = "qbScript";
        private QbItemScript _qbItem;



    }
}
