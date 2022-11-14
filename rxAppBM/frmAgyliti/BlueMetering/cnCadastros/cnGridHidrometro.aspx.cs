using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;
using System.Web;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridHidrometro : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext db;
        private BlueMeteringCliente cliente;

        public cnGridHidrometro()
        {
            db = new ApplicationDbContext();
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindById(User.Identity.GetUserId());
            cliente = db.BlueMeteringClientes.FirstOrDefault(c => c.BlueMeteringClienteId == user.BlueMeteringClienteId);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["BlueMeteringHidrometroTipoId"]);

            var dsCombo = db.BlueMeteringHidrometroTipos.Where(ht => ht.BlueMeteringClienteId == cliente.BlueMeteringClienteId).ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "Descricao";
            comboColumn.PropertiesComboBox.ValueField = "BlueMeteringHidrometroTipoId";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            var comboColumn2 = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["BlueMeteringLigacaoId"]);

            var dsCombo2 = db.BlueMeteringLigacoes.Where(l => l.BlueMeteringClienteId == cliente.BlueMeteringClienteId).ToList();

             comboColumn2.PropertiesComboBox.DataSource = dsCombo2;
            comboColumn2.PropertiesComboBox.TextField = "LigacaoId";
            comboColumn2.PropertiesComboBox.ValueField = "BlueMeteringLigacaoId";
            comboColumn2.PropertiesComboBox.ValueType = typeof(string);

            var comboColumn3 = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["BlueMeteringValvulaCorteId"]);

            var dsCombo3 = db.BlueMeteringValvulasCorte.Where(c => c.BlueMeteringClienteId == cliente.BlueMeteringClienteId).ToList();

            comboColumn3.PropertiesComboBox.DataSource = dsCombo3;
            comboColumn3.PropertiesComboBox.TextField = "NumeroSerie";
            comboColumn3.PropertiesComboBox.ValueField = "BlueMeteringValvulaCorteId";
            comboColumn3.PropertiesComboBox.ValueType = typeof(string);

            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringHidrometros.Where(h => h.BlueMeteringClienteId == cliente.BlueMeteringClienteId).ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newHidrometro = new BlueMeteringHidrometro();
            newHidrometro.BlueMeteringHidrometroId = Guid.NewGuid();
            newHidrometro.IdHidrometro = e.NewValues["IdHidrometro"]?.ToString();
            newHidrometro.RedeIotId = e.NewValues["RedeIotId"]?.ToString();
            newHidrometro.NumeroSerie = e.NewValues["NumeroSerie"]?.ToString();
            newHidrometro.BlueMeteringHidrometroTipoId = new Guid(e.NewValues["BlueMeteringHidrometroTipoId"]?.ToString());
            newHidrometro.Capacidade = e.NewValues["Capacidade"] == null ? 0 : Convert.ToDecimal(e.NewValues["Capacidade"]);
            newHidrometro.NumeroSerieRelojoaria = e.NewValues["NumeroSerieRelojoaria"]?.ToString();
            newHidrometro.MarcacaoInicial = e.NewValues["MarcacaoInicial"] == null ? 0 : Convert.ToDecimal(e.NewValues["MarcacaoInicial"]);
            newHidrometro.DeviceId = e.NewValues["DeviceId"]?.ToString();
            newHidrometro.BlueMeteringLigacaoId = new Guid(e.NewValues["BlueMeteringLigacaoId"]?.ToString());
            newHidrometro.BlueMeteringValvulaCorteId = new Guid(e.NewValues["BlueMeteringValvulaCorteId"]?.ToString());
            newHidrometro.BlueMeteringClienteId = cliente.BlueMeteringClienteId;

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
                hidrometro.BlueMeteringHidrometroTipoId = new Guid(e.NewValues["BlueMeteringHidrometroTipoId"]?.ToString());
                hidrometro.Capacidade = e.NewValues["Capacidade"] == null ? 0 : Convert.ToDecimal(e.NewValues["Capacidade"]);
                hidrometro.NumeroSerieRelojoaria = e.NewValues["NumeroSerieRelojoaria"]?.ToString();
                hidrometro.MarcacaoInicial = e.NewValues["MarcacaoInicial"] == null ? 0 : Convert.ToDecimal(e.NewValues["MarcacaoInicial"]);
                hidrometro.DeviceId = e.NewValues["DeviceId"]?.ToString();
                hidrometro.BlueMeteringLigacaoId = new Guid(e.NewValues["BlueMeteringLigacaoId"]?.ToString());
                hidrometro.BlueMeteringValvulaCorteId = new Guid(e.NewValues["BlueMeteringValvulaCorteId"]?.ToString());

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