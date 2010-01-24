using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Nanook.QueenBee.Parser;

namespace Nanook.QueenBee
{
    public partial class EditorForm : Form
    {
        [DllImport("user32", CharSet = CharSet.Auto)]
        private extern static IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0x000B;   

        private delegate void testSearchItem(QbFile qbFile, QbItemBase item);

        public EditorForm()
        {
            InitializeComponent();

            this.Visible = false;

            AppState.LastQbReplacePath = string.Empty;
            AppState.LastQbExtractPath = string.Empty;

            _formats = new Dictionary<string, PakFormatType>();
            _formats.Add("Wii (ngc)", PakFormatType.Wii);
            _formats.Add("PS2 (ps2)", PakFormatType.PS2);
            _formats.Add("XBox (xen)", PakFormatType.XBox);
            _formats.Add("XBox (xbx)", PakFormatType.XBox_XBX);
            _formats.Add("PC (xen)", PakFormatType.PC);
            _formats.Add("PC (wpc)", PakFormatType.PC_WPC);

            foreach (string s in _formats.Keys)
                cboFormatType.Items.Add(s);

            _info = null;
            this.FormClosing += new FormClosingEventHandler(EditorForm_FormClosing);

            _lvwPakColumnSorter = new ListViewColumnSorter();
            this.lstPakContents.ListViewItemSorter = _lvwPakColumnSorter;
            _lvwPakColumnSorter.SortColumn = 0;
            _lvwPakColumnSorter.Order = SortOrder.Ascending;

            _lvwSearchColumnSorter = new ListViewColumnSorter();
            this.lstSearchResults.ListViewItemSorter = _lvwSearchColumnSorter;
            _lvwSearchColumnSorter.SortColumn = 0;
            _lvwSearchColumnSorter.Order = SortOrder.Ascending;

            tabs.SelectedTab = tabPak;

            Assembly ass = Assembly.GetExecutingAssembly();
            object[] attributes = ass.GetCustomAttributes(true);
            string assName = string.Empty;
            string assDescription = string.Empty;
            string assCompany = string.Empty;
            Version assVersion = ass.GetName().Version;

            foreach (object attribute in attributes)
            {
                if (attribute is AssemblyDescriptionAttribute)
                    assDescription = (((AssemblyDescriptionAttribute)attribute).Description);
                else if (attribute is AssemblyTitleAttribute)
                    assName = (((AssemblyTitleAttribute)attribute).Title);
                else if (attribute is AssemblyCompanyAttribute)
                    assCompany = (((AssemblyCompanyAttribute)attribute).Company);
            }
            this.Text = string.Format("{0} ({1})     v{2}.{3}     by {4}", assName, assDescription, assVersion.Major.ToString(), assVersion.Minor.ToString(), assCompany);

            cboFormatType.SelectedIndex = 0;

            loadConfiguration();
            this.Visible = true;
        }

        #region PAK tab routines
        private PakFormatType formatToPakFormatType(string text)
        {
            return _formats[text];
        }

        private void cboPakType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPakFile.Text = string.Empty;
            txtPabFile.Text = string.Empty;
            txtDebugFile.Text = string.Empty;

            //PakFormat pts = new PakFormat(txtPakFile.Text, txtPabFile.Text, txtDebugFile.Text, formatToPakFormatType(cboFormatType.Text));
        }

