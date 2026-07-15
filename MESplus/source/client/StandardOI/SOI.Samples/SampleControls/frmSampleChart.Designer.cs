namespace SOI.Samples.SampleControls
{
    partial class frmSampleChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.PieChartAppearance pieChartAppearance1 = new Infragistics.UltraChart.Resources.Appearance.PieChartAppearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement2 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.BarChartAppearance barChartAppearance1 = new Infragistics.UltraChart.Resources.Appearance.BarChartAppearance();
            this.soiGroupBox1 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiChart2 = new SOI.OIFrx.SOIControls.SOIChart(this.components);
            this.soiGroupBox7 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiChart1 = new SOI.OIFrx.SOIControls.SOIChart(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).BeginInit();
            this.soiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox7)).BeginInit();
            this.soiGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiChart1)).BeginInit();
            this.SuspendLayout();
            // 
            // soiGroupBox1
            // 
            this.soiGroupBox1._UseOITheme = false;
            this.soiGroupBox1._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance17.BackColor = System.Drawing.Color.Black;
            appearance17.BackColor2 = System.Drawing.Color.Black;
            appearance17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance17.BorderColor2 = System.Drawing.Color.Black;
            appearance17.BorderColor3DBase = System.Drawing.Color.Black;
            this.soiGroupBox1.Appearance = appearance17;
            this.soiGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            appearance19.BackColor = System.Drawing.Color.White;
            appearance19.BackColor2 = System.Drawing.Color.White;
            appearance19.BorderColor = System.Drawing.Color.Black;
            appearance19.BorderColor2 = System.Drawing.Color.Black;
            this.soiGroupBox1.ContentAreaAppearance = appearance19;
            this.soiGroupBox1.Controls.Add(this.soiChart2);
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            appearance23.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            appearance23.BorderColor = System.Drawing.Color.Black;
            appearance23.BorderColor2 = System.Drawing.Color.Black;
            appearance23.FontData.BoldAsString = "True";
            appearance23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox1.HeaderAppearance = appearance23;
            this.soiGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor;
            this.soiGroupBox1.Location = new System.Drawing.Point(716, 14);
            this.soiGroupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.soiGroupBox1.Name = "soiGroupBox1";
            this.soiGroupBox1.Size = new System.Drawing.Size(692, 569);
            this.soiGroupBox1.TabIndex = 7;
            this.soiGroupBox1.Text = "Pie Chart";
            this.soiGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
