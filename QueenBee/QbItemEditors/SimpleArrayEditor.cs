using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Nanook.QueenBee.Parser;

namespace Nanook.QueenBee
{
    internal class SimpleArrayEditor : QbItemEditorBase
    {
        private ListBox lstItems;
        private TextBox txtItem;
        private Button btnConvert;
        private Button btnUpdate;
        private Button btnSet;
        private ContextMenuStrip menu;
        private IContainer components;
        private ToolStripMenuItem mnuFloat;
        private ToolStripMenuItem mnuInt;
        private ToolStripMenuItem mnuUint;
        private ToolStripMenuItem mnuHex;
        private ToolStripMenuItem mnuString;
        private ErrorProvider err;
        private ContextMenuStrip mnuEditItems;
        private ToolStripMenuItem mnuAddItem;
        private ToolStripMenuItem mnuInsertItem;
        private ToolStripMenuItem mnuRemoveItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem mnuItemMoveUp;
        private ToolStripMenuItem mnuItemMoveDown;
        private Button btnImport;
        private Button btnExport;
        private SaveFileDialog export;
        private OpenFileDialog import;
        private Label lblItems;
    
        public SimpleArrayEditor() : base()
        {
            InitializeComponent();
        }

        private void SimpleArrayEditor_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            try
            {
                GenericQbItem gi;

                _gItems = QbFile.GetGenericItems(base.QbItem);

                if (_gItems.Count != 0)
                {
                    gi = _gItems[0];

                    try
                    {
                        lstItems.BeginUpdate();
                        foreach (GenericQbItem gqi in _gItems)
                            lstItems.Items.Add(gqi.Value);

                        lstItems.SelectedIndex = 0;
                    }
                    finally
                    {
                        lstItems.EndUpdate();
                    }
                }
                else
                    gi = QbFile.CreateGenericArrayItem(base.QbItem);

                _currentEditType = gi.CurrentEditType;
                btnConvert.Text = GenericQbItem.GetTypeName(_currentEditType);

                lblItems.Text = gi.Name;

                mnuFloat.Click += new EventHandler(mnu_Click);
                mnuInt.Click += new EventHandler(mnu_Click);
                mnuUint.Click += new EventHandler(mnu_Click);
                mnuHex.Click += new EventHandler(mnu_Click);
                mnuString.Click += new EventHandler(mnu_Click);

                enableItems();
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Load Item Error", ex);
            }

        }

        private void enableItems()
        {
            bool b = _gItems.Count != 0;

            txtItem.Enabled = b;
            btnConvert.Enabled = b;
            btnSet.Enabled = b;
        }

