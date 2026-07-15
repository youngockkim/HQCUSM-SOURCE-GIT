using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.UTLCore
{
    public partial class frmDEVTest : Form
    {
        public frmDEVTest()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("In");
            TRSNode out_node = new TRSNode("Out");
            TRSNode array;
            TRSNode list;
            int i;
            FileInfo finfo;
            BinaryReader br;
            byte[] file_buffer;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = MPGC.MP_STEP_CREATE;

            in_node.AddString("TEST_ID", spdIn.ActiveSheet.Cells[0, 0].Value);
            in_node.AddString("NEXT_TEST_ID", spdIn.ActiveSheet.Cells[1, 0].Value);
            in_node.AddInt("TEST_INT", spdIn.ActiveSheet.Cells[2, 0].Value);
            in_node.AddFloat("TEST_FLOAT", spdIn.ActiveSheet.Cells[3, 0].Value);
            in_node.AddDouble("TEST_DOUBLE", spdIn.ActiveSheet.Cells[4, 0].Value);
            in_node.AddLong("TEST_LONG", spdIn.ActiveSheet.Cells[5, 0].Value);
            in_node.AddChar("TEST_CHAR", spdIn.ActiveSheet.Cells[6, 0].Value);
            in_node.AddString("TEST_STRING", spdIn.ActiveSheet.Cells[7, 0].Value);

            if(spdIn.ActiveSheet.Cells[8, 0].Value == null)
                in_node.AddBoolean("TEST_BOOL", spdIn.ActiveSheet.Cells[8, 0].Value);
            else
                in_node.AddBoolean("TEST_BOOL", (spdIn.ActiveSheet.Cells[8, 0].Value.ToString() == "T" ? true : false));

            in_node.AddBinary("TEST_BINARY", spdIn.ActiveSheet.Cells[9, 0].Value);
            if (spdIn.ActiveSheet.Cells[10, 0].Value == null)
                in_node.AddDatetime("TEST_DATETIME", spdIn.ActiveSheet.Cells[10, 0].Value);
            else
                in_node.AddDatetime("TEST_DATETIME", (DateTime)(spdIn.ActiveSheet.Cells[10, 0].Value));

            if (spdIn.ActiveSheet.Cells[11, 0].Value == null)
            {
                in_node.AddBlob("TEST_BLOB", spdIn.ActiveSheet.Cells[11, 0].Value);
            }
            else
            {
                finfo = new FileInfo(spdIn.ActiveSheet.Cells[11, 0].Value.ToString());
                if (finfo.Exists == false)
                {
                    in_node.AddBlob("TEST_BLOB", null);
                }
                else
                {
                    in_node.AddString("TEST_FILE_NAME", finfo.Name);

                    br = new BinaryReader(finfo.OpenRead());
                    file_buffer = br.ReadBytes((int)finfo.Length);
                    in_node.AddBlob("TEST_BLOB", file_buffer);
                    br.Close();
                }
            }

            array = in_node.AddArray("TEST_ARRAY", TRSArrayDataType.String);
            for (i = 0; i < spdAry.ActiveSheet.RowCount; i++)
            {
                array.AddItem(spdAry.ActiveSheet.Cells[i, 0].Value);
            }

            for (i = 0; i < spdList.ActiveSheet.RowCount; i += 4)
            {
                if (spdList.ActiveSheet.Cells[i, 0].Value != null)
                {
                    list = in_node.AddNode("TEST_LIST");

                    list.AddString("TEST_ID", spdList.ActiveSheet.Cells[i + 0, 0].Value);
                    list.AddInt("LIST_INT", spdList.ActiveSheet.Cells[i + 1, 0].Value);
                    list.AddDouble("LIST_DOUBLE", spdList.ActiveSheet.Cells[i + 2, 0].Value);
                    list.AddString("LIST_STRING", spdList.ActiveSheet.Cells[i + 3, 0].Value);
                }
            }

            if (MPCR.CallService("DEV", "DEV_Update_Member", in_node, ref out_node) == false)
            {
                return ;
            }

            MPCR.ShowSuccessMsg(out_node);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("In");
            TRSNode out_node = new TRSNode("Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = MPGC.MP_STEP_UPDATE;

            in_node.AddString("TEST_ID", spdIn.ActiveSheet.Cells[0, 0].Value);
            in_node.AddString("NEXT_TEST_ID", spdIn.ActiveSheet.Cells[1, 0].Value);
            in_node.AddInt("TEST_INT", spdIn.ActiveSheet.Cells[2, 0].Value);
            in_node.AddFloat("TEST_FLOAT", spdIn.ActiveSheet.Cells[3, 0].Value);
            in_node.AddDouble("TEST_DOUBLE", spdIn.ActiveSheet.Cells[4, 0].Value);
            in_node.AddLong("TEST_LONG", spdIn.ActiveSheet.Cells[5, 0].Value);
            in_node.AddChar("TEST_CHAR", spdIn.ActiveSheet.Cells[6, 0].Value);
            in_node.AddString("TEST_STRING", spdIn.ActiveSheet.Cells[7, 0].Value);

            if (spdIn.ActiveSheet.Cells[8, 0].Value == null)
                in_node.AddBoolean("TEST_BOOL", spdIn.ActiveSheet.Cells[8, 0].Value);
            else
                in_node.AddBoolean("TEST_BOOL", (spdIn.ActiveSheet.Cells[8, 0].Value.ToString() == "T" ? true : false));

            in_node.AddBinary("TEST_BINARY", spdIn.ActiveSheet.Cells[9, 0].Value);
            if (spdIn.ActiveSheet.Cells[10, 0].Value == null)
                in_node.AddDatetime("TEST_DATETIME", spdIn.ActiveSheet.Cells[10, 0].Value);
            else
                in_node.AddDatetime("TEST_DATETIME", (DateTime)(spdIn.ActiveSheet.Cells[10, 0].Value));

            if (MPCR.CallService("DEV", "DEV_Update_Member", in_node, ref out_node) == false)
            {
                return;
            }

            MPCR.ShowSuccessMsg(out_node);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("In");
            TRSNode out_node = new TRSNode("Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = MPGC.MP_STEP_DELETE;

            in_node.AddString("TEST_ID", spdIn.ActiveSheet.Cells[0, 0].Value);

            if (MPCR.CallService("DEV", "DEV_Update_Member", in_node, ref out_node) == false)
            {
                return;
            }

            MPCR.ShowSuccessMsg(out_node);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("In");
            TRSNode out_node = new TRSNode("Out");
            TRSNode list_item;
            int i;
            int i_row;

            MPCF.ClearList(spdOut);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            do
            {
                if (MPCR.CallService("DEV", "DEV_Update_Member", in_node, ref out_node) == false)
                {
                    return;
                }

                for (i = 0; i < out_node.GetList("TEST_LIST").Count; i++)
                {
                    i_row = spdOut.ActiveSheet.RowCount;
                    spdOut.ActiveSheet.RowCount++;

                    spdOut.ActiveSheet.Cells[i_row, 0].Value = out_node.GetList("TEST_LIST")[i].GetString("TEST_ID");
                    spdOut.ActiveSheet.Cells[i_row, 1].Value = out_node.GetList("TEST_LIST")[i].GetInt("TEST_INT");
                    spdOut.ActiveSheet.Cells[i_row, 2].Value = out_node.GetList("TEST_LIST")[i].GetFloat("TEST_FLOAT");
                    spdOut.ActiveSheet.Cells[i_row, 3].Value = out_node.GetList("TEST_LIST")[i].GetDouble("TEST_DOUBLE");
                    spdOut.ActiveSheet.Cells[i_row, 4].Value = out_node.GetList("TEST_LIST")[i].GetLong("TEST_LONG");
                    spdOut.ActiveSheet.Cells[i_row, 5].Value = out_node.GetList("TEST_LIST")[i].GetChar("TEST_CHAR");

                    list_item = out_node.GetList("TEST_LIST")[i];

                    spdOut.ActiveSheet.Cells[i_row, 6].Value = list_item.GetString("TEST_STRING");
                    spdOut.ActiveSheet.Cells[i_row, 7].Value = list_item.GetBoolean("TEST_BOOL");
                    spdOut.ActiveSheet.Cells[i_row, 8].Value = list_item.GetBinary("TEST_BINARY");
                    spdOut.ActiveSheet.Cells[i_row, 9].Value = list_item.GetDatetime("TEST_DATETIME");
                }

                in_node.SetString("NEXT_TEST_ID", out_node.GetString("NEXT_TEST_ID"));

            } while (in_node.GetString("NEXT_TEST_ID") != "");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}