//			'SOIChart' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.soiChart2.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.PieChart;
            // 
            // soiChart2
            // 
            this.soiChart2._UseOITheme = true;
            this.soiChart2.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.soiChart2.Axis.PE = paintElement1;
            this.soiChart2.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.soiChart2.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.soiChart2.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart2.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.X.MajorGridLines.Visible = true;
            this.soiChart2.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart2.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.X.MinorGridLines.Visible = false;
            this.soiChart2.Axis.X.Visible = true;
            this.soiChart2.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.X2.Labels.ItemFormatString = "";
            this.soiChart2.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.soiChart2.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.X2.Labels.Visible = false;
            this.soiChart2.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart2.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.X2.MajorGridLines.Visible = true;
            this.soiChart2.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart2.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.X2.MinorGridLines.Visible = false;
            this.soiChart2.Axis.X2.Visible = false;
            this.soiChart2.Axis.Y.Labels.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.soiChart2.Axis.Y.Labels.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.soiChart2.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.soiChart2.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.Y.Labels.SeriesLabels.FormatString = "";
            this.soiChart2.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.Y.Labels.SeriesLabels.Visible = false;
            this.soiChart2.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.Y.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.soiChart2.Axis.Y.LineThickness = 1;
            this.soiChart2.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Transparent;
            this.soiChart2.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.Y.MajorGridLines.Visible = false;
            this.soiChart2.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart2.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.Y.MinorGridLines.Visible = false;
            this.soiChart2.Axis.Y.TickmarkInterval = 2D;
            this.soiChart2.Axis.Y.Visible = true;
            this.soiChart2.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.Y2.Labels.ItemFormatString = "";
            this.soiChart2.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.Y2.Labels.SeriesLabels.FormatString = "";
            this.soiChart2.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.Y2.Labels.Visible = false;
            this.soiChart2.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart2.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.Y2.MajorGridLines.Visible = true;
            this.soiChart2.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart2.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.Y2.MinorGridLines.Visible = false;
            this.soiChart2.Axis.Y2.Visible = false;
            this.soiChart2.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.Z.Labels.ItemFormatString = "";
            this.soiChart2.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart2.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.Z.MajorGridLines.Visible = true;
            this.soiChart2.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart2.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.Z.MinorGridLines.Visible = false;
            this.soiChart2.Axis.Z.Visible = false;
            this.soiChart2.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.Z2.Labels.ItemFormatString = "";
            this.soiChart2.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart2.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart2.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart2.Axis.Z2.Labels.Visible = false;
            this.soiChart2.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart2.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.Z2.MajorGridLines.Visible = true;
            this.soiChart2.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart2.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart2.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart2.Axis.Z2.MinorGridLines.Visible = false;
            this.soiChart2.Axis.Z2.Visible = false;
            this.soiChart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.soiChart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.soiChart2.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.soiChart2.ColorModel.AlphaLevel = ((byte)(150));
            this.soiChart2.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.soiChart2.Data.SwapRowsAndColumns = true;
            this.soiChart2.Data.ZeroAligned = true;
            this.soiChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiChart2.EmptyChartText = "";
            this.soiChart2.Legend.BackgroundColor = System.Drawing.Color.Empty;
            this.soiChart2.Location = new System.Drawing.Point(2, 28);
            this.soiChart2.Name = "soiChart2";
            pieChartAppearance1.Labels.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            pieChartAppearance1.Labels.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            pieChartAppearance1.Labels.FormatString = "<ITEM_LABEL>\n<PERCENT_VALUE:#0.##>%";
            pieChartAppearance1.Labels.LeaderDrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Solid;
            pieChartAppearance1.Labels.LeaderLineThickness = 2;
            pieChartAppearance1.RadiusFactor = 70;
            this.soiChart2.PieChart = pieChartAppearance1;
            this.soiChart2.Size = new System.Drawing.Size(688, 539);
            this.soiChart2.SOIChartBarValueType = SOI.OIFrx.SOIChartBarValueType.Percentage;
            this.soiChart2.SOIChartType = SOI.OIFrx.SOIChartType.PieChart;
            this.soiChart2.TabIndex = 0;
            // 
            // soiGroupBox7
            // 
            this.soiGroupBox7._UseOITheme = false;
            this.soiGroupBox7._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance1.BackColor = System.Drawing.Color.Black;
            appearance1.BackColor2 = System.Drawing.Color.Black;
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance1.BorderColor2 = System.Drawing.Color.Black;
            appearance1.BorderColor3DBase = System.Drawing.Color.Black;
            this.soiGroupBox7.Appearance = appearance1;
            this.soiGroupBox7.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.White;
            appearance2.BorderColor = System.Drawing.Color.Black;
            appearance2.BorderColor2 = System.Drawing.Color.Black;
            this.soiGroupBox7.ContentAreaAppearance = appearance2;
            this.soiGroupBox7.Controls.Add(this.soiChart1);
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            appearance3.BorderColor = System.Drawing.Color.Black;
            appearance3.BorderColor2 = System.Drawing.Color.Black;
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox7.HeaderAppearance = appearance3;
            this.soiGroupBox7.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor;
            this.soiGroupBox7.Location = new System.Drawing.Point(14, 14);
            this.soiGroupBox7.Margin = new System.Windows.Forms.Padding(5);
            this.soiGroupBox7.Name = "soiGroupBox7";
            this.soiGroupBox7.Size = new System.Drawing.Size(692, 569);
            this.soiGroupBox7.TabIndex = 6;
            this.soiGroupBox7.Text = "Bar Chart";
            this.soiGroupBox7.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
