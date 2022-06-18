using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridConsumidorTipo : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridConsumidorTipo()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringConsumidorTipos.ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newConsumidorTipo = new BlueMeteringConsumidorTipo();
            newConsumidorTipo.BlueMeteringConsumidorTipoId = Guid.NewGuid();
            newConsumidorTipo.IdConsumidorTipo = e.NewValues["IdConsumidorTipo"]?.ToString();
            newConsumidorTipo.Descricao = e.NewValues["Descricao"]?.ToString();

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