using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Nanook.QueenBee.Parser;

namespace Nanook.QueenBee
{
    internal delegate void UpdatedEventHandler(object sender, EventArgs e);
    internal delegate void ErrorEventHandler(object sender, ErrorEventArgs e);

    internal partial class QbItemEditorBase : UserControl
    {

        public event UpdatedEventHandler Updated;
        public event ErrorEventHandler Error;

        public QbItemEditorBase()
        {
            InitializeComponent();
        }

        private void QbItemEditorBase_Load(object sender, EventArgs e)
        {

        }

        protected virtual void OnUpdated(EventArgs e)
        {
            if (Updated != null)
                Updated(this, e);
        }

        protected virtual void OnError(ErrorEventArgs e)
        {
            if (Error != null)
                Error(this, e);
        }

        protected void ShowError(string title, string message)
        {
            OnError(new ErrorEventArgs(title, message));
        }

        protected void ShowException(string title, Exception ex)
        {
            OnError(new ErrorEventArgs(title, ex));
        }

        protected void AddQbKeyToUserDebugFile(QbKey qbKey)
        {
            string qbKeyText = string.Empty;

            if (qbKey == null)
                return;

            if ((qbKeyText = _qbItemBase.Root.PakFormat.AddNonDebugQbKey(qbKey, _qbItemBase.Root.Filename, _qbItemBase.Root)).Length != 0)
                this.ShowError("QB Key Error", string.Format("QB Key '{0}' has the same crc as item '{1}' from the debug file.{2}{2}The QbKey text '{0}' will not be saved to the User Debug file.", qbKey.Text, qbKeyText, Environment.NewLine));
        }


        /// <summary>
        /// Raise an event to the parent 
        /// </summary>
        protected void UpdateQbItem()
        {
            this.OnUpdated(new EventArgs());
        }

        protected Type QbItemDataType
        {
            get
            {
                switch (_qbItemBase.QbItemType)
                {
                    case QbItemType.ArrayInteger:
                    case QbItemType.SectionInteger:
                    case QbItemType.StructItemInteger:
                        return typeof(int);

                    case QbItemType.SectionFloat:
                    case QbItemType.SectionFloatsX2:
                    case QbItemType.SectionFloatsX3:
                    case QbItemType.ArrayFloat:
                    case QbItemType.StructItemFloat:
                    case QbItemType.StructItemFloatsX2:
                    case QbItemType.StructItemFloatsX3:
                    case QbItemType.Floats:
                        return typeof(float);

                    case QbItemType.SectionString:
                    case QbItemType.ArrayString:
                    case QbItemType.StructItemString:
                    case QbItemType.SectionStringW:
                    case QbItemType.ArrayStringW:
                    case QbItemType.StructItemStringW:
                        return typeof(string);

                    case QbItemType.SectionQbKey:
                    case QbItemType.ArrayQbKey:
                    case QbItemType.ArrayQbKeyString:
                    case QbItemType.ArrayStringPointer: //GH:GH
                    case QbItemType.ArrayQbKeyStringQs: //GH:GH
                    case QbItemType.StructItemQbKey:
                    case QbItemType.StructItemQbKeyString:
                    case QbItemType.StructItemStringPointer:
                    case QbItemType.StructItemQbKeyStringQs:
                    case QbItemType.Unknown:
                        return typeof(byte[]);

                    default:
                        return typeof(byte[]);
                }
            }
        }

        public QbItemBase QbItem
        {
            get { return _qbItemBase; }
            set { _qbItemBase = value; }
        }


        private QbItemBase _qbItemBase;
    }
}