//			'SOIChart' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.soiChart1.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.BarChart;
            // 
            // soiChart1
            // 
            this.soiChart1._UseOITheme = true;
            this.soiChart1.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement2.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement2.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.soiChart1.Axis.PE = paintElement2;
            this.soiChart1.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.soiChart1.Axis.X.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.soiChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.soiChart1.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.soiChart1.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.soiChart1.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.soiChart1.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart1.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.X.MajorGridLines.Visible = true;
            this.soiChart1.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart1.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.X.MinorGridLines.Visible = false;
            this.soiChart1.Axis.X.Visible = false;
            this.soiChart1.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.soiChart1.Axis.X2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.soiChart1.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.soiChart1.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.soiChart1.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.soiChart1.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.soiChart1.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.X2.Labels.Visible = false;
            this.soiChart1.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart1.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.X2.MajorGridLines.Visible = true;
            this.soiChart1.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart1.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.X2.MinorGridLines.Visible = false;
            this.soiChart1.Axis.X2.Visible = false;
            this.soiChart1.Axis.Y.Labels.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.soiChart1.Axis.Y.Labels.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.soiChart1.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.soiChart1.Axis.Y.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.soiChart1.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart1.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.soiChart1.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart1.Axis.Y.Labels.SeriesLabels.Visible = false;
            this.soiChart1.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.Y.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.soiChart1.Axis.Y.LineThickness = 1;
            this.soiChart1.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Transparent;
            this.soiChart1.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.Y.MajorGridLines.Visible = false;
            this.soiChart1.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart1.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.Y.MinorGridLines.Visible = false;
            this.soiChart1.Axis.Y.TickmarkInterval = 2D;
            this.soiChart1.Axis.Y.Visible = true;
            this.soiChart1.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart1.Axis.Y2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.soiChart1.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart1.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.soiChart1.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.Y2.Labels.Visible = false;
            this.soiChart1.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart1.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.Y2.MajorGridLines.Visible = true;
            this.soiChart1.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart1.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.Y2.MinorGridLines.Visible = false;
            this.soiChart1.Axis.Y2.Visible = false;
            this.soiChart1.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart1.Axis.Z.Labels.ItemFormatString = "";
            this.soiChart1.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart1.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart1.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart1.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart1.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.Z.MajorGridLines.Visible = true;
            this.soiChart1.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart1.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.Z.MinorGridLines.Visible = false;
            this.soiChart1.Axis.Z.Visible = false;
            this.soiChart1.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart1.Axis.Z2.Labels.ItemFormatString = "";
            this.soiChart1.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.soiChart1.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.soiChart1.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.soiChart1.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.soiChart1.Axis.Z2.Labels.Visible = false;
            this.soiChart1.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.soiChart1.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.Z2.MajorGridLines.Visible = true;
            this.soiChart1.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.soiChart1.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.soiChart1.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.soiChart1.Axis.Z2.MinorGridLines.Visible = false;
            this.soiChart1.Axis.Z2.Visible = false;
            this.soiChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.soiChart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            barChartAppearance1.BarSpacing = 1;
            barChartAppearance1.SeriesSpacing = 2;
            this.soiChart1.BarChart = barChartAppearance1;
            this.soiChart1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.soiChart1.ColorModel.AlphaLevel = ((byte)(150));
            this.soiChart1.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.soiChart1.Data.ZeroAligned = true;
            this.soiChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiChart1.EmptyChartText = "";
            this.soiChart1.Legend.BackgroundColor = System.Drawing.Color.Empty;
            this.soiChart1.Location = new System.Drawing.Point(2, 28);
            this.soiChart1.Name = "soiChart1";
            this.soiChart1.Size = new System.Drawing.Size(688, 539);
            this.soiChart1.SOIChartBarValueType = SOI.OIFrx.SOIChartBarValueType.Percentage;
            this.soiChart1.SOIChartType = SOI.OIFrx.SOIChartType.BarChart;
            this.soiChart1.TabIndex = 0;
            // 
            // frmSampleChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 600);
            this.Controls.Add(this.soiGroupBox1);
            this.Controls.Add(this.soiGroupBox7);
            this.Name = "frmSampleChart";
            this.Text = "frmSampleChart";
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).EndInit();
            this.soiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox7)).EndInit();
            this.soiGroupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiChart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OIFrx.SOIControls.SOIGroupBox soiGroupBox7;
        private OIFrx.SOIControls.SOIChart soiChart1;
        private OIFrx.SOIControls.SOIGroupBox soiGroupBox1;
        private OIFrx.SOIControls.SOIChart soiChart2;
    }
}