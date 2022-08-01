using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridUnidadeGerenciamentoRegional : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridUnidadeGerenciamentoRegional()
        {
            db = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringUnidadeGerenciamentoRegionais.ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newUnidadeGerenciamentoRegional = new BlueMeteringUnidadeGerenciamentoRegional();
            newUnidadeGerenciamentoRegional.BlueMeteringUnidadeGerenciamentoRegionalId = Guid.NewGuid();
            newUnidadeGerenciamentoRegional.IdUnidadeGerenciamentoRegional = e.NewValues["IdUnidadeGerenciamentoRegional"]?.ToString();
            newUnidadeGerenciamentoRegional.Nome = e.NewValues["Nome"]?.ToString();
            newUnidadeGerenciamentoRegional.Endereco = e.NewValues["Endereco"]?.ToString();
            newUnidadeGerenciamentoRegional.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
            newUnidadeGerenciamentoRegional.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);

            db.BlueMeteringUnidadeGerenciamentoRegionais.Add(newUnidadeGerenciamentoRegional);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringUnidadeGerenciamentoRegionalId"]?.ToString());
            var unidadeGerenciamentoRegional = db.BlueMeteringUnidadeGerenciamentoRegionais.FirstOrDefault(l => l.BlueMeteringUnidadeGerenciamentoRegionalId == gridKey);
            if (unidadeGerenciamentoRegional != null)
            {
                unidadeGerenciamentoRegional.IdUnidadeGerenciamentoRegional = e.NewValues["IdUnidadeGerenciamentoRegional"]?.ToString();
                unidadeGerenciamentoRegional.Nome = e.NewValues["Nome"]?.ToString();
                unidadeGerenciamentoRegional.Endereco = e.NewValues["Endereco"]?.ToString();
                unidadeGerenciamentoRegional.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
                unidadeGerenciamentoRegional.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringUnidadeGerenciamentoRegionalId"]?.ToString());
            var unidadeGerenciamentoRegional = db.BlueMeteringUnidadeGerenciamentoRegionais.FirstOrDefault(l => l.BlueMeteringUnidadeGerenciamentoRegionalId == gridKey);

            db.BlueMeteringUnidadeGerenciamentoRegionais.Remove(unidadeGerenciamentoRegional);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

    }
}