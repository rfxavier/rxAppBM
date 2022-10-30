using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxAppBM.dashClasses;
using rxAppBM.dataObjClasses;
using rxAppBM.Models;
using System;
using System.Linq;
using System.Web;

namespace rxAppBM.frmAgyliti.BlueMetering.cnDashboards
{
    public partial class cnDashboardSLALeiturasConsumoMensal : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;

        public cnDashboardSLALeiturasConsumoMensal()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnSLALeiturasCnConsumoMensal);
            ASPxDashboard2.DashboardType = typeof(dashCnConsumoDiarioMedia);
        }
        
        protected void ASPxDashboard1_DataLoading(object sender, DevExpress.DashboardWeb.DataLoadingWebEventArgs e)
        {
            var parDashDataIni = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0).AddMonths(-5);
            var parDashDataFim = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);

            foreach (var parameter in e.Parameters)
            {
                if (parameter.Name == "parDashDataIni") parDashDataIni = Convert.ToDateTime(parameter.Value);
                if (parameter.Name == "parDashDataFim") parDashDataFim = Convert.ToDateTime(parameter.Value);
            }

            if (User.IsInRole("UserClient"))
            {
                var db = new ApplicationDbContext();

                var user = userManager.FindById(User.Identity.GetUserId());
                var cliente = db.BlueMeteringClientes.FirstOrDefault(c => c.BlueMeteringClienteId == user.BlueMeteringClienteId);

                var idCliente = cliente?.IdCliente;

                if (e.DataSourceName == "Object Data Source 2")
                    e.Data = dsConsumo.GetConsumoPorDiaPorCliente(parDashDataIni, parDashDataFim, idCliente);
                else if (e.DataSourceName == "Object Data Source 1")
                {
                    e.Data = dsLastSeen.GetDeviceCommSLAStatusPorCliente(idCliente);
                }
            }
            else
            {
                if (e.DataSourceName == "Object Data Source 2")
                    e.Data = dsConsumo.GetConsumoPorDia(parDashDataIni, parDashDataFim);
                else if (e.DataSourceName == "Object Data Source 1")
                {
                    e.Data = dsLastSeen.GetDeviceCommSLAStatus();
                }
            }
        }

        protected void ASPxDashboard2_DataLoading(object sender, DevExpress.DashboardWeb.DataLoadingWebEventArgs e)
        {
            if (User.IsInRole("UserClient"))
            {
                var db = new ApplicationDbContext();

                var user = userManager.FindById(User.Identity.GetUserId());
                var cliente = db.BlueMeteringClientes.FirstOrDefault(c => c.BlueMeteringClienteId == user.BlueMeteringClienteId);

                var idCliente = cliente?.IdCliente;

                e.Data = dsConsumo.GetConsumoPorDiaPorCliente(DateTime.Now.AddDays(-7), DateTime.Now, idCliente);
            }
            else
            {
                e.Data = dsConsumo.GetConsumoPorDia(DateTime.Now.AddDays(-7), DateTime.Now);
            }
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout1(object sender, DevExpress.DashboardWeb.ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(0);
        }

        protected void ASPxDashboard2_ConfigureDataReloadingTimeout(object sender, DevExpress.DashboardWeb.ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(0);
        }
    }
}