        private void mnu_Click(object sender, EventArgs e)
        {
            try
            {

                Type t;
                if (sender == mnuFloat)
                    t = typeof(float);
                else if (sender == mnuInt)
                    t = typeof(int);
                else if (sender == mnuUint)
                    t = typeof(uint);
                else if (sender == mnuHex)
                    t = typeof(byte[]);
                else if (sender == mnuString)
                    t = typeof(string);
                else
                    return;

                try
                {
                    int idx = getSelectedItem();

                    lstItems.BeginUpdate();
                    int i = 0;
                    foreach (GenericQbItem gi in _gItems)
                        lstItems.Items[i++] = gi.ConvertTo(t);


                    lstItems.SelectedIndex = idx;
                    txtItem.Text = _gItems[idx].Value;
                    _currentEditType = t;
                }
                finally
                {
                    lstItems.EndUpdate();
                }

                btnConvert.Text = GenericQbItem.GetTypeName(t);
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Menu Item Error", ex);
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clearError();
                refreshEditValue(-1);
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Select Item Error", ex);
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                string errMsg = GenericQbItem.ValidateText(_gItems[lstItems.SelectedIndex].Type, _gItems[lstItems.SelectedIndex].CurrentEditType, txtItem.Text);
                if (errMsg.Length != 0)
                    err.SetError(txtItem, errMsg);
                else
                {
                    int idx = getSelectedItem();
                    _gItems[idx].Value = txtItem.Text;
                    lstItems.Items[idx] = _gItems[idx].Value;
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Set Error", ex);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                clearError();
                int idx = getSelectedItem();

                mnuFloat.Enabled = _gItems[getSelectedItem()].CanConvertTo(typeof(float));
                mnuInt.Enabled = _gItems[getSelectedItem()].CanConvertTo(typeof(int));
                mnuUint.Enabled = _gItems[getSelectedItem()].CanConvertTo(typeof(uint));
                mnuHex.Enabled = _gItems[getSelectedItem()].CanConvertTo(typeof(byte[]));
                mnuString.Enabled = _gItems[getSelectedItem()].CanConvertTo(typeof(string));

                menu.Show(btnConvert, new Point(0, btnConvert.Height));

                refreshEditValue(idx);
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Convert Error", ex);
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
            if (_gItems.Count > 0)
                txtItem.Text = _gItems[getSelectedItem()].Value;
            else
                txtItem.Text = string.Empty;
        }

        private void clearError()
        {
            err.SetError(txtItem, string.Empty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string qbKeyText;

                try
                {
                    QbFile.SetGenericItems(base.QbItem, _gItems);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("Item conversion error: {0}", ex.Message));
                }
                base.UpdateQbItem();

                //Check if QbKey is in the debug file, if not then add it to the user defined list
                base.AddQbKeyToUserDebugFile(base.QbItem.ItemQbKey);

                if (base.QbItem.ItemQbKey != null)
                {
                    if ((qbKeyText = base.QbItem.Root.PakFormat.AddNonDebugQbKey(base.QbItem.ItemQbKey, base.QbItem.Root.Filename, base.QbItem.Root)).Length != 0)
                        base.ShowError("QB Key Error", string.Format("QB Key {0} as the same crc as item {1} from the debug file.", base.QbItem.ItemQbKey.Text, qbKeyText));
                }

                foreach (GenericQbItem gi in _gItems)
                {
                    //if QbKey, check to see if it's in the debug file, if not then add it to the user defined list
                    if (gi.Type == typeof(QbKey))
                        base.AddQbKeyToUserDebugFile(gi.ToQbKey());
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Update Error", ex);
            }
        }

        private void txtItem_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int idx = getSelectedItem();
                if (idx >= 0 && idx < _gItems.Count)
                {
                    string errMsg = GenericQbItem.ValidateText(_gItems[idx].Type, _gItems[idx].CurrentEditType, txtItem.Text);
                    //only allow this event to clear messages
                    if (errMsg.Length == 0)
                        err.SetError(txtItem, errMsg);
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void lstItems_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //lstItems.TopIndex
                    int idx = ((int)(e.Y / lstItems.ItemHeight) + (e.Y % lstItems.ItemHeight != 0 ? 1 : 0) + lstItems.TopIndex) - 1;

                    bool itemSelected = idx < lstItems.Items.Count;

                    if (itemSelected) //was an item clicked?
                    {
                        if (lstItems.SelectedIndex != idx)
                            lstItems.SelectedIndex = idx;
                    }
                    else if (lstItems.Items.Count != 0)
                    {
                        lstItems.SelectedIndex = lstItems.Items.Count - 1;
                        itemSelected = true;
                    }

                    mnuItemMoveUp.Enabled = (itemSelected && idx != 0);
                    mnuItemMoveDown.Enabled = (itemSelected && idx != lstItems.Items.Count - 1);
                    mnuInsertItem.Enabled = itemSelected;
                    mnuRemoveItem.Enabled = itemSelected;
                    mnuEditItems.Show(lstItems, e.Location);
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Menu Error", ex);
            }

        }

        private void mnuAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = lstItems.SelectedIndex;

                if (idx >= -1 && idx < lstItems.Items.Count)
                {
                    GenericQbItem qbi = QbFile.CreateGenericArrayItem(base.QbItem);
                    qbi.ConvertTo(_currentEditType);
                    _gItems.Insert(idx + 1, qbi);

                    lstItems.Items.Insert(idx + 1, qbi.Value);

                    enableItems();
                    lstItems.SelectedIndex = idx + 1;
                    txtItem.SelectAll();
                    txtItem.Focus();
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Add Item Error", ex);
            }
        }

