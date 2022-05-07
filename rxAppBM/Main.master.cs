using DevExpress.Web.ASPxTreeList;
using Microsoft.AspNet.Identity.Owin;
using rxApp.Domain.Entities;
using rxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rxApp
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private ApplicationDbContext db;
        private ApplicationUserManager userManager;
        object ds;

        public Main()
        {
            db = new ApplicationDbContext();
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxTreeList1.DataBind();
            ASPxTreeList1.ExpandAll();
            ASPxTreeList1.SettingsSelection.Recursive = true;

            if (!Page.IsPostBack)
            {
                if (Session["dateStart"] != null)
                {
                    deStart.Value = Session["dateStart"];
                }
                else
                {
                    deStart.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
                }

                if (Session["dateEnd"] != null)
                {
                    deEnd.Value = Session["dateEnd"];
                }
                else
                {
                    deEnd.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 23, 59, 59);
                }
            }
        }

        protected void ASPxTreeList1_DataBinding(object sender, EventArgs e)
        {
            ds = db.GetLockLojaClienteRedeViews.AsNoTracking().ToList();

            var dsLojaClienteRedeView = ds as List<GetLockLojaClienteRedeView>;

            var dsRedeGroup = dsLojaClienteRedeView.GroupBy(x => new { idRede = "R" + x.id_rede.ToString(), nomeRede = x.nome_rede }).Select(y => new TreeListDataSource() { id = y.Key.idRede, parentId = "", nome = y.Key.nomeRede }).ToList();

            var dsClienteGroup = dsLojaClienteRedeView.GroupBy(x => new { idCliente = "C" + x.id_cliente.ToString(), nomeCliente = x.nome_cliente, idRede = x.id_rede }).Select(y => new TreeListDataSource() { id = y.Key.idCliente, parentId = "R" + y.Key.idRede.ToString(), nome = y.Key.nomeCliente }).ToList();

            var dsLojaGroup = dsLojaClienteRedeView.GroupBy(x => new { idLoja = "L" + x.id_loja.ToString(), nomeLoja = x.nome_loja, idCliente = x.id_cliente }).Select(y => new TreeListDataSource() { id = y.Key.idLoja, parentId = "C" + y.Key.idCliente.ToString(), nome = y.Key.nomeLoja }).ToList();

            List<TreeListDataSource> dsTreeList = dsRedeGroup.Concat(dsClienteGroup).Concat(dsLojaGroup).ToList();

            ASPxTreeList1.DataSource = dsTreeList;
        }

        private class TreeListDataSource
        {
            public string id { get; set; }
            public string parentId { get; set; }
            public string nome { get; set; }
        }

        protected void ASPxTreeList1_DataBound(object sender, EventArgs e)
        {
            ASPxTreeList list = sender as ASPxTreeList;

            if (!IsPostBack)
            {
                if (Session["selectedLojas"] != null)
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];
                    var selectedKeys = selectedLojas.Select(x => "L" + x.ToString());

                    TreeListNodeIterator iterator = list.CreateNodeIterator();
                    TreeListNode node;
                    while (true)
                    {
                        node = iterator.GetNext();
                        if (node == null) break;

                        if (selectedKeys.Contains(node.Key))
                        {
                            node.Selected = true;
                        }
                    }
                }

            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            var selectedLojas = ASPxTreeList1.GetSelectedNodes().Where(k => k.Key.StartsWith("L")).Select(x => Convert.ToInt64(x.Key.Substring(1))).ToList();

            Session["selectedLojas"] = selectedLojas;

            var dateStart = new DateTime(deStart.Date.Year, deStart.Date.Month, deStart.Date.Day, 0, 0, 0);
            var dateEnd = new DateTime(deEnd.Date.Year, deEnd.Date.Month, deEnd.Date.Day, 23, 59, 59);

            Session["dateStart"] = dateStart;
            Session["dateEnd"] = dateEnd;

            //call the content page method to rebind the data and refresh the update panel.
            contentCallEvent?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler contentCallEvent;
    }
}