namespace Miracom.CliFrx
{
    partial class BaseForm01
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.Controls != null)
            {
                DisposeControl(this.Controls);
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected void DisposeControl(System.Windows.Forms.Control.ControlCollection colControl)
        {
            try
            {
                foreach (System.Windows.Forms.Control l_Control in colControl)
                {
                    if (l_Control is System.Windows.Forms.Panel ||
                        l_Control is System.Windows.Forms.GroupBox ||
                        l_Control is System.Windows.Forms.TabControl ||
                        l_Control is System.Windows.Forms.TabPage)
                    {
                        DisposeControl(l_Control.Controls);
                    }
                    else if (l_Control is System.Windows.Forms.ListView)
                    {
                        if (((System.Windows.Forms.ListView)l_Control).SmallImageList != null)
                        {
                            ((System.Windows.Forms.ListView)l_Control).SmallImageList.Images.Clear();
                            ((System.Windows.Forms.ListView)l_Control).SmallImageList.Dispose();
                            ((System.Windows.Forms.ListView)l_Control).SmallImageList = null;
                        }
                    }
                    else if (l_Control is System.Windows.Forms.TreeView)
                    {
                        if (((System.Windows.Forms.TreeView)l_Control).ImageList != null)
                        {
                            ((System.Windows.Forms.TreeView)l_Control).ImageList.Images.Clear();
                            ((System.Windows.Forms.TreeView)l_Control).ImageList.Dispose();
                            ((System.Windows.Forms.TreeView)l_Control).ImageList = null;
                        }
                    }
                    else if (l_Control is Miracom.UI.Controls.MCCodeView.MCCodeView)
                    {
                        if (((Miracom.UI.Controls.MCCodeView.MCCodeView)l_Control).GetListView.SmallImageList != null)
                        {
                            ((Miracom.UI.Controls.MCCodeView.MCCodeView)l_Control).GetListView.SmallImageList.Images.Clear();
                            ((Miracom.UI.Controls.MCCodeView.MCCodeView)l_Control).GetListView.SmallImageList.Dispose();
                            ((Miracom.UI.Controls.MCCodeView.MCCodeView)l_Control).GetListView.SmallImageList = null;
                        }
                    }

                    //l_Control.Dispose();
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMsgBox("DisposeControl()\n" + ex.Message);
            }
        }


        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "BaseForm01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BaseForm01";
            this.Activated += new System.EventHandler(this.BaseForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseForm_Closed);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BaseForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

    }
}