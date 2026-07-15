using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace SOI.OIFrx.SOIModel
{
    public class PrintOptionModel
    {
        private LabelOptionModel _label;
        public LabelOptionModel Label
        {
            get { return _label; }
            set { _label = value; }
        }

        private DocumentOptionModel _document;
        public DocumentOptionModel Document
        {
            get { return _document; }
            set { _document = value; }
        }

        public PrintOptionModel()
        {
            this.Label = new LabelOptionModel();
            this.Document = new DocumentOptionModel();
        }
    }

    public class LabelOptionModel
    {
        public string ConnectionType { get; set; }
        public string Port { get; set; }
        public Parity Parity { get; set; }
        public int DataBit { get; set; }
        public StopBits StopBits { get; set; }
        public Handshake Handshake { get; set; }
        public int BaudRate { get; set; }
        public string PrinterName { get; set; }
    }

    public class DocumentOptionModel
    {
        public string PrinterName { get; set; }
    }
}