        private void mnuInsertItem_Click(object sender, EventArgs e)
        {
            int idx = lstItems.SelectedIndex;

            try
            {
                if (idx >= 0 && idx < lstItems.Items.Count)
                {
                    GenericQbItem qbi = QbFile.CreateGenericArrayItem(base.QbItem);
                    qbi.ConvertTo(_currentEditType);
                    _gItems.Insert(idx, qbi);

                    lstItems.Items.Insert(idx, qbi.Value);

                    enableItems();
                    lstItems.SelectedIndex = idx;
                    txtItem.SelectAll();
                    txtItem.Focus();
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Insert Item Error", ex);
            }
        }

        private void mnuRemoveItem_Click(object sender, EventArgs e)
        {
            int idx = lstItems.SelectedIndex;

            try
            {
                if (idx >= 0 && idx < lstItems.Items.Count)
                {
                    _gItems.RemoveAt(idx);
                    lstItems.Items.RemoveAt(idx);

                    if (lstItems.Items.Count == 0)
                        txtItem.Text = "";
                    else
                    {
                        if (idx >= lstItems.Items.Count)
                            lstItems.SelectedIndex = lstItems.Items.Count - 1;
                        else
                            lstItems.SelectedIndex = idx;
                    }

                    enableItems();
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Simple Array Remove Item Error", ex);
            }

        }

        private void mnuItemMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                int from = lstItems.SelectedIndex;
                int to = from - 1;

                if (to < 0)
                    return;

                swapItems(from, to);
                lstItems.SelectedIndex = to;
            }
            catch
            {
            }
        }

        private void mnuItemMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                int from = lstItems.SelectedIndex;
                int to = from + 1;

                if (to >= lstItems.Items.Count)
                    return;

