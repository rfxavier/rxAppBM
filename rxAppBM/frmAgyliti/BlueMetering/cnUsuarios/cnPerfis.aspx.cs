using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using rxAppBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rxAppBM.frmAgyliti.BlueMetering.cnUsuarios
{
    public partial class cnPerfis : System.Web.UI.Page
    {
        private ApplicationDbContext db;


        public cnPerfis()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridProfiles.DataBind();
        }

        protected void GridProfiles_DataBinding(object sender, EventArgs e)
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles.ToList();
            
            GridProfiles.DataSource = GetAllowedRoles(roles);
        }

        protected void GridProfiles_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var result = roleMngr.Create(new IdentityRole(e.NewValues["Name"].ToString()));

            if (result.Succeeded)
            {
                e.Cancel = true;
                gridView.CancelEdit();
            }

        }

        protected void GridProfiles_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);
            var role = roleMngr.FindByName(e.Keys[0].ToString());

            role.Name = e.NewValues["Name"].ToString();
            var result = roleMngr.Update(role);

            if (result.Succeeded)
            {
                e.Cancel = true;
                gridView.CancelEdit();
            }
        }

        protected void GridProfiles_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var role = roleMngr.FindByName(e.Keys[0].ToString());
            var result = roleMngr.Delete(role);

            if (result.Succeeded)
            {
                e.Cancel = true;
                gridView.CancelEdit();
            }
        }

        protected List<IdentityRole> GetAllowedRoles(List<IdentityRole> roles)
        {
            var returnRoleList = new List<IdentityRole>();

            foreach (var identityRole in roles)
            {
                if (!(identityRole.Name == "AdmMaster" || identityRole.Name == "AdmPortal" || identityRole.Name == "User" || identityRole.Name == "UserClient"))
                {
                    returnRoleList.Add(identityRole);
                }                
            }

            return returnRoleList;
        }
    }
}