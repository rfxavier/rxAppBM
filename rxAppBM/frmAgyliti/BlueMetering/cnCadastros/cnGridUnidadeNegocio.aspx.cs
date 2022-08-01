using DevExpress.Web;
using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridUnidadeNegocio : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridUnidadeNegocio()
        {
            db = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["IdUnidadeGerenciamentoRegional"]);

            var dsCombo = db.BlueMeteringUnidadeGerenciamentoRegionais.ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "Nome";
            comboColumn.PropertiesComboBox.ValueField = "IdUnidadeGerenciamentoRegional";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            ASPxGridView1.DataBind();

        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringUnidadeNegocios.ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newUnidadeNegocio = new BlueMeteringUnidadeNegocio();
            newUnidadeNegocio.BlueMeteringUnidadeNegocioId = Guid.NewGuid();
            newUnidadeNegocio.IdUnidadeNegocio = e.NewValues["IdUnidadeNegocio"]?.ToString();
            newUnidadeNegocio.Nome = e.NewValues["Nome"]?.ToString();
            newUnidadeNegocio.Endereco = e.NewValues["Endereco"]?.ToString();
            newUnidadeNegocio.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
            newUnidadeNegocio.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
            newUnidadeNegocio.IdUnidadeGerenciamentoRegional = e.NewValues["IdUnidadeGerenciamentoRegional"]?.ToString();

            db.BlueMeteringUnidadeNegocios.Add(newUnidadeNegocio);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringUnidadeNegocioId"]?.ToString());
            var unidadeNegocio = db.BlueMeteringUnidadeNegocios.FirstOrDefault(l => l.BlueMeteringUnidadeNegocioId == gridKey);
            if (unidadeNegocio != null)
            {
                unidadeNegocio.IdUnidadeNegocio = e.NewValues["IdUnidadeNegocio"]?.ToString();
                unidadeNegocio.Nome = e.NewValues["Nome"]?.ToString();
                unidadeNegocio.Endereco = e.NewValues["Endereco"]?.ToString();
                unidadeNegocio.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
                unidadeNegocio.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
                unidadeNegocio.IdUnidadeGerenciamentoRegional = e.NewValues["IdUnidadeGerenciamentoRegional"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringUnidadeNegocioId"]?.ToString());
            var unidadeNegocio = db.BlueMeteringUnidadeNegocios.FirstOrDefault(l => l.BlueMeteringUnidadeNegocioId == gridKey);

            db.BlueMeteringUnidadeNegocios.Remove(unidadeNegocio);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

    }
}