                swapItems(from, to);
                lstItems.SelectedIndex = to;
            }
            catch
            {
            }
        }

        private void swapItems(int from, int to)
        {
            GenericQbItem tmp = _gItems[from];
            _gItems[from] = _gItems[to];
            _gItems[to] = tmp;

            string s = (string)lstItems.Items[from];
            lstItems.Items[from] = lstItems.Items[to];
            lstItems.Items[to] = s;
        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
                btnSet_Click(this, new EventArgs());
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFloat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHex = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuString = new System.Windows.Forms.ToolStripMenuItem();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.mnuEditItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsertItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.SaveFileDialog();
            this.import = new System.Windows.Forms.OpenFileDialog();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.mnuEditItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.IntegralHeight = false;
            this.lstItems.Location = new System.Drawing.Point(3, 33);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(267, 206);
            this.lstItems.TabIndex = 2;
            this.lstItems.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseUp);
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(0, 18);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(32, 13);
            this.lblItems.TabIndex = 0;
            this.lblItems.Text = "Items";
            // 
            // txtItem
            // 
            this.txtItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.err.SetIconPadding(this.txtItem, 37);
            this.txtItem.Location = new System.Drawing.Point(3, 242);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(215, 20);
            this.txtItem.TabIndex = 3;
            this.txtItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
            this.txtItem.Validating += new System.ComponentModel.CancelEventHandler(this.txtItem_Validating);
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(228, 8);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(42, 22);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "float";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(195, 274);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Location = new System.Drawing.Point(218, 242);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(35, 21);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFloat,
            this.mnuInt,
            this.mnuUint,
            this.mnuHex,
            this.mnuString});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(149, 114);
            // 
            // mnuFloat
            // 
            this.mnuFloat.Name = "mnuFloat";
            this.mnuFloat.Size = new System.Drawing.Size(148, 22);
            this.mnuFloat.Text = "Edit as Float";
            // 
            // mnuInt
            // 
            this.mnuInt.Name = "mnuInt";
            this.mnuInt.Size = new System.Drawing.Size(148, 22);
            this.mnuInt.Text = "Edit as Int";
            // 
            // mnuUint
            // 
            this.mnuUint.Name = "mnuUint";
            this.mnuUint.Size = new System.Drawing.Size(148, 22);
            this.mnuUint.Text = "Edit as UInt";
            // 
            // mnuHex
            // 
            this.mnuHex.Name = "mnuHex";
            this.mnuHex.Size = new System.Drawing.Size(148, 22);
            this.mnuHex.Text = "Edit as Hex";
            // 
            // mnuString
            // 
            this.mnuString.Name = "mnuString";
            this.mnuString.Size = new System.Drawing.Size(148, 22);
            this.mnuString.Text = "Edit as String";
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // mnuEditItems
            // 
            this.mnuEditItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsertItem,
            this.mnuAddItem,
            this.mnuRemoveItem,
            this.toolStripMenuItem1,
            this.mnuItemMoveUp,
            this.mnuItemMoveDown});
            this.mnuEditItems.Name = "contextMenuStrip1";
            this.mnuEditItems.Size = new System.Drawing.Size(150, 120);
            // 
            // mnuInsertItem
            // 
            this.mnuInsertItem.Name = "mnuInsertItem";
            this.mnuInsertItem.Size = new System.Drawing.Size(149, 22);
            this.mnuInsertItem.Text = "Insert Item";
            this.mnuInsertItem.Click += new System.EventHandler(this.mnuInsertItem_Click);
            // 
            // mnuAddItem
            // 
            this.mnuAddItem.Name = "mnuAddItem";
            this.mnuAddItem.Size = new System.Drawing.Size(149, 22);
            this.mnuAddItem.Text = "Add Item";
            this.mnuAddItem.Click += new System.EventHandler(this.mnuAddItem_Click);
            // 
            // mnuRemoveItem
            // 
            this.mnuRemoveItem.Name = "mnuRemoveItem";
            this.mnuRemoveItem.Size = new System.Drawing.Size(149, 22);
            this.mnuRemoveItem.Text = "Remove Item";
            this.mnuRemoveItem.Click += new System.EventHandler(this.mnuRemoveItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // mnuItemMoveUp
            // 
            this.mnuItemMoveUp.Name = "mnuItemMoveUp";
            this.mnuItemMoveUp.Size = new System.Drawing.Size(149, 22);
            this.mnuItemMoveUp.Text = "Move Up";
            this.mnuItemMoveUp.Click += new System.EventHandler(this.mnuItemMoveUp_Click);
            // 
            // mnuItemMoveDown
            // 
            this.mnuItemMoveDown.Name = "mnuItemMoveDown";
            this.mnuItemMoveDown.Size = new System.Drawing.Size(149, 22);
            this.mnuItemMoveDown.Text = "Move Down";
            this.mnuItemMoveDown.Click += new System.EventHandler(this.mnuItemMoveDown_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.Location = new System.Drawing.Point(84, 274);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import...";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(3, 274);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // export
            // 
            this.export.AddExtension = false;
            // 
            // import
            // 
            this.import.Title = "Open QB to Replace in PAK";
            // 
            // SimpleArrayEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.lstItems);
            this.Name = "SimpleArrayEditor";
            this.Size = new System.Drawing.Size(273, 300);
            this.Load += new System.EventHandler(this.SimpleArrayEditor_Load);
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.mnuEditItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
                string fname = string.Empty; // string.Format("{0}.{1}", base.QbItem.Root.Filename.Replace('\\', '#').Replace('/', '#').Replace('.', '#'), _fileExt);

                if (AppState.LastArrayPath.Length == 0)
                    fname = Path.Combine(AppState.LastArrayPath, fname);

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

                    AppState.LastArrayPath = (new FileInfo(fname)).DirectoryName;

                    using (FileStream fs = new FileStream(fname, FileMode.CreateNew, FileAccess.Write))
                    {
                        using (TextWriter tw = new StreamWriter(fs))
                        {
                            foreach (string s in lstItems.Items)
                            {
                                tw.WriteLine(s);
                            }
                        }
                    }
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
                string fname = string.Empty; // string.Format("{0}_{1}.array.txt", base.QbItem.Root.Filename.Replace('\\', '#').Replace('/', '#').Replace('.', '#'), base.QbItem.ItemQbKey.Crc.ToString("X").PadLeft(8, '0'));

                if (AppState.LastArrayPath.Length == 0)
                    fname = Path.Combine(AppState.LastArrayPath, fname);

                fname = getBestFullFilename(fname);


                import.Filter = string.Format("{0} (*.{0})|*.{0}|All files (*.*)|*.*", _fileExt);
                import.Title = string.Format("Import {0} file", _fileExt);
                import.CheckFileExists = true;
                import.CheckPathExists = true;
                import.FileName = fname;

                if (import.ShowDialog(this) != DialogResult.Cancel)
                {
                    fname = import.FileName;

                    using (FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read))
                    {
                        using (TextReader tr = new StreamReader(fs))
                        {
                            lstItems.Items.Clear();
                            _gItems.Clear();

                            string s;
                            while ((s = tr.ReadLine()) != null)
                            {
                                GenericQbItem qbi = QbFile.CreateGenericArrayItem(base.QbItem);
                                qbi.ConvertTo(_currentEditType);
                                _gItems.Add(qbi);
                                qbi.Value = s;

                                lstItems.Items.Add(qbi.Value);
                            }
                        }
                    }

                    if (lstItems.Items.Count > 1)
                        lstItems.SelectedIndex = 0;

                    btnUpdate_Click(this, e);
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Script Import Error", ex);
            }
        }


        private Type _currentEditType;
        private List<GenericQbItem> _gItems;
        private const string _fileExt = "array.txt";

    }
}
