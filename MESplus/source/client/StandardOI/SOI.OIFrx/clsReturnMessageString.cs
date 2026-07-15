using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Miracom.TRSCore;
using System.Collections;
using SOI.CliFrx;

namespace SOI.OIFrx
{
    public class ReturnMessageString
    {
        private bool m_bServerMsgFlag = false;
        private bool m_bNodeMsg = false;
        private string m_sMsgCode = "";
        private string m_sErrorMsg = "";
        private string m_sDBErrorMsg = "";
        private ArrayList m_arFieldMsg = new ArrayList();
        private List<TRSNode> m_out_node = new List<TRSNode>();
        private MSGBOX_ICON_TYPE m_eIconType = MSGBOX_ICON_TYPE.NONE;

        public bool IsServerMsgFlag
        {
            get
            {
                return m_bServerMsgFlag;
            }
            set
            {
                if (m_bServerMsgFlag.Equals(value) == false)
                {
                    m_bServerMsgFlag = value;
                }
            }
        }

        public bool IsNodeMsgFlag
        {
            get
            {
                return m_bNodeMsg;
            }
            set
            {
                if (m_bNodeMsg.Equals(value) == false)
                {
                    m_bNodeMsg = value;
                }
            }
        }

        public string MsgCode
        {
            get
            {
                return m_sMsgCode;
            }
            set
            {
                if (m_sMsgCode.Equals(value) == false)
                {
                    m_sMsgCode = value;
                }
            }
        }

        public string ErrorMsg
        {
            get
            {
                return m_sErrorMsg;
            }
            set
            {
                if (m_sErrorMsg.Equals(value) == false)
                {
                    m_sErrorMsg = value;
                }
            }
        }

        public string DBErrorMsg
        {
            get
            {
                return m_sDBErrorMsg;
            }
            set
            {
                if (m_sDBErrorMsg.Equals(value) == false)
                {
                    m_sDBErrorMsg = value;
                }
            }
        }

        public TRSNode SetFieldMsg
        {
            set
            {
                m_arFieldMsg.Clear();
                readFieldMsg(value);
            }
        }

        public ArrayList FieldMsg
        {
            get
            {
                return m_arFieldMsg;
            }
        }
        public List<TRSNode> OutNode
        {
            get
            {
                return m_out_node;
            }
            set
            {
                if (m_out_node.Equals(value) == false)
                {
                    m_out_node = value;
                }
            }
        }

        public MSGBOX_ICON_TYPE MsgBoxIconType
        {
            get
            {
                return m_eIconType;
            }
            set
            {
                m_eIconType = value;
            }
        }

        private void readFieldMsg(TRSNode node)
        {
            int i;
            string s_tmp;
            string s_value;

            for (i = 0; i < node.MemberCount; i++)
            {
                s_tmp = node.GetMember(i).Name;
                s_value = node.GetMember(i).Value;

                s_tmp += " = [" + s_value + "]";
                m_arFieldMsg.Add(s_tmp);
            }
        }

    }
}
