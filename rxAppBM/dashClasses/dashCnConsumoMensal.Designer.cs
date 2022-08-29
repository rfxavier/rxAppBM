namespace rxAppBM.dashClasses
{
    partial class dashCnConsumoMensal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.DashboardCommon.Dimension dimension1 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension2 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension3 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension4 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.ChartPane chartPane1 = new DevExpress.DashboardCommon.ChartPane();
            DevExpress.DashboardCommon.SimpleSeries simpleSeries1 = new DevExpress.DashboardCommon.SimpleSeries();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup2 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem2 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem3 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem4 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardParameter dashboardParameter1 = new DevExpress.DashboardCommon.DashboardParameter();
            DevExpress.DashboardCommon.DashboardParameter dashboardParameter2 = new DevExpress.DashboardCommon.DashboardParameter();
            this.comboBoxDashboardItem1 = new DevExpress.DashboardCommon.ComboBoxDashboardItem();
            this.dashboardObjectDataSource1 = new DevExpress.DashboardCommon.DashboardObjectDataSource();
            this.comboBoxDashboardItem2 = new DevExpress.DashboardCommon.ComboBoxDashboardItem();
            this.comboBoxDashboardItem3 = new DevExpress.DashboardCommon.ComboBoxDashboardItem();
            this.chartDashboardItem1 = new DevExpress.DashboardCommon.ChartDashboardItem();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // comboBoxDashboardItem1
            // 
            this.comboBoxDashboardItem1.ComponentName = "comboBoxDashboardItem1";
            dimension1.DataMember = "UnidadeGerenciamentoRegionalNome";
            dimension1.Name = "UGR Nome";
            this.comboBoxDashboardItem1.DataItemRepository.Clear();
            this.comboBoxDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0");
            this.comboBoxDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.comboBoxDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension1});
            this.comboBoxDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.comboBoxDashboardItem1.Name = "UGR";
            this.comboBoxDashboardItem1.ShowCaption = true;
            // 
            // dashboardObjectDataSource1
            // 
            this.dashboardObjectDataSource1.ComponentName = "dashboardObjectDataSource1";
            this.dashboardObjectDataSource1.DataMember = "GetConsumoPorDia";
            this.dashboardObjectDataSource1.DataSource = typeof(rxAppBM.dataObjClasses.dsConsumo);
            this.dashboardObjectDataSource1.Name = "Object Data Source 1";
            // 
            // comboBoxDashboardItem2
            // 
            this.comboBoxDashboardItem2.ComponentName = "comboBoxDashboardItem2";
            dimension2.DataMember = "UnidadeNegocioNome";
            dimension2.Name = "Unidade Negócio Nome";
            this.comboBoxDashboardItem2.DataItemRepository.Clear();
            this.comboBoxDashboardItem2.DataItemRepository.Add(dimension2, "DataItem0");
            this.comboBoxDashboardItem2.DataSource = this.dashboardObjectDataSource1;
            this.comboBoxDashboardItem2.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension2});
            this.comboBoxDashboardItem2.InteractivityOptions.IgnoreMasterFilters = true;
            this.comboBoxDashboardItem2.Name = "Unidade Negócio";
            this.comboBoxDashboardItem2.ShowCaption = true;
            // 
            // comboBoxDashboardItem3
            // 
            this.comboBoxDashboardItem3.ComponentName = "comboBoxDashboardItem3";
            dimension3.DataMember = "ConsumidorTipo";
            dimension3.Name = "Tipo Consumidor";
            this.comboBoxDashboardItem3.DataItemRepository.Clear();
            this.comboBoxDashboardItem3.DataItemRepository.Add(dimension3, "DataItem0");
            this.comboBoxDashboardItem3.DataSource = this.dashboardObjectDataSource1;
            this.comboBoxDashboardItem3.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension3});
            this.comboBoxDashboardItem3.InteractivityOptions.IgnoreMasterFilters = true;
            this.comboBoxDashboardItem3.Name = "Tipo Consumidor";
            this.comboBoxDashboardItem3.ShowCaption = true;
            // 
            // chartDashboardItem1
            // 
            dimension4.DataMember = "TimestampDate";
            dimension4.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear;
            dimension4.Name = "Mês";
            this.chartDashboardItem1.Arguments.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension4});
            this.chartDashboardItem1.AxisX.TitleVisible = false;
            this.chartDashboardItem1.ComponentName = "chartDashboardItem1";
            measure1.DataMember = "PayloadVolLitersDelta";
            measure1.Name = "Litros";
            measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number;
            measure1.NumericFormat.IncludeGroupSeparator = true;
            measure1.NumericFormat.Precision = 0;
            measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones;
            this.chartDashboardItem1.DataItemRepository.Clear();
            this.chartDashboardItem1.DataItemRepository.Add(dimension4, "DataItem0");
            this.chartDashboardItem1.DataItemRepository.Add(measure1, "DataItem1");
            this.chartDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.chartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.chartDashboardItem1.Legend.Visible = false;
            this.chartDashboardItem1.Name = "Chart 1";
            chartPane1.Name = "Pane 1";
            chartPane1.PrimaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.PrimaryAxisY.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number;
            chartPane1.PrimaryAxisY.NumericFormat.IncludeGroupSeparator = true;
            chartPane1.PrimaryAxisY.NumericFormat.Precision = 0;
            chartPane1.PrimaryAxisY.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones;
            chartPane1.PrimaryAxisY.ShowGridLines = true;
            chartPane1.PrimaryAxisY.TitleVisible = true;
            chartPane1.SecondaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.SecondaryAxisY.ShowGridLines = false;
            chartPane1.SecondaryAxisY.TitleVisible = true;
            simpleSeries1.AddDataItem("Value", measure1);
            chartPane1.Series.AddRange(new DevExpress.DashboardCommon.ChartSeries[] {
            simpleSeries1});
            this.chartDashboardItem1.Panes.AddRange(new DevExpress.DashboardCommon.ChartPane[] {
            chartPane1});
            this.chartDashboardItem1.ShowCaption = false;
            // 
            // dashCnConsumoMensal
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardObjectDataSource1});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.chartDashboardItem1,
            this.comboBoxDashboardItem1,
            this.comboBoxDashboardItem2,
            this.comboBoxDashboardItem3});
            dashboardLayoutItem1.DashboardItem = this.comboBoxDashboardItem1;
            dashboardLayoutItem1.Weight = 31.852986217457886D;
            dashboardLayoutItem2.DashboardItem = this.comboBoxDashboardItem2;
            dashboardLayoutItem2.Weight = 35.911179173047472D;
            dashboardLayoutItem3.DashboardItem = this.comboBoxDashboardItem3;
            dashboardLayoutItem3.Weight = 32.235834609494638D;
            dashboardLayoutGroup2.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1,
            dashboardLayoutItem2,
            dashboardLayoutItem3});
            dashboardLayoutGroup2.DashboardItem = null;
            dashboardLayoutGroup2.Weight = 6.47921760391198D;
            dashboardLayoutItem4.DashboardItem = this.chartDashboardItem1;
            dashboardLayoutItem4.Weight = 93.520782396088023D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutGroup2,
            dashboardLayoutItem4});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            dashboardLayoutGroup1.Weight = 100D;
            this.LayoutRoot = dashboardLayoutGroup1;
            dashboardParameter1.Description = "Data Inicial";
            dashboardParameter1.Name = "parDashDataIni";
            dashboardParameter1.Type = typeof(System.DateTime);
            dashboardParameter1.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            dashboardParameter2.Description = "Data Final";
            dashboardParameter2.Name = "parDashDataFim";
            dashboardParameter2.Type = typeof(System.DateTime);
            dashboardParameter2.Value = new System.DateTime(2999, 1, 1, 0, 0, 0, 0);
            this.Parameters.AddRange(new DevExpress.DashboardCommon.DashboardParameter[] {
            dashboardParameter1,
            dashboardParameter2});
            this.Title.Text = "Consumo Mensal";
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.ChartDashboardItem chartDashboardItem1;
        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource1;
        private DevExpress.DashboardCommon.ComboBoxDashboardItem comboBoxDashboardItem1;
        private DevExpress.DashboardCommon.ComboBoxDashboardItem comboBoxDashboardItem2;
        private DevExpress.DashboardCommon.ComboBoxDashboardItem comboBoxDashboardItem3;
    }
}
