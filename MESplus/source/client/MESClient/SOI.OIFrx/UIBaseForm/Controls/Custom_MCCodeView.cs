using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System;
using System.ComponentModel;
using Miracom.UI;
using Miracom.CliFrx;

namespace SOI.OIFrx
{
            [DefaultEvent("SelectedItemChanged")]
            public class Custom_MCCodeView : Miracom.UI.Controls.MCControlBase
            {
                #region " Event Handler"

                private MCCodeViewSelChangedHandler SelectedItemChangedEvent;
                public event MCCodeViewSelChangedHandler SelectedItemChanged
                {
                    add
                    {
                        SelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(SelectedItemChangedEvent, value);
                    }
                    remove
                    {
                        SelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(SelectedItemChangedEvent, value);
                    }
                }

                private System.EventHandler ButtonPressEvent;
                public event System.EventHandler ButtonPress
                {
                    add
                    {
                        ButtonPressEvent = (System.EventHandler)System.Delegate.Combine(ButtonPressEvent, value);
                    }
                    remove
                    {
                        ButtonPressEvent = (System.EventHandler)System.Delegate.Remove(ButtonPressEvent, value);
                    }
                }

                private System.Windows.Forms.KeyPressEventHandler TextBoxKeyPressEvent;
                public event System.Windows.Forms.KeyPressEventHandler TextBoxKeyPress
                {
                    add
                    {
                        TextBoxKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(TextBoxKeyPressEvent, value);
                    }
                    remove
                    {
                        TextBoxKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(TextBoxKeyPressEvent, value);
                    }
                }

                private System.EventHandler TextBoxTextChangedEvent;
                public event System.EventHandler TextBoxTextChanged
                {
                    add
                    {
                        TextBoxTextChangedEvent = (System.EventHandler)System.Delegate.Combine(TextBoxTextChangedEvent, value);
                    }
                    remove
                    {
                        TextBoxTextChangedEvent = (System.EventHandler)System.Delegate.Remove(TextBoxTextChangedEvent, value);
                    }
                }

                private System.EventHandler TextBoxLostFocusEvent;
                public event System.EventHandler TextBoxLostFocus
                {
                    add
                    {
                        TextBoxLostFocusEvent = (System.EventHandler)System.Delegate.Combine(TextBoxLostFocusEvent, value);
                    }
                    remove
                    {
                        TextBoxLostFocusEvent = (System.EventHandler)System.Delegate.Remove(TextBoxLostFocusEvent, value);
                    }
                }

                private System.EventHandler TextBoxGotFocusEvent;
                private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDisplay;
                private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDesc;
                private Panel pnlDisplay;
                private Panel txtDescPadding;
                private Panel panel1;
            
                public event System.EventHandler TextBoxGotFocus
                {
                    add
                    {
                        TextBoxGotFocusEvent = (System.EventHandler)System.Delegate.Combine(TextBoxGotFocusEvent, value);
                    }
                    remove
                    {
                        TextBoxGotFocusEvent = (System.EventHandler)System.Delegate.Remove(TextBoxGotFocusEvent, value);
                    }
                }

                #endregion

                #region " Windows Form 디자이너에서 생성한 코드 "

                private Custom_MCCodeViewPopup m_MCCodeViewPopup = null;

                public Custom_MCCodeView()
                {
                    //이 호출은 Windows Form 디자이너에 필요합니다.
                    InitializeComponent();

                    //InitializeComponent()를 호출한 다음에 초기화 작업을 추가하십시오.

                    this.btnButton.Visible = VisibleButton;

                }

                //UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
                protected override void Dispose(bool disposing)
                {
                    if (disposing)
                    {
                        if (this.m_MCCodeViewPopup != null)
                        {
                            this.m_MCCodeViewPopup.Dispose();
                            this.m_MCCodeViewPopup = null;
                        }

                        if (!(components == null))
                        {
                            components.Dispose();
                        }
                    }

                    base.Dispose(disposing);
                }

                private IContainer components;

