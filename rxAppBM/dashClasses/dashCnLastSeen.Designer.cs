namespace rxAppBM.dashClasses
{
    partial class dashCnLastSeen
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
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn1 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Dimension dimension2 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn2 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Dimension dimension3 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn3 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Dimension dimension4 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension5 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension6 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup2 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem2 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem3 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            this.gridDashboardItem1 = new DevExpress.DashboardCommon.GridDashboardItem();
            this.comboBoxDashboardItem1 = new DevExpress.DashboardCommon.ComboBoxDashboardItem();
            this.treeViewDashboardItem1 = new DevExpress.DashboardCommon.TreeViewDashboardItem();
            this.dashboardObjectDataSource1 = new DevExpress.DashboardCommon.DashboardObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // gridDashboardItem1
            // 
            dimension1.DataMember = "PayloadId";
            dimension1.Name = "Device";
            gridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn1.AddDataItem("Dimension", dimension1);
            dimension2.DataMember = "CommDate";
            dimension2.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DateHourMinuteSecond;
            dimension2.Name = "Data última comunicação";
            gridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn2.AddDataItem("Dimension", dimension2);
            dimension3.DataMember = "commRemark";
            dimension3.Name = "Tempo desde última comunicação";
            gridDimensionColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn3.AddDataItem("Dimension", dimension3);
            this.gridDashboardItem1.Columns.AddRange(new DevExpress.DashboardCommon.GridColumnBase[] {
            gridDimensionColumn1,
            gridDimensionColumn2,
            gridDimensionColumn3});
            this.gridDashboardItem1.ComponentName = "gridDashboardItem1";
            this.gridDashboardItem1.DataItemRepository.Clear();
            this.gridDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0");
            this.gridDashboardItem1.DataItemRepository.Add(dimension2, "DataItem1");
            this.gridDashboardItem1.DataItemRepository.Add(dimension3, "DataItem2");
            this.gridDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.gridDashboardItem1.Name = "Devices";
            this.gridDashboardItem1.ShowCaption = true;
            // 
            // comboBoxDashboardItem1
            // 
            this.comboBoxDashboardItem1.ComponentName = "comboBoxDashboardItem1";
            dimension4.DataMember = "commStatus";
            dimension4.Name = "Status Comunicação";
            this.comboBoxDashboardItem1.DataItemRepository.Clear();
            this.comboBoxDashboardItem1.DataItemRepository.Add(dimension4, "DataItem0");
            this.comboBoxDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.comboBoxDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension4});
            this.comboBoxDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.comboBoxDashboardItem1.Name = "Sem Comunicação";
            this.comboBoxDashboardItem1.ShowCaption = true;
            // 
            // treeViewDashboardItem1
            // 
            this.treeViewDashboardItem1.ComponentName = "treeViewDashboardItem1";
            dimension5.DataMember = "UnidadeNegocioNome";
            dimension5.Name = "Unidade Negócio";
            dimension6.DataMember = "UnidadeGerenciamentoRegionalNome";
            dimension6.Name = "UGR";
            this.treeViewDashboardItem1.DataItemRepository.Clear();
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension5, "DataItem0");
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension6, "DataItem1");
            this.treeViewDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.treeViewDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension6,
            dimension5});
            this.treeViewDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.treeViewDashboardItem1.Name = "UN / UGR";
            this.treeViewDashboardItem1.ShowCaption = true;
            // 
            // dashboardObjectDataSource1
            // 
            this.dashboardObjectDataSource1.ComponentName = "dashboardObjectDataSource1";
            this.dashboardObjectDataSource1.Name = "Object Data Source 1";
            // 
            // dashCnLastSeen
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardObjectDataSource1});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.gridDashboardItem1,
            this.comboBoxDashboardItem1,
            this.treeViewDashboardItem1});
            dashboardLayoutItem1.DashboardItem = this.comboBoxDashboardItem1;
            dashboardLayoutItem1.Weight = 7.3619631901840492D;
            dashboardLayoutItem2.DashboardItem = this.treeViewDashboardItem1;
            dashboardLayoutItem2.Weight = 92.638036809815958D;
            dashboardLayoutGroup2.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1,
            dashboardLayoutItem2});
            dashboardLayoutGroup2.DashboardItem = null;
            dashboardLayoutGroup2.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            dashboardLayoutGroup2.Weight = 14.058355437665783D;
            dashboardLayoutItem3.DashboardItem = this.gridDashboardItem1;
            dashboardLayoutItem3.Weight = 85.941644562334218D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutGroup2,
            dashboardLayoutItem3});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Weight = 100D;
            this.LayoutRoot = dashboardLayoutGroup1;
            this.Title.Text = "Devices - Status Comunicação";
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.GridDashboardItem gridDashboardItem1;
        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource1;
        private DevExpress.DashboardCommon.ComboBoxDashboardItem comboBoxDashboardItem1;
        private DevExpress.DashboardCommon.TreeViewDashboardItem treeViewDashboardItem1;
    }
}
