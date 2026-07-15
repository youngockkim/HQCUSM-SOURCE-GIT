using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FarPoint.Win.Spread;
using SOI.OIFrx.SOIControls;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using System.Windows.Forms;
using SOI.OIFrx;
using CliFrx = SOI.CliFrx;
using System.Runtime.InteropServices;

namespace BOI.OIFrx.BOIControls
{    
    

    public partial class BOISpread : SOISpread
    {
        #region Property

        //private SOIContextMenu textBoxContextMenu;

        public delegate void RowFocusChangedHandler(int iprvRow, int icurRow);

        public event RowFocusChangedHandler RowFocusChanged;
        

        private InputMap im;

        private bool blnShown = false;

        private int iprvRow = 0;

        private Form _parentForm;
        private UserControl _parentUserControl;
        private Control _parentControl;


        //private bool _useOITheme = true; // 최초 컨트롤 Add시 Default로 테마 적용
        //public bool _UseOITheme
        //{
        //    get
        //    {
        //        return _useOITheme;
        //    }
        //    set
        //    {
        //        _useOITheme = value;
        //        SetOITheme();
        //    }
        //}

        //private bool _useAutoHeight = true;
        //public bool _UseAutoHeight
        //{
        //    get
        //    {
        //        return _useAutoHeight;
        //    }
        //    set
        //    {
        //        _useAutoHeight = value;
        //        SetColumnHeaderHeight(SOIColumnHeight);
        //        SetCellHeight(SOICellHeight);
        //    }
        //}

        //private int soiColumnHeight = 30;
        //public int SOIColumnHeight
        //{
        //    get
        //    {
        //        return soiColumnHeight;
        //    }
        //    set
        //    {
        //        soiColumnHeight = value;
        //        if(_UseAutoHeight == true)
        //        {
        //            SetColumnHeaderHeight(soiColumnHeight);
        //        }
        //    }
        //}

        //private int soiCellHeight = 25;
        //public int SOICellHeight
        //{
        //    get
        //    {
        //        return soiCellHeight;
        //    }
        //    set
        //    {
        //        soiCellHeight = value;
        //        if(_UseAutoHeight == true)
        //        {
        //            SetCellHeight(soiCellHeight);
        //        }
        //    }
        //}

        //private bool useSOIContextMenu = true;
        //public bool UseSOIContextMenu
        //{
        //    get
        //    {
        //        return useSOIContextMenu;
        //    }
        //    set
        //    {
        //        useSOIContextMenu = value;
        //        SetContextMenu(useSOIContextMenu);
        //    }
        //}

        private bool useEnterKeyForMove = true;
        public bool UseEnterKeyForMove
        {
            get
            {
                return useEnterKeyForMove;
            }
            set
            {
                useEnterKeyForMove = value;                
            }
        }

        private bool useKeyPad = false;
        
        public bool UseKeyPad
        {
            get
            {
                return useKeyPad;
            }
            set
            {
                useKeyPad = value;
            }
        }

        #endregion

        #region Constructor

