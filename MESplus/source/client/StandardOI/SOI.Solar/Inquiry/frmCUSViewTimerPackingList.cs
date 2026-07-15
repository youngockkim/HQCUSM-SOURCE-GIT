using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;
using BOI.OIFrx;

namespace SOI.Solar
{
    public partial class frmCUSViewTimerPackingList : SOIBaseForm03
    {
        #region Property

        private bool bIsShown = false;
        Timer time = null;
        int printcnt = 0;

        #endregion

        public frmCUSViewTimerPackingList()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        #endregion

        #region [Variable Definition]

        bool b_load_flag;

        private enum BOX_LIST
        {
			CHECKBOX,
            BOX_ID,
            IN_TIME
        }

        #endregion

        #region [FormDefinition]

        #endregion

        #region Event Handler

        private void frmCUSViewTimerPackingList_Load(object sender, EventArgs e)
        {
            // Caption 변환
            MPCF.ConvertCaption(this);
        }

        private void frmCUSViewTimerPackingList_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                bIsShown = true;
            }
        }

        private void frmCUSViewTimerPackingList_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdList, true);

                ViewPackingList();
                
                b_load_flag = true;
            }
        }

        #endregion

        #region [Function Definition]

        private bool ProcSearch(ref DataTable boxDt)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            string s_sql = "";

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$BOX_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(spdList.ActiveSheet.Cells[0, (int)BOX_LIST.BOX_ID].Value.ToString());

                dvcArgu[2].sCondtion_ID = "$FG_ID";
                dvcArgu[2].sCondition_Value = string.Empty;

                if (TPDR.GetDataOne("", ref boxDt, "VIEW_BOX_LOT_LIST_1", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (boxDt != null)
                        boxDt.Dispose();

                    GC.Collect();
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ProcPrint(DataTable boxDt)
        {
            TRSNode out_node = new TRSNode("OUT_NODE");

            int i;
            string sProdID;

            try
            {
                udcPrint.InitFlexibleScreen();
                udcPrint.ScreenID = "ViewPackingList";
                udcPrint.ScreenSpread.Tag = "ViewPackingList";
                udcPrint.ProcStep = '1';
                MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
                udcPrint.OwnerFuncName = menuInfo.s_func_name; 
                udcPrint.LotID = "ViewPackingList";

                if (udcPrint.LoadDesign() == false)
                {
                    return false;
                }

                out_node.SetString("MAT_SHORT_DESC", MPCF.Trim(boxDt.Rows[0]["MAT_DESC"].ToString()));
                out_node.SetString("BOX_ID", boxDt.Rows[0]["BOX_ID"].ToString());

                for (i = 0; i < boxDt.Rows.Count; i++)
                {
                    sProdID = String.Format("PROD_ID_{0}", i + 1);
                    out_node.SetString(sProdID, MPCF.Trim(boxDt.Rows[i]["FG_ID"].ToString()));

                    if(i == 0)
                    {
                        out_node.SetString("CREATE_TIME", boxDt.Rows[i]["CREATE_TIME"].ToString());
                    }
                }

                if (udcPrint.SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                udcPrint.ScreenSpread.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;

                MPCF.PrintFlexibleScreen(this, base.printOption, udcPrint, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ProcDelete()
        {
            try
            {
                if (Tran_BoxID_Delete()) // DB 삭제 후
                {
                    Tran_List_Delete(); // UI 삭제
                }
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool Tran_List_Delete()
        {
            try
            {
                spdList_Sheet1.RemoveRows(0, 1);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool Tran_BoxID_Delete()
        {
            try
            {
                TRSNode in_node = new TRSNode("TRAN_IN");
                TRSNode out_node = new TRSNode("TRAN_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_DELETE;
                in_node.AddString("BOX_ID", MPCF.Trim(spdList.ActiveSheet.Cells[0, (int)BOX_LIST.BOX_ID].Value.ToString()));
                in_node.AddString("IN_TIME", MPCF.Trim(spdList.ActiveSheet.Cells[0, (int)BOX_LIST.IN_TIME].Value.ToString()).Replace("-","").Replace(":","").Replace(" ",""));

                if (MPCF.CallService("CUS", "CWIP_Tran_Boxid_Delete", in_node, ref out_node, false) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void ProcPrintAuto()
        {
            if (spdList.ActiveSheet.RowCount == 0)
                return;

            DataTable boxDt = new DataTable();
            
            // 1. BoxID로 발행 데이터 조회
            if (!ProcSearch(ref boxDt))
            {
                return;
            }

            // 2. 리스트 상단 항목 발행
            while (MPCF.ToInt(txtPrintQty.Value) > printcnt)
            {
                printcnt++;
                ProcPrint(boxDt);
            }

            // 3. 발행 후 리스트 항목 삭제 / 테이블 데이터 삭제 CTMPPAKDAT
            if (!ProcDelete())
            {
                return;
            }
        }

        private bool ViewPackingList()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                spdList.ActiveSheet.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                if (TPDR.GetDataOne("", ref dt, "VIEW_BOX_LOT_AUTO_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdList.ActiveSheet.RowCount++;
                    spdList.ActiveSheet.Cells[i, (int)BOX_LIST.BOX_ID].Value = dt.Rows[i]["BOX_ID"].ToString();
                    spdList.ActiveSheet.Cells[i, (int)BOX_LIST.IN_TIME].Value = dt.Rows[i]["IN_TIME"].ToString();
                }

                MPCF.FitColumnHeader(spdList);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void time_Tick(object sender, EventArgs e)
        {
            try
            {
                time.Stop();

                //타이머 시간마다 리스트 확인, 리스트가 존재하지 않을때만 재조회, 순차 발행
                if (spdList.ActiveSheet.RowCount == 0)
                {
                    if (!ViewPackingList())
                    {
                        time.Start();
                        return;
                    }
                }

                //타이머 시간마다 출력
                ProcPrintAuto();

                ////INTERVAL 타임 변경시 재 시작
                //if (time.Interval != ((int)itvValue.Value * 1000))
                //{
                    //time.Stop();
                    //time.Interval = (int)itvValue.Value;
                    //time.Start();

                    printcnt = 0;

                    time.Start();

                //}
            }
            catch
            {
                time.Stop();
                time.Dispose();
                time = null;
            }
        }

        #endregion

        #region [Event Definition]

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;

                ViewPackingList();

                time = new Timer();
                time.Tick += new EventHandler(time_Tick);
                time.Interval = (int)itvValue.Value * 1000;
                time.Start();
            }
            catch
            {
            }
        }

        private void frmCUSViewTimerPackingList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (time != null && time.Enabled)
                {
                    time.Stop();
                    time.Dispose();
                    time = null;
                }
            }
            catch
            {
            }
        }

        #endregion

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (time != null)
                {
                    time.Stop();

                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }
            }
            catch
            {

            }           
        }

		private bool CheckCondition(string FuncName, int Case = 0)
		{
			try
			{
				switch (FuncName)
				{
					case CSGC.MP_CHECK_VIEW:

						break;

					case CSGC.MP_CHECK_CREATE:

						break;

					case CSGC.MP_CHECK_UPDATE:

						break;

					case CSGC.MP_CHECK_DELETE:
						if (spdList.ActiveSheet.RowCount == 0)
						{
							MPCF.ShowMsgBox(MPCF.GetMessage(461));
							return false;
						}
						break;

					default:
						break;
				}

				return true;
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
				return false;
			}
		}

		private void Tran_BoxID_Delete_Multi()
		{
			try
			{
				for (int i = 0; i < spdList.ActiveSheet.RowCount; i++)
				{
					if (Convert.ToBoolean(spdList.ActiveSheet.Cells[i, (int)BOX_LIST.CHECKBOX].Value) == true)
					{
						TRSNode in_node = new TRSNode("TRAN_IN");
						TRSNode out_node = new TRSNode("TRAN_OUT");

						MPCF.SetInMsg(in_node);
						in_node.ProcStep = MPGC.MP_STEP_DELETE;
						in_node.AddString("BOX_ID", MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)BOX_LIST.BOX_ID].Value.ToString()));
						in_node.AddString("IN_TIME", MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)BOX_LIST.IN_TIME].Value.ToString()).Replace("-", "").Replace(":", "").Replace(" ", ""));

						if (MPCF.CallService("CUS", "CWIP_Tran_Boxid_Delete", in_node, ref out_node, false) == false)
						{
							return;
						}
					}
				}

			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			}
		}

		private void Spread_List_Delete_Multi()
		{
			try
			{
				for (int i = spdList.ActiveSheet.RowCount - 1; i >= 0; i--)
				{
					if (Convert.ToBoolean(spdList.ActiveSheet.Cells[i, (int)BOX_LIST.CHECKBOX].Value) == true)
					{
						spdList.ActiveSheet.Rows.Remove(i, 1);
					}
				}
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			}
		}

		private void btnView_Click(object sender, EventArgs e)
		{
			if (time != null)
			{
				time.Stop();

				btnStart.Enabled = true;
				btnStop.Enabled = false;
			}

			MPCF.ClearList(spdList);
			if (ViewPackingList() == true)
			{
				MPCF.ShowMessage("정상적으로 조회 되었습니다.", MSG_LEVEL.INFO, false);
			}
			else
			{
				MPCF.ShowMessage("조회 결과가 없습니다.", MSG_LEVEL.WARNING, false);
			}


		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result;
			result = MPCF.ShowMsgBox(MPCF.GetMessage(451), MessageBoxButtons.YesNo);

			if (result != DialogResult.Yes)  // Data Non-commit Case
			{
				return;
			}

			if (time != null)
			{
				time.Stop();

				btnStart.Enabled = true;
				btnStop.Enabled = false;
			}

			if (!CheckCondition(CSGC.MP_CHECK_DELETE)) { return; }

			Tran_BoxID_Delete_Multi();
			Spread_List_Delete_Multi();

			ViewPackingList();
		}

		private void spdList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if (e.ColumnHeader && e.Column == 0)
			{
				//전체 헤더 선택
				string s_hChk = string.Empty;

				if (spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Text == "True")
				{
					s_hChk = "False";
				}
				else
				{
					s_hChk = "True";
				}

				spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Text = s_hChk;

				for (int i = 0; i < spdList.ActiveSheet.Rows.Count; i++)
				{
					spdList.ActiveSheet.Cells[i, 0].Text = s_hChk;
				}
			}
		}
    }
}
