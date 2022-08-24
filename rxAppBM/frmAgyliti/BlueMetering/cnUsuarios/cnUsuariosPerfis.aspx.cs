using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using rxAppBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rxAppBM.frmAgyliti.BlueMetering.cnUsuarios
{
    public partial class cnUsuariosPerfis : Page
    {
        private ApplicationDbContext db;
        private ApplicationUserManager userManager;


        public cnUsuariosPerfis()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn1 = ((GridViewDataComboBoxColumn)GridUserProfiles.Columns["UserId"]);

            var dsCombo1 = userManager.Users.ToList();

            comboColumn1.PropertiesComboBox.DataSource = dsCombo1;
            comboColumn1.PropertiesComboBox.TextField = "UserName";
            comboColumn1.PropertiesComboBox.ValueField = "Id";
            comboColumn1.PropertiesComboBox.ValueType = typeof(string);


            var comboColumn2 = ((GridViewDataComboBoxColumn)GridUserProfiles.Columns["RoleId"]);

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles.ToList();

            var dsCombo2 = GetAllowedRoles(roles);

            comboColumn2.PropertiesComboBox.DataSource = dsCombo2;
            comboColumn2.PropertiesComboBox.TextField = "Name";
            comboColumn2.PropertiesComboBox.ValueField = "Id";
            comboColumn2.PropertiesComboBox.ValueType = typeof(string);

            GridUserProfiles.DataBind();
        }

        protected void GridUserProfiles_DataBinding(object sender, EventArgs e)
        {
            var usersAndRoles = new List<IdentityUserRole>();
            var users = db.Users;

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var allRoles = roleMngr.Roles.ToList();

            foreach (var user in users)
            {
                var userRoles = userManager.GetRoles(user.Id).ToList();

                var roles = GetAllowedRoles(allRoles).Where(r => userRoles.Contains(r.Name)).ToList();

                foreach (var role in roles)
                {
                    usersAndRoles.Add(new IdentityUserRole
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    });
                }
            }

            GridUserProfiles.DataSource = usersAndRoles;
        }

        protected void GridUserProfiles_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var user = userManager.FindById(e.NewValues["UserId"].ToString());

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles.ToList();
                
            var role = roles.FirstOrDefault(r => r.Id == e.NewValues["RoleId"].ToString());

            var result = manager.AddToRole(user.Id, role.Name);

            if (result.Succeeded)
            {
                e.Cancel = true;
                GridUserProfiles.CancelEdit();
            }
        }

        protected void GridUserProfiles_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var user = userManager.FindById(e.Keys[0].ToString());

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles.ToList();

            var role = roles.FirstOrDefault(r => r.Id == e.Keys[1].ToString());

            var result = manager.RemoveFromRole(user.Id, role.Name);

            if (result.Succeeded)
            {
                e.Cancel = true;
                GridUserProfiles.CancelEdit();
            }
        }


        protected void GridUserProfiles_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
                if (e.ButtonType == ColumnCommandButtonType.Edit)
                    e.Visible = false;
        }
        protected List<IdentityRole> GetAllowedRoles(List<IdentityRole> roles)
        {
            var returnRoleList = new List<IdentityRole>();

            foreach (var identityRole in roles)
            {
                if (!(identityRole.Name == "AdmMaster" || identityRole.Name == "AdmPortal" || identityRole.Name == "User"))
                {
                    returnRoleList.Add(identityRole);
                }
            }

            return returnRoleList;
        }
    }
}