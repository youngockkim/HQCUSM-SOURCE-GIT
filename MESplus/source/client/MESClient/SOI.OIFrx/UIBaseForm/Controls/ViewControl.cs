using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    public partial class ViewControl : Form
    {
        private DataTable m_dt = new DataTable();
        TextBox QueryStatement = new TextBox();
        string sMenuName = null;

        public ViewControl()
        {
            InitializeComponent();
        }

        public DataTable DataSource
        {
            get { return m_dt; }
            set
            {
                //m_dt.TableName = "SpdData";
                m_dt = value;
            }
        }

        /// <summary>
        /// View SQL Query
        /// </summary>
        private string ViewSQL()
        {
            return MOGV.gsQueryStatementLong;
        }
        /// <summary>
        /// Columns Hide
        /// </summary>
        /// <param name="psMenuName"></param>
        public ViewControl(string psMenuName)
        {
            InitializeComponent();

            sMenuName = psMenuName;

            //this.TitleBar.TitleBarCaption = sMenuName;
            //this.StatusBar.BarHeight = 15;
            //this.TitleBar.ShouldDrawButtonBox = false;
            //for (int i = 0; i < 3; i++)
            //{
            //    this.TitleBar.TitleBarButtons.RemoveAt(0);
            //}

            //this.UseMainIcon = false;
            //this.StatusBar.UseSizeGrip = false;
            this.Text = "View Control";

        }

        private void SpreadControl_Load(object sender, EventArgs e)
        {
            switch (sMenuName)
            {
                case "View Query":
                    this.Size = new Size(800, 600);
                    this.Text = "View Query Statement";
                    panel7.Dock = DockStyle.Fill;

                    UcQueryViewer viewer = new UcQueryViewer();
                    viewer.Text = ViewSQL();
                    panel7.Controls.Add(viewer);
                    viewer.BringToFront();

                    //QueryStatement.Multiline = true;                
                    //QueryStatement.Text = ViewSQL();
                    //QueryStatement.ScrollBars = ScrollBars.Vertical;
                    //panel7.Controls.Add(QueryStatement);                    
                    //QueryStatement.Dock = DockStyle.Fill;
                    //QueryStatement.BringToFront();
                    //QueryStatement.KeyDown += new KeyEventHandler(QueryStatement_KeyDown);

                    break;

                default:
                    this.Dispose();
                    break;
            }
        }


        #region Inner Classes
        public partial class UcQueryViewer : UserControl
        {
            private delegate void AppendToolStripMenuItemEventHandler(string queryId, QueryIndex qi);

            private static readonly string[] ExcludeItems;

            static UcQueryViewer()
            {
                ExcludeItems = new string[] { "VERSION" };
            }

            #region 디자이너에서 생성한 코드
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
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region 구성 요소 디자이너에서 생성한 코드

            /// <summary> 
            /// 디자이너 지원에 필요한 메서드입니다. 
            /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
            /// </summary>
            private void InitializeComponent()
            {
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.toolStrip1 = new System.Windows.Forms.ToolStrip();
                this.SuspendLayout();
                // 
                // textBox1
                // 
                this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.textBox1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.textBox1.Location = new System.Drawing.Point(0, 25);
                this.textBox1.Multiline = true;
                this.textBox1.Name = "textBox1";
                this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                this.textBox1.Size = new System.Drawing.Size(300, 275);
                this.textBox1.TabIndex = 0;
                // 
                // toolStrip1
                // 
                this.toolStrip1.Font = new System.Drawing.Font("굴림", 9F);
                this.toolStrip1.Location = new System.Drawing.Point(0, 0);
                this.toolStrip1.Name = "toolStrip1";
                this.toolStrip1.Size = new System.Drawing.Size(300, 25);
                this.toolStrip1.TabIndex = 1;
                this.toolStrip1.Text = "toolStrip1";
                this.toolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
                this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
                // 
                // UcQueryViewer
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Controls.Add(this.textBox1);
                this.Controls.Add(this.toolStrip1);
                this.Name = "UcQueryViewer";
                this.Size = new System.Drawing.Size(300, 300);
                this.Load += new System.EventHandler(this.UcQueryViewer_Load);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.ToolStrip toolStrip1;
            #endregion

            public UcQueryViewer()
            {
                InitializeComponent();

                textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
                Dock = DockStyle.Fill;
            }

            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.A)
                    textBox1.SelectAll();
            }

            private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {
                if (e.ClickedItem.Tag is QueryIndex)
                {
                    QueryIndex qindex = e.ClickedItem.Tag as QueryIndex;
                    textBox1.Select(textBox1.TextLength - 1, 0);
                    textBox1.ScrollToCaret();
                    textBox1.Select(qindex.CommentLineIndex, 0);
                    textBox1.ScrollToCaret();
                    textBox1.Select(qindex.StartIndex, qindex.Length);
                    textBox1.Focus();
                }
            }

            private void UcQueryViewer_Load(object sender, EventArgs e)
            {
                Visible = true;
                Application.DoEvents();

                System.Threading.ThreadPool.QueueUserWorkItem(
                    new System.Threading.WaitCallback(AnalizeQuery), textBox1.Text);
            }

            private void AnalizeQuery(object state)
            {
                string text = state as string;

                if (text == null)
                    return;

                const int CommentBracket = 2; // CommentBracket: /* or */
                int index = 0;
                string open = "-------------------\r\n/*";
                string close = "*/\r\n--------------------";

                for (int i = 0; ; i++)
                {
                    int idx1 = text.IndexOf(open, index);

                    if (idx1 < 0)
                        break;

                    int idx2 = text.IndexOf(close, idx1);

                    if (idx2 < 0)
                        break;

                    string queryId = text.Substring(idx1 + open.Length, idx2 - idx1 - close.Length + 1).Trim();
                    index = idx2 + close.Length;

                    if (Array.IndexOf<string>(ExcludeItems, queryId) < 0)
                    {
                        AppendToolStripMenuItem(queryId,
                            new QueryIndex(
                            idx1,
                            idx1 + open.Length - CommentBracket,
                            idx2 + 2 * CommentBracket - idx1 - open.Length));
                    }
                }
            }

            private void AppendToolStripMenuItem(string queryId, QueryIndex qi)
            {
                if (toolStrip1.InvokeRequired)
                {
                    toolStrip1.BeginInvoke(new AppendToolStripMenuItemEventHandler(AppendToolStripMenuItem), queryId, qi);
                }
                else
                {
                    Update();
                    toolStrip1.Items.Add(queryId).Tag = qi;
                }
            }

            public override string Text
            {
                get { return textBox1.Text; }
                set { textBox1.Text = value; }
            }

            class QueryIndex
            {
                public int CommentLineIndex { get; private set; }
                public int StartIndex { get; private set; }
                public int Length { get; private set; }

                public QueryIndex(int commentLineIndex, int startIndex, int length)
                {
                    CommentLineIndex = commentLineIndex;
                    StartIndex = startIndex;
                    Length = length;
                }
            }
        }
        #endregion

    }
}
