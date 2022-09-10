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
            //e.Data = dsConsumo.GetConsumoPorDia(deStart.Date, deEnd.Date);

            var parDashDataIni = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0).AddMonths(-5);
            var parDashDataFim = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);

            foreach (var parameter in e.Parameters)
            {
                if (parameter.Name == "parDashDataIni") parDashDataIni = Convert.ToDateTime(parameter.Value);
                if (parameter.Name == "parDashDataFim") parDashDataFim = Convert.ToDateTime(parameter.Value);
            }

            e.Data = dsConsumo.GetConsumoPorDia(parDashDataIni, parDashDataFim);
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, DevExpress.DashboardWeb.ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(60);
        }

        protected void ASPxDashboard1_SetInitialDashboardState(object sender, DevExpress.DashboardWeb.SetInitialDashboardStateEventArgs e)
        {
            DashboardState dashboardState = new DashboardState();

            var dateEnd = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            var dateStart = DateTime.Now.AddMonths(-5).ToString("yyyy-MM-ddT00:00:00");

            DashboardParameterState parameterStateDataIni = new DashboardParameterState("parDashDataIni", dateStart, typeof(string));
            DashboardParameterState parameterStateDataFim = new DashboardParameterState("parDashDataFim", dateEnd, typeof(string));

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