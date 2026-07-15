using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace SECSParser
{
    public partial class Form1 : Form
    {
        Dictionary<String, XmlNode> smgMaster, hmgMaster;

        Dictionary<string, string> m = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
            XmlDocument model = new XmlDocument();
            try
            {
                model.Load("SecsCommon.ssm");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Can't find SecsCommon.ssm file!");
            }

            XmlNodeList smgList = model.GetElementsByTagName("SMG");
            XmlNodeList hmgList = model.GetElementsByTagName("HMG");
            smgMaster = new Dictionary<String, XmlNode>();
            hmgMaster = new Dictionary<String, XmlNode>();

            for (int x = 0; x < smgList.Count; x++)
            {
                smgMaster[Attribute(smgList[x], "N")] = smgList[x];
                comboBoxSmg1.Items.Add(Attribute(smgList[x], "N"));
            }

            for (int x = 0; x < hmgList.Count; x++)
            {
                hmgMaster[Attribute(hmgList[x], "N")] = hmgList[x];
                comboBoxHmg1.Items.Add(Attribute(hmgList[x], "N"));
            }
        }

        private string Attribute(XmlNode node, string attribute)
        {
            return node == null || node.Attributes[attribute] == null ? "" : node.Attributes[attribute].Value;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<object> args = e.Argument as List<object>;
            List<string> inputList = new List<string>();
            string type = args[0] as string;
            string[] fileNames = args[1] as string[];
            int fileCount = 0;

            foreach (string input in inputTextBox.Text.Split('\n'))
            {
                if (input.Trim().Length > 0)
                {
                    inputList.Add(input.Trim());
                }
            }
            foreach (string filename in fileNames)
            {
                if (processButton.Text.Equals("Process")) return;
                fileCount++;
                string buffer = "";
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                if (type.Equals("DEFECT"))
                {
                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("EAPMES_Collect_Inspection_Data_Sualab"))
                        {
                            string lotId = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                            string resId = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            string gemClock = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");
                            string result = Attribute(hmg.SelectSingleNode(".//HIT[@N='RESULT']"), "V");
                            string mode = Attribute(hmg.SelectSingleNode(".//HIT[@N='MODE']"), "V");


                            if (result.Equals("1"))
                            {
                                int loss_seq = 1;
                                string head = "INSERT INTO CWIPCELLOS_TEMP (FACTORY, LOSS_CATEGORY, CELL_ID, LOSS_SEQ, LOSS_QTY, STRING_ID, LOSS_TYPE, LOSS_GROUP, LOT_ID, MAT_ID, FLOW, OPER, ORDER_ID, LINE_ID, RES_ID, STATUS_FLAG, INV_LOT_ID, TYPE_FLAG, LOSS_COMMENT, CMF_1, CMF_2, CMF_3, CMF_4, CMF_5, CREATE_TIME, TRAN_TIME, WORK_DATE, WORK_SHIFT, WORKER, INS_CNT, LOT_HIST_SEQ, RESULT_VALUE, LOSS_CODE, LOCATION_ID, LOC_X, LOC_Y) VALUES ('USGAM1', 'E1', '" + lotId + "', '";

                                XmlNode paramlist = hmg.SelectSingleNode(".//HIT[@N='INSPECTION_LIST']");
                                if (paramlist != null)
                                {
                                    foreach (XmlNode param in paramlist.ChildNodes)
                                    {
                                        string locId = Attribute(param.SelectSingleNode(".//HIT[@N='AOI_LOCATION']"), "V");
                                        string defect = Attribute(param.SelectSingleNode(".//HIT[@N='AOI_REASON_CODE']"), "V");

                                        buffer += head + +loss_seq + "', 0, ' ', ' ', ' ', '" + lotId + "', ' ', ' ', ' ', (SELECT ORDER_ID FROM CEDCLOTRLT WHERE INS_TYPE='E1' AND LOT_ID='" + lotId + "'), (SELECT LINE_ID FROM CEDCLOTRLT WHERE INS_TYPE='E1' AND LOT_ID='" + lotId + "'), '" + resId + "', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '" + gemClock.Substring(0, 14) + "', '" + gemClock.Substring(0, 14) + "', ' ', ' ', ' ', (SELECT INS_CNT FROM CEDCLOTRLH WHERE LOT_ID = '" + lotId + "' AND TO_DATE(INS_TIME, 'YYYYMMDDHH24MISS') BETWEEN TO_DATE('" + gemClock.Substring(0, 12) + "', 'YYYYMMDDHH24MISS')-1/1440 AND TO_DATE('" + gemClock.Substring(0, 12) + "', 'YYYYMMDDHH24MISS')+1/1440 AND INS_TYPE = 'E1'), (SELECT LAST_HIST_SEQ FROM CEDCLOTRLT WHERE INS_TYPE='E1' AND LOT_ID='" + lotId + "'), '" + result + "', " + "'" + defect + "', '" + locId + "', '" + locId.Substring(0, 1) + "', '" + locId.Substring(1) + "');\r\n";
                                        loss_seq++;
                                    }
                                }
                            }
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("MAGAZINE"))
                {
                    XmlNodeList smgList = doc.GetElementsByTagName("SMG");
                    for (int x = 0; x < smgList.Count; x++)
                    {
                        XmlNode smg = smgList[x];
                        string ceid = Attribute(smg.SelectSingleNode(".//SIT[@N='CEID']"), "V");
                        string eqpid = Attribute(smg.SelectSingleNode(".//SIT[@N='EQPID']"), "V");
                        string gem_clock = Attribute(smg.SelectSingleNode(".//SIT[@N='GEM_CLOCK']"), "V");
                        string magazine = Attribute(smg.SelectSingleNode(".//SIT[@N='EQUIPMENTTYPE']"), "V");
                        string vmagazine_id = Attribute(smg.SelectSingleNode(".//SIT[@N='VMAGAZINEID']"), "V");
                        string cell_id = Attribute(smg.SelectSingleNode(".//SIT[@N='CELLID']"), "V");

                        m[ceid] = ceid + "\t" + eqpid + "\t" + magazine + "\t" + vmagazine_id + "\t" + cell_id + "\t" + gem_clock + "\r\n";

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)smgList.Count * 100));
                    }
                }
                else if (type.Equals("CLEAVING"))
                {
                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("MESEAP_Assign_Magazine_To_Cart"))
                        {
                            string resId = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            string orgMsgId = Attribute(hmg.SelectSingleNode(".//HIT[@N='ORG_MSG_ID']"), "V");
                            string clientTime = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");
                            string orderId = Attribute(hmg.SelectSingleNode(".//HIT[@N='ORDER_ID']"), "V");

                            if (!orgMsgId.Equals(""))
                            {
                                buffer += resId + "\t" + clientTime + "\t" + orgMsgId + "\t" + orderId + "\r\n";
                            }
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("TABBER"))
                {
                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("MESEAP_Collect_Process_Data_String"))
                        {
                            string resId = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            string orgMsgId = Attribute(hmg.SelectSingleNode(".//HIT[@N='ORG_MSG_ID']"), "V");
                            string clientTime = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");
                            string stringId = Attribute(hmg.SelectSingleNode(".//HIT[@N='STRING_ID']"), "V");

                            if (orgMsgId.Equals("WIP-0561"))
                            {
                                buffer += resId + "\t" + clientTime + "\t" + orgMsgId + "\t" + stringId + "\r\n";
                            }
                        }
                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }

                else if (type.Equals("LOT"))
                {
                    List<string> list = new List<string>();
                    list.Add("");

                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Contains("MESEAP_") || Attribute(hmg, "N").Contains("EAPMES_"))
                        {
                            string lotId = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                            string resId = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            string message = Attribute(hmg, "N");
                            string clientTime = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");
                            if (!list.Contains(lotId)) continue;
                            buffer += message + "\t" + resId + "\t" + clientTime + "\t" + lotId + "\r\n";

                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("AOI"))
                {
                    XmlNodeList smgList = doc.GetElementsByTagName("SMG");
                    for (int x = 0; x < smgList.Count; x++)
                    {
                        XmlNode smg = smgList[x];
                        if (Attribute(smg, "N").Equals("InspectionResultReportSend"))
                        {
                            string ceid = Attribute(smg.SelectSingleNode(".//SIT[@N='CEID']"), "V");
                            string eqpid = Attribute(smg.SelectSingleNode(".//SIT[@N='EQPID']"), "V");
                            string gemclock = Attribute(smg.SelectSingleNode(".//SIT[@N='GEM_CLOCK']"), "V");

                            if (eqpid.Contains("-AOI-") || eqpid.Contains("-MVI-"))
                            {
                                string moduleid = Attribute(smg.SelectSingleNode(".//SIT[@N='MODULEID']"), "V");
                                string result = Attribute(smg.SelectSingleNode(".//SIT[@N='RESULT']"), "V");

                                if (!inputList.Contains(moduleid) && inputList.Count > 0) continue;

                                Dictionary<string, int> dictionary144 = new Dictionary<string, int>();
                                dictionary144.Add("IG_A1", 0);
                                dictionary144.Add("IG_A2", 1);
                                dictionary144.Add("IG_A12", 2);
                                dictionary144.Add("IG_A13", 3);
                                dictionary144.Add("IG_A23", 4);
                                dictionary144.Add("IG_A24", 5);
                                dictionary144.Add("IG_F1", 6);
                                dictionary144.Add("IG_F2", 7);
                                dictionary144.Add("IG_F12", 8);
                                dictionary144.Add("IG_F13", 9);
                                dictionary144.Add("IG_F23", 10);
                                dictionary144.Add("IG_F24", 11);
                                dictionary144.Add("IG_AA", 12);
                                dictionary144.Add("IG_B1", 13);
                                dictionary144.Add("IG_C1", 14);
                                dictionary144.Add("IG_D1", 15);
                                dictionary144.Add("IG_E1", 16);
                                dictionary144.Add("IG_FA", 17);
                                dictionary144.Add("IG_AZ", 18);
                                dictionary144.Add("IG_B24", 19);
                                dictionary144.Add("IG_C24", 20);
                                dictionary144.Add("IG_D24", 21);
                                dictionary144.Add("IG_E24", 22);
                                dictionary144.Add("IG_FZ", 23);

                                Dictionary<string, int> dictionary120 = new Dictionary<string, int>();
                                dictionary120.Add("IG_A1", 0);
                                dictionary120.Add("IG_A2", 1);
                                dictionary120.Add("IG_A10", 2);
                                dictionary120.Add("IG_A11", 3);
                                dictionary120.Add("IG_A19", 4);
                                dictionary120.Add("IG_A20", 5);
                                dictionary120.Add("IG_F1", 6);
                                dictionary120.Add("IG_F2", 7);
                                dictionary120.Add("IG_F10", 8);
                                dictionary120.Add("IG_F11", 9);
                                dictionary120.Add("IG_F19", 10);
                                dictionary120.Add("IG_F20", 11);
                                dictionary120.Add("IG_AA", 12);
                                dictionary120.Add("IG_B1", 13);
                                dictionary120.Add("IG_C1", 14);
                                dictionary120.Add("IG_D1", 15);
                                dictionary120.Add("IG_E1", 16);
                                dictionary120.Add("IG_FA", 17);
                                dictionary120.Add("IG_AZ", 18);
                                dictionary120.Add("IG_B20", 19);
                                dictionary120.Add("IG_C20", 20);
                                dictionary120.Add("IG_D20", 21);
                                dictionary120.Add("IG_E20", 22);
                                dictionary120.Add("IG_FZ", 23);

                                List<string> data = new List<string>();
                                data.Add(gemclock.Substring(0, 14));
                                data.Add(eqpid);
                                data.Add(moduleid);
                                data.Add(result);

                                XmlNode paramlist = smg.SelectSingleNode(".//SIT[@N='PARAM_LIST']");
                                if (paramlist != null)
                                {
                                    string size = "144";

                                    for (int y = 0; y < paramlist.ChildNodes.Count; y++)
                                    {
                                        Dictionary<string, int> d = dictionary144;
                                        string name = Attribute(paramlist.ChildNodes[y].ChildNodes[0], "V").Replace("AOI02_", "").Replace("AOI01_", "");
                                        string value = Attribute(paramlist.ChildNodes[y].ChildNodes[1], "V");

                                        if (!d.Keys.Contains(name))
                                        {
                                            d = dictionary120;
                                            size = "120";
                                        }
                                        while (y < d[name])
                                        {
                                            data.Add("");
                                        }

                                        data.Add(value);
                                    }

                                    if (paramlist.ChildNodes.Count == 0)
                                    {
                                        for (int y = 0; y < 24; y++)
                                        {
                                            data.Add("");
                                        }
                                    }

                                    data.Add(size);

                                    string query = "INSERT INTO CEDCLOTAOI (INS_TIME,RES_ID,LOT_ID,RESULT_VALUE,DATA_1,DATA_2,DATA_3,DATA_4,DATA_5,DATA_6,DATA_7,DATA_8,DATA_9,DATA_10,DATA_11,DATA_12,DATA_13,DATA_14,DATA_15,DATA_16,DATA_17,DATA_18,DATA_19,DATA_20,DATA_21,DATA_22,DATA_23,DATA_24,CMF_1,INS_USER_ID,FACTORY,LINE_ID,OPER,INS_TYPE,INS_CNT,INS_SEQ,LOT_HIST_SEQ,CMF_2,CMF_3,CMF_4,CMF_5,CMF_6,CMF_7,CMF_8,CMF_9,CMF_10)";
                                    query += " VALUES ('" + String.Join("' , '", data.ToArray()) + "', ";
                                    query += "' ', 'USGAM1', 'MDL0" + data[1].ToString().Substring(4, 1) + "', 'M3020', 'ET', (SELECT NVL(MAX(INS_CNT), 0)+1 FROM CEDCLOTAOI WHERE LOT_ID = '" + data[2] + "'), (SELECT NVL(MAX(INS_SEQ), 0)+1 FROM CEDCLOTAOI WHERE LOT_ID = '" + data[2] + "'), -1, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ');";
                                    buffer += query + "\r\n";
                                }

                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3020' AND TRAN_CODE = 'START' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3020' AND TRAN_CODE = 'END' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3020', OPER = 'M3020', START_RES_ID = '" + eqpid + "', END_RES_ID = ' ', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-2 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'START' AND OLD_OPER < 'M3020' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3020', OPER = 'M3030', START_RES_ID = '" + eqpid + "', END_RES_ID = '" + eqpid + "', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-1 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'END' AND OLD_OPER < 'M3020' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET SYS_TRAN_TIME = TRAN_TIME, START_TIME = TRAN_TIME, END_TIME = TRAN_TIME, CREATE_TIME = TRAN_TIME, FAC_IN_TIME = TRAN_TIME, FLOW_IN_TIME = TRAN_TIME, OPER_IN_TIME = TRAN_TIME, OLD_FAC_IN_TIME = TRAN_TIME, OLD_FLOW_IN_TIME = TRAN_TIME, OLD_OPER_IN_TIME = TRAN_TIME WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH_TEMP SELECT /*+ INDEX(CEDCLOTRLH, CEDCLOTRLH_PK) */ * FROM CEDCLOTRLH WHERE FACTORY = 'USGAM1' AND INS_CNT = 1 AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY INS_TIME;\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET OPER = 'M3020', INS_TYPE = 'ET', CMF_2 = ' ', CMF_3 = ' ', CMF_4 = ' ', CMF_5 = ' ', RES_ID = '" + eqpid + "', INS_TIME = (SELECT MAX(TRAN_TIME) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3020' AND TRAN_CODE = 'START' AND LOT_ID = '" + moduleid + "'), RESULT_VALUE = '" + result + "' WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET RESULT_TIME = INS_TIME, CMF_1 = INS_TIME WHERE INS_TYPE = 'ET' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS SELECT * FROM MWIPLOTHIS_TEMP WHERE OLD_OPER = 'M3020' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'ET' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLT SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'ET' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLT SET (LAST_HIST_SEQ, INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT) = (SELECT (SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3020' AND LOT_ID = '" + moduleid + "'), INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'ET' AND LOT_ID = '" + moduleid + "')  WHERE INS_TYPE = 'ET' AND LOT_ID = '" + moduleid + "';\r\n\r\n";

                            }
                        }
                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)smgList.Count * 100));
                    }
                }
                else if (type.Equals("SIM"))
                {
                    Dictionary<string, string> d = new Dictionary<string, string>();
                    d.Add("I_SIM_01_VOC", "VOC");
                    d.Add("I_SIM_01_EFF", "EFF");
                    //d.Add("I_SIM_01_ENV_TEMP", "TREF");
                    d.Add("I_SIM_01_FF", "FF");
                    d.Add("I_SIM_01_IMAX", "IMPP");
                    d.Add("I_SIM_01_ISC", "ISC");
                    d.Add("I_SIM_01_MODULE_TEMP", "TEMP");
                    d.Add("I_SIM_01_PMAX", "PMPP");
                    d.Add("I_SIM_01_RESULT", "EL");
                    d.Add("I_SIM_01_RS", "RS");
                    d.Add("I_SIM_01_RSH", "RSH");
                    d.Add("I_SIM_01_SUN", "SUN");
                    d.Add("I_SIM_01_SURF_TEMP", "SURFTEMP");
                    d.Add("I_SIM_01_VMAX", "VMPP");

                    List<string> list = new List<string>();
                    list.Add("I_SIM_01_VOC");
                    list.Add("I_SIM_01_EFF");
                    //list.Add("I_SIM_01_ENV_TEMP");
                    list.Add("I_SIM_01_FF");
                    list.Add("I_SIM_01_IMAX");
                    list.Add("I_SIM_01_ISC");
                    list.Add("I_SIM_01_MODULE_TEMP");
                    list.Add("I_SIM_01_PMAX");
                    list.Add("I_SIM_01_RESULT");
                    list.Add("I_SIM_01_RS");
                    list.Add("I_SIM_01_RSH");
                    list.Add("I_SIM_01_SUN");
                    list.Add("I_SIM_01_SURF_TEMP");
                    list.Add("I_SIM_01_VMAX");

                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("EAPMES_Collect_Inspection_Data"))
                        {
                            string eqpid = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            if (eqpid.Contains("-SIM-"))
                            {
                                string moduleid = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                                string result = Attribute(hmg.SelectSingleNode(".//HIT[@N='RESULT']"), "V");
                                string gemclock = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");

                                if (!inputList.Contains(moduleid) && inputList.Count > 0) continue;

                                buffer += "DELETE FROM MWIPLOTHIS_TEMP;\r\n";
                                buffer += "DELETE FROM CEDCLOTRLH_TEMP;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3050' AND TRAN_CODE = 'START' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3050' AND TRAN_CODE = 'END' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3050', OPER = 'M3050', START_RES_ID = '" + eqpid + "', END_RES_ID = ' ', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-2 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'START' AND OLD_OPER < 'M3050' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3050', OPER = 'M3060', START_RES_ID = '" + eqpid + "', END_RES_ID = '" + eqpid + "', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-1 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'END' AND OLD_OPER < 'M3050' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET SYS_TRAN_TIME = TRAN_TIME, START_TIME = TRAN_TIME, END_TIME = TRAN_TIME, CREATE_TIME = TRAN_TIME, FAC_IN_TIME = TRAN_TIME, FLOW_IN_TIME = TRAN_TIME, OPER_IN_TIME = TRAN_TIME, OLD_FAC_IN_TIME = TRAN_TIME, OLD_FLOW_IN_TIME = TRAN_TIME, OLD_OPER_IN_TIME = TRAN_TIME WHERE LOT_ID = '" + moduleid + "';\r\n";
                                //buffer += "INSERT INTO CEDCLOTRLH_TEMP SELECT /*+ INDEX(CEDCLOTRLH, CEDCLOTRLH_PK) */ * FROM CEDCLOTRLH WHERE FACTORY = 'USGAM1' AND INS_CNT = 1 AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY INS_TIME;\r\n";
								// 20211118 parser edit
								buffer += "INSERT INTO CEDCLOTRLH_TEMP SELECT /*+ INDEX(CEDCLOTRLH, CEDCLOTRLH_PK) */ * FROM CEDCLOTRLH WHERE FACTORY = 'USGAM1' AND INS_CNT = 1 AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "';\r\n"; //  ORDER BY INS_TIME;\r\n";

                                buffer += "UPDATE CEDCLOTRLH_TEMP SET OPER = 'M3050', INS_TYPE = 'SI', CMF_2 = ' ', CMF_3 = ' ', CMF_4 = ' ', CMF_5 = ' ', RES_ID = '" + eqpid + "', INS_TIME = (SELECT MAX(TRAN_TIME) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3050' AND TRAN_CODE = 'START' AND LOT_ID = '" + moduleid + "'), RESULT_VALUE = '" + result + "' WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET RESULT_TIME = INS_TIME, CMF_1 = INS_TIME WHERE INS_TYPE = 'SI' AND LOT_ID = '" + moduleid + "';\r\n";

                                buffer += "UPDATE CEDCLOTRLH_TEMP SET FLASHER_CODE = RES_ID";
                                XmlNode paramlist = hmg.SelectSingleNode(".//HIT[@N='PARAM_LIST']");
                                if (paramlist != null)
                                {
                                    for (int y = 0; y < list.Count; y++)
                                    {
                                        XmlNode param = paramlist.SelectSingleNode(".//HIT[@V='" + list[y] + "']");
                                        if (param != null)
                                        {
                                            string value = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='PARAM_VALUE']"), "V");
                                            //buffer += "," + d[list[y]] + "='" + value + "'";

											// 20211118 parser edit
											string index = ".";
											int IndexValue = value.IndexOf(index);
											string result222 = value;
											if (IndexValue > -1 && value.Length > 7)
											{
												result222 = value.Substring(0, IndexValue + 7);
											}

											buffer += "," + d[list[y]] + "='" + result222 + "'";

                                        }
                                    }
                                }
                                buffer += "WHERE INS_TYPE = 'SI' AND LOT_ID = '" + moduleid + "';\r\n";

                                buffer += "INSERT INTO MWIPLOTHIS SELECT * FROM MWIPLOTHIS_TEMP WHERE OLD_OPER = 'M3050' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'SI' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLT SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'SI' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLT SET (LAST_HIST_SEQ, INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT) = (SELECT (SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3050' AND LOT_ID = '" + moduleid + "'), INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'SI' AND LOT_ID = '" + moduleid + "')  WHERE INS_TYPE = 'SI' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPELTSTS SET (EFF, RSH, RS, FF, ISC, VOC, IMPP, VMPP, PMPP, TEMP, SURFTEMP, SUN, EL) = (SELECT EFF, RSH, RS, FF, ISC, VOC, IMPP, VMPP, PMPP, TEMP, SURFTEMP, SUN, EL FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'SI' AND LOT_ID = '" + moduleid + "') WHERE LOT_ID = '" + moduleid + "';\r\n\r\n";
                            }

                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("HVT"))
                {
                    List<string> list = new List<string>();
                    list.Add("I_HVT_01_VOLTAGE_RESULT");
                    list.Add("I_HVT_01_CURRENT_RESULT");

                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("EAPMES_Collect_Inspection_Data"))
                        {
                            string eqpid = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            if (eqpid.Contains("-HVT-"))
                            {
                                string moduleid = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                                string result = Attribute(hmg.SelectSingleNode(".//HIT[@N='RESULT']"), "V");
                                string gemclock = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");

                                if (!inputList.Contains(moduleid) && inputList.Count > 0) continue;
                                buffer += "DELETE FROM MWIPLOTHIS_TEMP;\r\n";
                                buffer += "DELETE FROM CEDCLOTRLH_TEMP;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3060' AND TRAN_CODE = 'START' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3060' AND TRAN_CODE = 'END' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3060', OPER = 'M3060', START_RES_ID = '" + eqpid + "', END_RES_ID = ' ', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-2 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'START' AND OLD_OPER < 'M3060' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3060', OPER = 'M3070', START_RES_ID = '" + eqpid + "', END_RES_ID = '" + eqpid + "', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-1 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'END' AND OLD_OPER < 'M3060' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET SYS_TRAN_TIME = TRAN_TIME, START_TIME = TRAN_TIME, END_TIME = TRAN_TIME, CREATE_TIME = TRAN_TIME, FAC_IN_TIME = TRAN_TIME, FLOW_IN_TIME = TRAN_TIME, OPER_IN_TIME = TRAN_TIME, OLD_FAC_IN_TIME = TRAN_TIME, OLD_FLOW_IN_TIME = TRAN_TIME, OLD_OPER_IN_TIME = TRAN_TIME WHERE LOT_ID = '" + moduleid + "';\r\n";
                                //buffer += "INSERT INTO CEDCLOTRLH_TEMP SELECT /*+ INDEX(CEDCLOTRLH, CEDCLOTRLH_PK) */ * FROM CEDCLOTRLH WHERE FACTORY = 'USGAM1' AND INS_CNT = 1 AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY INS_TIME;\r\n";
								// 20211118 parser edit
								buffer += "INSERT INTO CEDCLOTRLH_TEMP SELECT /*+ INDEX(CEDCLOTRLH, CEDCLOTRLH_PK) */ * FROM CEDCLOTRLH WHERE FACTORY = 'USGAM1' AND INS_CNT = 1 AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "';\r\n";//  ORDER BY INS_TIME;\r\n";

                                buffer += "UPDATE CEDCLOTRLH_TEMP SET OPER = 'M3060', INS_TYPE = 'HI', CMF_2 = ' ', CMF_3 = ' ', CMF_4 = ' ', CMF_5 = ' ', RES_ID = '" + eqpid + "', INS_TIME = (SELECT MAX(TRAN_TIME) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3060' AND TRAN_CODE = 'START' AND LOT_ID = '" + moduleid + "'), RESULT_VALUE = '" + result + "' WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET RESULT_TIME = INS_TIME, CMF_1 = INS_TIME WHERE INS_TYPE = 'HI' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS SELECT * FROM MWIPLOTHIS_TEMP WHERE OLD_OPER = 'M3060' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'HI' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLT SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'HI' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLT SET (LAST_HIST_SEQ, INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT) = (SELECT (SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3060' AND LOT_ID = '" + moduleid + "'), INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'HI' AND LOT_ID = '" + moduleid + "')  WHERE INS_TYPE = 'HI' AND LOT_ID = '" + moduleid + "';\r\n";

                                string head = "INSERT INTO CEDCINSDAT (LOT_ID, RES_ID, TRAN_TIME, SEQ_NUM, FACTORY, LINE_ID, OPER, LOT_HIST_SEQ, PARAM_NAME, PARAM_VALUE, CMF_1, CMF_2, CMF_3, CMF_4, CMF_5) VALUES ('";
                                head += moduleid;
                                head += "', '";
                                head += eqpid;
                                head += "', (SELECT MAX(TRAN_TIME) FROM MWIPLOTHIS_TEMP WHERE LOT_ID = '";
                                head += moduleid;
                                head += "' AND OPER = 'M3060' GROUP BY LOT_ID), '";

                                string tail = ", ' ', ' ', ' ', ' ', ' ');";
                                XmlNode paramlist = hmg.SelectSingleNode(".//HIT[@N='PARAM_LIST']");
                                if (paramlist != null)
                                {
                                    for (int y = 0; y < list.Count; y++)
                                    {
                                        XmlNode param = paramlist.SelectSingleNode(".//HIT[@V='" + list[y] + "']");
                                        if (param != null)
                                        {
                                            string val = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='PARAM_VALUE']"), "V");
                                            if (val.Length > 0)
                                            {
                                                string body = (y + 1) + "', 'USGAM1', 'MDL0" + moduleid.Substring(2, 1) + "', 'M3060', (SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE LOT_ID = '";
                                                body += moduleid;
                                                body += "' AND OPER = 'M3060' GROUP BY LOT_ID), '";
                                                body += list[y];
                                                body += "', '";
                                                body += val;
                                                body += "'";
                                                buffer += head + body + tail + "\r\n";
                                            }
                                        }
                                    }
                                }

                                buffer += "\r\n";
                            }

                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("FEL"))
                {
                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("EAPMES_Collect_Inspection_Data_Sualab"))
                        {
                            string eqpid = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            if (eqpid.Contains("-FEL-"))
                            {
                                string moduleid = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                                string result = Attribute(hmg.SelectSingleNode(".//HIT[@N='RESULT']"), "V");
                                string gemclock = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");
                                string mode = Attribute(hmg.SelectSingleNode(".//HIT[@N='MODE']"), "V");
                                if (!inputList.Contains(moduleid) && inputList.Count > 0) continue;

                                buffer += "DELETE FROM MWIPLOTHIS_TEMP LOT_ID = '" + moduleid + "' ;\r\n";
                                buffer += "DELETE FROM CEDCLOTRLH_TEMP LOT_ID = '" + moduleid + "' ;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M2040' AND TRAN_CODE = 'START' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M2040' AND TRAN_CODE = 'END' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M2040', OPER = 'M2040', START_RES_ID = '" + eqpid + "', END_RES_ID = ' ', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-2 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'START' AND OLD_OPER < 'M2040' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M2040', OPER = 'M3080', START_RES_ID = '" + eqpid + "', END_RES_ID = '" + eqpid + "', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-1 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'END' AND OLD_OPER < 'M2040' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET SYS_TRAN_TIME = TRAN_TIME, START_TIME = TRAN_TIME, END_TIME = TRAN_TIME, CREATE_TIME = TRAN_TIME, FAC_IN_TIME = TRAN_TIME, FLOW_IN_TIME = TRAN_TIME, OPER_IN_TIME = TRAN_TIME, OLD_FAC_IN_TIME = TRAN_TIME, OLD_FLOW_IN_TIME = TRAN_TIME, OLD_OPER_IN_TIME = TRAN_TIME WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH_TEMP SELECT /*+ INDEX(CEDCLOTRLH, CEDCLOTRLH_PK) */ * FROM CEDCLOTRLH WHERE FACTORY = 'USGAM1' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY INS_TIME;\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET OPER = 'M2040', INS_TYPE = 'E1', CMF_2 = ' ', CMF_3 = ' ', CMF_4 = ' ', CMF_5 = ' ', RES_ID = '" + eqpid + "', INS_TIME = (SELECT MAX(TRAN_TIME) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M2040' AND TRAN_CODE = 'START' AND LOT_ID = '" + moduleid + "'), RESULT_VALUE = '" + result + "' WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET RESULT_TIME = INS_TIME, CMF_1 = INS_TIME WHERE INS_TYPE = 'E1' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS SELECT * FROM MWIPLOTHIS_TEMP WHERE OLD_OPER = 'M2040' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'E1' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLT SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'E1' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLT SET (LAST_HIST_SEQ, INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT) = (SELECT (SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M2040' AND LOT_ID = '" + moduleid + "'), INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'E1' AND LOT_ID = '" + moduleid + "')  WHERE INS_TYPE = 'E1' AND LOT_ID = '" + moduleid + "';\r\n";

                                string head = "INSERT INTO CWIPCELLOS (FACTORY, LOSS_CATEGORY, CELL_ID, LOSS_SEQ, LOSS_QTY, STRING_ID, LOSS_TYPE, LOSS_GROUP, LOT_ID, MAT_ID, FLOW, OPER, ORDER_ID, LINE_ID, RES_ID, STATUS_FLAG, INV_LOT_ID, TYPE_FLAG, LOSS_COMMENT, CMF_1, CMF_2, CMF_3, CMF_4, CMF_5, CREATE_TIME, TRAN_TIME, WORK_DATE, WORK_SHIFT, WORKER, INS_CNT, LOT_HIST_SEQ, RESULT_VALUE, LOSS_CODE, LOCATION_ID, LOC_X, LOC_Y) VALUES ('USGAM1', 'E1', '" + moduleid + "', NVL((SELECT MIN(LOSS_SEQ) FROM CWIPCELLOS WHERE LOT_ID = '" + moduleid + "' AND LOSS_CATEGORY = 'E1'), 0)-1, 0, ' ', ' ', ' ', '" + moduleid + "', ' ', ' ', ' ', (SELECT ORDER_ID FROM CEDCLOTRLT WHERE INS_TYPE='E1' AND LOT_ID='" + moduleid + "'), (SELECT LINE_ID FROM CEDCLOTRLT WHERE INS_TYPE='E1' AND LOT_ID='" + moduleid + "'), '" + eqpid + "', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '" + gemclock.Substring(0, 14) + "', '" + gemclock.Substring(0, 14) + "', ' ', ' ', ' ', (SELECT INS_CNT FROM CEDCLOTRLT WHERE INS_TYPE='E1' AND LOT_ID='" + moduleid + "'), (SELECT LAST_HIST_SEQ FROM CEDCLOTRLT WHERE INS_TYPE='E1' AND LOT_ID='" + moduleid + "'), '" + result + "', ";

                                XmlNode paramlist = hmg.SelectSingleNode(".//HIT[@N='DEFECT_LIST']");
                                if (paramlist != null)
                                {
                                    foreach (XmlNode param in paramlist.ChildNodes)
                                    {
                                        string locId = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='AOI_LOCATION']"), "V");
                                        string defect = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='AOI_REASON_CODE']"), "V");

                                        if (mode.Equals("3"))
                                        {
                                            locId = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='ML_LOCATION']"), "V");
                                            defect = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='ML_REASON_CODE']"), "V");
                                        }

                                        buffer += head + "'" + defect + "', '" + locId + "', '" + locId.Substring(0, 1) + "', '" + locId.Substring(1) + "');\r\n";
                                    }
                                }

                                buffer += "\r\n";
                            }
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("BEL"))
                {
                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("EAPMES_Collect_Inspection_Data_Sualab"))
                        {
                            string eqpid = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            if (eqpid.Contains("-BEL-"))
                            {
                                string moduleid = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                                string result = Attribute(hmg.SelectSingleNode(".//HIT[@N='RESULT']"), "V");
                                string gemclock = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");
                                string mode = Attribute(hmg.SelectSingleNode(".//HIT[@N='MODE']"), "V");
                                if (!inputList.Contains(moduleid) && inputList.Count > 0) continue;

                                buffer += "DELETE FROM MWIPLOTHIS_TEMP;\r\n";
                                buffer += "DELETE FROM CEDCLOTRLH_TEMP;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3070' AND TRAN_CODE = 'START' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3070' AND TRAN_CODE = 'END' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3070', OPER = 'M3070', START_RES_ID = '" + eqpid + "', END_RES_ID = ' ', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-2 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'START' AND OLD_OPER < 'M3070' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3070', OPER = 'M3080', START_RES_ID = '" + eqpid + "', END_RES_ID = '" + eqpid + "', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-1 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'END' AND OLD_OPER < 'M3070' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET SYS_TRAN_TIME = TRAN_TIME, START_TIME = TRAN_TIME, END_TIME = TRAN_TIME, CREATE_TIME = TRAN_TIME, FAC_IN_TIME = TRAN_TIME, FLOW_IN_TIME = TRAN_TIME, OPER_IN_TIME = TRAN_TIME, OLD_FAC_IN_TIME = TRAN_TIME, OLD_FLOW_IN_TIME = TRAN_TIME, OLD_OPER_IN_TIME = TRAN_TIME WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH_TEMP SELECT /*+ INDEX(CEDCLOTRLH, CEDCLOTRLH_PK) */ * FROM CEDCLOTRLH WHERE FACTORY = 'USGAM1' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY INS_TIME;\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET OPER = 'M3070', INS_TYPE = 'E2', CMF_2 = ' ', CMF_3 = ' ', CMF_4 = ' ', CMF_5 = ' ', RES_ID = '" + eqpid + "', INS_TIME = (SELECT MAX(TRAN_TIME) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3070' AND TRAN_CODE = 'START' AND LOT_ID = '" + moduleid + "'), RESULT_VALUE = '" + result + "' WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET RESULT_TIME = INS_TIME, CMF_1 = INS_TIME WHERE INS_TYPE = 'E2' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS SELECT * FROM MWIPLOTHIS_TEMP WHERE OLD_OPER = 'M3070' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'E2' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLT SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'E2' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLT SET (LAST_HIST_SEQ, INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT) = (SELECT (SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3070' AND LOT_ID = '" + moduleid + "'), INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'E2' AND LOT_ID = '" + moduleid + "')  WHERE INS_TYPE = 'E2' AND LOT_ID = '" + moduleid + "';\r\n";

                                string head = "INSERT INTO CWIPCELLOS (FACTORY, LOSS_CATEGORY, CELL_ID, LOSS_SEQ, LOSS_QTY, STRING_ID, LOSS_TYPE, LOSS_GROUP, LOT_ID, MAT_ID, FLOW, OPER, ORDER_ID, LINE_ID, RES_ID, STATUS_FLAG, INV_LOT_ID, TYPE_FLAG, LOSS_COMMENT, CMF_1, CMF_2, CMF_3, CMF_4, CMF_5, CREATE_TIME, TRAN_TIME, WORK_DATE, WORK_SHIFT, WORKER, INS_CNT, LOT_HIST_SEQ, RESULT_VALUE, LOSS_CODE, LOCATION_ID, LOC_X, LOC_Y) VALUES ('USGAM1', 'E2', '" + moduleid + "', NVL((SELECT MIN(LOSS_SEQ) FROM CWIPCELLOS WHERE LOT_ID = '" + moduleid + "' AND LOSS_CATEGORY = 'E2'), 0)-1, 0, ' ', ' ', ' ', '" + moduleid + "', ' ', ' ', ' ', (SELECT ORDER_ID FROM CEDCLOTRLT WHERE INS_TYPE='E2' AND LOT_ID='" + moduleid + "'), (SELECT LINE_ID FROM CEDCLOTRLT WHERE INS_TYPE='E2' AND LOT_ID='" + moduleid + "'), '" + eqpid + "', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '" + gemclock.Substring(0, 14) + "', '" + gemclock.Substring(0, 14) + "', ' ', ' ', ' ', (SELECT INS_CNT FROM CEDCLOTRLT WHERE INS_TYPE='E2' AND LOT_ID='" + moduleid + "'), (SELECT LAST_HIST_SEQ FROM CEDCLOTRLT WHERE INS_TYPE='E2' AND LOT_ID='" + moduleid + "'), '" + result + "', ";

                                XmlNode paramlist = hmg.SelectSingleNode(".//HIT[@N='DEFECT_LIST']");
                                if (paramlist != null)
                                {
                                    foreach (XmlNode param in paramlist.ChildNodes)
                                    {
                                        string locId = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='AOI_LOCATION']"), "V");
                                        string defect = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='AOI_REASON_CODE']"), "V");

                                        if (mode.Equals("3"))
                                        {
                                            locId = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='ML_LOCATION']"), "V");
                                            defect = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='ML_REASON_CODE']"), "V");
                                        }

                                        buffer += head + "'" + defect + "', '" + locId + "', '" + locId.Substring(0, 1) + "', '" + locId.Substring(1) + "');\r\n";
                                    }
                                }

                                buffer += "\r\n";
                            }
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("GRT"))
                {
                    List<string> list = new List<string>();

                    list.Add("I_GRD_01_MODULE_ID");
                    list.Add("I_GRD_01_STEP_1_MEASURE_OHM");
                    list.Add("I_GRD_01_STEP_1_RESULT");
                    list.Add("I_GRD_01_STEP_2_MEASURE_OHM");
                    list.Add("I_GRD_01_STEP_2_RESULT");
                    list.Add("I_GRD_01_STEP_3_MEASURE_OHM");
                    list.Add("I_GRD_01_STEP_3_RESULT");
                    list.Add("I_GRD_01_STEP_4_MEASURE_OHM");
                    list.Add("I_GRD_01_STEP_4_RESULT");

                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("EAPMES_Collect_Inspection_Data"))
                        {
                            string eqpid = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            if (eqpid.Contains("-GRT-"))
                            {
                                string moduleid = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                                string result = Attribute(hmg.SelectSingleNode(".//HIT[@N='RESULT']"), "V");
                                string gemclock = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");

                                if (!inputList.Contains(moduleid) && inputList.Count > 0) continue;

                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3100' AND TRAN_CODE = 'START' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3100' AND TRAN_CODE = 'END' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3100', OPER = 'M3100', START_RES_ID = '" + eqpid + "', END_RES_ID = ' ', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-2 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'START' AND OLD_OPER < 'M3100' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3100', OPER = 'M3110', START_RES_ID = '" + eqpid + "', END_RES_ID = '" + eqpid + "', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-1 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'END' AND OLD_OPER < 'M3100' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET SYS_TRAN_TIME = TRAN_TIME, START_TIME = TRAN_TIME, END_TIME = TRAN_TIME, CREATE_TIME = TRAN_TIME, FAC_IN_TIME = TRAN_TIME, FLOW_IN_TIME = TRAN_TIME, OPER_IN_TIME = TRAN_TIME, OLD_FAC_IN_TIME = TRAN_TIME, OLD_FLOW_IN_TIME = TRAN_TIME, OLD_OPER_IN_TIME = TRAN_TIME WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH_TEMP SELECT /*+ INDEX(CEDCLOTRLH, CEDCLOTRLH_PK) */ * FROM CEDCLOTRLH WHERE FACTORY = 'USGAM1' AND INS_CNT = 1 AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY INS_TIME;\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET OPER = 'M3100', INS_TYPE = 'GR', CMF_2 = ' ', CMF_3 = ' ', CMF_4 = ' ', CMF_5 = ' ', RES_ID = '" + eqpid + "', INS_TIME = (SELECT MAX(TRAN_TIME) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3100' AND TRAN_CODE = 'START' AND LOT_ID = '" + moduleid + "'), RESULT_VALUE = '" + result + "' WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET RESULT_TIME = INS_TIME, CMF_1 = INS_TIME WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS SELECT * FROM MWIPLOTHIS_TEMP WHERE OLD_OPER = 'M3100' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLT SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLT SET (LAST_HIST_SEQ, INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT) = (SELECT (SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3100' AND LOT_ID = '" + moduleid + "'), INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "')  WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "';\r\n";

                                string head = "INSERT INTO CEDCINSDAT (LOT_ID, RES_ID, TRAN_TIME, SEQ_NUM, FACTORY, LINE_ID, OPER, LOT_HIST_SEQ, PARAM_NAME, PARAM_VALUE, CMF_1, CMF_2, CMF_3, CMF_4, CMF_5) VALUES ('";
                                head += moduleid;
                                head += "', '";
                                head += eqpid;
                                head += "', (SELECT MAX(TRAN_TIME) FROM MWIPLOTHIS_TEMP WHERE LOT_ID = '";
                                head += moduleid;
                                head += "' AND OPER = 'M3100' GROUP BY LOT_ID), '";

                                string tail = ", ' ', ' ', ' ', ' ', ' ');";
                                XmlNode paramlist = hmg.SelectSingleNode(".//HIT[@N='PARAM_LIST']");
                                if (paramlist != null)
                                {
                                    for (int y = 0; y < list.Count; y++)
                                    {
                                        XmlNode param = paramlist.SelectSingleNode(".//HIT[@V='" + list[y] + "']");
                                        if (param != null)
                                        {
                                            string val = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='PARAM_VALUE']"), "V");
                                            if (val.Length > 0)
                                            {
                                                string body = (y + 1) + "', 'USGAM1', 'MDL0" + moduleid.Substring(4, 1) + "', 'M3100', (SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE LOT_ID = '";
                                                body += moduleid;
                                                body += "' AND OPER = 'M3100' GROUP BY LOT_ID), '";
                                                body += list[y];
                                                body += "', '";
                                                body += val;
                                                body += "'";
                                                buffer += head + body + tail + "\r\n";
                                            }
                                        }
                                    }
                                }

                                buffer += "\r\n";
                            }

                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("GRT_UPDATE"))
                {
                    List<string> list = new List<string>();

                    list.Add("I_GRD_01_MODULE_ID");
                    list.Add("I_GRD_01_STEP_1_MEASURE_OHM");
                    list.Add("I_GRD_01_STEP_1_RESULT");
                    list.Add("I_GRD_01_STEP_2_MEASURE_OHM");
                    list.Add("I_GRD_01_STEP_2_RESULT");
                    list.Add("I_GRD_01_STEP_3_MEASURE_OHM");
                    list.Add("I_GRD_01_STEP_3_RESULT");
                    list.Add("I_GRD_01_STEP_4_MEASURE_OHM");
                    list.Add("I_GRD_01_STEP_4_RESULT");

                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("EAPMES_Collect_Inspection_Data"))
                        {
                            string eqpid = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            if (eqpid.Contains("-GRT-"))
                            {
                                string moduleid = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                                string result = Attribute(hmg.SelectSingleNode(".//HIT[@N='RESULT']"), "V");
                                string gemclock = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");

                                if (!inputList.Contains(moduleid) && inputList.Count > 0) continue;
                                /*
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3100' AND TRAN_CODE = 'START' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS_TEMP SELECT * FROM MWIPLOTHIS WHERE OLD_OPER < 'M3100' AND TRAN_CODE = 'END' AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY HIST_SEQ DESC;\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3100', OPER = 'M3100', START_RES_ID = '" + eqpid + "', END_RES_ID = ' ', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-2 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'START' AND OLD_OPER < 'M3100' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET TRAN_TIME = '" + gemclock.Substring(0, 14) + "', OLD_OPER = 'M3100', OPER = 'M3110', START_RES_ID = '" + eqpid + "', END_RES_ID = '" + eqpid + "', PREV_ACTIVE_HIST_SEQ = -1, HIST_SEQ = (SELECT DECODE(MIN(HIST_SEQ), 1, 0, MIN(HIST_SEQ))-1 FROM MWIPLOTHIS WHERE LOT_ID = '" + moduleid + "') WHERE TRAN_CODE = 'END' AND OLD_OPER < 'M3100' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE MWIPLOTHIS_TEMP SET SYS_TRAN_TIME = TRAN_TIME, START_TIME = TRAN_TIME, END_TIME = TRAN_TIME, CREATE_TIME = TRAN_TIME, FAC_IN_TIME = TRAN_TIME, FLOW_IN_TIME = TRAN_TIME, OPER_IN_TIME = TRAN_TIME, OLD_FAC_IN_TIME = TRAN_TIME, OLD_FLOW_IN_TIME = TRAN_TIME, OLD_OPER_IN_TIME = TRAN_TIME WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH_TEMP SELECT /*+ INDEX(CEDCLOTRLH, CEDCLOTRLH_PK)  * FROM CEDCLOTRLH WHERE FACTORY = 'USGAM1' AND INS_CNT = 1 AND ROWNUM = 1 AND LOT_ID = '" + moduleid + "' ORDER BY INS_TIME;\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET OPER = 'M3100', INS_TYPE = 'GR', CMF_2 = ' ', CMF_3 = ' ', CMF_4 = ' ', CMF_5 = ' ', RES_ID = '" + eqpid + "', INS_TIME = (SELECT MAX(TRAN_TIME) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3100' AND TRAN_CODE = 'START' AND LOT_ID = '" + moduleid + "'), RESULT_VALUE = '" + result + "' WHERE LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLH_TEMP SET RESULT_TIME = INS_TIME, CMF_1 = INS_TIME WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO MWIPLOTHIS SELECT * FROM MWIPLOTHIS_TEMP WHERE OLD_OPER = 'M3100' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLH SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "INSERT INTO CEDCLOTRLT SELECT * FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "';\r\n";
                                buffer += "UPDATE CEDCLOTRLT SET (LAST_HIST_SEQ, INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT) = (SELECT (SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE OPER = 'M3100' AND LOT_ID = '" + moduleid + "'), INS_TIME, RESULT_TIME, RESULT_VALUE, INS_CNT FROM CEDCLOTRLH_TEMP WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "')  WHERE INS_TYPE = 'GR' AND LOT_ID = '" + moduleid + "';\r\n";

                               
                                buffer += "INSERT INTO CEDCINSDAT_TEMP SELECT * FROM CEDCINSDAT WHERE OPER = 'M3100' AND FACTORY = 'USGAM1'";
                                buffer += " AND LINE_ID = 'MDL0" + moduleid.Substring(4, 1) + "'";
                                buffer += " AND RES_ID = '" + eqpid + "'";
                                buffer += " AND LOT_HIST_SEQ = '";
                                buffer += "(SELECT MAX(HIST_SEQ) FROM MWIPLOTHIS_TEMP WHERE LOT_ID = '";
                                buffer += " AND LOT_ID = '" + moduleid + "';\r\n";
                                */

                                string head = "INSERT INTO CEDCINSDAT_TEMP (LOT_ID, RES_ID, TRAN_TIME, SEQ_NUM, FACTORY, LINE_ID, OPER, LOT_HIST_SEQ, PARAM_NAME, PARAM_VALUE, CMF_1, CMF_2, CMF_3, CMF_4, CMF_5) VALUES ('";
                                head += moduleid;
                                head += "', '";
                                head += eqpid;
                                //head += "', (SELECT MAX(TRAN_TIME) FROM CEDCINSDAT WHERE LOT_ID = '";
                                //head += moduleid;
                                head += "', '" + gemclock.Substring(0, 14) + "', '";


                                string tail = ", ' ', ' ', ' ', ' ', ' ');";
                                XmlNode paramlist = hmg.SelectSingleNode(".//HIT[@N='PARAM_LIST']");


                                if (paramlist != null)
                                {
                                    for (int y = 0; y < list.Count; y++)
                                    {
                                        XmlNode param = paramlist.SelectSingleNode(".//HIT[@V='" + list[y] + "']");
                                        if (param != null)
                                        {
                                            string val = Attribute(param.ParentNode.SelectSingleNode(".//HIT[@N='PARAM_VALUE']"), "V");
                                            if (val.Length > 0)
                                            {
                                                string body = (y + 1) + "', 'USGAM1', 'MDL0" + moduleid.Substring(4, 1) + "', 'M3100', (SELECT MAX(LOT_HIST_SEQ) FROM CEDCINSDAT WHERE LOT_ID = '";
                                                body += moduleid;
                                                body += "' AND TRAN_TIME LIKE '" + gemclock.Substring(0, 8) + "%";
                                                body += "' AND OPER = 'M3100' GROUP BY LOT_ID), '";
                                                body += list[y];
                                                body += "', '";
                                                body += val;
                                                body += "'";
                                                buffer += head + body + tail + "\r\n";
                                            }
                                        }
                                    }
                                }
                                buffer += "\r\n";
                            }

                        }
                        /*
                        UPDATE CEDCINSDAT A SET A.PARAM_VALUE = NVL( (SELECT PARAM_VALUE FROM CEDCINSDAT_TEMP B WHERE B.LOT_ID = A.LOT_ID AND B.RES_ID = A.RES_ID AND B.SEQ_NUM = A.SEQ_NUM AND B.PARAM_NAME = A.PARAM_NAME AND B.LOT_HIST_SEQ = A.LOT_HIST_SEQ), ' ') WHERE A.PARAM_NAME = 'I_GRD_01_MODULE_ID'	      AND A.PARAM_VALUE =  ' ' AND A.LOT_HIST_SEQ = (SELECT C.LOT_HIST_SEQ FROM CEDCINSDAT_TEMP C WHERE C.LOT_ID = A.LOT_ID AND C.RES_ID = A.RES_ID AND C.SEQ_NUM = A.SEQ_NUM AND C.PARAM_NAME = A.PARAM_NAME AND C.LOT_HIST_SEQ = A.LOT_HIST_SEQ) AND A.LOT_ID IN (SELECT DISTINCT LOT_ID FROM CEDCINSDAT_TEMP ) AND A.TRAN_TIME LIKE '20191026%';
                        UPDATE CEDCINSDAT A SET A.PARAM_VALUE = NVL( (SELECT PARAM_VALUE FROM CEDCINSDAT_TEMP B WHERE B.LOT_ID = A.LOT_ID AND B.RES_ID = A.RES_ID AND B.SEQ_NUM = A.SEQ_NUM AND B.PARAM_NAME = A.PARAM_NAME AND B.LOT_HIST_SEQ = A.LOT_HIST_SEQ), ' ') WHERE A.PARAM_NAME = 'I_GRD_01_STEP_1_MEASURE_OHM' AND A.PARAM_VALUE =  ' ' AND A.LOT_HIST_SEQ = (SELECT C.LOT_HIST_SEQ FROM CEDCINSDAT_TEMP C WHERE C.LOT_ID = A.LOT_ID AND C.RES_ID = A.RES_ID AND C.SEQ_NUM = A.SEQ_NUM AND C.PARAM_NAME = A.PARAM_NAME AND C.LOT_HIST_SEQ = A.LOT_HIST_SEQ) AND A.LOT_ID IN (SELECT DISTINCT LOT_ID FROM CEDCINSDAT_TEMP ) AND A.TRAN_TIME LIKE '20191026%';
                        UPDATE CEDCINSDAT A SET A.PARAM_VALUE = NVL( (SELECT PARAM_VALUE FROM CEDCINSDAT_TEMP B WHERE B.LOT_ID = A.LOT_ID AND B.RES_ID = A.RES_ID AND B.SEQ_NUM = A.SEQ_NUM AND B.PARAM_NAME = A.PARAM_NAME AND B.LOT_HIST_SEQ = A.LOT_HIST_SEQ), ' ') WHERE A.PARAM_NAME = 'I_GRD_01_STEP_1_RESULT'	  AND A.PARAM_VALUE =  ' ' AND A.LOT_HIST_SEQ = (SELECT C.LOT_HIST_SEQ FROM CEDCINSDAT_TEMP C WHERE C.LOT_ID = A.LOT_ID AND C.RES_ID = A.RES_ID AND C.SEQ_NUM = A.SEQ_NUM AND C.PARAM_NAME = A.PARAM_NAME AND C.LOT_HIST_SEQ = A.LOT_HIST_SEQ) AND A.LOT_ID IN (SELECT DISTINCT LOT_ID FROM CEDCINSDAT_TEMP ) AND A.TRAN_TIME LIKE '20191026%';
                        UPDATE CEDCINSDAT A SET A.PARAM_VALUE = NVL( (SELECT PARAM_VALUE FROM CEDCINSDAT_TEMP B WHERE B.LOT_ID = A.LOT_ID AND B.RES_ID = A.RES_ID AND B.SEQ_NUM = A.SEQ_NUM AND B.PARAM_NAME = A.PARAM_NAME AND B.LOT_HIST_SEQ = A.LOT_HIST_SEQ), ' ') WHERE A.PARAM_NAME = 'I_GRD_01_STEP_2_MEASURE_OHM' AND A.PARAM_VALUE =  ' ' AND A.LOT_HIST_SEQ = (SELECT C.LOT_HIST_SEQ FROM CEDCINSDAT_TEMP C WHERE C.LOT_ID = A.LOT_ID AND C.RES_ID = A.RES_ID AND C.SEQ_NUM = A.SEQ_NUM AND C.PARAM_NAME = A.PARAM_NAME AND C.LOT_HIST_SEQ = A.LOT_HIST_SEQ) AND A.LOT_ID IN (SELECT DISTINCT LOT_ID FROM CEDCINSDAT_TEMP ) AND A.TRAN_TIME LIKE '20191026%';
                        UPDATE CEDCINSDAT A SET A.PARAM_VALUE = NVL( (SELECT PARAM_VALUE FROM CEDCINSDAT_TEMP B WHERE B.LOT_ID = A.LOT_ID AND B.RES_ID = A.RES_ID AND B.SEQ_NUM = A.SEQ_NUM AND B.PARAM_NAME = A.PARAM_NAME AND B.LOT_HIST_SEQ = A.LOT_HIST_SEQ), ' ') WHERE A.PARAM_NAME = 'I_GRD_01_STEP_2_RESULT'      AND A.PARAM_VALUE =  ' ' AND A.LOT_HIST_SEQ = (SELECT C.LOT_HIST_SEQ FROM CEDCINSDAT_TEMP C WHERE C.LOT_ID = A.LOT_ID AND C.RES_ID = A.RES_ID AND C.SEQ_NUM = A.SEQ_NUM AND C.PARAM_NAME = A.PARAM_NAME AND C.LOT_HIST_SEQ = A.LOT_HIST_SEQ) AND A.LOT_ID IN (SELECT DISTINCT LOT_ID FROM CEDCINSDAT_TEMP ) AND A.TRAN_TIME LIKE '20191026%';
                        UPDATE CEDCINSDAT A SET A.PARAM_VALUE = NVL( (SELECT PARAM_VALUE FROM CEDCINSDAT_TEMP B WHERE B.LOT_ID = A.LOT_ID AND B.RES_ID = A.RES_ID AND B.SEQ_NUM = A.SEQ_NUM AND B.PARAM_NAME = A.PARAM_NAME AND B.LOT_HIST_SEQ = A.LOT_HIST_SEQ), ' ') WHERE A.PARAM_NAME = 'I_GRD_01_STEP_3_MEASURE_OHM' AND A.PARAM_VALUE =  ' ' AND A.LOT_HIST_SEQ = (SELECT C.LOT_HIST_SEQ FROM CEDCINSDAT_TEMP C WHERE C.LOT_ID = A.LOT_ID AND C.RES_ID = A.RES_ID AND C.SEQ_NUM = A.SEQ_NUM AND C.PARAM_NAME = A.PARAM_NAME AND C.LOT_HIST_SEQ = A.LOT_HIST_SEQ) AND A.LOT_ID IN (SELECT DISTINCT LOT_ID FROM CEDCINSDAT_TEMP ) AND A.TRAN_TIME LIKE '20191026%';
                        UPDATE CEDCINSDAT A SET A.PARAM_VALUE = NVL( (SELECT PARAM_VALUE FROM CEDCINSDAT_TEMP B WHERE B.LOT_ID = A.LOT_ID AND B.RES_ID = A.RES_ID AND B.SEQ_NUM = A.SEQ_NUM AND B.PARAM_NAME = A.PARAM_NAME AND B.LOT_HIST_SEQ = A.LOT_HIST_SEQ), ' ') WHERE A.PARAM_NAME = 'I_GRD_01_STEP_3_RESULT'	  AND A.PARAM_VALUE =  ' ' AND A.LOT_HIST_SEQ = (SELECT C.LOT_HIST_SEQ FROM CEDCINSDAT_TEMP C WHERE C.LOT_ID = A.LOT_ID AND C.RES_ID = A.RES_ID AND C.SEQ_NUM = A.SEQ_NUM AND C.PARAM_NAME = A.PARAM_NAME AND C.LOT_HIST_SEQ = A.LOT_HIST_SEQ) AND A.LOT_ID IN (SELECT DISTINCT LOT_ID FROM CEDCINSDAT_TEMP ) AND A.TRAN_TIME LIKE '20191026%';
                        */
                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("FQC"))
                {
                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("EAPMES_Collect_Process_Data_FQC"))
                        {
                            string resId = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            string moduleId = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                            string grade = Attribute(hmg.SelectSingleNode(".//HIT[@N='GRADE']"), "V");
                            string powerGrade = Attribute(hmg.SelectSingleNode(".//HIT[@N='POWER_GRADE']"), "V");
                            string fqcResult = Attribute(hmg.SelectSingleNode(".//HIT[@N='FQC_RESULT']"), "V");
                            string fqcJudge = Attribute(hmg.SelectSingleNode(".//HIT[@N='FQC_JUDGE']"), "V");

                            if (!inputList.Contains(moduleId) && inputList.Count > 0) continue;

                            buffer += moduleId + "\t" + grade + "\t" + powerGrade + "\t" + fqcResult + "\t" + fqcJudge + "\t";

                            //SELECT 
                            XmlNode paramlist = hmg.SelectSingleNode(".//HIT[@N='DEFECT_LIST']");
                            if (paramlist != null)
                            {
                                string query = "SELECT KEY_1 FROM MGCMTBLDAT HERE FACTORY = 'USGAM1' AND TABLE_NAME = '@DEFECT' AND KEY_2 = 'M3110' AND KEY_1 IN (";
                                foreach (XmlNode paramItem in paramlist.ChildNodes)
                                {
                                    buffer += Attribute(paramItem.SelectSingleNode(".//HIT[@N='REASON_CODE']"), "V");
                                    buffer += "/" + Attribute(paramItem.SelectSingleNode(".//HIT[@N='LOC_ID']"), "V") + ", ";
                                    if (query.Contains(",'")) query += ",'";
                                    query += Attribute(paramItem.SelectSingleNode(".//HIT[@N='REASON_CODE']"), "V") + "'";
                                }
                                query += ") AND ROWNUM = 1 ORDER BY DATA_8 ASC;";
                                buffer += query + "\r\n";
                            }
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("SUALAB"))
                {
                    XmlNodeList smgList = doc.GetElementsByTagName("SMG");
                    for (int x = 0; x < smgList.Count; x++)
                    {
                        XmlNode smg = smgList[x];
                        string ceid = Attribute(smg.SelectSingleNode(".//SIT[@N='CEID']"), "V");
                        if (ceid.Equals("701"))
                        {
                            string moduleid = Attribute(smg.SelectSingleNode(".//SIT[@N='MODULEID']"), "V");

                            for (int y = 0; y < smgList.Count; y++)
                            {
                                XmlNode smg700 = smgList[y];
                                string ceid700 = Attribute(smg700.SelectSingleNode(".//SIT[@N='CEID']"), "V");
                                string moduleid700 = Attribute(smg700.SelectSingleNode(".//SIT[@N='MODULEID']"), "V");
                                if (ceid700.Equals("700") && moduleid700.Equals(moduleid))
                                {
                                    buffer += smg700.OuterXml + "\r\n";
                                    break;
                                }
                            }

                            buffer += smg.OuterXml + "\r\n";
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)smgList.Count * 100));
                    }
                }
                else if (type.Equals("HCLMOV"))
                {
                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("MESEAP_Load_Magazine") || Attribute(hmg, "N").Equals("EAPMES_Load_Magazine"))
                        {
                            string name = Attribute(hmg, "N");
                            string resId = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            //string orgMsgId = Attribute(hmg.SelectSingleNode(".//HIT[@N='ORG_MSG_ID']"), "V");
                            string clientTime = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");
                            string orderId = Attribute(hmg.SelectSingleNode(".//HIT[@N='ORDER_ID']"), "V");

                            //if (!orgMsgId.Equals(""))
                            //{
                            //       buffer += resId + "\t" + clientTime + "\t" + orgMsgId + "\t" + orderId + "\r\n";
                            //}
                            buffer += resId + "\t" + name + "\t" + clientTime + "\r\n";
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("INS_ERROR"))
                {
                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Contains("MESEAP_"))
                        {
                            string lotid = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                            string resid = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            string clienttime = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");

                            if (lotid.Equals("") || lotid.Length != 18 || !lotid.All(Char.IsNumber))
                            {
                                buffer += resid + "\t" + clienttime + "\t" + Attribute(hmg, "N") + "\r\n";
                            }
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100));
                    }
                }
                else if (type.Equals("SKIP_INSPECTION"))
                {
                    Dictionary<string, string> d = new Dictionary<string, string>();


                    XmlNodeList hmgList = doc.GetElementsByTagName("HMG");
                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("EAPMES_Collect_Inspection_Data"))
                        {
                            string lotid = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                            string resid = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            string clienttime = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");

                            d.Add(lotid + "\t" + resid + "\t" + "EAPMES_Collect_Inspection_Data", clienttime);
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(x + 1) / (double)hmgList.Count * 100) / 2);
                    }

                    for (int x = 0; x < hmgList.Count; x++)
                    {
                        XmlNode hmg = hmgList[x];
                        if (Attribute(hmg, "N").Equals("MESEAP_Collect_Inspection_Data"))
                        {
                            string lotid = Attribute(hmg.SelectSingleNode(".//HIT[@N='LOT_ID']"), "V");
                            string resid = Attribute(hmg.SelectSingleNode(".//HIT[@N='RES_ID']"), "V");
                            string clienttime = Attribute(hmg.SelectSingleNode(".//HIT[@N='CLIENT_TIME']"), "V");

                            if (d.ContainsKey(lotid + "\t" + resid + "\t" + "EAPMES_Collect_Inspection_Data"))
                            {
                                d.Remove(lotid + "\t" + resid + "\t" + "EAPMES_Collect_Inspection_Data");
                            }
                        }

                        fileProgressBar.Invoke(new UpdateFileProgressBar(UpdateFileProgressBar_Process), (int)((double)(hmgList.Count + x + 1) / (double)hmgList.Count * 100) / 2);
                    }


                    for (int x = 0; x < d.Count; x++)
                    {
                        buffer += d.Keys.ElementAt(x) + "\t" + d[d.Keys.ElementAt(x)] + "\r\n";
                    }
                }


                resultTextBox.Invoke(new UpdateTextBox(UpdateTextBox_Process), buffer);
                backgroundWorker1.ReportProgress((int)((double)fileCount / (double)fileNames.Length * 100));
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            totalProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            processButton.Text = "Process";
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(processButton.Text.Equals("Process"))
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    processButton.Text = "Stop";
                    totalProgressBar.Value = 0;
                    resultTextBox.ResetText();
                    counterLabel.Text = "";
                    foreach (Control radioButton in flowLayoutPanel2.Controls)
                    {
                        if (radioButton is RadioButton && ((RadioButton)radioButton).Checked)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            backgroundWorker1.RunWorkerAsync(new List<object>() { radioButton.Tag, openFileDialog1.FileNames });
                            return;
                        }
                    }
                }
            }
            else
            {
                Cursor.Current = Cursors.Default;
                processButton.Text = "Process";
                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
            }
        }

        private delegate void UpdateTextBox(string text);
        private delegate void UpdateFileProgressBar(int progress);

        private void UpdateTextBox_Process(string text)
        {
            resultTextBox.AppendText(text);

            try
            {
                counterLabel.Text = (Int32.Parse(counterLabel.Text) + 1) + "";
            }
            catch (FormatException e)
            {
                counterLabel.Text = "0";
            }
        }

        private void UpdateFileProgressBar_Process(int progress)
        {
            fileProgressBar.Value = progress;
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
