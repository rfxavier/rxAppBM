using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace rxApp.frmRx.Agyliti.GetLock.cnGridMain
{
    public partial class cnGridMain : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;
        public cnGridMain()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Create an event handler for the master page's contentCallEvent event
            Master.contentCallEvent += new EventHandler(Page_Load);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            //var ds = new EntityServerModeSource { QueryableSource = new ApplicationDbContext().GetLockMessageViews };

            LinqServerModeDataSource lnsource = new LinqServerModeDataSource { ContextTypeName = "rxApp.Models.ApplicationDbContext", TableName = "GetLockMessageViews" };
            lnsource.Selecting += EntityServerModeDataSource1_Selecting;

            ASPxGridView1.DataSource = lnsource;
        }

        string displayText = String.Empty;
        DateTime curDate;
        protected void ASPxGridView1_ProcessColumnAutoFilter(object sender, DevExpress.Web.ASPxGridViewAutoFilterEventArgs e)
        {
            if (e.Column.FieldName != "trackCreationTime")
                return;

            if (e.Kind == DevExpress.Web.GridViewAutoFilterEventKind.CreateCriteria)
                if (DateTime.TryParse(e.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out curDate))
                {
                    BinaryOperator op1 = new BinaryOperator("trackCreationTime", curDate, BinaryOperatorType.GreaterOrEqual);
                    BinaryOperator op2 = new BinaryOperator("trackCreationTime", curDate.AddMinutes(1), BinaryOperatorType.Less);
                    GroupOperator grOp = new GroupOperator(GroupOperatorType.And, op1, op2);
                    e.Criteria = grOp;
                    displayText = curDate.ToString("dd-MMMM-yyyy hh:mm");
                }

            if (e.Kind == DevExpress.Web.GridViewAutoFilterEventKind.ExtractDisplayText)
                e.Value = displayText;
        }

        protected void ASPxGridView1_AutoFilterCellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "trackCreationTime")
                return;
            ASPxDateEdit ed = e.Editor as ASPxDateEdit;
            ed.TimeSectionProperties.Visible = true;
            ed.TimeSectionProperties.TimeEditProperties.EditFormatString = "hh:mm";
        }

        protected void EntityServerModeDataSource1_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var db = new ApplicationDbContext();

            e.KeyExpression = "id";

            if (User.IsInRole("User"))
            {
                var user = userManager.FindById(User.Identity.GetUserId());
                var loja = db.GetLockLojas.FirstOrDefault(l => l.id == user.GetLockLojaId);

                var idLoja = loja?.id;

                e.QueryableSource = db.GetLockMessageViews.Where(g => g.id_loja == idLoja);
            }
            else
            {
                // e.QueryableSource = db.GetLockMessageViews;

                if (Session["selectedLojas"] != null && (Session["dateStart"] != null) && (Session["dateEnd"] != null))
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];
                    var dateStart = (DateTime)Session["dateStart"];
                    var dateEnd = (DateTime)Session["dateEnd"];
                    e.QueryableSource = db.GetLockMessageViews.Where(g => selectedLojas.Contains(g.id_loja) && g.trackCreationTime >= dateStart && g.trackCreationTime <= dateEnd);
                }
                else if (Session["selectedLojas"] != null && (Session["dateStart"] != null) && (Session["dateEnd"] == null))
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];
                    var dateStart = (DateTime)Session["dateStart"];
                    e.QueryableSource = db.GetLockMessageViews.Where(g => selectedLojas.Contains(g.id_loja) && g.trackCreationTime >= dateStart);
                }
                else if (Session["selectedLojas"] != null && (Session["dateStart"] == null) && (Session["dateEnd"] != null))
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];
                    var dateEnd = (DateTime)Session["dateEnd"];
                    e.QueryableSource = db.GetLockMessageViews.Where(g => selectedLojas.Contains(g.id_loja) && g.trackCreationTime <= dateEnd);
                }
                else if (Session["selectedLojas"] == null && (Session["dateStart"] != null) && (Session["dateEnd"] != null))
                {
                    var dateStart = (DateTime)Session["dateStart"];
                    var dateEnd = (DateTime)Session["dateEnd"];
                    e.QueryableSource = db.GetLockMessageViews.Where(g => g.trackCreationTime >= dateStart && g.trackCreationTime <= dateEnd);
                }
                else if (Session["selectedLojas"] == null && (Session["dateStart"] != null) && (Session["dateEnd"] == null))
                {
                    var dateStart = (DateTime)Session["dateStart"];
                    e.QueryableSource = db.GetLockMessageViews.Where(g => g.trackCreationTime >= dateStart);
                }
                else if (Session["selectedLojas"] == null && (Session["dateStart"] == null) && (Session["dateEnd"] != null))
                {
                    var dateEnd = (DateTime)Session["dateEnd"];
                    e.QueryableSource = db.GetLockMessageViews.Where(g => g.trackCreationTime <= dateEnd);
                }
                else
                {
                    e.QueryableSource = db.GetLockMessageViews.Where(g => g.trackCreationTime >= new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0) && g.trackCreationTime <= new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 23, 59, 59));
                }
            }
        }
        protected void UpdatePanel(object sender, EventArgs e)
        {
            updateDetails.Update(); //refresh the update pabel
        }

        protected void UpdatePanel_Unload(object sender, EventArgs e)
        {
            RegisterUpdatePanel((UpdatePanel)sender);
        }
        protected void RegisterUpdatePanel(UpdatePanel panel)
        {
            var sType = typeof(ScriptManager);
            var mInfo = sType.GetMethod("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel", BindingFlags.NonPublic | BindingFlags.Instance);
            if (mInfo != null)
                mInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] { panel });
        }
    }
}