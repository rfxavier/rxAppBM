using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridValvulaCorte : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridValvulaCorte()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringValvulasCorte.ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newValvulaCorte = new BlueMeteringValvulaCorte();
            newValvulaCorte.BlueMeteringValvulaCorteId = Guid.NewGuid();
            newValvulaCorte.IdValvulaCorte = e.NewValues["IdValvulaCorte"]?.ToString();
            newValvulaCorte.NumeroSerie = e.NewValues["NumeroSerie"]?.ToString();

            db.BlueMeteringValvulasCorte.Add(newValvulaCorte);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringValvulaCorteId"]?.ToString());
            var valvulaCorte = db.BlueMeteringValvulasCorte.FirstOrDefault(l => l.BlueMeteringValvulaCorteId == gridKey);
            if (valvulaCorte != null)
            {
                valvulaCorte.IdValvulaCorte = e.NewValues["IdValvulaCorte"]?.ToString();
                valvulaCorte.NumeroSerie = e.NewValues["NumeroSerie"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringValvulaCorteId"]?.ToString());
            var valvulaCorte = db.BlueMeteringValvulasCorte.FirstOrDefault(l => l.BlueMeteringValvulaCorteId == gridKey);

            db.BlueMeteringValvulasCorte.Remove(valvulaCorte);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

    }
}