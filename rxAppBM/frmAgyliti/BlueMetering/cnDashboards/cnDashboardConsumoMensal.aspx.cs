using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using rxAppBM.dashClasses;
using rxAppBM.dataObjClasses;
using System;
using System.Web;

namespace rxAppBM.frmAgyliti.BlueMetering.cnDashboards
{
    public partial class cnDashboardConsumoMensal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnConsumoMensal);

            deEnd.DateRangeSettings.MaxDayCount = 5 * 31;

            if (!Page.IsPostBack)
            {
                deStart.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0).AddMonths(-5);

                deEnd.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
            }
            
        }

        protected void ASPxDashboard1_DataLoading(object sender, DevExpress.DashboardWeb.DataLoadingWebEventArgs e)
        {
            e.Data = dsConsumo.GetConsumoPorDia(deStart.Date, deEnd.Date);
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, DevExpress.DashboardWeb.ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(60);
        }

        protected void ASPxDashboard1_SetInitialDashboardState(object sender, DevExpress.DashboardWeb.SetInitialDashboardStateEventArgs e)
        {
            DashboardState dashboardState = new DashboardState();

            DashboardParameterState parameterStateDataIni = new DashboardParameterState("parDashDataIni", "2022-01-01T00:00:00", typeof(string));
            DashboardParameterState parameterStateDataFim = new DashboardParameterState("parDashDataFim", "2099-12-31T00:00:00", typeof(string));

            dashboardState.Parameters.Add(parameterStateDataIni);
            dashboardState.Parameters.Add(parameterStateDataFim);

            e.InitialState = dashboardState;
        }
        protected void ASPxDashboard1_CustomParameters(object sender, CustomParametersWebEventArgs e)
        {
            e.Parameters.Add(new DashboardParameter("Param1", typeof(Guid), CacheManager.UniqueCacheParam));
        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            CacheManager.ResetCache();
        }

        public class CacheManager
        {
            public static void ResetCache()
            {
                if (HttpContext.Current.Session != null)
                    HttpContext.Current.Session["UniqueCacheParam"] = Guid.NewGuid();
            }
            public static Guid UniqueCacheParam
            {
                get
                {
                    if (HttpContext.Current.Session == null)
                        return Guid.Empty;
                    else
                    {
                        if (HttpContext.Current.Session["UniqueCacheParam"] == null)
                            ResetCache();
                        return (Guid)HttpContext.Current.Session["UniqueCacheParam"];
                    }
                }
            }
        }
    }
}