                private System.Windows.Forms.ToolTip tipToolTip;
                private System.Windows.Forms.ImageList imlButton;
                private System.Windows.Forms.Panel pnlText;
                private System.Windows.Forms.TextBox txtCode;
                private System.Windows.Forms.Button btnButton;
                private System.Windows.Forms.Panel pnlDesc;
                [System.Diagnostics.DebuggerStepThrough()]
                private void InitializeComponent()
                {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Custom_MCCodeView));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.imlButton = new System.Windows.Forms.ImageList(this.components);
            this.tipToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlText = new System.Windows.Forms.Panel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.txtDisplay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnButton = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.pnlDesc = new System.Windows.Forms.Panel();
            this.txtDescPadding = new System.Windows.Forms.Panel();
            this.txtDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.pnlText.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplay)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlDesc.SuspendLayout();
            this.txtDescPadding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // imlButton
            // 
            this.imlButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlButton.ImageStream")));
            this.imlButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imlButton.Images.SetKeyName(0, "");
            this.imlButton.Images.SetKeyName(1, "");
            this.imlButton.Images.SetKeyName(2, "");
            // 
            // pnlText
            // 
            this.pnlText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            this.pnlText.Controls.Add(this.pnlDisplay);
            this.pnlText.Controls.Add(this.txtCode);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlText.Location = new System.Drawing.Point(0, 0);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(150, 35);
            this.pnlText.TabIndex = 1;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(174)))), ((int)(((byte)(255)))));
            this.pnlDisplay.Controls.Add(this.txtDisplay);
            this.pnlDisplay.Controls.Add(this.panel1);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Padding = new System.Windows.Forms.Padding(2, 2, 3, 2);
            this.pnlDisplay.Size = new System.Drawing.Size(150, 35);
            this.pnlDisplay.TabIndex = 7;
            // 
            // txtDisplay
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            appearance3.BackColor2 = System.Drawing.Color.Gray;
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ForeColorDisabled = System.Drawing.Color.Silver;
            this.txtDisplay.Appearance = appearance3;
            this.txtDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            this.txtDisplay.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.txtDisplay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDisplay.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplay.Location = new System.Drawing.Point(2, 2);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(123, 31);
            this.txtDisplay.TabIndex = 5;
            this.txtDisplay.TextChanged += new System.EventHandler(this.txtDisplay_TextChanged);
            this.txtDisplay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDisplay_KeyDown);
            this.txtDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDisplay_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(125, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.panel1.Size = new System.Drawing.Size(22, 31);
            this.panel1.TabIndex = 7;
            // 
            // btnButton
            // 
            this.btnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            this.btnButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnButton.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButton.ForeColor = System.Drawing.Color.Aqua;
            this.btnButton.ImageList = this.imlButton;
            this.btnButton.Location = new System.Drawing.Point(0, 1);
            this.btnButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnButton.Name = "btnButton";
            this.btnButton.Size = new System.Drawing.Size(22, 29);
            this.btnButton.TabIndex = 1;
            this.btnButton.Text = "▼";
            this.btnButton.UseVisualStyleBackColor = false;
            this.btnButton.Click += new System.EventHandler(this.Button_Click);
            this.btnButton.MouseHover += new System.EventHandler(this.btnButton_MouseHover);
            this.btnButton.Resize += new System.EventHandler(this.btnButton_Resize);
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            this.txtCode.ForeColor = System.Drawing.Color.White;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(150, 20);
            this.txtCode.TabIndex = 4;
            this.txtCode.Visible = false;
            // 
            // pnlDesc
            // 
            this.pnlDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            this.pnlDesc.Controls.Add(this.txtDescPadding);
            this.pnlDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesc.Location = new System.Drawing.Point(150, 0);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlDesc.Size = new System.Drawing.Size(150, 35);
            this.pnlDesc.TabIndex = 0;
            this.pnlDesc.Visible = false;
            // 
            // txtDescPadding
            // 
            this.txtDescPadding.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(63)))), ((int)(((byte)(113)))));
            this.txtDescPadding.Controls.Add(this.txtDesc);
            this.txtDescPadding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescPadding.Location = new System.Drawing.Point(8, 0);
            this.txtDescPadding.Name = "txtDescPadding";
            this.txtDescPadding.Padding = new System.Windows.Forms.Padding(2);
            this.txtDescPadding.Size = new System.Drawing.Size(142, 35);
            this.txtDescPadding.TabIndex = 7;
            // 
            // txtDesc
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            appearance1.BackColor2 = System.Drawing.Color.Gray;
            appearance1.BorderColor = System.Drawing.Color.Transparent;
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.ForeColorDisabled = System.Drawing.Color.Silver;
            this.txtDesc.Appearance = appearance1;
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            this.txtDesc.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.txtDesc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.Location = new System.Drawing.Point(2, 2);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(138, 21);
            this.txtDesc.TabIndex = 6;
            // 
            // Custom_MCCodeView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnlDesc);
            this.Controls.Add(this.pnlText);
            this.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.Name = "Custom_MCCodeView";
            this.Size = new System.Drawing.Size(300, 35);
            this.FontChanged += new System.EventHandler(this.MCCodeView_FontChanged);
            this.Resize += new System.EventHandler(this.MCCodeView_Resize);
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.pnlDisplay.ResumeLayout(false);
            this.pnlDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlDesc.ResumeLayout(false);
            this.txtDescPadding.ResumeLayout(false);
            this.txtDescPadding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                #region "Properties Implements"

                private bool m_IsKeyPress = false;
                private string m_KeyPressText = "";

                private ListViewItem m_SelectedItem = null;

                private Size m_DropDownSize; // not used
                private int m_SelectedSubItemIndex = -1;
                private int m_DisplaySubItemIndex = -1;                         // 2006.07.19. Aiden Koo
                private int m_SelectedDescIndex = -1;                           // 2006.07.19. Aiden Koo
                private FlatStyle m_btnFlatStyle = FlatStyle.Popup;
                private bool m_bIsViewBtnImage = false;
                private string m_sBtnToolTipText = "";
                private string m_sTextBoxToolTipText = "";
                private System.Windows.Forms.BorderStyle m_StyleBorder = BorderStyle.None;
                private int m_iButtonWidth = 20;
                private bool m_bVisibleButton = true;
                private bool m_bVisibleDesc = false;
                private bool m_bVisibleColumnHeader = false;
                private int m_iIndex = 0; // not used
                private bool m_bReadOnly = false;
                private bool m_bIsPopup = true;
                private Color m_crBackColor = System.Drawing.Color.FromArgb(20, 37, 60);  
                private int m_iMaxLength = 32767;
                private object m_objFocusing = null;
                private int m_SearchSubItemIndex = 0;
                private bool m_bSameWidthHeightOfButton = false;
                //private object m_MCCodeViewPopup;
               
                public object Focusing
                {
                    get
                    {
                        return m_objFocusing;
                    }
                    set
                    {
                        m_objFocusing = value;
                    }
                }

                public ListView GetListView
                {
                    get
                    {
                        tipToolTip.Active = false;
                        return ((ListView)m_MCCodeViewPopup.m_MCCodeDropList);
                    }
                }

                public FlatStyle BtnFlatStyle
                {
                    get
                    {
                        return m_btnFlatStyle;
                    }
                    set
                    {
                        m_btnFlatStyle = value;
                        btnButton.FlatStyle = m_btnFlatStyle;
                        if (value == FlatStyle.System)
                        {
                            IsViewBtnImage = false;
                        }
                    }
                }

                public bool IsViewBtnImage
                {
                    get
                    {
                        return m_bIsViewBtnImage;
                    }
                    set
                    {
                        m_bIsViewBtnImage = value;
                        if (m_bIsViewBtnImage == true)
                        {
                            btnButton.ImageIndex = 1;
                            btnButton.Text = "";
                            if (BtnFlatStyle == FlatStyle.System)
                            {
                                BtnFlatStyle = FlatStyle.Standard;
                            }
                        }
                        else
                        {
                            btnButton.ImageIndex = -1;
                            btnButton.Text = "▼";
                            btnButton.Invalidate(false);
                        }
                    }
                }

                public string BtnToolTipText
                {
                    get
                    {
                        return m_sBtnToolTipText;
                    }
                    set
                    {
                        m_sBtnToolTipText = value;
                        tipToolTip.SetToolTip(btnButton, m_sBtnToolTipText);
                    }
                }

                public string TextBoxToolTipText
                {
                    get
                    {
                        return m_sTextBoxToolTipText;
                    }
                    set
                    {
                        m_sTextBoxToolTipText = value;
                        tipToolTip.SetToolTip(txtDisplay, m_sTextBoxToolTipText);
                    }
                }

                public BorderStyle StyleBorder
                {
                    get
                    {
                        return m_StyleBorder;
                    }
                    set
                    {
                        m_StyleBorder = value;
                        //txtDisplay.BorderStyle = m_StyleBorder;
                    }
                }

                public ImageList SmallImageList
                {
                    get
                    {
                        return m_MCCodeViewPopup.m_MCCodeDropList.SmallImageList;
                    }
                    set
                    {
                        m_MCCodeViewPopup.m_MCCodeDropList.SmallImageList = value;
                    }
                }

                public int SelectedSubItemIndex
                {
                    get
                    {
                        return m_SelectedSubItemIndex;
                    }
                    set
                    {
                        m_SelectedSubItemIndex = value;

                        // 2006.07.19. Aiden Koo
                        if (m_DisplaySubItemIndex == -1)
                        {
                            m_DisplaySubItemIndex = value;
                            m_MCCodeViewPopup.DisplaySubItemIndex = value;
                        }

                        m_MCCodeViewPopup.SelectedSubItemIndex = value;
                    }
                }

                // 2006.07.19. Aiden Koo
                public int DisplaySubItemIndex
                {
                    get
                    {
                        return m_DisplaySubItemIndex;
                    }
                    set
                    {
                        m_DisplaySubItemIndex = value;
                        m_MCCodeViewPopup.DisplaySubItemIndex = value;
                    }
                }

                // 2006.07.19. Aiden Koo
                public int SelectedDescIndex
                {
                    get
                    {
                        return m_SelectedDescIndex;
                    }
                    set
                    {
                        m_SelectedDescIndex = value;
                    }
                }

                public int SearchSubItemIndex
                {
                    get
                    {
                        return m_SearchSubItemIndex;
                    }
                    set
                    {
                        m_SearchSubItemIndex = value;
                    }
                }

                public override string Text
                {
                    get
                    {
                        if (m_DisplaySubItemIndex == m_SelectedSubItemIndex)
                        {
                            return txtDisplay.Text;
                        }
                        else
                        {
                            return txtCode.Text;
                        }
                    }
                    set
                    {
                        if (m_DisplaySubItemIndex == m_SelectedSubItemIndex)
                        {
                            txtDisplay.Text = value;
                        }
                        else if (m_SelectedSubItemIndex < 0 ||
                                m_DisplaySubItemIndex < 0 ||
                                m_SelectedSubItemIndex > GetListView.Columns.Count - 1 ||
                                m_DisplaySubItemIndex > GetListView.Columns.Count - 1)
                        {
                            // 2007.01.16. Aiden Koo.
                            // Index가 범위를 벗어난 경우
                            txtDisplay.Text = value;
                            txtCode.Text = value;
                        }
                        else
                        {
                            txtCode.Text = value;

                            if (value != null)
                            {
                                if (value.Trim() == "")
                                {
                                    txtDisplay.Text = "";
                                }
                                else
                                {
                                    if (GetListView.Items.Count > 0)
                                    {
                                        int i;

                                        for (i = 0; i < GetListView.Items.Count; i++)
                                        {
                                            if (GetListView.Items[i].SubItems[m_SelectedSubItemIndex].Text != null)
                                            {
                                                if (GetListView.Items[i].SubItems[m_SelectedSubItemIndex].Text.Trim() == value.Trim())
                                                {
                                                    txtDisplay.Text = GetListView.Items[i].SubItems[m_DisplaySubItemIndex].Text;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                txtDisplay.Text = "";
                            }
                        }

                        if (m_bVisibleDesc == true)
                        {
                            if (m_SelectedSubItemIndex < 0 ||
                                m_DisplaySubItemIndex < 0 ||
                                m_SelectedSubItemIndex > GetListView.Columns.Count - 1 ||
                                m_DisplaySubItemIndex > GetListView.Columns.Count - 1)
                            {
                                // 2007.01.16. Aiden Koo.
                                // Index가 범위를 벗어난 경우
                                txtDesc.Text = value;
                            }
                            else if (m_SelectedSubItemIndex != m_SelectedDescIndex)
                            {

                                if (value != null)
                                {
                                    if (value.Trim() == "")
                                    {
                                        txtDesc.Text = "";
                                    }
                                    else
                                    {
                                        if (GetListView.Items.Count > 0)
                                        {
                                            int i;

                                            for (i = 0; i < GetListView.Items.Count; i++)
                                            {
                                                if (GetListView.Items[i].SubItems[m_SelectedSubItemIndex].Text != null)
                                                {
                                                    if (GetListView.Items[i].SubItems[m_SelectedSubItemIndex].Text.Trim() == value.Trim())
                                                    {
                                                        txtDesc.Text = GetListView.Items[i].SubItems[m_SelectedDescIndex].Text;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    txtDesc.Text = "";
                                }

                            }
                        }
                    }
                }

                public string DisplayText
                {
                    get
                    {
                        return txtDisplay.Text;
                    }
                    set
                    {
                        txtDisplay.Text = value;
                    }
                }

                public string DescText
                {
                    get
                    {
                        return txtDesc.Text;
                    }
                    set
                    {
                        txtDesc.Text = value;
                    }
                }

                //add by CM Koo. 2005.08.25
                public TextBox GetTextBox
                {
                    get
                    {
                        if (m_DisplaySubItemIndex == m_SelectedSubItemIndex)
                        {
                            return txtCode;
                        }
                        else
                        {
                            return txtCode;
                        }
                    }
                }

                public TextBox GetDisplayTextBox
                {
                    get
                    {
                        return txtCode;
                    }
                }

                public int TextBoxWidth
                {
                    get
                    {
                        return pnlText.Width;
                    }
                    set
                    {
                        pnlText.Width = value;
                    }
                }

                public bool VisibleButton
                {
                    get
                    {
                        return m_bVisibleButton;
                    }
                    set
                    {
                        m_bVisibleButton = value;
                        btnButton.Visible = m_bVisibleButton;
                    }
                }

                public bool VisibleDescription
                {
                    get
                    {
                        return m_bVisibleDesc;
                    }
                    set
                    {
                        m_bVisibleDesc = value;
                        pnlDesc.Visible = m_bVisibleDesc;
                    }
                }

                public bool VisibleColumnHeader
                {
                    get
                    {
                        return m_bVisibleColumnHeader;
                    }
                    set
                    {
                        m_bVisibleColumnHeader = value;
                        if (value == true)
                        {
                            this.m_MCCodeViewPopup.m_MCCodeDropList.HeaderStyle = ColumnHeaderStyle.Clickable;
                        }
                        else
                        {
                            this.m_MCCodeViewPopup.m_MCCodeDropList.HeaderStyle = ColumnHeaderStyle.None;
                        }
                        this.m_MCCodeViewPopup.VisibleColumnHeader = value;
                    }
                }

                public int Index
                {
                    get
                    {
                        return m_iIndex;
                    }
                    set
                    {
                        m_iIndex = value;
                    }
                }

                public bool ReadOnly
                {
                    get
                    {
                        return m_bReadOnly;
                    }
                    set
                    {
                        m_bReadOnly = value;
                        txtDisplay.ReadOnly = m_bReadOnly;
                        txtDisplay.BackColor = BackColor;
                    }
                }

                public new Color BackColor
                {
                    get
                    {
                        return m_crBackColor;
                    }
                    set
                    {
                        m_crBackColor = value;
                        txtDisplay.BackColor = m_crBackColor;
                    }
                }

                public int MaxLength
                {
                    get
                    {
                        return m_iMaxLength;
                    }
                    set
                    {
                        if (value < 0 || value > 32767)
                        {
                            value = 32767;
                        }
                        m_iMaxLength = value;
                        txtDisplay.MaxLength = m_iMaxLength;
                    }
                }

                public int SelectionStart
                {
                    get
                    {
                        return txtDisplay.SelectionStart;
                    }
                    set
                    {
                        if (value < 0 || value > 32767)
                        {
                            value = 32767;
                        }
                        txtDisplay.SelectionStart = value;
                    }
                }

                public int ButtonWidth
                {
                    get
                    {
                        return m_iButtonWidth;
                    }
                    set
                    {
                        if (m_bVisibleButton == true && m_bSameWidthHeightOfButton == false)
                        {
                            if (value < 1)
                            {
                                m_iButtonWidth = 1;
                            }
                            else
                            {
                                m_iButtonWidth = value;
                                btnButton.Width = m_iButtonWidth;
                            }
                        }
                    }
                }

                public bool SameWidthHeightOfButton
                {
                    get
                    {
                        return m_bSameWidthHeightOfButton;
                    }
                    set
                    {
                        m_bSameWidthHeightOfButton = value;
                        btnButton_Resize(null, null);
                    }
                }


                [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Size DropDownSize
                {
                    get
                    {
                        return m_DropDownSize;
                    }
                    set
                    {
                        m_DropDownSize = value;
                    }
                }

                [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public ListView.ListViewItemCollection Items
                {
                    get
                    {
                        return m_MCCodeViewPopup.Items;
                    }
                }

                [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public ListView.ColumnHeaderCollection Columns
                {
                    get
                    {
                        return m_MCCodeViewPopup.Columns;
                    }
                }

                [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public ListViewItem SelectedItem
                {
                    get
                    {
                        return m_SelectedItem;
                    }
                }

                [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public bool IsPopup
                {
                    get
                    {
                        return m_bIsPopup;
                    }
                    set
                    {
                        m_bIsPopup = value;
                    }
                }


                #endregion

                public void Init()
                {

                    m_MCCodeViewPopup.m_MCCodeDropList.Clear();
                    SmallImageList = imlButton;
                }

                public bool AddEmptyRow(int iRowCount)
                {

                    int i = 0;
                    int j = 0;
                    ListViewItem itmx = null;

                    try
                    {
                        for (i = 0; i < iRowCount; i++)
                        {
                            itmx = new ListViewItem("");
                            for (j = 0; j < Columns.Count; j++)
                            {
                                itmx.SubItems.Add("");
                            }
                            Items.Add(itmx);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "AddEmptyRow()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    return true;

                }

                public bool InsertEmptyRow(int InsertIndex, int iRowCount)
                {

                    int i = 0;
                    int j = 0;
                    ListViewItem itmx = null;

                    try
                    {
                        for (i = 0; i < iRowCount; i++)
                        {
                            itmx = new ListViewItem("");
                            for (j = 0; j < Columns.Count; j++)
                            {
                                itmx.SubItems.Add("");
                            }
                            Items.Insert(InsertIndex, itmx);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "AddEmptyRow()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    return true;

                }

                private void OnPopUp_SelectionChanged(object sender, MCCodeViewSelChanged_EventArgs e)
                {

                    m_MCCodeViewPopup.DroppedDownFlag = false;
                    txtDisplay.Text = e.DisplayText;
                    txtCode.Text = e.Text;
                    m_SelectedItem = e.SelectedItem;

                    if (m_SelectedDescIndex > -1)
                    {
                        txtDesc.Text = e.SelectedItem.SubItems[m_SelectedDescIndex].Text;
                    }
                    else
                    {
                        txtDesc.Text = "";
                    }

                    
                    txtDisplay.Focus();
                    txtDisplay.Select(txtDisplay.TextLength, 0);

                    MCCodeViewSelChanged_EventArgs oArgs = new MCCodeViewSelChanged_EventArgs(m_SelectedItem, e.SelectedSubItemIndex, e.DisplaySubItemIndex);
                    if (SelectedItemChangedEvent != null)
                        SelectedItemChangedEvent(this, oArgs);

                }

                private void Button_Click(System.Object sender, System.EventArgs e)
                {

                    if (ButtonPressEvent != null)
                        ButtonPressEvent(this, e);

                    if (IsPopup == false)
                    {
                        IsPopup = true;
                        return;
                    }

                    OnButtonPress();

                }

                public void OnButtonPress()
                {

                    if (m_MCCodeViewPopup.DroppedDownFlag == true)
                    {
                        return;
                    }

                    ShowPopUp();

                }

                public void ListClear()
                {

                    Columns.Clear();
                    Items.Clear();

                }

                public void ShowPopUp()
                {
                    m_MCCodeViewPopup.Position = this.PointToScreen(new Point(btnButton.Left + btnButton.Width / 2, btnButton.Top + btnButton.Height / 2));
                    if (m_MCCodeViewPopup.ShowPopup(true) == false)
                    {
                        if (m_MCCodeViewPopup.m_MCCodeDropList.GCMTableName.Trim() != "")
                        {
                            tipToolTip.SetToolTip(this.btnButton, m_MCCodeViewPopup.m_MCCodeDropList.GCMTableName);
                        }
                        else
                        {
                            tipToolTip.SetToolTip(this.btnButton, "No Data");
                        }
                        tipToolTip.AutomaticDelay = 0;
                        tipToolTip.AutoPopDelay = 5000;
                        tipToolTip.Active = true;
                        if (!(Focusing == null))
                        {
                            //Focusing.Focus();
                        }
                        return;
                    }
                    if (m_MCCodeViewPopup.m_MCCodeDropList.GCMTableName.Trim() != "")
                    {
                        tipToolTip.SetToolTip(this.btnButton, m_MCCodeViewPopup.m_MCCodeDropList.GCMTableName);
                        tipToolTip.AutomaticDelay = 0;
                        tipToolTip.AutoPopDelay = 5000;
                        tipToolTip.Active = true;
                    }
                    else
                    {
                        tipToolTip.Active = false;
                    }
                    m_MCCodeViewPopup.DroppedDownFlag = true;

                    m_MCCodeViewPopup.m_MCCodeDropList.Focus();

                    if (this.Text != "")
                    {
                        m_MCCodeViewPopup.FocusItem(this.Text, SelectedSubItemIndex);
                    }
                }

                private void txtDisplay_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
                {

                    if (e.KeyCode == Keys.Down)
                    {
                        if (ButtonPressEvent != null)
                            ButtonPressEvent(this, e);
                        if (m_MCCodeViewPopup.DroppedDownFlag == true)
                        {
                            return;
                        }
                        ShowPopUp();
                    }

                }

                private void txtDisplay_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
                {

                    if (TextBoxKeyPressEvent != null)
                        TextBoxKeyPressEvent(this, e);

                    m_IsKeyPress = true;
                    m_KeyPressText = txtDisplay.Text;

                    // Display TextBox에 값을 입력하고 엔터를 눌렀을 때에 리스트가 존재하고
                    // Code값을 화면에 표시하고
                    // Description을 표시하며 Code값의 인덱스와 Desc의 인덱스가 다르다면
                    // Code값에 대한 Desc를 화면에 표시한다.
                    if (txtDisplay.Text != null && txtDisplay.Text.Trim() != "" &&
                        e.KeyChar == 13 && GetListView.Items.Count > 0 &&
                        m_SelectedSubItemIndex == m_DisplaySubItemIndex && m_bVisibleDesc == true && m_SelectedSubItemIndex != m_SelectedDescIndex)
                    {
                        this.Text = Text;
                    }
                }

                private void txtDisplay_TextChanged(object sender, System.EventArgs e)
                {

                    if (m_DisplaySubItemIndex == m_SelectedSubItemIndex)
                    {
                        txtCode.Text = txtDisplay.Text;
                    }

                    //if (m_bVisibleDesc == true)
                    {
                        if (txtDisplay.Text != null)
                        {
                            if (txtDisplay.Text.Trim() == "")
                            {
                                txtCode.Text = "";
                                txtDesc.Text = "";
                            }
                        }
                    }

                    if (m_IsKeyPress == true && m_KeyPressText != txtDisplay.Text)
                    {
                        txtCode.Text = txtDisplay.Text;

                        m_IsKeyPress = false;
                        m_KeyPressText = "";
                    }

                    if (TextBoxTextChangedEvent != null)
                        TextBoxTextChangedEvent(this, e);

                }

                private void txtDisplay_LostFocus(object sender, System.EventArgs e)
                {

                    if (TextBoxLostFocusEvent != null)
                        TextBoxLostFocusEvent(this, e);

                }

                private void txtDisplay_GotFocus(object sender, System.EventArgs e)
                {

                    if (TextBoxGotFocusEvent != null)
                        TextBoxGotFocusEvent(this, e);

                }

                private void MCCodeView_Resize(object sender, System.EventArgs e)
                {
                    if (VisibleDescription == false)
                    {
                        pnlText.Width = this.Width;
                    }
                }

                private void MCCodeView_FontChanged(object sender, System.EventArgs e)
                {

                    this.m_MCCodeViewPopup.Font = this.Font;
                    this.pnlText.Font = this.Font;
                    this.txtDisplay.Font = this.Font;
                    this.txtDesc.Font = this.Font;

                }

                private void btnButton_MouseHover(object sender, EventArgs e)
                {
                    tipToolTip.AutomaticDelay = 0;
                    tipToolTip.AutoPopDelay = 5000;
                    tipToolTip.Active = true;
                }
                              
                private void btnButton_Resize(object sender, EventArgs e)
                {
                    if (m_bVisibleButton == true && m_bSameWidthHeightOfButton == true)
                    {
                        btnButton.Width = btnButton.Height;
                        m_iButtonWidth = btnButton.Height;
                    }
                }




            }

}
