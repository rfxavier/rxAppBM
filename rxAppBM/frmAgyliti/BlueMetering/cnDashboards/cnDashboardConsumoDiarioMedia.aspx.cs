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
    public partial class cnDashboardConsumoDiarioMedia : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;

        public cnDashboardConsumoDiarioMedia()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnConsumoDiarioMedia);
        }
        protected void ASPxDashboard1_DataLoading(object sender, DevExpress.DashboardWeb.DataLoadingWebEventArgs e)
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

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, DevExpress.DashboardWeb.ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(60);
        }

    }
}