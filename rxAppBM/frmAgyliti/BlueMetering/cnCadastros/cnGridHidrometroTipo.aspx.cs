using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridHidrometroTipo : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridHidrometroTipo()
        {
            db = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringHidrometroTipos.ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newHidrometroTipo = new BlueMeteringHidrometroTipo();
            newHidrometroTipo.BlueMeteringHidrometroTipoId = Guid.NewGuid();
            newHidrometroTipo.IdHidrometroTipo = e.NewValues["IdHidrometroTipo"]?.ToString();
            newHidrometroTipo.Descricao = e.NewValues["Descricao"]?.ToString();

            db.BlueMeteringHidrometroTipos.Add(newHidrometroTipo);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringHidrometroTipoId"]?.ToString());
            var HidrometroTipo = db.BlueMeteringHidrometroTipos.FirstOrDefault(l => l.BlueMeteringHidrometroTipoId == gridKey);
            if (HidrometroTipo != null)
            {
                HidrometroTipo.IdHidrometroTipo = e.NewValues["IdHidrometroTipo"]?.ToString();
                HidrometroTipo.Descricao = e.NewValues["Descricao"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringHidrometroTipoId"]?.ToString());
            var HidrometroTipo = db.BlueMeteringHidrometroTipos.FirstOrDefault(l => l.BlueMeteringHidrometroTipoId == gridKey);

            db.BlueMeteringHidrometroTipos.Remove(HidrometroTipo);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }
    }
}