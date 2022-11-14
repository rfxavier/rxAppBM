using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;
using System.Web;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridConsumidorTipo : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext db;
        private BlueMeteringCliente cliente;

        public cnGridConsumidorTipo()
        {
            db = new ApplicationDbContext();
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindById(User.Identity.GetUserId());
            cliente = db.BlueMeteringClientes.FirstOrDefault(c => c.BlueMeteringClienteId == user.BlueMeteringClienteId);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringConsumidorTipos.Where(ct => ct.BlueMeteringClienteId == cliente.BlueMeteringClienteId).ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newConsumidorTipo = new BlueMeteringConsumidorTipo();
            newConsumidorTipo.BlueMeteringConsumidorTipoId = Guid.NewGuid();
            newConsumidorTipo.IdConsumidorTipo = e.NewValues["IdConsumidorTipo"]?.ToString();
            newConsumidorTipo.Descricao = e.NewValues["Descricao"]?.ToString();
            newConsumidorTipo.BlueMeteringClienteId = cliente.BlueMeteringClienteId;

            db.BlueMeteringConsumidorTipos.Add(newConsumidorTipo);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringConsumidorTipoId"]?.ToString());
            var consumidorTipo = db.BlueMeteringConsumidorTipos.FirstOrDefault(l => l.BlueMeteringConsumidorTipoId == gridKey);
            if (consumidorTipo != null)
            {
                consumidorTipo.IdConsumidorTipo = e.NewValues["IdConsumidorTipo"]?.ToString();
                consumidorTipo.Descricao = e.NewValues["Descricao"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringConsumidorTipoId"]?.ToString());
            var consumidorTipo = db.BlueMeteringConsumidorTipos.FirstOrDefault(l => l.BlueMeteringConsumidorTipoId == gridKey);

            db.BlueMeteringConsumidorTipos.Remove(consumidorTipo);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }
    }
}