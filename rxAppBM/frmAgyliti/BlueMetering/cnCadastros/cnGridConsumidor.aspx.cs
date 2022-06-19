using DevExpress.Web;
using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridConsumidor : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridConsumidor()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["IdConsumidorTipo"]);

            var dsCombo = db.BlueMeteringConsumidorTipos.ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "Descricao";
            comboColumn.PropertiesComboBox.ValueField = "IdConsumidorTipo";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringConsumidores.ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newConsumidor = new BlueMeteringConsumidor();
            newConsumidor.BlueMeteringConsumidorId = Guid.NewGuid();
            newConsumidor.IdConsumidor = e.NewValues["IdConsumidor"]?.ToString();
            newConsumidor.IdExternoConsumidor = e.NewValues["IdExternoConsumidor"]?.ToString();
            newConsumidor.NomeCompleto = e.NewValues["NomeCompleto"]?.ToString();
            newConsumidor.CPF = e.NewValues["CPF"]?.ToString();
            newConsumidor.RG = e.NewValues["RG"]?.ToString();
            newConsumidor.IdConsumidorTipo = e.NewValues["IdConsumidorTipo"]?.ToString();

            db.BlueMeteringConsumidores.Add(newConsumidor);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringConsumidorId"]?.ToString());
            var consumidor = db.BlueMeteringConsumidores.FirstOrDefault(l => l.BlueMeteringConsumidorId == gridKey);
            if (consumidor != null)
            {
                consumidor.IdConsumidor = e.NewValues["IdConsumidor"]?.ToString();
                consumidor.IdExternoConsumidor = e.NewValues["IdExternoConsumidor"]?.ToString();
                consumidor.NomeCompleto = e.NewValues["NomeCompleto"]?.ToString();
                consumidor.CPF = e.NewValues["CPF"]?.ToString();
                consumidor.RG = e.NewValues["RG"]?.ToString();
                consumidor.IdConsumidorTipo = e.NewValues["IdConsumidorTipo"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringConsumidorId"]?.ToString());
            var consumidor = db.BlueMeteringConsumidores.FirstOrDefault(l => l.BlueMeteringConsumidorId == gridKey);

            db.BlueMeteringConsumidores.Remove(consumidor);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }
    }
}