using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Nanook.QueenBee.Parser;

namespace Nanook.QueenBee
{
    internal partial class GenericQbEditItem : UserControl
    {
        public GenericQbEditItem()
        {
            InitializeComponent();

            if (this.DesignMode)
                return;

            txtValue.ReadOnly = true;
            btnConvert.Text = string.Empty;

            txtValue.Validating += new CancelEventHandler(txtValue_Validating);

            txtValue.LostFocus += new EventHandler(txtValue_LostFocus);

        }

        private void mnu_Click(object sender, EventArgs e)
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

            txtValue.Text = _gItem.ConvertTo(t);
            btnConvert.Text = GenericQbItem.GetTypeName(t);
        }


        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            string errMsg = GenericQbItem.ValidateText(_gItem.Type, _gItem.CurrentEditType, txtValue.Text);
            err.SetError(txtValue, errMsg);
            if (errMsg.Length != 0)
                e.Cancel = true;
            else
                _gItem.Value = txtValue.Text;
        }

        private void txtValue_LostFocus(object sender, EventArgs e)
        {
            this.Validate();
        }

        public override string Text
        {
            get { return _gItem.ConvertTo(_gItem.Type); }
            set { txtValue.Text = value; }
        }

        public bool Readonly
        {
            get { return _gItem.ReadOnly; }
        }

        public Type DataType
        {
            get { return _gItem.Type; }
        }

        public int LabelWidth
        {
            get { return lbl.Width; }
        }

        public bool IsValid
        {
            get { return err.GetError(txtValue).Length == 0; }
        }

        public GenericQbItem GenericQbItem
        {
            get { return _gItem; }
        }

        public int TextBoxLeft
        {
            get { return txtValue.Left; }
            set
            {
                int w = (txtValue.Width + (txtValue.Left - value));
                txtValue.Left = value;
                txtValue.Width = w;

            }
        }

        public void SetData(GenericQbItem item)
        {
            _gItem = item;

            txtValue.ReadOnly = item.ReadOnly;

            if (!GenericQbItem.IsTypeSupported(item.Type))
                throw new ArgumentOutOfRangeException(string.Format("{0} is not supported", _gItem.Type.FullName));

            btnConvert.Text = GenericQbItem.GetTypeName(_gItem.CurrentEditType);

            lbl.Text = _gItem.Name;

            txtValue.Text = _gItem.Value;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (err.GetError(txtValue).Length == 0)
            {
                mnuFloat.Enabled = _gItem.CanConvertTo(typeof(float));
                mnuInt.Enabled = _gItem.CanConvertTo(typeof(int));
                mnuUint.Enabled = _gItem.CanConvertTo(typeof(uint));
                mnuHex.Enabled = _gItem.CanConvertTo(typeof(byte[]));
                mnuString.Enabled = _gItem.CanConvertTo(typeof(string));

                menu.Show(btnConvert, new Point(0, btnConvert.Height));
            }
        }

        public bool CanConvertTo(Type toType)
        {
            return _gItem.CanConvertTo(toType);
        }

        /// <summary>
        /// Convert text representations
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toType">Type to convert to</param>
        /// <returns></returns>
        public string ConvertTo(Type toType)
        {
            if (!GenericQbItem.IsTypeSupported(toType))
                throw new ArgumentOutOfRangeException(string.Format("{0} is not supported", toType.FullName));

            string s = _gItem.ConvertTo(toType);
            btnConvert.Text = GenericQbItem.GetTypeName(toType);
            txtValue.Text = s;
            return s;
        }


        public Type CurrentEditType
        {
            get { return _gItem.CurrentEditType; }
        }

        private GenericQbItem _gItem;

    }
}
