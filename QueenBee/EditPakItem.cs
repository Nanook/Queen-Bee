using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nanook.QueenBee.Parser;
using System.IO;

namespace Nanook.QueenBee
{
    public enum EditPakItemType
    {
        New,
        Add,
        Rename
    }

    public partial class EditPakItem : Form
    {


        public EditPakItem(EditPakItemType type)
        {
            InitializeComponent();

            bool b = type == EditPakItemType.Add;

            this.Height = b ? 180 : 150;
            txtImport.Visible = b;
            btnImport.Visible = b;
            lblImport.Visible = b;
            chkFilename.Visible = (type != EditPakItemType.Rename);

            cboFileType.Items.AddRange(Enum.GetNames(typeof(PakItemType)));

            chkFilename.Checked = true;

            switch (type)
            {
                case EditPakItemType.New:
                    this.Text = "New Pak Item";
                    break;
                case EditPakItemType.Add:
                    this.Text = "Add Pak Item";
                    break;
                case EditPakItemType.Rename:
                    this.Text = "Rename Pak Item";
                    break;
                default:
                    this.Text = "Edit Pak Item";
                    break;
            }

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
@"PAK headers contain certain information that must be specified.

Example: Using the Songlist QB file on the Wii the values would be:
    Path='scripts\guitar\songlist.qb.ngc'
    Type=Qb     Quick pick list.
    Other=.qb   Used when type is Other. 
    
    Check Include Filename in Header to include the filename in the PAK.
    
Note: GH3 Wii misses the first character from the path, you can include it to ensure header FileIds are correct
      The FileId doesn't appear to affect the game, it may just need to be unique.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool IncludeFileNameInHeader
        {
            get { return chkFilename.Checked; }
            set { chkFilename.Checked = value; }
        }

        public string PakItemFilename
        {
            get { return txtItemPath.Text.Trim(); }
            set { txtItemPath.Text = value; }
        }

        public QbKey ItemType
        {
            get
            {
                PakItemType type = (PakItemType)Enum.Parse(typeof(PakItemType), cboFileType.Text);

                if (type == PakItemType.Other)
                    return QbKey.Create(txtOther.Text.Trim().Length != 0 && txtOther.Text.StartsWith(".") ? txtOther.Text : "." + txtOther.Text);
                else
                    return PakHeaderItem.PakItemTypeToFileType(type);
            }
            set
            {
                PakItemType type = PakHeaderItem.FileTypeToPakItemType(value);

                if (type != PakItemType.Other && cboFileType.Items.Contains(type.ToString()))
                    cboFileType.SelectedItem = type.ToString();
                else
                {
                    cboFileType.SelectedItem = PakItemType.Other.ToString();
                    if (value.HasText)
                        txtOther.Text = value.Text;
                }
            }
        }

        public string ImportFilename
        {
            get { return txtImport.Text.Trim(); }
            set { txtImport.Text = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtOther.Visible && txtOther.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "The value of Other has not been specified", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.PakItemFilename.Trim().Length == 0)
            {
                MessageBox.Show(this, "The pak item filename has not been specified", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            open.Filter = "All files (*.*)|*.*";

            if (open.ShowDialog(this) != DialogResult.Cancel)
                txtImport.Text = open.FileName;
        }

        private void cboFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PakItemType type = (PakItemType)Enum.Parse(typeof(PakItemType), cboFileType.Text);
            txtOther.Visible = type == PakItemType.Other;
            lblOther.Visible = type == PakItemType.Other;
        }


    }
}