        public BOISpread()
        {
            //base.Events.Dispose();

            
            //InitializeComponent();

            this.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.BOISpread_LeaveCell);
            this.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.BOISpread_EnterCell);
            this.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.BOISpread_CellClick);

            if (useEnterKeyForMove == true)
            {
                
            }

            this.RowFocusChanged += new RowFocusChangedHandler(BOISpread_RowFocusChanged);

            this.HorizontalScrollBarHeight = 25;
            this.VerticalScrollBarWidth = 25;      
        }

                      
        

        void BOISpread_RowFocusChanged(int iprvRow, int icurRow)
        {
            //throw new NotImplementedException();
        }        

        #endregion

        #region Event Handler

        //protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        //{
        //    // 디자인 모드에서만 적용
        //    if (DesignMode == true)
        //    {
        //        SetOITheme();
        //    }

        //    base.OnPaint(pe);
        //}

        protected override void  OnLayout(LayoutEventArgs levent)
        {
            if (blnShown == false)
            {                                                
                FarPoint.Win.Spread.Model.ISheetDataModel isdm;
                isdm = (FarPoint.Win.Spread.Model.ISheetDataModel)this.ActiveSheet.Models.Data;
                isdm.Changed += new FarPoint.Win.Spread.Model.SheetDataModelEventHandler(isdm_Changed);
                isdm.ColumnCount = this.Sheets[0].ColumnCount;
                isdm.RowCount = this.Sheets[0].RowCount;                                      
                
            }
            if (blnShown == false && useEnterKeyForMove == true)
            {
                im = this.GetInputMap(InputMapMode.WhenFocused);
                im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRowWrap);
                im = this.GetInputMap(InputMapMode.WhenFocused);
                im.Put(new Keystroke(Keys.Enter, Keys.Shift), SpreadActions.MoveToPreviousRowWrap);
                im = this.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRowWrap);
                im = this.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                im.Put(new Keystroke(Keys.Enter, Keys.Shift), SpreadActions.MoveToPreviousRowWrap);
                im = this.GetInputMap(InputMapMode.WhenFocused);
                im.Put(new Keystroke(Keys.Delete, Keys.None), SpreadActions.ClearCell);
                Add_Form_Closed_Event_ParentForm((Control)this.GetContainerControl());
                Get_Column_Width();
                blnShown = true;
                
            }
 	        base.OnLayout(levent);            
            
        }              
        

        void isdm_Changed(object sender, FarPoint.Win.Spread.Model.SheetDataModelEventArgs e)
        {
            if (e.Type == FarPoint.Win.Spread.Model.SheetDataModelEventType.RowsRemoved)
            {
                RowFocusChanged(iprvRow, e.Row - 1);
            }                                
        }    


        private void BOISpread_EnterCell(object sender, EnterCellEventArgs e)
        {            
            if (useKeyPad == true)
            {
                if (this.ActiveSheet.Columns[e.Column].CellType is FarPoint.Win.Spread.CellType.NumberCellType &&
                    this.ActiveSheet.Columns[e.Column].Locked == false && this.ActiveSheet.Cells[e.Row, e.Column].Locked == false)
                {                    
                    BICF.ShowKeyPad(MousePosition, (int)this.ActiveSheet.GetColumnWidth(e.Column), (int)this.ActiveSheet.GetRowHeight(e.Row), this);                    
                    this.OnChange(new ChangeEventArgs(e.View, e.Row, e.Column));
                }
                
            }
        }

       

        private void BOISpread_CellClick(object sender, CellClickEventArgs e)
        {
            if (useKeyPad == true)
            {
                if (this.ActiveSheet.Columns[e.Column].CellType is FarPoint.Win.Spread.CellType.NumberCellType &&
                    this.ActiveSheet.Columns[e.Column].Locked == false && this.ActiveSheet.Cells[e.Row, e.Column].Locked == false)
                {
                    this.ActiveSheet.SetActiveCell(0, 0, true);

                }
            }
        }

        private void BOISpread_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            if (e.Row != e.NewRow)
            {
                iprvRow = e.Row;
                RowFocusChanged(iprvRow, e.NewRow);
                return;
            }            
        }

        

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        //public void SetOITheme()
        //{
            
        //}
 

        /// <summary>
        /// KeyPad로 부터 전달된 값을 덧붙여 입력합니다.
        /// </summary>
        /// <param name="oValue"></param>
        public void AddValue(object oValue)
        {
            // 현재 Value가 null인 경우
            if (this.ActiveSheet.ActiveCell.Value == null)
            {
                this.ActiveSheet.ActiveCell.Value = oValue;
            }
            else
            {
                // 0으로 시작하는 경우 0 제거
                if (this.ActiveSheet.ActiveCell.Value.ToString().StartsWith("0") == true)
                {
                    this.ActiveSheet.ActiveCell.Value = (this.ActiveSheet.ActiveCell.Value.ToString().Remove(0) + oValue.ToString());
                }
                // 0으로 시작하지 않는 경우 추가
                else
                {
                    try
                    {
                        this.ActiveSheet.ActiveCell.Value = (this.ActiveSheet.ActiveCell.Value.ToString() + oValue.ToString());
                    }
                    catch (OverflowException)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// KeyPad로 부터 전달된 삭제명령을 수행합니다.
        /// </summary>
        public void RemoveLastValue()
        {
            if (this.ActiveSheet.ActiveCell.Value != null)
            {
                if (this.ActiveSheet.ActiveCell.Value.ToString().Length == 1)
                {
                    if (this.ActiveSheet.ActiveCell.CellType is FarPoint.Win.Spread.CellType.NumberCellType)
                    {
                        if (((FarPoint.Win.Spread.CellType.NumberCellType)this.ActiveSheet.ActiveCell.CellType).DecimalPlaces > 0)
                        {
                            if (Convert.ToDouble(this.ActiveSheet.ActiveCell.Value) != 0)
                            {
                                this.ActiveSheet.ActiveCell.Value = 0.0d;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(this.ActiveSheet.ActiveCell.Value) != 0)
                            {
                                this.ActiveSheet.ActiveCell.Value = 0;
                            }
                        }
                        
                    }                    
                }
                else
                {
                    this.ActiveSheet.ActiveCell.Value = this.ActiveSheet.ActiveCell.Value.ToString().Remove(this.ActiveSheet.ActiveCell.Value.ToString().Length - 1);
                }
            }
        }

        public void Add_Form_Closed_Event_ParentForm(Control ctl)
        {
            try
            {

                if (ctl is Form)
                {
                    _parentForm = (Form)ctl;
                    _parentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
                    _parentControl = _parentForm;
                }
                else if (ctl is UserControl)
                {
                    _parentUserControl = (UserControl)ctl;
                    _parentUserControl.HandleDestroyed += new EventHandler(_parentUserControl_HandleDestroyed);
                    _parentControl = _parentUserControl;                    
                }                
                else
                {
                    Add_Form_Closed_Event_ParentForm((Control)ctl.GetContainerControl());
                }
            }
            catch
            {
            }
            
            
        }

        void _parentUserControl_HandleDestroyed(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Sheets[0].ColumnCount; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, _parentUserControl.Name + "_" + this.Name, MPCF.Trim(this.Sheets[0].ColumnHeader.Columns[i].Index), this.Sheets[0].ColumnHeader.Columns[i].Width);
                }
            }
            catch
            {
            }
        }     

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Sheets[0].ColumnCount; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, _parentForm.Name + "_" + this.Name, MPCF.Trim(this.Sheets[0].ColumnHeader.Columns[i].Index), this.Sheets[0].ColumnHeader.Columns[i].Width);
                }
            }
            catch
            {
            }
        }

        private void Get_Column_Width()
        {
            try
            {
                string keyValue = string.Empty;
                if (_parentControl != null)
                {
                    if (_parentControl is Form)
                    {
                        keyValue = _parentForm.Name + "_" + this.Name;
                    }
                    else if (_parentControl is UserControl)
                    {
                        keyValue = _parentUserControl.Name + "_" + this.Name;
                    }
                    for (int i = 0; i < this.Sheets[0].ColumnCount; i++)
                    {
                        if (MPCF.GetRegSetting(Application.ProductName, keyValue, MPCF.Trim(this.Sheets[0].ColumnHeader.Columns[i].Index)) != "")
                        {
                            this.Sheets[0].ColumnHeader.Columns[i].Width = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, keyValue, MPCF.Trim(this.Sheets[0].ColumnHeader.Columns[i].Index)));
                        }
                    }
                }
            }
            catch
            {
            }
        }        
    

        #endregion
        
    }

    
}
