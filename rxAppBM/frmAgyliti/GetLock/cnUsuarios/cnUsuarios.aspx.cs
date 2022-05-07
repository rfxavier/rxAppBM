using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxApp.Models;
using System;
using System.Data;
using System.Linq;
using System.Web;

namespace rxApp.frmAgyliti.GetLock.cnUsuarios
{
    public partial class cnUsuarios : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext db;

        public cnUsuarios()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new ApplicationDbContext();

            var comboColumn = ((GridViewDataComboBoxColumn)GridUsers.Columns["GetLockLojaId"]);

            var dsCombo = db.GetLockLojas.ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "nome";
            comboColumn.PropertiesComboBox.ValueField = "id";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            GridUsers.DataBind();
        }

        protected void GridUsers_DataBinding(object sender, EventArgs e)
        {
            GridUsers.DataSource = userManager.Users.ToList();
        }

        protected void confirmButton_Click(object sender, EventArgs e)
        {
            UpdatePasswordField(cpsw.Text, npsw.Text);
            ASPxPopupControl1.ShowOnPageLoad = false;
        }

        protected void UpdatePasswordField(string oldPassword, string newPassword)
        {
            int index = GridUsers.EditingRowVisibleIndex;
            DataTable dt = Session["data"] as DataTable;
            dt.Rows[0]["CurrPwd"] = oldPassword;
            dt.Rows[0]["NewPwd"] = newPassword;
            Session["data"] = dt;

        }

        protected void GridUsers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = new ApplicationUser() { UserName = e.NewValues["UserName"].ToString(), Email = e.NewValues["UserName"].ToString() };
            user.GetLockLojaId = Convert.ToInt64(e.NewValues["GetLockLojaId"]);
            IdentityResult result = manager.Create(user, e.NewValues["PasswordHash"].ToString());
            if (result.Succeeded)
            {

                manager.AddToRole(user.Id, "User");

                e.Cancel = true;
                gridView.CancelEdit();
            }
            else
            {
                //ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void GridUsers_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            DataTable dt = new DataTable();

            dt = Session["data"] as DataTable;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = manager.FindById(e.Keys[0].ToString());
            user.GetLockLojaId = Convert.ToInt64(e.NewValues["GetLockLojaId"]);
            manager.Update(user);

            if (!((dt.Rows[0]["CurrPwd"].ToString() == "" && dt.Rows[0]["NewPwd"].ToString() == "")))
            {
                IdentityResult result = manager.ChangePassword(e.Keys[0].ToString(), dt.Rows[0]["CurrPwd"].ToString(), dt.Rows[0]["NewPwd"].ToString());
                if (result.Succeeded)
                {
                    e.Cancel = true;
                    gridView.CancelEdit();
                }
                else
                {
                    //AddErrors(result);
                }
            } else
            {
                e.Cancel = true;
                gridView.CancelEdit();
            }
        }

        protected void GridUsers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            IdentityResult result = manager.Delete(manager.FindById(e.Keys[0].ToString()));
            if (result.Succeeded)
            {
                e.Cancel = true;
                gridView.CancelEdit();
            }
            else
            {
                //AddErrors(result);
            }
        }

        protected void GridUsers_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            DataTable dt = new DataTable();

            if (Session["data"] == null)
            {
                dt.Columns.Add("CurrPwd", typeof(string));
                dt.Columns.Add("NewPwd", typeof(string));

                dt.Rows.Add(new object[] { "", "" });
                Session["data"] = dt;
            }
            else
            {
                dt = Session["data"] as DataTable;
                dt.Rows[0]["CurrPwd"] = "";
                dt.Rows[0]["NewPwd"] = "";
            }
        }
    }
}