        private string getBestFullFilename(string fullFilename)
        {
            if (fullFilename == null)
                return string.Empty;
            else if (fullFilename.Trim().Length == 0)
                return string.Empty;

            FileInfo fi;
            string pth = fullFilename;
            try
            {
                fi = new FileInfo(pth);
            }
            catch
            {
                return string.Empty;
            }
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

        private void btnPakFile_Click(object sender, EventArgs e)
        {
            string file = getBestFullFilename(txtPakFile.Text);

            PakFormat pts = new PakFormat(file, "", "", formatToPakFormatType(cboFormatType.Text));
            openInput.Filter = string.Format("{0} (*.pak.{1})|*.pak.{1}|All files (*.*)|*.*", pts.PakFormatType.ToString(), pts.FileExtension);
            openInput.Title = string.Format("Open {0} PAK file", pts.PakFormatType.ToString());

            openInput.FileName = file;
            if (openInput.ShowDialog(this) != DialogResult.Cancel)
            {
                txtPakFile.Text = openInput.FileName;
                pts = new PakFormat(txtPakFile.Text, "", "", formatToPakFormatType(cboFormatType.Text));
                if (!pts.IsCompressed && pts.PabFileExists)
                    txtPabFile.Text = pts.FullPabFilename;
                else if (pts.IsCompressed && pts.CompressedPabFileExists)
                    txtPabFile.Text = pts.FullCompressedPabFilename;
                else
                    txtPabFile.Text = string.Empty;
                if (!pts.IsCompressed && pts.DebugFileExists)
                    txtDebugFile.Text = pts.FullDebugFilename;
                else if (pts.IsCompressed && pts.CompressedDebugFileExists)
                    txtDebugFile.Text = pts.FullCompressedDebugFilename;
                else
                    txtDebugFile.Text = string.Empty;
            }

        }

        private void btnPabFile_Click(object sender, EventArgs e)
        {
            string filePak = getBestFullFilename(txtPakFile.Text);
            string filePab = getBestFullFilename(txtPabFile.Text);
            string fileDbg = getBestFullFilename(txtDebugFile.Text);

            PakFormat pts = new PakFormat(filePak, filePab, fileDbg, formatToPakFormatType(cboFormatType.Text));
            openInput.Filter = string.Format("{0} (*.pab.{1})|*.pab.{1}|All files (*.*)|*.*", pts.PakFormatType.ToString(), pts.FileExtension);
            openInput.Title = string.Format("Open {0} PAB file", pts.PakFormatType.ToString());

            openInput.FileName = filePab;
            if (openInput.ShowDialog(this) != DialogResult.Cancel)
            {
                txtPabFile.Text = openInput.FileName;
            }
        }

        private void btnDebugFile_Click(object sender, EventArgs e)
        {
            string filePak = getBestFullFilename(txtPakFile.Text);
            string filePab = getBestFullFilename(txtPabFile.Text);
            string fileDbg = getBestFullFilename(txtDebugFile.Text);

            PakFormat pts = new PakFormat(filePak, filePab, fileDbg, formatToPakFormatType(cboFormatType.Text));
            openInput.Filter = string.Format("{0} (*.pak.{1})|*.pak.{1}|All files (*.*)|*.*", pts.PakFormatType.ToString(), pts.FileExtension);
            openInput.Title = string.Format("Open {0} DBG file", pts.PakFormatType.ToString());

            openInput.FileName = fileDbg;
            if (openInput.ShowDialog(this) != DialogResult.Cancel)
            {
                txtDebugFile.Text = openInput.FileName;
            }
        }

        private void btnLoadPak_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (txtPakFile.Text.Trim().Length == 0)
                {
                    showError("Pak File Error", "The PAK filename is blank");
                    return;
                }

                _pakFormat = new PakFormat(txtPakFile.Text, txtPabFile.Text, txtDebugFile.Text, formatToPakFormatType(cboFormatType.Text), false);

                if (_pakFormat.IsCompressed)
                {
                    if (!_pakFormat.CompressedPakFileExists)
                    {
                        showError("Pak File Error", string.Format("The PAK file does not exist '{0}'", txtPakFile.Text));
                        return;
                    }

                    if (txtPabFile.Text.Length != 0 && !_pakFormat.CompressedPabFileExists)
                    {
                        showError("Pab File Error", string.Format("The PAB file does not exist '{0}'", txtPabFile.Text));
                        return;
                    }

                    if (txtDebugFile.Text.Length != 0 && !_pakFormat.CompressedDebugFileExists)
                    {
                        showError("Debug File Error", string.Format("The Debug file does not exist '{0}'", txtDebugFile.Text));
                        return;
                    }
                }
                else
                {
                    if (!_pakFormat.PakFileExists)
                    {
                        showError("Pak File Error", string.Format("The PAK file does not exist '{0}'", txtPakFile.Text));
                        return;
                    }

                    if (txtPabFile.Text.Length != 0 && !_pakFormat.PabFileExists)
                    {
                        showError("Pab File Error", string.Format("The PAB file does not exist '{0}'", txtPabFile.Text));
                        return;
                    }

                    if (txtDebugFile.Text.Length != 0 && !_pakFormat.DebugFileExists)
                    {
                        showError("Debug File Error", string.Format("The Debug file does not exist '{0}'", txtDebugFile.Text));
                        return;
                    }
                }

                clearInterface();

                AppState.InputFormat = cboFormatType.Text;
                AppState.PakFilename = txtPakFile.Text;
                AppState.PabFilename = txtPabFile.Text;
                AppState.DebugFilename = txtDebugFile.Text;
                AppState.Backup = chkBackup.Checked;

                try
                {
                    if (chkBackup.Checked)
                    {
                        if (_pakFormat.PakFormatType == PakFormatType.XBox)
                        {
                            backup(_pakFormat.FullCompressedPakFilename);
                            if (_pakFormat.PabFileExists)
                                backup(_pakFormat.FullCompressedPabFilename);
                        }
                        else
                        {
                            backup(_pakFormat.FullPakFilename);
                            if (_pakFormat.PabFileExists)
                                backup(_pakFormat.FullPabFilename);
                        }
                    }
                }
                catch (Exception ex)
                {
                    showException("PAK Backup Error", ex);
                    clearInterface();
                    return;
                }

                try
                {
                    _pakFile = new PakEditor(_pakFormat);
                }
                catch (Exception ex)
                {
                    showException("PAK File Load/Parse Error", ex);
                    clearInterface();
                    return;
                }

                if (_pakFile.RequiresPab && !_pakFormat.PabFileExists)
                {
                    showError("PAK Error", "The data for this PAK is not present, it may require a PAB");
                    clearInterface();
                    return;
                }

                try
                {
                    if (_pakFormat.DebugFileExists)
                        _dbgFile = new PakEditor(_pakFormat, true);
                    else
                        _dbgFile = null;
                }
                catch (Exception ex)
                {
                    showException("Debug File Load/Parse Error", ex);
                    clearInterface();
                    return;
                }

                try
                {
                    ListViewItem li;
                    string[] fn;
                    char[] sc = new char[] { '\\' };

                    lstPakContents.BeginUpdate();
                    lstPakContents.ListViewItemSorter = null;
                    lstPakContents.Items.Clear();
                    foreach (PakHeaderItem phi in _pakFile.Headers.Values)
                    {
                        fn = phi.Filename.Split(sc);
                        li = new ListViewItem(fn[fn.Length - 1]);
                        li.SubItems.Add(phi.Filename);
                        li.SubItems.Add(string.Format("{0} ({1})", (phi.HeaderStart + phi.FileOffset).ToString("X").PadLeft(8, '0'), (phi.HeaderStart + phi.FileOffset).ToString()));
                        li.SubItems.Add(phi.FileLength.ToString());
                        li.SubItems.Add(phi.FileType.Text);
                        li.ImageIndex = getPakFileImageIndex(phi.PakFileType);
                        li.Tag = phi;
                        lstPakContents.Items.Add(li);
                    }

                    lstPakContents.Focus();

                    updateStatusItems();
                }
                catch (Exception ex)
                {
                    showException("PAK List Population Error", ex);
                    clearInterface();
                    return;
                }
                finally
                {
                    lstPakContents.ListViewItemSorter = _lvwPakColumnSorter;
                    lstPakContents.EndUpdate();
                }

                lstPakContents.Sort();

                if (lstPakContents.Items.Count > 0)
                {
                    lstPakContents.Items[0].Selected = true;
                    lstPakContents.Items[0].Focused = true;
                }

                tabPak.Text = string.Format("PAK: {0}", (new FileInfo(_pakFile.Filename)).Name);
                mnuEditQBFile.Enabled = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;

                try
                {
                    if (_pakFile.StructItemChildrenType == StructItemChildrenType.NotSet)
                    {
                        if (MessageBox.Show(this,
@"Unable to detect StructItem Children Type.

Is this a newer PAK file (GH:WT onwards)?

New PAK files have array IDs within Struct types. Queen Bee can load these
types without needing to know the type. It is required when creating new types
This PAK has no StructItem children so this setting could not be detected.", "StructItem Children Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _pakFormat.StructItemChildrenType = StructItemChildrenType.ArrayItems;
                        }
                        else
                        {
                            _pakFormat.StructItemChildrenType = StructItemChildrenType.StructItems;
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void updateStatusItems()
        {
            long pab = 0;
            if (_pakFormat.PabFileExists)
            {
                pab = (new FileInfo(_pakFormat.FullPabFilename)).Length;
                tlblPakFileInfo.Text = string.Format("PAK/PAB file: {0}/{1} bytes, {2} files", _pakFile.FileLength.ToString(), pab.ToString(), _pakFile.Headers.Count.ToString());
            }
            else
                tlblPakFileInfo.Text = string.Format("PAK file: {0} bytes, {1} files", _pakFile.FileLength.ToString(), _pakFile.Headers.Count.ToString());

        }

        private int getPakFileImageIndex(PakItemType type)
        {
            switch (type)
            {
                case PakItemType.Qb:
                    return 9;
                case PakItemType.Sqb:
                    return 9;
                case PakItemType.Debug:
                    return 10;
                case PakItemType.Image:
                    return 11;
                case PakItemType.Midi:
                    return 13;
                case PakItemType.Texture:
                    return 11;
                case PakItemType.Skin:
                    return 11;
                default:
                    return 12;
            }

        }

        private void backup(string filename)
        {
            //let exceptions be raised
            string bakFilename = string.Format("{0}.bak", filename);

            if (File.Exists(filename))
            {
                if (File.Exists(bakFilename))
                    File.Delete(bakFilename);
                File.Copy(filename, bakFilename);
            }

        }

        private string loadDbgQBFile(string qbFilename)
        {
            string dbgFilename = qbFilename.Replace(string.Format(".qb.{0}", _pakFormat.FileExtension), string.Format(".{0}", _pakFormat.QbDebugExtension));

            string key = null;

            try
            {
                if (_dbgFile != null)
                {
                    if (_dbgFile.Headers.ContainsKey(dbgFilename.ToLower()))
                        key = dbgFilename.ToLower();
                    else
                    {
                        dbgFilename = qbFilename.Replace(string.Format(".qb.{0}", _pakFormat.FileExtension), string.Format(".{0}.{1}", _pakFormat.QbDebugExtension, _pakFormat.FileExtension));

                        if (_dbgFile.Headers.ContainsKey(dbgFilename.ToLower()))
                            key = dbgFilename.ToLower();
                        else
                        {
                            //use the qb pak headers to lookup the debugQbKeys.
                            //the debug pak has QBKeys as the keys instead of filenames
                            foreach (PakHeaderItem phi in _pakFile.Headers.Values)
                            {
                                if (phi.Filename.ToLower() == qbFilename)
                                {
                                    key = phi.DebugQbKey.ToString("X").PadLeft(8, '0').ToLower();
                                    break;
                                }
                            }
                        }
                    }

                    if (key != null && _dbgFile != null && _dbgFile.Headers.ContainsKey(key))
                        return _dbgFile.ExtractFileToString(key);
                }
            }
            catch
            {
            }
            return string.Empty;
        }

        private void loadEditQBFile(string qbFilename)
        {

            string dbgFileContents = loadDbgQBFile(qbFilename);

            try
            {
                _qbFile = _pakFile.ReadQbFile(qbFilename, dbgFileContents);
            }
            catch (Exception ex)
            {
                showException("PAK Extract / QB Parse Error", ex);
                clearInterfaceQb();
                return;
            }

            populateQbList(null);

            btnSavePak.Enabled = false;
            tabQb.Text = string.Format("QB: {0}", _qbFile.Filename);
        }

        private void populateQbList(QbItemBase selectItem)
        {
            ListViewItem topItem = null;
            try
            {
                bool isRefresh = (selectItem != null);  

                lstQbItems.BeginUpdate();

                //try to preserve the top item
                ListViewItem top = lstQbItems.TopItem; //can return null
                int topIdx = 0;
                
                //if is refresh, try and select the same item
                if (isRefresh && top != null)
                {
                    for (int i = 0; i < lstQbItems.Items.Count; i++)
                    {
                        if (lstQbItems.Items[i] == top)
                        {
                            topIdx = i;
                            break;
                        }
                    }
                }

                //clear items without as much flicker as Items.Clear
                for (int i = lstQbItems.Items.Count - 1; i >= 0; i--)
                    lstQbItems.Items.RemoveAt(i);

                foreach (QbItemBase itm in _qbFile.Items)
                {
                    addItemToGui(itm, 0);
                    addSubItemsToGui(itm, 0 + 1);

                }

                ListViewItem foundItem = null;
                if (selectItem != null)
                {
                    foreach (ListViewItem li in lstQbItems.Items)
                    {
                        if (li.Tag == selectItem)
                        {
                            foundItem = li;
                            break;
                        }
                    }
                }

                if (foundItem == null && lstQbItems.Items.Count != 0)
                    foundItem = lstQbItems.Items[0];

                if (isRefresh && top != null && lstQbItems.Items.Count != 0 && topIdx >= 0 && topIdx < lstQbItems.Items.Count)
                {
                    topItem = lstQbItems.Items[topIdx];
                    lstQbItems.TopItem = topItem;
                    lstQbItems.TopItem = topItem; //crazy, but stops the wrong item being set.
                }

                if (foundItem != null)
                {
                    foundItem.Selected = true;
                    foundItem.Focused = true;
                    foundItem.EnsureVisible();
                }

                if (lstQbItems.SelectedIndices.Count == 0 && lstQbItems.Items.Count != 0)
                {
                    lstQbItems.Items[0].Selected = true;
                    lstQbItems.Items[0].Focused = true;
                }

                if (lstQbItems.SelectedIndices.Count == 0)
                {
                    gboEdit.Controls.Clear();
                }

                tlblQbFileInfo.Text = string.Format("QB file: {0} items, {1} bytes", lstQbItems.Items.Count.ToString(), _qbFile.Length.ToString());
            }
            catch (Exception ex)
            {
                showException("QB List Population Error", ex);
                clearInterfaceQb();
                return;
            }
            finally
            {
                lstQbItems.EndUpdate();
            }

        }

        private void addSubItemsToGui(QbItemBase parent, int indent)
        {
            foreach (QbItemBase itm in parent.Items)
            {
                addItemToGui(itm, indent);
                addSubItemsToGui(itm, indent + 1);
            }
        }

        private void lstPakContents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _lvwPakColumnSorter.Numeric = (lstPakContents.Columns[e.Column].Text == "Length");

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwPakColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_lvwPakColumnSorter.Order == SortOrder.Ascending)
                    _lvwPakColumnSorter.Order = SortOrder.Descending;
                else
                    _lvwPakColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwPakColumnSorter.SortColumn = e.Column;
                _lvwPakColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lstPakContents.Sort();

        }

        private void lstPakContents_DoubleClick(object sender, EventArgs e)
        {
            mnuEditQBFile_Click(this, new EventArgs());
        }

        private void lstPakContents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
                mnuEditQBFile_Click(this, new EventArgs());
        }

        private void lstPakContents_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lstPakContents.SelectedItems.Count != 0)
                    mnuContext.Show(lstPakContents, e.Location);
            }
        }

        private void mnuTestAllQbFiles_Click(object sender, EventArgs e)
        {
            PakEditor pak = null;

            try
            {
                pak = new PakEditor(_pakFormat);
            }
            catch (Exception ex)
            {
                showException("PAK Load Error", ex);
                return;
            }

            string filename = string.Empty;
            try
            {
                int skipped = 0;
                foreach (PakHeaderItem phi in pak.Headers.Values)
                {
                    filename = phi.Filename;

                    //System.Diagnostics.Debug.WriteLine(phi.Filename);  //DEBUG FILENAME
                    if (phi.PakFileType == PakItemType.Qb || phi.PakFileType == PakItemType.Sqb || phi.PakFileType == PakItemType.Midi)
                    {
                        //showError("Error", "Only QB files can be tested.");
                        //return;

                        QbFile qbf = pak.ReadQbFile(phi.Filename);
                        QbItemBase qib = qbf.IsValid();
                        if (qib != null)
                            throw new ApplicationException(string.Format("{0} at position 0x{1}", QbFile.FormatIsValidErrorMessage(qib, qib.IsValid), qib.Position.ToString("X").PadLeft(8, '0')));

                    }
                    else
                        skipped++;


                }
                int c = (pak.Headers.Values.Count - skipped);
                MessageBox.Show(this, string.Format("PAK and {0} QB file{1} validated succesfully, {2} skipped", c.ToString(), c == 1 ? "" : "s", skipped.ToString()), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                showError("QB Test Error", string.Format("{0} in '{1}'", ex.Message, filename));
                return;
            }

        }

        private void mnuReplaceFile_Click(object sender, EventArgs e)
        {
            try
            {

                string qbname = lstPakContents.SelectedItems[0].SubItems[1].Text;
                string fname = qbname.Replace('\\', '#').Replace('/', '#');

                if (AppState.LastQbReplacePath.Length != 0)
                {
                    if (Directory.Exists(AppState.LastQbReplacePath))
                    {
                        openQb.InitialDirectory = AppState.LastQbReplacePath;
                        fname = Path.Combine(AppState.LastQbReplacePath, fname);
                    }
                }

                fname = getBestFullFilename(fname);

                openQb.Filter = string.Format("{0} (*.qb.{1})|*.qb.{1}|All files (*.*)|*.*", _pakFormat.PakFormatType.ToString(), _pakFormat.FileExtension);

                openQb.FileName = fname;
                if (openQb.ShowDialog(this) != DialogResult.Cancel)
                {
                    this.Cursor = Cursors.WaitCursor;
                    AppState.LastQbReplacePath = (new FileInfo(openQb.FileName)).DirectoryName;
                    _pakFile.ReplaceFile(qbname, openQb.FileName);

                    refreshPakList();
                }
            }
            catch (Exception ex)
            {
                showException("Replace Error", ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void mnuExtractFile_Click(object sender, EventArgs e)
        {
            try
            {
                string qbname = lstPakContents.SelectedItems[0].SubItems[1].Text;
                string fname = qbname.Replace('\\', '#').Replace('/', '#');

                if (AppState.LastQbExtractPath.Length != 0)
                {
                    if (Directory.Exists(AppState.LastQbExtractPath))
                    {
                        saveQb.InitialDirectory = AppState.LastQbExtractPath;
                        fname = Path.Combine(AppState.LastQbExtractPath, fname);
                    }
                }

                fname = getBestFullFilename(fname);

                saveQb.Filter = string.Format("{0} (*.qb.{1})|*.qb.{1}|All files (*.*)|*.*", _pakFormat.PakFormatType.ToString(), _pakFormat.FileExtension);

                saveQb.FileName = fname;
                if (saveQb.ShowDialog(this) != DialogResult.Cancel)
                {
                    this.Cursor = Cursors.WaitCursor;
                    AppState.LastQbExtractPath = (new FileInfo(saveQb.FileName)).DirectoryName;

                    if (File.Exists(saveQb.FileName))
                        File.Delete(saveQb.FileName);
                    _pakFile.ExtractFile(qbname, saveQb.FileName);
                }
            }
            catch (Exception ex)
            {
                showException("Extract Error", ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void mnuExtractAll_Click(object sender, EventArgs e)
        {
            try
            {
                browseQb.SelectedPath = string.Format(@"{0}\", AppState.LastQbExtractPath.TrimEnd('\\'));
                if (browseQb.ShowDialog(this) != DialogResult.Cancel)
                {
                    this.Cursor = Cursors.WaitCursor;
                    AppState.LastQbExtractPath = browseQb.SelectedPath.TrimEnd('\\');
                    string fn;
                    foreach (PakHeaderItem phi in _pakFile.Headers.Values)
                    {
                        fn = Path.Combine(AppState.LastQbExtractPath, phi.Filename.Replace('\\', '#'));
                        if (File.Exists(fn))
                            File.Delete(fn);
                        _pakFile.ExtractFile(phi.Filename, fn);
                    }
                    MessageBox.Show(this, "All QB files extracted succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                showException("Extract All Error", ex);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void mnuEditQBFile_Click(object sender, EventArgs e)
        {
            if (!mnuEditQBFile.Enabled) //double click and enter on lstPakContents will call this
                return;

            PakHeaderItem phi = (PakHeaderItem)lstPakContents.SelectedItems[0].Tag;

            if (phi.PakFileType != PakItemType.Qb && phi.PakFileType != PakItemType.Sqb && phi.PakFileType != PakItemType.Midi)
            {
                showError("Error", "Only QB files can be edited.");
                return;
            }

            tabs.SelectedTab = tabQb;
            Application.DoEvents();

            loadEditQBFile(phi.Filename);
        }

        public void refreshPakList()
        {
            PakHeaderItem phi;
            foreach (ListViewItem li in lstPakContents.Items)
            {
                phi = _pakFile.Headers[li.SubItems[1].Text.ToLower()];

                li.SubItems[2].Text = (string.Format("{0} ({1})", (phi.HeaderStart + phi.FileOffset).ToString("X").PadLeft(8, '0'), (phi.HeaderStart + phi.FileOffset).ToString()));
                li.SubItems[3].Text = phi.FileLength.ToString();
                li.SubItems[4].Text = phi.FileType.Text;

            }
        }

        private void mnuNewFile_Click(object sender, EventArgs e)
        {
            EditPakItem f = new EditPakItem(EditPakItemType.New);

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                if (f.PakItemFilename.Trim().Length == 0)
                {
                    MessageBox.Show(this, "The pak item filename was not specified", "New File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (pakItemExists(f.PakItemFilename, null))
                {
                    MessageBox.Show(this, string.Format("'{0}' already exists", f.PakItemFilename), "New File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    selectPakItem(f.PakItemFilename);
                    return;
                }

                //get the unknown value from another file
                byte[] unknown = new byte[] { 0x1C, 0x08, 0x02, 0x04, 0x10, 0x04, 0x08, 0x0C, 0x0C, 0x08, 0x02, 0x04, 0x14, 0x02, 0x04, 0x0C, 0x10, 0x10, 0x0C, 0x00 };
                QbFile qbf = null;
                QbKey qbType = QbKey.Create(".qb");
                foreach (PakHeaderItem phi in _pakFile.Headers.Values)
                {
                    if (phi.FileType == qbType)
                    {
                        qbf = _pakFile.ReadQbFile(phi.Filename);
                        unknown = (byte[])((QbItemUnknown)qbf.Items[0]).UnknownData.Clone();
                        break;
                    }
                }

                //some hard coded values rather than ask the user for them... Always the same update if required
                _pakFile.NewFile(f.PakItemFilename, f.ItemType, f.IncludeFileNameInHeader, 0, unknown);
                reloadPak();
                selectPakItem(f.PakItemFilename);
            }
        }

        private void mnuAddFile_Click(object sender, EventArgs e)
        {
            EditPakItem f = new EditPakItem(EditPakItemType.Add);

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (!File.Exists(f.ImportFilename))
                    {
                        MessageBox.Show(this, string.Format("'{0}' does not exist", f.ImportFilename), "Add File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (f.PakItemFilename.Trim().Length == 0)
                    {
                        MessageBox.Show(this, "The pak item filename was not specified", "Add File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (pakItemExists(f.PakItemFilename, null))
                    {
                        MessageBox.Show(this, string.Format("'{0}' already exists", f.PakItemFilename), "Add File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        selectPakItem(f.PakItemFilename);
                        return;
                    }

                    //some hard coded values rather than ask the user for them... Always the same update if required
                    _pakFile.AddFile(f.ImportFilename, f.PakItemFilename, f.ItemType, f.IncludeFileNameInHeader);
                    reloadPak();
                    selectPakItem(f.PakItemFilename);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void mnuRenameFile_Click(object sender, EventArgs e)
        {
            EditPakItem f = new EditPakItem(EditPakItemType.Rename);
            PakHeaderItem phi = (PakHeaderItem)lstPakContents.SelectedItems[0].Tag;

            f.IncludeFileNameInHeader = ((phi.Flags & PakHeaderFlags.Filename) == PakHeaderFlags.Filename);
            if (f.IncludeFileNameInHeader) //we don't know the filename
                f.PakItemFilename = phi.Filename;
            f.ItemType = phi.FileType;

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (f.PakItemFilename.Trim().Length == 0)
                    {
                        MessageBox.Show(this, "The pak item filename was not specified", "Rename File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (pakItemExists(f.PakItemFilename, phi))
                    {
                        MessageBox.Show(this, string.Format("'{0}' already exists", f.PakItemFilename), "Rename File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        selectPakItem(f.PakItemFilename);
                        return;
                    }

                    //some hard coded values rather than ask the user for them... Always the same update if required
                    _pakFile.RenameFile(phi.Filename, f.PakItemFilename, f.ItemType);
                    reloadPak();
                    selectPakItem(f.PakItemFilename);

                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void mnuRemoveFile_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (lstPakContents.Items.Count <= 1)
                {
                    MessageBox.Show(this, "Pak Files with no files are not supported", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                PakHeaderItem phi = (PakHeaderItem)lstPakContents.SelectedItems[0].Tag;
                _pakFile.RemoveFile(phi.Filename);

                reloadPak();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool pakItemExists(string qbFilename, PakHeaderItem exclude)
        {
            string fn = qbFilename.ToLower();
            QbKey qk = QbKey.Create(fn);
            foreach (PakHeaderItem phi in _pakFile.Headers.Values)
            {
                if (exclude != null && exclude == phi)
                    continue;
                if (fn == phi.Filename.ToLower() || phi.PakFullFileNameQbKey == qk.Crc)
                    return true;
            }
            return false;
        }

        private void selectPakItem(string qbFilename)
        {
            string fn = qbFilename.ToLower();
            string qk = QbKey.Create(fn).Crc.ToString("X").PadLeft(8, '0').ToUpper();
            foreach (ListViewItem li in lstPakContents.Items)
            {
                if (li.SubItems[1].Text.ToLower() == fn || li.SubItems[1].Text.ToUpper() == qk)
                {
                    li.Selected = true;
                    li.EnsureVisible();
                    break;
                }
            }
        }

        private void reloadPak()
        {
            int topIdx = 0;

            try
            {
                int idx = lstPakContents.SelectedItems[0].Index;
                lstPakContents.BeginUpdate();

                //try to preserve the top item
                topIdx = lstPakContents.TopItem.Index; //can return null

                //clear items without as much flicker as Items.Clear
                for (int i = lstPakContents.Items.Count - 1; i >= 0; i--)
                    lstPakContents.Items.RemoveAt(i);

                btnLoadPak_Click(this, new EventArgs());
                if (idx >= lstPakContents.Items.Count)
                    idx = lstPakContents.Items.Count - 1;
                if (topIdx >= lstPakContents.Items.Count)
                    topIdx = lstPakContents.Items.Count - 1;

                lstPakContents.Items[idx].Selected = true;

                lstPakContents.TopItem = lstPakContents.Items[topIdx];
                lstPakContents.TopItem = lstPakContents.Items[topIdx]; //crazy, but stops the wrong item being set.

            }
            finally
            {
                lstPakContents.EndUpdate();
            }
        }

        #endregion

        #region QB tab routines
        private void btnSavePak_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                long pakLen = _pakFormat.CompressedPakFilesize;
                long pabLen = _pakFormat.CompressedPabFilesize;

                QbItemBase qib;
                try
                {
                    _qbFile.AlignPointers();
                    qib = _qbFile.IsValid();
                    if (qib != null)
                    {
                        foreach (ListViewItem li in lstQbItems.Items)
                        {
                            if (li.Tag == qib)
                            {
                                li.Selected = true;
                                li.EnsureVisible();

                                showError("Invalid Item", QbFile.FormatIsValidErrorMessage(qib, qib.IsValid));
                            }
                        }
                        return;
                    }

                    _pakFile.ReplaceFile(_qbFile.Filename, _qbFile);

                    btnSavePak.Enabled = false;
                }
                catch (Exception ex)
                {
                    showException("Save to PAK Error", ex);
                    return;
                }

                try
                {
                    _pakFormat.SaveDebugQbKey();
                }
                catch (Exception ex)
                {
                    showException("Save to User QB Key Error", ex);
                    return;
                }


                try
                {
                    if (_pakFormat.IsCompressed)
                    {
                        if (_pakFormat.PakFormatType == PakFormatType.XBox)
                        {
                            if (pakLen > _pakFormat.CompressedPakFilesize)
                                showError("PAK Size", string.Format("The PAK file is {0} bytes larger than the original", (pakLen - _pakFormat.CompressedPakFilesize).ToString()));

                            if (pabLen > _pakFormat.CompressedPabFilesize)
                                showError("PAB Size", string.Format("The PAB file is {0} bytes larger than the original", (pabLen - _pakFormat.CompressedPabFilesize).ToString()));

                        }
                    }

                }
                catch (Exception ex)
                {
                    showException("Compress Files Error", ex);
                    return;
                }

                refreshPakList();
                updateStatusItems();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void addItemToGui(QbItemBase itm, int indent)
        {
            //let exceptions be raised
            ListViewItem li = new ListViewItem(itm.QbItemType.ToString());
            li.IndentCount = indent;
            if (itm.DebugName.Length != 0)
                li.SubItems.Add(itm.DebugName);
            else if (itm.ItemQbKey != null && itm.ItemQbKey.Crc != 0)
                li.SubItems.Add(itm.ItemQbKey.Crc.ToString("X").PadLeft(8, '0'));
            else
                li.SubItems.Add(string.Empty);

            li.SubItems.Add(getValueForList(itm));
            li.SubItems.Add(string.Format("{0} ({1})", itm.Position.ToString("X").PadLeft(8, '0'), itm.Position.ToString()));
            li.SubItems.Add(itm.Length.ToString());
            li.SubItems.Add(itm.GetType().Name);
            li.ImageIndex = getQbItemImageIndex(itm.QbItemType);
            li.Tag = itm; //hold a reference to the item
            lstQbItems.Items.Add(li);

        }

        private string getValueForList(QbItemBase itm)
        {
            int max = 100;
            StringBuilder sb = new StringBuilder(max);

            if (itm is QbItemInteger)
            {
                foreach (uint i in ((QbItemInteger)itm).Values)
                {
                    if (sb.Length != 0)
                        sb.Append(", ");
                    sb.Append(((int)i).ToString()); //default to ease for this quick list
                    if (sb.Length > max)
                        break;
                }
            }
            else if (itm is QbItemFloat)
            {
                foreach (float f in ((QbItemFloat)itm).Values)
                {
                    if (sb.Length != 0)
                        sb.Append(", ");
                    sb.Append(f.ToString());
                    if (sb.Length > max)
                        break;
                }
            }
            else if (itm is QbItemFloats)
            {
                foreach (float f in ((QbItemFloats)itm).Values)
                {
                    if (sb.Length != 0)
                        sb.Append(", ");
                    sb.Append(f.ToString());
                    if (sb.Length > max)
                        break;
                }
            }
            else if (itm is QbItemQbKey)
            {
                foreach (QbKey qb in ((QbItemQbKey)itm).Values)
                {
                    if (sb.Length != 0)
                        sb.Append(", ");
                    if (qb.Text.Length != 0)
                        sb.Append(qb.Text);
                    else
                        sb.Append(qb.Crc.ToString("X").PadLeft(8, '0'));
                    if (sb.Length > max)
                        break;
                }
            }
            else if (itm is QbItemString)
            {
                foreach (string s in ((QbItemString)itm).Strings)
                {
                    if (sb.Length != 0)
                        sb.Append(", ");
                    sb.Append(s);
                    if (sb.Length > max)
                        break;
                }
            }

            string str = sb.ToString();
            if (str.Length > max)
                return string.Concat(str.Substring(0, max), "...");
            else
                return str;
        }

        private void lstItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected)
                return;

            QbItemEditorBase editor;
            try
            {
                SendMessage(gboEdit.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
                clearEditor();


                QbItemBase itm = e.Item.Tag as QbItemBase;

                if (itm == null)
                    return;


                if (itm is QbItemScript)
                {
                    editor = new ScriptEditor();
                    ((ScriptEditor)editor).SelectedTabIndex = AppState.ScriptActiveTab;
                }
                else if ((itm.Format == QbFormat.ArrayPointer || itm.Format == QbFormat.ArrayValue) && itm.QbItemType != QbItemType.ArrayStruct && itm.QbItemType != QbItemType.ArrayArray)
                    editor = new SimpleArrayEditor();
                else
                    editor = new GenericQbItemEditor();
                editor.Updated += new UpdatedEventHandler(editor_Updated);
                editor.Error += new ErrorEventHandler(editor_Error);

                editor.QbItem = itm;
                editor.Left = 3;
                editor.Top = 14;
                editor.Width = gboEdit.Width - 6;
                editor.Height = gboEdit.Height - 17;
                editor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                gboEdit.Controls.Add(editor);
            }
            finally
            {
                SendMessage(gboEdit.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                gboEdit.Refresh();
            }

        }

        private void editor_Error(object sender, ErrorEventArgs e)
        {
            if (e.Exception != null)
                showException(e.Title, e.Exception);
            else
                showError(e.Title, e.Message);
        }

        private void editor_Updated(object sender, EventArgs e)
        {
            try
            {
                QbItemBase qbItem = (QbItemBase)lstQbItems.SelectedItems[0].Tag;

                if (lstQbItems.SelectedItems.Count != 0)
                {
                    ListViewItem li = lstQbItems.SelectedItems[0];

                    //update the itemqbkey text in the list view
                    li.SubItems[1].Text = (qbItem.ItemQbKey != null) ? qbItem.ItemQbKey.Text : string.Empty;
                    //refresh the item
                    lstItems_ItemSelectionChanged(lstQbItems, new ListViewItemSelectionChangedEventArgs(li, li.Index, true));
                }
                refreshListPosLength();
            }
            catch (Exception ex)
            {
                showException("Failed to Refresh List", ex);
                return;
            }

            btnSavePak.Enabled = true;
        }


        private void refreshListPosLength()
        {
            _qbFile.AlignPointers();
            QbItemBase qib;
            try
            {
                lstQbItems.BeginUpdate();
                foreach (ListViewItem li in lstQbItems.Items)
                {
                    qib = (QbItemBase)li.Tag;
                    li.SubItems[2].Text = getValueForList(qib);
                    li.SubItems[3].Text = string.Format("{0} ({1})", qib.Position.ToString("X").PadLeft(8, '0'), qib.Position.ToString());
                    li.SubItems[4].Text = qib.Length.ToString();

                }
            }
            finally
            {
                lstQbItems.EndUpdate();
            }

        }

        private void lstQbItems_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (lstQbItems.SelectedItems.Count == 0)
                    gboEdit.Controls.Clear();

                if (e.Button != MouseButtons.Right)
                    return;

                _addItemParent = null;
                _addItemSibling = null;

                int sIdx = lstQbItems.SelectedItems.Count > 0 ? lstQbItems.SelectedIndices[0] : -1;
                int pIdx; //parent index
                ToolStripMenuItem mi;
                QbItemType[] types = null;

                if (sIdx != -1)
                {
                    ListViewItem li = lstQbItems.SelectedItems[0];
                    _addItemSibling = (QbItemBase)li.Tag;


                    //find parent list item
                    if (li.IndentCount != 0)
                    {
                        pIdx = sIdx;
                        while (lstQbItems.Items[--pIdx].IndentCount != li.IndentCount - 1) ;
                        _addItemParent = (QbItemBase)lstQbItems.Items[pIdx].Tag;
                    }


                    for (int m = mnuInsertSibling.DropDownItems.Count - 1; m >= 0; m--)
                    {
                        mi = (ToolStripMenuItem)mnuInsertSibling.DropDownItems[m];
                        mi.Click -= new EventHandler(qbAddItemInsertSibling_Click);
                        mnuInsertSibling.DropDownItems.Remove(mi);
                    }

                    for (int m = mnuAddSibling.DropDownItems.Count - 1; m >= 0; m--)
                    {
                        mi = (ToolStripMenuItem)mnuAddSibling.DropDownItems[m];
                        mi.Click -= new EventHandler(qbAddItemAddSibling_Click);
                        mnuAddSibling.DropDownItems.Remove(mi);
                    }
                }


                //remove items and remove event handlers
                for (int m = mnuAddChild.DropDownItems.Count - 1; m >= 0; m--)
                {
                    mi = (ToolStripMenuItem)mnuAddChild.DropDownItems[m];
                    mi.Click -= new EventHandler(qbAddItemChild_Click);
                    mnuAddChild.DropDownItems.Remove(mi);
                }

                bool pasteAddChild = false;
                bool pasteInsertSibling = false;
                bool pasteAddSibling = false;

                //add new menu items
                types = QbFile.SupportedChildTypes(_addItemSibling == null ? QbItemType.Root : _addItemSibling.QbItemType);
                foreach (QbItemType qbt in types)
                {
                    string n = getMenuTypename(qbt);

                    if (_copyItem != null && qbt == _copyItem.QbItemType)
                        pasteAddChild = true;

                    mi = (ToolStripMenuItem)mnuAddChild.DropDownItems.Add(n, imgList.Images[getQbItemImageIndex(qbt)], qbAddItemChild_Click);
                    mi.Tag = qbt; // sIdx; //store selected index in list
                }

                if (sIdx != -1)
                {
                    types = QbFile.SupportedChildTypes(_addItemParent == null || _addItemSibling.QbItemType == QbItemType.Unknown ? QbItemType.Root : _addItemParent.QbItemType);
                    foreach (QbItemType qbt in types)
                    {
                        string n = getMenuTypename(qbt);

                        if (_copyItem != null && qbt == _copyItem.QbItemType)
                        {
                            pasteAddSibling = true;
                            if (_addItemSibling.QbItemType != QbItemType.Unknown) //cannot insert before unknown
                                pasteInsertSibling = true;
                        }

                        if (_addItemSibling.QbItemType != QbItemType.Unknown)
                        {
                            mi = (ToolStripMenuItem)mnuInsertSibling.DropDownItems.Add(n, imgList.Images[getQbItemImageIndex(qbt)], qbAddItemInsertSibling_Click);
                            mi.Tag = qbt; // sIdx; //store selected index in list
                        }
                        mi = (ToolStripMenuItem)mnuAddSibling.DropDownItems.Add(n, imgList.Images[getQbItemImageIndex(qbt)], qbAddItemAddSibling_Click);
                        mi.Tag = qbt; // sIdx; //store selected index in list
                    }
                }

                mnuQbEdit.Tag = sIdx;

                mnuAddChild.Enabled = (mnuAddChild.DropDownItems.Count != 0);
                mnuInsertSibling.Enabled = sIdx != -1 && (mnuInsertSibling.DropDownItems.Count != 0);
                mnuAddSibling.Enabled = sIdx != -1 && (mnuAddSibling.DropDownItems.Count != 0);
                mnuRemoveSibling.Enabled = _addItemSibling != null && _addItemSibling.QbItemType != QbItemType.Unknown;

                mnuPasteAddChild.Enabled = pasteAddChild && mnuAddChild.Enabled;
                mnuPasteInsertSibling.Enabled = pasteInsertSibling && mnuInsertSibling.Enabled;
                mnuPasteAddSibling.Enabled = pasteAddSibling && mnuAddSibling.Enabled;


                mnuCopyItems.Enabled = _addItemSibling != null && _addItemSibling.QbItemType != QbItemType.Unknown;
                if (_addItemSibling != null) //selected item
                    mnuCopyItems.Text = string.Format("Copy ({0})", getMenuTypename(_addItemSibling.QbItemType));
                else
                    mnuCopyItems.Text = "Copy";

                mnuPasteItems.Enabled = _copyItem != null;
                if (_copyItem != null)
                    mnuPasteItems.Text = string.Format("Paste ({0})", getMenuTypename(_copyItem.QbItemType));
                else
                    mnuPasteItems.Text = "Paste";

                mnuQbEdit.Show(lstQbItems, e.Location);
            }
            catch (Exception ex)
            {
                showException("Failed to create menu items.", ex);
                return;
            }
        }

        private void mnuCopyItems_Click(object sender, EventArgs e)
        {
            //clone so we can paste over multiple paks
            _copyItem = ((QbItemBase)lstQbItems.Items[(int)mnuQbEdit.Tag].Tag).Clone();
        }

        private void mnuPasteAddChild_Click(object sender, EventArgs e)
        {
            addItemChild(_copyItem.Clone());
        }

        private void mnuPasteInsertSibling_Click(object sender, EventArgs e)
        {
            addItemInsertSibling(_copyItem.Clone());
        }

        private void mnuPasteAddSibling_Click(object sender, EventArgs e)
        {
            addItemAddSibling(_copyItem.Clone());
        }


        private string getMenuTypename(QbItemType qbt)
        {
            string n = qbt.ToString();
            //if (n.StartsWith("Array"))
            //    n = n.Substring("Array".Length);
            //else if (n.StartsWith("StructItem"))
            //    n = n.Substring("StructItem".Length);
            //else if (n.StartsWith("Section"))
            //    n = n.Substring("Section".Length);
            return n;
        }


        private void qbAddItemChild_Click(object sender, EventArgs e)
        {
            QbItemBase qbi = QbFile.CreateQbItemType(_qbFile, (QbItemType)((ToolStripMenuItem)sender).Tag);
            //QbItemBase qbi = QbFile.CreateQbItemType(_qbFile, (QbItemType)Enum.Parse(typeof(QbItemType), ((ToolStripMenuItem)sender).Text));
            addItemChild(qbi);
        }


        private void qbAddItemInsertSibling_Click(object sender, EventArgs e)
        {
            QbItemBase qbi = QbFile.CreateQbItemType(_qbFile, (QbItemType)((ToolStripMenuItem)sender).Tag);
            //QbItemBase qbi = QbFile.CreateQbItemType(_qbFile, (QbItemType)Enum.Parse(typeof(QbItemType), (string)((ToolStripMenuItem)sender).Tag));
            addItemInsertSibling(qbi);
        }

        private void qbAddItemAddSibling_Click(object sender, EventArgs e)
        {
            QbItemBase qbi = QbFile.CreateQbItemType(_qbFile, (QbItemType)((ToolStripMenuItem)sender).Tag);
            //QbItemBase qbi = QbFile.CreateQbItemType(_qbFile, (QbItemType)Enum.Parse(typeof(QbItemType), ((ToolStripMenuItem)sender).Text));
            addItemAddSibling(qbi);
        }

        private void qbRemoveItem(object sender, EventArgs e)
        {
            try
            {

                if (!(mnuQbEdit.Tag is int))
                    return;
                if (_addItemSibling == null)
                    return;

                int selectedIndex = (int)mnuQbEdit.Tag;

                if (selectedIndex < 0)
                    return;

                if (_addItemParent == null)
                    _qbFile.RemoveItem(_addItemSibling);
                else
                    _addItemParent.RemoveItem(_addItemSibling);

                int nextIdx = lstQbItems.Items.Count - 1;
                int idnt = lstQbItems.Items[selectedIndex].IndentCount;
                for (int i = selectedIndex + 1; i < lstQbItems.Items.Count; i++)
                {
                    if (lstQbItems.Items[i].IndentCount <= idnt)
                    {
                        nextIdx = i;
                        break;
                    }
                }

                if (selectedIndex == nextIdx)
                    nextIdx--;

                QbItemBase selectItem = null;
                if (nextIdx >= 0 && nextIdx < lstQbItems.Items.Count)
                    selectItem = (QbItemBase)lstQbItems.Items[nextIdx].Tag;
                //            if (selectedIndex > 0)
                //                selectItem = (QbItemBase)lstQbItems.Items[selectedIndex - 1].Tag;

                _qbFile.AlignPointers();
                populateQbList(selectItem);
                btnSavePak.Enabled = true;
            }
            catch (Exception ex)
            {
                showException("Failed to remove item.", ex);
                return;
            }
        }

        private void addItemChild(QbItemBase newItem)
        {
            try
            {
                qbAddItemFloatAdjust(newItem, true);

                if (_addItemSibling != null)
                    _addItemSibling.AddItem(newItem);
                else
                    _qbFile.AddItem(newItem);

                _qbFile.AlignPointers();
                populateQbList(newItem);
                btnSavePak.Enabled = true;
            }
            catch (Exception ex)
            {
                showException("Failed to add child item.", ex);
                return;
            }
        }

        private void addItemInsertSibling(QbItemBase newItem)
        {
            try
            {
                qbAddItemFloatAdjust(newItem, false);

                if (_addItemParent == null)
                    _qbFile.InsertItem(newItem, _addItemSibling, true);
                else
                    _addItemParent.InsertItem(newItem, _addItemSibling, true);

                _qbFile.AlignPointers();
                populateQbList(newItem);
                btnSavePak.Enabled = true;
            }
            catch (Exception ex)
            {
                showException("Failed to insert sibling item.", ex);
                return;
            }
        }

        private void addItemAddSibling(QbItemBase newItem)
        {
            try
            {
                qbAddItemFloatAdjust(newItem, false);

                if (_addItemParent == null)
                    _qbFile.InsertItem(newItem, _addItemSibling, false);
                else
                    _addItemParent.InsertItem(newItem, _addItemSibling, false);

                _qbFile.AlignPointers();
                populateQbList(newItem);
                btnSavePak.Enabled = true;
            }
            catch (Exception ex)
            {
                showException("Failed to add sibling item.", ex);
                return;
            }
        }

        /// <summary>
        /// If the parent is a FLoatsX3 then adjust the float type.
        /// </summary>
        private void qbAddItemFloatAdjust(QbItemBase qbi, bool addChild)
        {
            if (qbi.QbItemType != QbItemType.Floats)
                return;

            if (addChild)
            {
                if (_addItemSibling.QbItemType == QbItemType.ArrayFloatsX3 || _addItemSibling.QbItemType == QbItemType.SectionFloatsX3 || _addItemSibling.QbItemType == QbItemType.StructItemFloatsX3)
                    ((QbItemFloats)qbi).Values = new float[3];
            }
            else
            {
                if (_addItemParent != null && (_addItemParent.QbItemType == QbItemType.ArrayFloatsX3 || _addItemParent.QbItemType == QbItemType.SectionFloatsX3 || _addItemParent.QbItemType == QbItemType.StructItemFloatsX3))
                    ((QbItemFloats)qbi).Values = new float[3];
            }
        }

        #endregion

        #region QB Search

        private bool isPakLoaded()
        {
            if (_pakFile == null)
            {
                showError("PAK Error", "There is no PAK file loaded.");
                tabs.SelectedTab = tabPak;
                return false;
            }
            return true;
        }

        private void btnStringSearch_Click(object sender, EventArgs e)
        {
            if (!isPakLoaded())
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                lstSearchResults.BeginUpdate();
                lstSearchResults.ListViewItemSorter = null;
                lstSearchResults.Items.Clear();

                QbItemString qbs;
                QbItemScript qbsc;
                string srch = txtStringSearch.Text.ToLower();
                searchQbFile(delegate(QbFile qbFile, QbItemBase item)
                {
                    if ((qbs = (item as QbItemString)) != null)
                    {
                        foreach (string s in qbs.Strings)
                        {
                            if (s.ToLower().Contains(srch))
                                addSearchListItem(s, qbFile, qbs);
                        }
                    }
                    else if ((qbsc = (item as QbItemScript)) != null)
                    {
                        foreach (ScriptString s in qbsc.Strings)
                        {
                            if (s.Text.ToLower().Contains(srch))
                                addSearchListItem(s.Text, qbFile, qbsc);
                        }
                    }

                });
                messageIfNoResults();
            }
            catch (Exception ex)
            {
                showException("String Search Error", ex);
            }
            finally
            {
                lstSearchResults.ListViewItemSorter = _lvwSearchColumnSorter;
                lstSearchResults.EndUpdate();

                this.Cursor = Cursors.Default;
            }
        }

        private void messageIfNoResults()
        {
            if (lstSearchResults.Items.Count == 0)
                MessageBox.Show(this, "No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnQbKeySearch_Click(object sender, EventArgs e)
        {
            if (!isPakLoaded())
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (err.GetError(txtQbKeySearch).Length != 0)
                    return;
                else
                {
                    if (!Regex.IsMatch(txtQbKeySearch.Text, "^[^ ]{2,}$"))
                    {
                        err.SetError(txtQbKeySearch, "Invalid QB Key Search, can not be blank and must be text or an even amount of characters, a valid example is artist or 1A4F98AF");
                        return;
                    }
                }

                lstSearchResults.BeginUpdate();
                lstSearchResults.ListViewItemSorter = null;
                lstSearchResults.Items.Clear();

                string srchOrig = txtQbKeySearch.Text.Trim();
                string srchStr = srchOrig.ToUpper();
                bool isCrc = Regex.IsMatch(txtQbKeySearch.Text, "^([A-F0-9]{2})+$");
                uint srchCrc = 0;

                QbItemQbKey qbq;
                if (isCrc)
                {
                    srchStr = srchStr.PadLeft(8, '0');
                    byte[] b;
                    if (srchStr.Length > 2)
                    {
                        b = new byte[srchStr.Length / 2];
                        for (int c = 0; c < srchStr.Length; c += 2)
                            b[c / 2] = byte.Parse(srchStr.Substring(c, 2), System.Globalization.NumberStyles.HexNumber);
                        if (BitConverter.IsLittleEndian) //convert to the way the Current architecture stores numbers
                            Array.Reverse(b);
                    }
                    else
                        return;


                    srchCrc = BitConverter.ToUInt32(b, 0);
                }
                else
                {
                    srchCrc = QbKey.Create(srchStr).Crc; //allow text searches when there's no debug file (partial text search won't work
                }


                searchQbFile(delegate(QbFile qbFile, QbItemBase item)
                {
                    if ((qbq = (item as QbItemQbKey)) != null)
                    {
                        foreach (QbKey qb in qbq.Values)
                        {
                            if (srchCrc == qb.Crc)
                                addSearchListItem(srchOrig, qbFile, qbq);
                            else if (!isCrc && (srchStr.Length == 0 || qb.Text.ToUpper().Contains(srchStr)))
                                addSearchListItem(qb.Text, qbFile, qbq);
                        }
                    }

                    if (item.ItemQbKey != null)
                    {
                        if (srchCrc == item.ItemQbKey.Crc)
                            addSearchListItem(srchOrig, qbFile, item);
                        else if (!isCrc && (srchStr.Length == 0 || item.ItemQbKey.Text.ToUpper().Contains(srchStr)))
                            addSearchListItem(item.ItemQbKey.Text, qbFile, item);
                    }
                });
                messageIfNoResults();
            }
            catch (Exception ex)
            {
                showException("QbKey Search Error", ex);
            }
            finally
            {
                lstSearchResults.ListViewItemSorter = _lvwSearchColumnSorter;
                lstSearchResults.EndUpdate();

                this.Cursor = Cursors.Default;

            }
        }

        private void btnNumberSearch_Click(object sender, EventArgs e)
        {
            if (!isPakLoaded())
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (err.GetError(txtNumberSearch).Length != 0)
                    return;
                else
                {
                    if (!Regex.IsMatch(txtNumberSearch.Text, @"^(-?[0-9]+|-?[0-9]+\.[0-9]+)$"))
                    {
                        err.SetError(txtNumberSearch, "Invalid Number Search, must be a valid number e.g. 10 or 10.0");
                        return;
                    }
                }

                lstSearchResults.BeginUpdate();
                lstSearchResults.ListViewItemSorter = null;
                lstSearchResults.Items.Clear();

                bool hasPoint = txtNumberSearch.Text.Contains(".");
                bool hasMinus = (txtNumberSearch.Text[0] == '-');

                double d = double.Parse(txtNumberSearch.Text);

                bool schFloat = true;
                bool schInt = !hasPoint && hasMinus;
                bool schUInt = !hasPoint && !hasMinus;
                float schF = 0;
                int schI = 0;
                uint schUI = 0;

                try
                {
                    schF = float.Parse(txtNumberSearch.Text);
                }
                catch
                {
                    schFloat = false;
                }

                try
                {
                    if (schInt)
                        schI = int.Parse(txtNumberSearch.Text);
                }
                catch
                {
                    schInt = false;
                }

                try
                {
                    if (schUInt = (schUInt && !schInt))
                        schUI = uint.Parse(txtNumberSearch.Text);
                }
                catch
                {
                    schUInt = false;
                }

                searchQbFile(delegate(QbFile qbFile, QbItemBase item)
                {
                    if (schFloat)
                    {
                        float[] fs = new float[0];

                        QbItemFloat q = (item as QbItemFloat);
                        if (q != null)
                            fs = q.Values;
                        else
                        {
                            QbItemFloats q2 = (item as QbItemFloats);
                            q2 = (item as QbItemFloats);
                            if (q2 != null)
                                fs = q2.Values;
                        }

                        foreach (float f in fs)
                        {
                            if (schF == f)
                                addSearchListItem(schF.ToString(), qbFile, item);
                        }
                    }

                    if (schInt)
                    {
                        QbItemInteger ii = (item as QbItemInteger);
                        if (ii != null)
                        {
                            foreach (int i in ii.Values)
                            {
                                if (schI == i)
                                    addSearchListItem(schI.ToString(), qbFile, item);
                            }
                        }
                    }
                        else if (schUInt)
                    {
                        QbItemInteger ii = (item as QbItemInteger);
                        if (ii != null)
                        {
                            foreach (int i in ii.Values)
                            {
                                if (schUI == i)
                                    addSearchListItem(schUI.ToString(), qbFile, item);
                            }
                        }
                    }
                    
                });



                messageIfNoResults();
            }
            catch (Exception ex)
            {
                showException("Number Search Error", ex);
            }
            finally
            {
                lstSearchResults.ListViewItemSorter = _lvwSearchColumnSorter;
                lstSearchResults.EndUpdate();

                this.Cursor = Cursors.Default;

            }
        }


        private void addSearchListItem(string found, QbFile qbFile, QbItemBase qib)
        {
            ListViewItem li = new ListViewItem(found);
            li.ImageIndex = getQbItemImageIndex(qib.QbItemType);
            li.SubItems.Add(qbFile.Filename);
            li.SubItems.Add(string.Format("{0} ({1})", qib.Position.ToString("X").PadLeft(8, '0'), qib.Position.ToString()));
            li.SubItems.Add(qib.QbItemType.ToString());
            lstSearchResults.Items.Add(li);
        }

        private void searchQbFile(testSearchItem callback)
        {
            QbFile qbf;
            foreach (PakHeaderItem phi in _pakFile.Headers.Values)
            {
                if (phi.PakFileType == PakItemType.Qb || phi.PakFileType == PakItemType.Sqb || phi.PakFileType == PakItemType.Midi)
                {
                    qbf = _pakFile.ReadQbFile(phi.Filename, loadDbgQBFile(phi.Filename));
                    searchItems(qbf, qbf.Items, callback);
                }
            }
        }

        private void searchItems(QbFile qbFile, List<QbItemBase> qibs, testSearchItem callback)
        {
            foreach (QbItemBase qib in qibs)
            {
                callback(qbFile, qib);
                if (qib.Items.Count != 0)
                    searchItems(qbFile, qib.Items, callback);
            }
        }

        private void lstSearchResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _lvwPakColumnSorter.Numeric = false;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwSearchColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_lvwSearchColumnSorter.Order == SortOrder.Ascending)
                    _lvwSearchColumnSorter.Order = SortOrder.Descending;
                else
                    _lvwSearchColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwSearchColumnSorter.SortColumn = e.Column;
                _lvwSearchColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lstSearchResults.Sort();
        }

        private void lstSearchResults_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem li;
            if (lstSearchResults.SelectedItems.Count != 0)
            {
                li = lstSearchResults.SelectedItems[0];
                if (_qbFile == null || (_qbFile != null && _qbFile.Filename != li.SubItems[1].Text))
                {
                    clearInterfaceQb();
                    _qbFile = _pakFile.ReadQbFile(li.SubItems[1].Text);
                    loadEditQBFile(_qbFile.Filename);
                }

                tabs.SelectedTab = tabQb;
                Application.DoEvents();

                bool found = false;
                foreach (ListViewItem lvi in lstQbItems.Items)
                {
                    if (lvi.SubItems[3].Text == li.SubItems[2].Text)
                    {
                        lvi.EnsureVisible();
                        lvi.Selected = true;

                        if (gboEdit.Controls.Count != 0)
                        {
                            if (gboEdit.Controls[0] is ScriptEditor)
                                ((ScriptEditor)gboEdit.Controls[0]).SelectedTabIndex = 0; //select strings tab
                        }

                        found = true;
                        break;
                    }
                }
                if (!found)
                    showError("Select Error", "Item position not found, this can happen if you have modified and saved the PAK after this search was performed.");
            }
        }

        private void txtStringSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
                btnStringSearch_Click(this, new EventArgs());
        }

        private void txtQbKeySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
                btnQbKeySearch_Click(this, new EventArgs());
        }

        private void txtNumberSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
                btnNumberSearch_Click(this, new EventArgs());
        }

        private void lstSearchResults_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lstPakContents.SelectedItems.Count != 0)
                {
                    mnuSearchFilter.Show(lstSearchResults, e.Location);
                }
            }
        }

        private void mnuSearchFilter_Click(object sender, EventArgs e)
        {
            ListViewItem li;
            if (lstSearchResults.SelectedItems.Count != 0)
                li = lstSearchResults.SelectedItems[0];
            else
                return;

            try
            {
                lstSearchResults.BeginUpdate();

                if (sender == mnuFOnItem || sender == mnuFOutItem)
                    filterSearchResults(0, sender == mnuFOnItem, li.SubItems[0].Text);
                else if (sender == mnuFOnFilename || sender == mnuFOutFilename)
                    filterSearchResults(1, sender == mnuFOnFilename, li.SubItems[1].Text);
                else if (sender == mnuFOnDataType || sender == mnuFOutDataType)
                    filterSearchResults(3, sender == mnuFOnDataType, li.SubItems[3].Text);
            }
            finally
            {
                lstSearchResults.EndUpdate();
            }
        }

        private void filterSearchResults(int colIndex, bool filterOn, string value)
        {
            for (int i = lstSearchResults.Items.Count - 1; i >= 0; i--)
            {
                if (filterOn)
                {
                    if (lstSearchResults.Items[i].SubItems[colIndex].Text != value)
                        lstSearchResults.Items.Remove(lstSearchResults.Items[i]);
                }
                else
                {
                    if (lstSearchResults.Items[i].SubItems[colIndex].Text == value)
                        lstSearchResults.Items.Remove(lstSearchResults.Items[i]);
                }
            }
        }

        #endregion

        #region Interface Routines
        private void clearInterface()
        {
            lstPakContents.Items.Clear();
            tlblPakFileInfo.Text = string.Empty;
            clearInterfaceSearch();
            clearInterfaceQb();
            mnuEditQBFile.Enabled = false;
            tabPak.Text = "PAK File";

            _pakFile = null;
            _dbgFile = null;
        }

        private void clearInterfaceSearch()
        {
            lstSearchResults.Items.Clear();
        }

        private void clearInterfaceQb()
        {
            lstQbItems.Items.Clear();
            clearEditor();
            tlblQbFileInfo.Text = string.Empty;
            btnSavePak.Enabled = false;
            tabQb.Text = "QB File";

            _qbFile = null;

            tabs.SelectedTab = tabPak;
        }

        private void clearEditor()
        {
            if (gboEdit.Controls.Count != 0)
            {
                QbItemEditorBase editor = (QbItemEditorBase)gboEdit.Controls[0];
                editor.Updated -= new UpdatedEventHandler(editor_Updated);
                editor.Error -= new ErrorEventHandler(editor_Error);
                gboEdit.Controls.Clear();
            }

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (_info == null)
            {
                _info = new InfoForm();
                _info.FormClosed += new FormClosedEventHandler(_info_FormClosed);
            }
            _info.Show();
            _info.BringToFront();

        }

        private void _info_FormClosed(object sender, FormClosedEventArgs e)
        {
            _info = null;
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveConfiguration();

            if (_info != null)
            {
                _info.FormClosed -= new FormClosedEventHandler(_info_FormClosed);
                _info.Close();
                _info = null;
            }
        }

        private void tabs_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabQb && btnSavePak.Enabled)
            {
                if (MessageBox.Show(this,
                    string.Format("You have not saved changes to the PAK file.{0}{0}Are you sure you want to leave this tab?", Environment.NewLine),
                    "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void EditorForm_Resize_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                AppState.SaveWindowInfo(this);
        }

        private void splitPak_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                AppState.SavePakSplitterInfo((SplitContainer)sender);
        }

        private void splitQb_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                AppState.SaveQbSplitterInfo((SplitContainer)sender);
        }

        private void splitSearch_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                AppState.SaveSearchSplitterInfo((SplitContainer)sender);
        }

        private void tlblLink_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start((string)((ToolStripStatusLabel)sender).Tag);
            }
            catch (Exception ex)
            {
                showException("Browse to URL Error", ex);
            }
        }

        private void showError(string title, string message)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void showException(string title, Exception ex)
        {
            showError(title, ex.Message);
        }

        private int getQbItemImageIndex(QbItemType t)
        {
            switch (t)
            {
                case QbItemType.SectionArray:
                case QbItemType.ArrayArray:
                case QbItemType.StructItemArray:
                    return 0;

                case QbItemType.SectionFloat:
                case QbItemType.SectionFloatsX2:
                case QbItemType.SectionFloatsX3:
                case QbItemType.ArrayFloat:
                case QbItemType.ArrayFloatsX2:
                case QbItemType.ArrayFloatsX3:
                case QbItemType.StructItemFloat:
                case QbItemType.StructItemFloatsX2:
                case QbItemType.StructItemFloatsX3:
                case QbItemType.Floats:
                    return 1;

                case QbItemType.SectionInteger:
                case QbItemType.ArrayInteger:
                case QbItemType.StructItemInteger:
                    return 2; //int

                case QbItemType.SectionQbKey:
                case QbItemType.SectionQbKeyString:
                case QbItemType.SectionStringPointer:
                case QbItemType.SectionQbKeyStringQs: //GH:GH
                case QbItemType.ArrayQbKey:
                case QbItemType.StructItemQbKey:
                case QbItemType.ArrayQbKeyString:
                case QbItemType.ArrayStringPointer: //GH:GH
                case QbItemType.ArrayQbKeyStringQs: //GH:GH
                case QbItemType.StructItemQbKeyString:
                case QbItemType.StructItemStringPointer:
                case QbItemType.StructItemQbKeyStringQs:
                    return 3;

                case QbItemType.SectionScript:
                    return 4;

                case QbItemType.SectionString:
                case QbItemType.ArrayString:
                case QbItemType.StructItemString:
                case QbItemType.SectionStringW:
                case QbItemType.ArrayStringW:
                case QbItemType.StructItemStringW:
                    return 5;

                case QbItemType.SectionStruct:
                case QbItemType.ArrayStruct:
                case QbItemType.StructItemStruct:
                case QbItemType.StructHeader:
                    return 6;

                case QbItemType.Unknown:
                    return 8;
                default:
                    return 9;
            }
        }

        private void loadConfiguration()
        {
            try
            {
                Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                int v = int.Parse(loadSetting(c, "ConfigVersion", "1"));

                AppState.InputFormat = loadSetting(c, "InputFormat", cboFormatType.Text);

                if (v < 3) //naming format changed
                {
                    for (int i = 0; i < cboFormatType.Items.Count; i++)
                    {
                        if (((string)cboFormatType.Items[i]).StartsWith(AppState.InputFormat))
                            AppState.InputFormat = (string)cboFormatType.Items[i];
                    }
                }

                AppState.PakFilename = loadSetting(c, "PakFilename");
                AppState.PabFilename = loadSetting(c, "PabFilename");
                AppState.DebugFilename = loadSetting(c, "DebugFilename");
                AppState.Backup = loadSetting(c, "Backup", "True") != "False";
                AppState.LastQbReplacePath = loadSetting(c, "LastQbReplacePath");
                AppState.LastQbExtractPath = loadSetting(c, "LastQbExtractPath");
                AppState.LastScriptPath = loadSetting(c, "LastScriptPath");
                AppState.LastArrayPath = loadSetting(c, "LastScriptPath");
                AppState.ScriptActiveTab = int.Parse(loadSetting(c, "ScriptActiveTab", "0"));
                AppState.LoadPakListColInfo(lstPakContents,
                    loadSetting(c, "PakListColWidths"),
                    loadSetting(c, "PakListColPositions"),
                    loadSetting(c, "PakListSort"));
                AppState.LoadSearchListColInfo(lstSearchResults,
                    loadSetting(c, "SearchListColWidths"),
                    loadSetting(c, "SearchListColPositions"),
                    loadSetting(c, "SearchListSort"));
                AppState.LoadQbListColInfo(lstQbItems,
                    loadSetting(c, "QbListColWidths"),
                    loadSetting(c, "QbListColPositions"));

                AppState.LoadWindowInfo(this, loadSetting(c, "WindowInfo"));

                AppState.LoadPakSplitterPosition(splitPak, loadSetting(c, "PakSplitterPosition"));
                AppState.LoadSearchSplitterPosition(splitSearch, loadSetting(c, "SearchSplitterPosition"));
                AppState.LoadQbSplitterPosition(splitQb, loadSetting(c, "QbSplitterPosition"));

                QbFile.AllowedScriptStringChars = loadSetting(c, "AllowedScriptStringChars", @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890\/?!""£$%^&*()-+{}[]'#@~?><,. =®©_");

                if (!QbFile.AllowedScriptStringChars.Contains("="))
                    QbFile.AllowedScriptStringChars = QbFile.AllowedScriptStringChars + "="; //added v1.1

                cboFormatType.Text = AppState.InputFormat;
                txtPakFile.Text = AppState.PakFilename;
                txtPabFile.Text = AppState.PabFilename;
                txtDebugFile.Text = AppState.DebugFilename;
                chkBackup.Checked = AppState.Backup;

                if (v == 1) //migrate from settings version 1
                {

                    int p;

                    //remove filename from path (bug in previous version)
                    if (AppState.LastQbReplacePath.Length != 0)
                    {
                        p = AppState.LastQbReplacePath.LastIndexOf('\\');
                        if (p != -1)
                            AppState.LastQbReplacePath = AppState.LastQbReplacePath.Substring(0, p);
                    }
                    if (AppState.LastQbExtractPath.Length != 0)
                    {
                        p = AppState.LastQbExtractPath.LastIndexOf('\\');
                        if (p != -1)
                            AppState.LastQbExtractPath = AppState.LastQbExtractPath.Substring(0, p);
                    }

                }

            }
            catch (Exception ex)
            {
                showException("Load Configuration Error", ex);
            }
        }

        private void saveConfiguration()
        {
            try
            {
                Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //always back this up. File paths only backed up when load is used
                AppState.Backup = chkBackup.Checked;

                saveSetting(c, "ConfigVersion", "3");
                saveSetting(c, "InputFormat", AppState.InputFormat);
                saveSetting(c, "PakFilename", AppState.PakFilename);
                saveSetting(c, "PabFilename", AppState.PabFilename);
                saveSetting(c, "DebugFilename", AppState.DebugFilename);
                saveSetting(c, "Backup", AppState.Backup.ToString());
                saveSetting(c, "LastQbReplacePath", AppState.LastQbReplacePath);
                saveSetting(c, "LastQbExtractPath", AppState.LastQbExtractPath);
                saveSetting(c, "LastScriptPath", AppState.LastScriptPath);
                saveSetting(c, "LastArrayPath", AppState.LastArrayPath);
                saveSetting(c, "ScriptActiveTab", AppState.ScriptActiveTab.ToString());

                AppState.SavePakListColInfo(lstPakContents);
                saveSetting(c, "PakListColPositions", AppState.PakListColPositions);
                saveSetting(c, "PakListColWidths", AppState.PakListColWidths);
                saveSetting(c, "PakListSort", AppState.PakListSort);

                AppState.SaveSearchListColInfo(lstSearchResults);
                saveSetting(c, "SearchListColPositions", AppState.SearchListColPositions);
                saveSetting(c, "SearchListColWidths", AppState.SearchListColWidths);
                saveSetting(c, "SearchListSort", AppState.SearchListSort);

                AppState.SaveQbListColInfo(lstQbItems);
                saveSetting(c, "QbListColPositions", AppState.QbListColPositions);
                saveSetting(c, "QbListColWidths", AppState.QbListColWidths);

                AppState.SaveWindowInfo(this);
                saveSetting(c, "WindowInfo", AppState.WindowInfo);

                saveSetting(c, "PakSplitterPosition", AppState.PakSplitterPosition.ToString());
                saveSetting(c, "SearchSplitterPosition", AppState.SearchSplitterPosition.ToString());
                saveSetting(c, "QbSplitterPosition", AppState.QbSplitterPosition.ToString());

                saveSetting(c, "AllowedScriptStringChars", QbFile.AllowedScriptStringChars);

                c.Save();
            }
            catch (Exception ex)
            {
                showException("Save Configuration Error", ex);
            }
        }

        private string loadSetting(Configuration c, string item)
        {
            return loadSetting(c, item, string.Empty);
        }

        private string loadSetting(Configuration c, string item, string defaultItem)
        {
            KeyValueConfigurationElement kvce;
            kvce = c.AppSettings.Settings[item];
            if (kvce != null)
                return kvce.Value;
            else
                return defaultItem;

        }

        private void saveSetting(Configuration c, string name, string value)
        {
            if (c.AppSettings.Settings[name] == null)
                c.AppSettings.Settings.Add(name, value);
            else
                c.AppSettings.Settings[name].Value = value;
        }

        private void txtQbKeySearch_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtQbKeySearch.Text, "^(|[^ ]{2,})$"))
            {
                err.SetError(txtQbKeySearch, "Invalid QB Key Search, can not be blank and must be text or an even amount of characters, a valid example is artist or 1A4F98AF");
                return;
            }
            else
                err.SetError(txtQbKeySearch, "");
        }

        private void txtNumberSearch_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtNumberSearch.Text, @"^(|-?[0-9]+|-?[0-9]+\.[0-9]+)$"))
            {
                err.SetError(txtNumberSearch, "Invalid Number Search, must be a valid number e.g. 10 or 10.0");
                return;
            }
            else
                err.SetError(txtNumberSearch, "");
        }

        #endregion

        #region Test Routines
        private void btnInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                btnTestSize.Visible = !btnTestSize.Visible;
                btnTestQbFile.Visible = !btnTestQbFile.Visible;
            }
        }

        private void btnTestSize_Click(object sender, EventArgs e)
        {
            PakEditor pak = null;

            try
            {
                pak = new PakEditor(_pakFormat);
            }
            catch (Exception ex)
            {
                showException("PAK Load Error", ex);
                return;
            }

            string saveQbName = string.Empty;
            try
            {
                int skipped = 0;
                foreach (PakHeaderItem phi in _pakFile.Headers.Values)
                {
                    saveQbName = string.Format(@"C:\gh3temp\__\{0}", phi.Filename.Replace(@"\", "#"));

                    if (phi.PakFileType == PakItemType.Qb || phi.PakFileType == PakItemType.Sqb || phi.PakFileType == PakItemType.Midi)
                    {
                        _pakFile.ExtractFile(phi.Filename, saveQbName);
                        testQbFile(saveQbName);
                    }
                    else
                        skipped++;
                }

                int c = (pak.Headers.Values.Count - skipped);
                MessageBox.Show(this, string.Format("PAK and {0} QB file{1} validated succesfully, {2} skipped", c.ToString(), c == 1 ? "" : "s", skipped.ToString()), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                showError("Test Size Error", string.Format("{0} in '{1}'", ex.Message, saveQbName));
                return;
            }
        }

        private void testQbFile(string filename)
        {
            QbFile qbf;
            QbFile qbTest;
            QbItemString qbs;

            qbf = new QbFile(filename, _pakFormat);
            searchItems(qbf, qbf.Items, delegate(QbFile qbFile, QbItemBase item)
            {
                if ((qbs = (item as QbItemString)) != null)
                {
                    for (int i = 0; i < qbs.Strings.Length; i++)
                        qbs.Strings[i] = "nanook";
                }
            });

            if (File.Exists(filename))
                File.Delete(filename);
            qbf.AlignPointers();
            qbf.Write(filename);

            qbTest = new QbFile(filename, _pakFormat);
            File.Delete(filename);
        }

        private void btnTestQbFile_Click(object sender, EventArgs e)
        {
            if (openInput.ShowDialog(this) != DialogResult.Cancel)
                testQbFile(openInput.FileName);
        }

        #endregion

        //2 temp variables for the add QB item context menu
        private QbItemBase _addItemParent;
        private QbItemBase _addItemSibling;

        private ListViewColumnSorter _lvwPakColumnSorter;
        private ListViewColumnSorter _lvwSearchColumnSorter;
        private PakEditor _pakFile;
        private PakEditor _dbgFile;
        private QbFile _qbFile;
        private InfoForm _info;
        private PakFormat _pakFormat;
        private Dictionary<string, PakFormatType> _formats;

        private QbItemBase _copyItem;




    }
}
