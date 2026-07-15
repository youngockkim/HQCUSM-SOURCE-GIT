namespace SOI.OIFrx.SOIControls
{
    partial class SOIChart
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
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
//			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.BarChart;
            // 
            // SOIChart
            // 
            this.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.Axis.PE = paintElement1;
            this.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.Axis.X.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.X.MajorGridLines.Visible = true;
            this.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.X.MinorGridLines.Visible = false;
            this.Axis.X.Visible = true;
            this.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.Axis.X2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.X2.Labels.Visible = false;
            this.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.X2.MajorGridLines.Visible = true;
            this.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.X2.MinorGridLines.Visible = false;
            this.Axis.X2.Visible = false;
            this.Axis.Y.Labels.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.Axis.Y.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Near;
            this.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.Y.MajorGridLines.Visible = true;
            this.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.Y.MinorGridLines.Visible = false;
            this.Axis.Y.Visible = true;
            this.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.Axis.Y2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.Y2.Labels.Visible = false;
            this.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.Y2.MajorGridLines.Visible = true;
            this.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.Y2.MinorGridLines.Visible = false;
            this.Axis.Y2.Visible = false;
            this.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.Axis.Z.Labels.ItemFormatString = "";
            this.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.Z.MajorGridLines.Visible = true;
            this.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.Z.MinorGridLines.Visible = false;
            this.Axis.Z.Visible = false;
            this.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.Axis.Z2.Labels.ItemFormatString = "";
            this.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.Axis.Z2.Labels.Visible = false;
            this.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.Z2.MajorGridLines.Visible = true;
            this.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.Axis.Z2.MinorGridLines.Visible = false;
            this.Axis.Z2.Visible = false;
            this.ColorModel.AlphaLevel = ((byte)(150));
            this.Name = "SOIChart";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
