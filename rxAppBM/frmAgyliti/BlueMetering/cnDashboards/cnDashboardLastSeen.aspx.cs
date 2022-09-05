using rxAppBM.dashClasses;
using rxAppBM.dataObjClasses;
using System;

namespace rxAppBM.frmAgyliti.BlueMetering.cnDashboards
{
    public partial class cnDashboardLastSeen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnLastSeen);
        }
        protected void ASPxDashboard1_DataLoading(object sender, DevExpress.DashboardWeb.DataLoadingWebEventArgs e)
        {
            e.Data = dsLastSeen.GetDeviceCommStatus();
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, DevExpress.DashboardWeb.ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(60);
        }

    }
}