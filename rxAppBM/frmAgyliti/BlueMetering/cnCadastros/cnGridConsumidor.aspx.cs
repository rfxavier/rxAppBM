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
    public partial class cnGridConsumidor : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext db;
        private BlueMeteringCliente cliente;

        public cnGridConsumidor()
        {
            db = new ApplicationDbContext();
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindById(User.Identity.GetUserId());
            cliente = db.BlueMeteringClientes.FirstOrDefault(c => c.BlueMeteringClienteId == user.BlueMeteringClienteId);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["BlueMeteringConsumidorTipoId"]);

            var dsCombo = db.BlueMeteringConsumidorTipos.Where(ct => ct.BlueMeteringClienteId == cliente.BlueMeteringClienteId).ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "Descricao";
            comboColumn.PropertiesComboBox.ValueField = "BlueMeteringConsumidorTipoId";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringConsumidores.Where(c => c.BlueMeteringClienteId == cliente.BlueMeteringClienteId).ToList();
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
            newConsumidor.BlueMeteringConsumidorTipoId = new Guid(e.NewValues["BlueMeteringConsumidorTipoId"]?.ToString());
            newConsumidor.BlueMeteringClienteId = cliente.BlueMeteringClienteId;

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
                consumidor.BlueMeteringConsumidorTipoId = new Guid(e.NewValues["BlueMeteringConsumidorTipoId"]?.ToString());

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