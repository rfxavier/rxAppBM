using DevExpress.Web;
using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridLigacao : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridLigacao()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["IdConsumidor"]);

            var dsCombo = db.BlueMeteringConsumidores.ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "NomeCompleto";
            comboColumn.PropertiesComboBox.ValueField = "IdConsumidor";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            var comboColumn3 = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["IdValvulaCorte"]);

            var dsCombo3 = db.BlueMeteringValvulasCorte.ToList();

            comboColumn3.PropertiesComboBox.DataSource = dsCombo3;
            comboColumn3.PropertiesComboBox.TextField = "NumeroSerie";
            comboColumn3.PropertiesComboBox.ValueField = "IdValvulaCorte";
            comboColumn3.PropertiesComboBox.ValueType = typeof(string);

            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringLigacoes.ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newLigacao = new BlueMeteringLigacao();
            newLigacao.BlueMeteringLigacaoId = Guid.NewGuid();
            newLigacao.LigacaoId = e.NewValues["LigacaoId"]?.ToString();
            newLigacao.Rgi = e.NewValues["Rgi"]?.ToString();
            newLigacao.Endereco = e.NewValues["Endereco"]?.ToString();
            newLigacao.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
            newLigacao.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
            newLigacao.IdConsumidor = e.NewValues["IdConsumidor"]?.ToString();
            newLigacao.IdValvulaCorte = e.NewValues["IdValvulaCorte"]?.ToString();

            db.BlueMeteringLigacoes.Add(newLigacao);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringLigacaoId"]?.ToString());
            var ligacao = db.BlueMeteringLigacoes.FirstOrDefault(l => l.BlueMeteringLigacaoId == gridKey);
            if (ligacao != null)
            {
                ligacao.LigacaoId = e.NewValues["LigacaoId"]?.ToString();
                ligacao.Rgi = e.NewValues["Rgi"]?.ToString();
                ligacao.Endereco = e.NewValues["Endereco"]?.ToString();
                ligacao.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
                ligacao.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
                ligacao.IdConsumidor = e.NewValues["IdConsumidor"]?.ToString();
                ligacao.IdValvulaCorte = e.NewValues["IdValvulaCorte"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringLigacaoId"]?.ToString());
            var ligacao = db.BlueMeteringLigacoes.FirstOrDefault(l => l.BlueMeteringLigacaoId == gridKey);

            db.BlueMeteringLigacoes.Remove(ligacao);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }
    }
}