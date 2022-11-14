using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using rxAppBM.Models;
using System;
using System.Data;
using System.Linq;
using System.Web;

namespace rxAppBM.frmAgyliti.GetLock.cnUsuarios
{
    public partial class cnUsuariosAdmin : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext db;

        public cnUsuariosAdmin()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new ApplicationDbContext();

            GridUsers.DataBind();
        }

        protected void GridUsers_DataBinding(object sender, EventArgs e)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //Get admin role
            var adminRole = roleManager.FindByName("AdmPortal");

            GridUsers.DataSource = userManager.Users.Where(x => x.Roles.Any(role => role.RoleId == adminRole.Id)).ToList();
        }

        protected void confirmButton_Click(object sender, EventArgs e)
        {
            UpdatePasswordField(npsw.Text);
            ASPxPopupControl1.ShowOnPageLoad = false;
        }

        protected void UpdatePasswordField(string newPassword)
        {
            int index = GridUsers.EditingRowVisibleIndex;
            DataTable dt = Session["data"] as DataTable;
            dt.Rows[0]["NewPwd"] = newPassword;
            Session["data"] = dt;

        }

        protected void GridUsers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = new ApplicationUser() { UserName = e.NewValues["UserName"].ToString(), Email = e.NewValues["UserName"].ToString() };

            IdentityResult result = manager.Create(user, e.NewValues["PasswordHash"].ToString());
            if (result.Succeeded)
            {

                manager.AddToRole(user.Id, "AdmPortal");

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

            manager.Update(user);

            string token = manager.GeneratePasswordResetToken(user.Id);
            IdentityResult result = userManager.ResetPassword(user.Id, token, dt.Rows[0]["NewPwd"].ToString());

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
                dt.Columns.Add("NewPwd", typeof(string));

                dt.Rows.Add(new object[] { "", "" });
                Session["data"] = dt;
            }
            else
            {
                dt = Session["data"] as DataTable;
                dt.Rows[0]["NewPwd"] = "";
            }
        }
    }
}