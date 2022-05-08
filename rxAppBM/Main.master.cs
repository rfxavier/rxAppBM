using Microsoft.AspNet.Identity.Owin;
using rxAppBM.Models;
using System;
using System.Web;

namespace rxAppBM
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

        }
    }
}