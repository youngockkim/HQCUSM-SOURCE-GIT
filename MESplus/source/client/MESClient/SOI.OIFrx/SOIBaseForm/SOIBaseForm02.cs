using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracom.TRSCore;
using SOI.CliFrx;
using SOI.OIFrx.SOIThemes;
using System.IO;
using System.Diagnostics;

using Miracom.MESCore;
using Miracom.CliFrx;

namespace SOI.OIFrx.SOIBaseForm
{
    public partial class SOIBaseForm02 : SOIBaseForm01
    {
        #region Property

        private bool b_is_favorite;
        private Miracom.CliFrx.MenuInfoTag menuInfo;
        private int iFavSeqNum;
        private int iInitCount = 0;

        public new bool _UseOITheme
        {
            get
            {
                return base._UseOITheme;
            }
            set
            {
                base._UseOITheme = value;
                SetOITheme();
            }
        }

        private string _helpInfoFileName;
        [Browsable(false)]
        public string HelpInfoFileName
        {
            get { return _helpInfoFileName; }
            set { _helpInfoFileName = value; }
        }

        private byte[] _helpInfoFile;
        [Browsable(false)]
        public byte[] HelpInfoFile
        {
            get { return _helpInfoFile; }
            set { _helpInfoFile = value; }
        }

        private SOIBaseFormStyle _soiFormStyle;
        public SOIBaseFormStyle _SOIFormStyle
        {
            get { return _soiFormStyle; }
            set 
            {
                bool bApply = true;
                if (_soiFormStyle == SOIBaseFormStyle.Undefined
                    && iInitCount < 1)
                {
                    bApply = false;
                }
                _soiFormStyle = value;
                iInitCount++;

                if (bApply == true)
                {                    
                    SetFormStyle(_soiFormStyle);                    
                }
            }
        }

        #endregion

        #region Constructor

        public SOIBaseForm02()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// 화면을 그릴 때 발생합니다.
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            // 디자인 모드에서만 적용
            if (DesignMode == true)
            {
                SetOITheme();
            }

            base.OnPaint(pe);
        }

        /// <summary>
        /// 화면 로드 시 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SOIBaseForm02_Load(object sender, EventArgs e)
        {
            //if (DesignMode == true)
            //{
            //    return;
            //}

            //// 테마 로드
            //SetOITheme();

            //// Menu 정보 로드
            //menuInfo = (Miracom.CliFrx.MenuInfoTag)this.Tag;

            //// 즐겨찾기 설정
            //SetFavorite();

            //// Help Guide 설정
            //SetHelpInfo();

            if (MOGV.gIBaseFormEvent != null)
            {
                MOGV.gIBaseFormEvent.Form_Load(this, e);
            }

        }

        
        /// <summary>
        /// Help Info File을 실행합니다.
        /// PNG, JPG, BMP 이미지 파일인 경우 내부 이미지 뷰어 팝업을 실행합니다.
        /// PDF 파일인 경우 외부 PDF 뷰어 exe 파일을 실행합니다.
        /// 기타 파일인 경우 확장자에 맞추어 외부 프로그램을 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbHelp_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우
                if (this.HelpInfoFile.Length < 1)
                {
                    return;
                }

                // 파일 확장자 체크
                string extension = System.IO.Path.GetExtension(this.HelpInfoFileName);
                if (extension.StartsWith("."))
                {
                    extension = extension.Substring(1);
                }

