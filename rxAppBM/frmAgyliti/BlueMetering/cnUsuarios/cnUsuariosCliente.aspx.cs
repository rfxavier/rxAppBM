using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using rxAppBM;
using rxAppBM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace rxApp.frmAgyliti.GetLock.cnUsuarios
{
    public partial class cnUsuariosCliente : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext db;

        public cnUsuariosCliente()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new ApplicationDbContext();

            var comboColumn = ((GridViewDataComboBoxColumn)GridUsers.Columns["BlueMeteringClienteId"]);

            var dsCombo = db.BlueMeteringClientes.ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "NomeFantasia";
            comboColumn.PropertiesComboBox.ValueField = "BlueMeteringClienteId";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            GridUsers.DataBind();
        }

        protected void GridUsers_DataBinding(object sender, EventArgs e)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //Get user role
            var clientRole = roleManager.FindByName("UserClient");


            GridUsers.DataSource = userManager.Users.Where(x => x.Roles.Any(role=> role.RoleId == clientRole.Id)).ToList();
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
            user.BlueMeteringClienteId = new Guid(e.NewValues["BlueMeteringClienteId"].ToString());
            IdentityResult result = manager.Create(user, e.NewValues["PasswordHash"].ToString());
            if (result.Succeeded)
            {

                manager.AddToRole(user.Id, "UserClient");

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
            user.BlueMeteringClienteId = new Guid(e.NewValues["BlueMeteringClienteId"].ToString());
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

        protected void GridUsers_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            if (e.NewValues["UserName"] != null &&
                !IsValidEmail(e.NewValues["UserName"].ToString()))
            {
                AddError(e.Errors, GridUsers.Columns["UserName"],
                    "Usuário precisa ter formato de um email válido");
            }
            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0)
                e.RowError = "Corrija todos os erros";
        }
        void AddError(Dictionary<GridViewColumn, string> errors,
            GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}