using DevExpress.Web;
using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Linq;

namespace rxAppBM.frmAgyliti.BlueMetering.cnCadastros
{
    public partial class cnGridCliente : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridCliente()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.BlueMeteringClientes.ToList();
        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newCliente = new BlueMeteringCliente();
            newCliente.BlueMeteringClienteId = Guid.NewGuid();
            newCliente.IdCliente = e.NewValues["IdCliente"]?.ToString();
            newCliente.NomeFantasia = e.NewValues["NomeFantasia"]?.ToString();
            newCliente.CNPJ = e.NewValues["CNPJ"]?.ToString();
            newCliente.Endereco = e.NewValues["Endereco"]?.ToString();
            newCliente.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
            newCliente.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
            newCliente.PessoaContato = e.NewValues["PessoaContato"]?.ToString();
            newCliente.Email = e.NewValues["Email"]?.ToString();
            newCliente.Telefone = e.NewValues["Telefone"]?.ToString();

            db.BlueMeteringClientes.Add(newCliente);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringClienteId"]?.ToString());
            var cliente = db.BlueMeteringClientes.FirstOrDefault(l => l.BlueMeteringClienteId == gridKey);
            if (cliente != null)
            {
                cliente.IdCliente = e.NewValues["IdCliente"]?.ToString();
                cliente.NomeFantasia = e.NewValues["NomeFantasia"]?.ToString();
                cliente.CNPJ = e.NewValues["CNPJ"]?.ToString();
                cliente.Endereco = e.NewValues["Endereco"]?.ToString();
                cliente.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
                cliente.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
                cliente.PessoaContato = e.NewValues["PessoaContato"]?.ToString();
                cliente.Email = e.NewValues["Email"]?.ToString();
                cliente.Telefone = e.NewValues["Telefone"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = new Guid(e.Keys["BlueMeteringClienteId"]?.ToString());
            var cliente = db.BlueMeteringClientes.FirstOrDefault(l => l.BlueMeteringClienteId == gridKey);

            db.BlueMeteringClientes.Remove(cliente);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }
    }
}