                // 이미지인 경우
                if (extension.ToUpper().Equals("PNG") == true
                    || extension.ToUpper().Equals("JPG") == true
                    || extension.ToUpper().Equals("BMP") == true)
                {
                    MPOF.RunImageViewer(MPOF.ByteArrayToImage(this.HelpInfoFile));
                }
                // PDF인 경우
                else
                {
                    string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + "." + extension;
                    File.WriteAllBytes(path, this.HelpInfoFile);

                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = path;
                        process.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage("SOIBaseForm02.pbHelp_Click() Error \n" + ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public new void SetOITheme()
        {
            if (_UseOITheme == true)
            {
                // 속성

                // 색상
                if (MOGV.gTheme is clsLightColors)
                {
                    pbHelp.Image = Properties.Resources.HelpImage;
                    pbStdOper.Image = Properties.Resources.InfoImage;
                }
                else
                {
                    pbHelp.Image = Properties.Resources.HelpImage_DarkGray;
                    pbStdOper.Image = Properties.Resources.InfoImage_DarkGray;
                }

                //base.SetOITheme();
            }
        }

        /// <summary>
        /// Form의 기본 Font를 변경합니다.
        /// Common Variable에 변경할 Font의 크기를 설정하고 사용합니다.
        /// OI Style: 12pt
        /// UI Style: 9pt
        /// </summary>
        /// <param name="style"></param>
        public void SetFormStyle(SOIBaseFormStyle style)
        {
            // Auto Scale Mode Change
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            // Change Auto Scroll Margin
            if (style == SOIBaseFormStyle.OI_Style)
            {
                this.pnlMiddleMargin.AutoScrollMinSize = new System.Drawing.Size(0, 599);
            }
            else if (style == SOIBaseFormStyle.UI_Style)
            {
                this.pnlMiddleMargin.AutoScrollMinSize = new System.Drawing.Size(0, 597);
            }
            
            // Change Form Font
            MPOF.ChangeFormFont(this.pnlMiddleMargin, style);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        /// <summary>
        /// 즐겨찾기 화면 여부를 설정합니다.
        /// </summary>
        /// <returns></returns>
        public bool SetFavorite()
        {
            try
            {
                // 즐겨찾기 화면인 경우
                if (CheckFavorite(this) == true)
                {
                    //pbFavorite.Image = Image.FromFile(@"SOIResources\Icons\favoriteOn.png");
                    pbFavorite.Image = Properties.Resources.favoriteOn;
                    b_is_favorite = true;
                }
                else
                {
                    //pbFavorite.Image = Image.FromFile(@"SOIResources\Icons\favoriteOff.png");
                    pbFavorite.Image = Properties.Resources.favoriteOff;
                    b_is_favorite = false;
                }

                return true;
            }
            catch(Exception ex)
            {
                MPOF.ShowMessage("SOIBaseForm02.SetFavorite() Error \n" + ex.Message, MSSAG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 즐겨찾기 화면 여부를 설정합니다.
        /// </summary>
        /// <returns></returns>
        public bool SetFavorite(bool bFavorite)
        {
            try
            {
                if (bFavorite == true)
                {
                    pbFavorite.Image = Properties.Resources.favoriteOn;
                    b_is_favorite = true;
                }
                else
                {
                    pbFavorite.Image = Properties.Resources.favoriteOff;
                    b_is_favorite = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage("SOIBaseForm02.SetFavorite(bool) Error \n" + ex.Message, MSSAG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Help 아이콘 활성화 여부를 설정합니다.
        /// 설정된 Help Guide 파일이 있는 경우 활성화 합니다.
        /// </summary>
        /// <returns></returns>
        public bool SetHelpInfo()
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_OUT");

            try
            {
                // 화면 명이 없는 경우 
                if (string.IsNullOrEmpty(this.menuInfo.s_func_name) == true)
                {
                    return false;
                }

                // Help File 호출
                MPOF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FUNC_NAME", this.menuInfo.s_func_name);
                if (MPCR.CallService("SEC", "SEC_View_Function", in_node, ref out_node) == false)
                {
                    return false;
                }
                byte[] helpBytes = out_node.GetBlob(MPGC.MP_BIN_DATA_1);

                // Help File이 있는 경우
                if (helpBytes == null || helpBytes.Length < 1)
                {
                    return false;
                }
                else
                {
                    this.HelpInfoFileName = out_node.GetString(MPGC.MP_BIN_DATA_1 + "_FILE_NAME");
                    this.HelpInfoFile = helpBytes;
                    this.pbHelp.Visible = true;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage("SOIBaseForm02.SetHelpInfo() Error \n" + ex.Message, MSSAG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 즐겨찾기 화면 여부를 확인합니다.
        /// </summary>
        /// <returns></returns>
        public bool CheckFavorite(Form frm)
        {
            bool bResult = false;

            try
            {
                // 즐겨찾기 화면목록에서
                List<TRSNode> func_list;

                if (MOGV.galFavFunctionList != null 
                    && MOGV.galFavFunctionList.Count > 0
                    && MOGV.galFavFunctionList[0] != null)
                {
                    func_list = ((TRSNode)MOGV.galFavFunctionList[0]).GetList(0);
                }
                else
                {
                    return false;
                }

                for (int i = func_list.Count; i > 0; i--)
                {
                    // 현재 화면이 있는 경우
                    if (((Miracom.CliFrx.MenuInfoTag)frm.Tag).s_func_name == func_list[i - 1].GetString("FUNC_NAME"))
                    {
                        bResult = true;
                        iFavSeqNum = i;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                MPOF.ShowMessage("SOIBaseForm02.CheckFavorite() Error \n" + ex.Message, MSSAG_LEVEL.ERROR, false);
                return false;
            }

            return bResult;
        }

        

        #endregion
    }
}
