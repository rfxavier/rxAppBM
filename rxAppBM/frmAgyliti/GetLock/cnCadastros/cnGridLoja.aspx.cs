using DevExpress.Web;
using rxApp.Domain.Entities;
using rxApp.Models;
using System;
using System.Linq;

namespace rxApp.frmAgyliti.GetLock.cnCadastros
{
    public partial class cnGridLoja : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridLoja()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["cod_cliente"]);

            var dsCombo = db.GetLockClientes.ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "nome";
            comboColumn.PropertiesComboBox.ValueField = "id";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.GetLockLojas.ToList();
        }

        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newLoja = new GetLockLoja();
            newLoja.cod_loja = e.NewValues["cod_loja"]?.ToString();
            newLoja.nome = e.NewValues["nome"]?.ToString();
            newLoja.cod_cliente = e.NewValues["cod_cliente"]?.ToString();
            newLoja.razao_social = e.NewValues["razao_social"]?.ToString();
            newLoja.cnpj = e.NewValues["cnpj"]?.ToString();
            newLoja.endereco = e.NewValues["endereco"]?.ToString();
            newLoja.complemento = e.NewValues["complemento"]?.ToString();
            newLoja.bairro = e.NewValues["bairro"]?.ToString();
            newLoja.cidade = e.NewValues["cidade"]?.ToString();
            newLoja.uf = e.NewValues["uf"]?.ToString();
            newLoja.CEP = e.NewValues["CEP"]?.ToString();
            newLoja.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
            newLoja.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
            newLoja.pessoa_contato = e.NewValues["pessoa_contato"]?.ToString();
            newLoja.email = e.NewValues["email"]?.ToString();

            db.GetLockLojas.Add(newLoja);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = (long)Convert.ToInt64(e.Keys["id"]);
            var loja = db.GetLockLojas.FirstOrDefault(l => l.id == gridKey);
            if (loja != null)
            {
                loja.cod_loja = e.NewValues["cod_loja"]?.ToString();
                loja.nome = e.NewValues["nome"]?.ToString();
                loja.cod_cliente = e.NewValues["cod_cliente"]?.ToString();
                loja.razao_social = e.NewValues["razao_social"]?.ToString();
                loja.cnpj = e.NewValues["cnpj"]?.ToString();
                loja.endereco = e.NewValues["endereco"]?.ToString();
                loja.complemento = e.NewValues["complemento"]?.ToString();
                loja.bairro = e.NewValues["bairro"]?.ToString();
                loja.cidade = e.NewValues["cidade"]?.ToString();
                loja.uf = e.NewValues["uf"]?.ToString();
                loja.CEP = e.NewValues["CEP"]?.ToString();
                loja.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
                loja.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
                loja.pessoa_contato = e.NewValues["pessoa_contato"]?.ToString();
                loja.email = e.NewValues["email"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = (long)Convert.ToInt64(e.Keys["id"]);
            var loja = db.GetLockLojas.FirstOrDefault(l => l.id == gridKey);

            db.GetLockLojas.Remove(loja); 
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }
    }
}