namespace rxAppBM.dashClasses
{
    partial class dashCnSLALeituras
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
            DevExpress.DashboardCommon.CalculatedField calculatedField1 = new DevExpress.DashboardCommon.CalculatedField();
            DevExpress.DashboardCommon.Dimension dimension1 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.Dimension dimension2 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure2 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn1 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Dimension dimension3 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn2 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Measure measure3 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.GridMeasureColumn gridMeasureColumn1 = new DevExpress.DashboardCommon.GridMeasureColumn();
            DevExpress.DashboardCommon.GridItemFormatRule gridItemFormatRule1 = new DevExpress.DashboardCommon.GridItemFormatRule();
            DevExpress.DashboardCommon.FormatConditionValue formatConditionValue1 = new DevExpress.DashboardCommon.FormatConditionValue();
            DevExpress.DashboardCommon.AppearanceSettings appearanceSettings1 = new DevExpress.DashboardCommon.AppearanceSettings();
            DevExpress.DashboardCommon.GridItemFormatRule gridItemFormatRule2 = new DevExpress.DashboardCommon.GridItemFormatRule();
            DevExpress.DashboardCommon.FormatConditionValue formatConditionValue2 = new DevExpress.DashboardCommon.FormatConditionValue();
            DevExpress.DashboardCommon.AppearanceSettings appearanceSettings2 = new DevExpress.DashboardCommon.AppearanceSettings();
            DevExpress.DashboardCommon.GridItemFormatRule gridItemFormatRule3 = new DevExpress.DashboardCommon.GridItemFormatRule();
            DevExpress.DashboardCommon.FormatConditionValue formatConditionValue3 = new DevExpress.DashboardCommon.FormatConditionValue();
            DevExpress.DashboardCommon.AppearanceSettings appearanceSettings3 = new DevExpress.DashboardCommon.AppearanceSettings();
            DevExpress.DashboardCommon.GridItemFormatRule gridItemFormatRule4 = new DevExpress.DashboardCommon.GridItemFormatRule();
            DevExpress.DashboardCommon.FormatConditionValue formatConditionValue4 = new DevExpress.DashboardCommon.FormatConditionValue();
            DevExpress.DashboardCommon.AppearanceSettings appearanceSettings4 = new DevExpress.DashboardCommon.AppearanceSettings();
            DevExpress.DashboardCommon.GridItemFormatRule gridItemFormatRule5 = new DevExpress.DashboardCommon.GridItemFormatRule();
            DevExpress.DashboardCommon.FormatConditionValue formatConditionValue5 = new DevExpress.DashboardCommon.FormatConditionValue();
            DevExpress.DashboardCommon.AppearanceSettings appearanceSettings5 = new DevExpress.DashboardCommon.AppearanceSettings();
            DevExpress.DashboardCommon.GridItemFormatRule gridItemFormatRule6 = new DevExpress.DashboardCommon.GridItemFormatRule();
            DevExpress.DashboardCommon.FormatConditionValue formatConditionValue6 = new DevExpress.DashboardCommon.FormatConditionValue();
            DevExpress.DashboardCommon.AppearanceSettings appearanceSettings6 = new DevExpress.DashboardCommon.AppearanceSettings();
            DevExpress.DashboardCommon.ColorSchemeEntry colorSchemeEntry1 = new DevExpress.DashboardCommon.ColorSchemeEntry();
            DevExpress.DashboardCommon.ColorSchemeEntry colorSchemeEntry2 = new DevExpress.DashboardCommon.ColorSchemeEntry();
            DevExpress.DashboardCommon.ColorSchemeEntry colorSchemeEntry3 = new DevExpress.DashboardCommon.ColorSchemeEntry();
            DevExpress.DashboardCommon.ColorSchemeEntry colorSchemeEntry4 = new DevExpress.DashboardCommon.ColorSchemeEntry();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem2 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            this.dashboardObjectDataSource1 = new DevExpress.DashboardCommon.DashboardObjectDataSource();
            this.pieDashboardItem1 = new DevExpress.DashboardCommon.PieDashboardItem();
            this.gridDashboardItem1 = new DevExpress.DashboardCommon.GridDashboardItem();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dashboardObjectDataSource1
            // 
            calculatedField1.Expression = "\' \'";
            calculatedField1.Name = "dummy";
            this.dashboardObjectDataSource1.CalculatedFields.AddRange(new DevExpress.DashboardCommon.CalculatedField[] {
            calculatedField1});
            this.dashboardObjectDataSource1.ComponentName = "dashboardObjectDataSource1";
            this.dashboardObjectDataSource1.DataMember = "GetDeviceCommSLAStatus";
            this.dashboardObjectDataSource1.DataSource = typeof(rxAppBM.dataObjClasses.dsLastSeen);
            this.dashboardObjectDataSource1.Name = "Object Data Source 1";
            // 
            // pieDashboardItem1
            // 
            dimension1.DataMember = "SLAStatus";
            this.pieDashboardItem1.Arguments.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension1});
            this.pieDashboardItem1.ComponentName = "pieDashboardItem1";
            measure1.DataMember = "NumberOfDevices";
            measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number;
            measure1.NumericFormat.IncludeGroupSeparator = true;
            measure1.NumericFormat.Precision = 0;
            measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones;
            this.pieDashboardItem1.DataItemRepository.Clear();
            this.pieDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0");
            this.pieDashboardItem1.DataItemRepository.Add(measure1, "DataItem1");
            this.pieDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.pieDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.pieDashboardItem1.LabelContentType = DevExpress.DashboardCommon.PieValueType.None;
            this.pieDashboardItem1.Name = "Pies 1";
            this.pieDashboardItem1.PieType = DevExpress.DashboardCommon.PieType.Donut;
            this.pieDashboardItem1.ShowCaption = false;
            this.pieDashboardItem1.ShowPieCaptions = false;
            this.pieDashboardItem1.TooltipContentType = DevExpress.DashboardCommon.PieValueType.Percent;
            this.pieDashboardItem1.Values.AddRange(new DevExpress.DashboardCommon.Measure[] {
            measure1});
            this.pieDashboardItem1.VisibleDataFilterString = "[DataItem0] <> \'Total de medidores ativos\'";
            // 
            // gridDashboardItem1
            // 
            dimension2.DataMember = "SLAStatus";
            measure2.DataMember = "Order";
            measure2.SummaryType = DevExpress.DashboardCommon.SummaryType.Max;
            dimension2.SortByMeasure = measure2;
            gridDimensionColumn1.Weight = 6.8011690796535129D;
            gridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn1.AddDataItem("Dimension", dimension2);
            dimension3.DataMember = "SLAStatus";
            gridDimensionColumn2.Weight = 371.88792527545411D;
            gridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn2.AddDataItem("Dimension", dimension3);
            measure3.DataMember = "NumberOfDevices";
            measure3.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number;
            measure3.NumericFormat.IncludeGroupSeparator = true;
            measure3.NumericFormat.Precision = 0;
            measure3.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones;
            gridMeasureColumn1.Weight = 31.013331003220021D;
            gridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridMeasureColumn1.AddDataItem("Measure", measure3);
            this.gridDashboardItem1.Columns.AddRange(new DevExpress.DashboardCommon.GridColumnBase[] {
            gridDimensionColumn1,
            gridDimensionColumn2,
            gridMeasureColumn1});
            this.gridDashboardItem1.ComponentName = "gridDashboardItem1";
            this.gridDashboardItem1.DataItemRepository.Clear();
            this.gridDashboardItem1.DataItemRepository.Add(dimension2, "DataItem0");
            this.gridDashboardItem1.DataItemRepository.Add(measure3, "DataItem1");
            this.gridDashboardItem1.DataItemRepository.Add(measure2, "DataItem2");
            this.gridDashboardItem1.DataItemRepository.Add(dimension3, "DataItem3");
            this.gridDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            appearanceSettings1.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Custom;
            appearanceSettings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(244)))));
            appearanceSettings1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(244)))));
            formatConditionValue1.StyleSettings = appearanceSettings1;
            formatConditionValue1.Value1 = "Todas as leituras recebidas";
            gridItemFormatRule1.Condition = formatConditionValue1;
            gridItemFormatRule1.DataItem = dimension2;
            gridItemFormatRule1.DataItemApplyTo = dimension2;
            gridItemFormatRule1.Name = "FormatRule 2";
            appearanceSettings2.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Custom;
            appearanceSettings2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(214)))), ((int)(((byte)(254)))));
            appearanceSettings2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(214)))), ((int)(((byte)(254)))));
            formatConditionValue2.StyleSettings = appearanceSettings2;
            formatConditionValue2.Value1 = "Sem leitura por 1 dia";
            gridItemFormatRule2.Condition = formatConditionValue2;
            gridItemFormatRule2.DataItem = dimension2;
            gridItemFormatRule2.DataItemApplyTo = dimension2;
            gridItemFormatRule2.Name = "FormatRule 1";
            appearanceSettings3.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Custom;
            appearanceSettings3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(255)))));
            appearanceSettings3.FontFamily = "Bahnschrift Condensed";
            appearanceSettings3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(255)))));
            formatConditionValue3.StyleSettings = appearanceSettings3;
            formatConditionValue3.Value1 = "Sem leitura por 7 dias";
            gridItemFormatRule3.Condition = formatConditionValue3;
            gridItemFormatRule3.DataItem = dimension2;
            gridItemFormatRule3.DataItemApplyTo = dimension2;
            gridItemFormatRule3.Name = "FormatRule 3";
            appearanceSettings4.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Custom;
            appearanceSettings4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            appearanceSettings4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            formatConditionValue4.StyleSettings = appearanceSettings4;
            formatConditionValue4.Value1 = "Sem leitura por 30 dias";
            gridItemFormatRule4.Condition = formatConditionValue4;
            gridItemFormatRule4.DataItem = dimension2;
            gridItemFormatRule4.DataItemApplyTo = dimension2;
            gridItemFormatRule4.Name = "FormatRule 4";
            appearanceSettings5.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Custom;
            appearanceSettings5.FontStyle = System.Drawing.FontStyle.Bold;
            formatConditionValue5.StyleSettings = appearanceSettings5;
            formatConditionValue5.Value1 = "Total de medidores ativos";
            gridItemFormatRule5.Condition = formatConditionValue5;
            gridItemFormatRule5.DataItem = dimension3;
            gridItemFormatRule5.DataItemApplyTo = dimension3;
            gridItemFormatRule5.Name = "FormatRule 5";
            appearanceSettings6.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Custom;
            appearanceSettings6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            formatConditionValue6.StyleSettings = appearanceSettings6;
            formatConditionValue6.Value1 = "Total de medidores ativos";
            gridItemFormatRule6.Condition = formatConditionValue6;
            gridItemFormatRule6.DataItem = dimension2;
            gridItemFormatRule6.DataItemApplyTo = dimension2;
            gridItemFormatRule6.Name = "FormatRule 6";
            this.gridDashboardItem1.FormatRules.AddRange(new DevExpress.DashboardCommon.GridItemFormatRule[] {
            gridItemFormatRule1,
            gridItemFormatRule2,
            gridItemFormatRule3,
            gridItemFormatRule4,
            gridItemFormatRule5,
            gridItemFormatRule6});
            this.gridDashboardItem1.GridOptions.ColumnWidthMode = DevExpress.DashboardCommon.GridColumnWidthMode.Manual;
            this.gridDashboardItem1.GridOptions.ShowColumnHeaders = false;
            this.gridDashboardItem1.HiddenMeasures.AddRange(new DevExpress.DashboardCommon.Measure[] {
            measure2});
            this.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.gridDashboardItem1.Name = "Grid 1";
            this.gridDashboardItem1.ShowCaption = false;
            // 
            // dashCnSLALeituras
            // 
            colorSchemeEntry1.ColorDefinition = new DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-8530178));
            colorSchemeEntry1.DataSource = this.dashboardObjectDataSource1;
            colorSchemeEntry1.DimensionKeys.AddRange(new DevExpress.DashboardCommon.ColorSchemeDimensionKey[] {
            new DevExpress.DashboardCommon.ColorSchemeDimensionKey(new DevExpress.DashboardCommon.DimensionDefinition("SLAStatus"), "Sem leitura por 1 dia")});
            colorSchemeEntry2.ColorDefinition = new DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-9868545));
            colorSchemeEntry2.DataSource = this.dashboardObjectDataSource1;
            colorSchemeEntry2.DimensionKeys.AddRange(new DevExpress.DashboardCommon.ColorSchemeDimensionKey[] {
            new DevExpress.DashboardCommon.ColorSchemeDimensionKey(new DevExpress.DashboardCommon.DimensionDefinition("SLAStatus"), "Sem leitura por 30 dias")});
            colorSchemeEntry3.ColorDefinition = new DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-3947521));
            colorSchemeEntry3.DataSource = this.dashboardObjectDataSource1;
            colorSchemeEntry3.DimensionKeys.AddRange(new DevExpress.DashboardCommon.ColorSchemeDimensionKey[] {
            new DevExpress.DashboardCommon.ColorSchemeDimensionKey(new DevExpress.DashboardCommon.DimensionDefinition("SLAStatus"), "Sem leitura por 7 dias")});
            colorSchemeEntry4.ColorDefinition = new DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-16776716));
            colorSchemeEntry4.DataSource = this.dashboardObjectDataSource1;
            colorSchemeEntry4.DimensionKeys.AddRange(new DevExpress.DashboardCommon.ColorSchemeDimensionKey[] {
            new DevExpress.DashboardCommon.ColorSchemeDimensionKey(new DevExpress.DashboardCommon.DimensionDefinition("SLAStatus"), "Todas as leituras recebidas")});
            this.ColorScheme.AddRange(new DevExpress.DashboardCommon.ColorSchemeEntry[] {
            colorSchemeEntry1,
            colorSchemeEntry2,
            colorSchemeEntry3,
            colorSchemeEntry4});
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardObjectDataSource1});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.pieDashboardItem1,
            this.gridDashboardItem1});
            dashboardLayoutItem1.DashboardItem = this.pieDashboardItem1;
            dashboardLayoutItem1.Weight = 64.087061668681983D;
            dashboardLayoutItem2.DashboardItem = this.gridDashboardItem1;
            dashboardLayoutItem2.Weight = 35.912938331318017D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1,
            dashboardLayoutItem2});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            dashboardLayoutGroup1.Weight = 100D;
            this.LayoutRoot = dashboardLayoutGroup1;
            this.Title.ShowMasterFilterState = false;
            this.Title.Text = "SLA Leituras dos últimos 30 dias";
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.PieDashboardItem pieDashboardItem1;
        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource1;
        private DevExpress.DashboardCommon.GridDashboardItem gridDashboardItem1;
    }
}
