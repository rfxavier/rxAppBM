using DevExpress.Web;
using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridHidrometro : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridHidrometro()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["IdHidrometroTipo"]);

            var dsCombo = db.BlueMeteringHidrometroTipos.ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "Descricao";
            comboColumn.PropertiesComboBox.ValueField = "IdHidrometroTipo";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            var comboColumn2 = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["IdLigacao"]);

            var dsCombo2 = db.BlueMeteringLigacoes.ToList();

            comboColumn2.PropertiesComboBox.DataSource = dsCombo2;
            comboColumn2.PropertiesComboBox.TextField = "LigacaoId";
            comboColumn2.PropertiesComboBox.ValueField = "LigacaoId";
            comboColumn2.PropertiesComboBox.ValueType = typeof(string);

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
            ASPxGridView1.DataSource = db.BlueMeteringHidrometros.ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newHidrometro = new BlueMeteringHidrometro();
            newHidrometro.BlueMeteringHidrometroId = Guid.NewGuid();
            newHidrometro.IdHidrometro = e.NewValues["IdHidrometro"]?.ToString();
            newHidrometro.RedeIotId = e.NewValues["RedeIotId"]?.ToString();
            newHidrometro.NumeroSerie = e.NewValues["NumeroSerie"]?.ToString();
            newHidrometro.IdHidrometroTipo = e.NewValues["IdHidrometroTipo"]?.ToString();
            newHidrometro.Capacidade = e.NewValues["Capacidade"] == null ? 0 : Convert.ToDecimal(e.NewValues["Capacidade"]);
            newHidrometro.NumeroSerieRelojoaria = e.NewValues["NumeroSerieRelojoaria"]?.ToString();
            newHidrometro.MarcacaoInicial = e.NewValues["MarcacaoInicial"] == null ? 0 : Convert.ToDecimal(e.NewValues["MarcacaoInicial"]);
            newHidrometro.DeviceId = e.NewValues["DeviceId"]?.ToString();
            newHidrometro.IdLigacao = e.NewValues["IdLigacao"]?.ToString();
            newHidrometro.IdValvulaCorte = e.NewValues["IdValvulaCorte"]?.ToString();

            db.BlueMeteringHidrometros.Add(newHidrometro);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringHidrometroId"]?.ToString());
            var hidrometro = db.BlueMeteringHidrometros.FirstOrDefault(l => l.BlueMeteringHidrometroId == gridKey);
            if (hidrometro != null)
            {
                hidrometro.IdHidrometro = e.NewValues["IdHidrometro"]?.ToString();
                hidrometro.RedeIotId = e.NewValues["RedeIotId"]?.ToString();
                hidrometro.NumeroSerie = e.NewValues["NumeroSerie"]?.ToString();
                hidrometro.IdHidrometroTipo = e.NewValues["IdHidrometroTipo"]?.ToString();
                hidrometro.Capacidade = e.NewValues["Capacidade"] == null ? 0 : Convert.ToDecimal(e.NewValues["Capacidade"]);
                hidrometro.NumeroSerieRelojoaria = e.NewValues["NumeroSerieRelojoaria"]?.ToString();
                hidrometro.MarcacaoInicial = e.NewValues["MarcacaoInicial"] == null ? 0 : Convert.ToDecimal(e.NewValues["MarcacaoInicial"]);
                hidrometro.DeviceId = e.NewValues["DeviceId"]?.ToString();
                hidrometro.IdLigacao = e.NewValues["IdLigacao"]?.ToString();
                hidrometro.IdValvulaCorte = e.NewValues["IdValvulaCorte"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringHidrometroId"]?.ToString());
            var Hidrometro = db.BlueMeteringHidrometros.FirstOrDefault(l => l.BlueMeteringHidrometroId == gridKey);

            db.BlueMeteringHidrometros.Remove(Hidrometro);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

    }
}