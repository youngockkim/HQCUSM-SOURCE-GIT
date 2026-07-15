using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOI.OIFrx.SOIModel
{
    public class ErrorModel
    {
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
            }
        }

        private String _msgCode;
        public String MsgCode
        {
            get { return _msgCode; }
            set
            {
                _msgCode = value;
            }
        }

        private String _errorMsg;
        public String ErrorMsg
        {
            get { return _errorMsg; }
            set
            {
                _errorMsg = value;
            }
        }

        private char _statusValue;
        public char StatusValue
        {
            get { return _statusValue; }
            set
            {
                _statusValue = value;
            }
        }

        private char _msgCate;
        public char MsgCate
        {
            get { return _msgCate; }
            set
            {
                _msgCate = value;
            }
        }

        private String _dbErrorMsg;
        public String DBErrorMsg
        {
            get { return _dbErrorMsg; }
            set
            {
                _dbErrorMsg = value;
            }
        }

        private List<FieldMsg> _fieldMsg;
        public List<FieldMsg> FieldMsg
        {
            get { return _fieldMsg; }
            set
            {
                _fieldMsg = value;
            }
        }

        private string _issueDate;
        public string IssueDate
        {
            get { return _issueDate; }
            set
            {
                _issueDate = value;
            }
        }
    }

    public class FieldMsg
    {

        private String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        private String _text;
        public String Text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }

        private String _type;
        public String Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }
    }
}
