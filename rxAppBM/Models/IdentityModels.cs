using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using rxAppBM.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace rxAppBM.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BlueMeteringMessage> BlueMeteringMessages { get; set; }
        public DbSet<BlueMeteringAlarm> BlueMeteringAlarms { get; set; }
        public DbSet<BlueMeteringLigacao> BlueMeteringLigacoes { get; set; }
        public DbSet<BlueMeteringConsumidor> BlueMeteringConsumidores { get; set; }
        public DbSet<BlueMeteringConsumidorTipo> BlueMeteringConsumidorTipos { get; set; }
        public DbSet<BlueMeteringHidrometro> BlueMeteringHidrometros { get; set; }
        public DbSet<BlueMeteringHidrometroTipo> BlueMeteringHidrometroTipos { get; set; }
        public DbSet<BlueMeteringValvulaCorte> BlueMeteringValvulasCorte { get; set; }
        public DbSet<BlueMeteringUnidadeGerenciamentoRegional> BlueMeteringUnidadeGerenciamentoRegionais { get; set; }
        public DbSet<BlueMeteringUnidadeNegocio> BlueMeteringUnidadeNegocios { get; set; }
        public DbSet<BlueMeteringConsumoPorDia> BlueMeteringConsumoPorDias { get; set; }
        public DbSet<BlueMeteringMessageView> BlueMeteringMessageViews { get; set; }
        public DbSet<BlueMeteringConsumoPorDiaView> BlueMeteringConsumoPorDiaViews { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(250));

            //modelBuilder.ComplexType<AppImageType>()
            //    .Ignore(r => r.Name);

            modelBuilder.Configurations.Add(new ApplicationUserConfig());
            modelBuilder.Configurations.Add(new BlueMeteringMessageConfig());
            modelBuilder.Configurations.Add(new BlueMeteringAlarmConfig());
            modelBuilder.Configurations.Add(new BlueMeteringLigacaoConfig());
            modelBuilder.Configurations.Add(new BlueMeteringConsumidorConfig());
            modelBuilder.Configurations.Add(new BlueMeteringConsumidorTipoConfig());
            modelBuilder.Configurations.Add(new BlueMeteringHidrometroConfig());
            modelBuilder.Configurations.Add(new BlueMeteringHidrometroTipoConfig());
            modelBuilder.Configurations.Add(new BlueMeteringValvulaCorteConfig());
            modelBuilder.Configurations.Add(new BlueMeteringUnidadeGerenciamentoRegionalConfig());
            modelBuilder.Configurations.Add(new BlueMeteringUnidadeNegocioConfig());
            modelBuilder.Configurations.Add(new BlueMeteringConsumoPorDiaConfig());
            modelBuilder.Configurations.Add(new BlueMeteringMessageViewConfig());
            modelBuilder.Configurations.Add(new BlueMeteringConsumoPorDiaViewConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}

#region Helpers
namespace rxAppBM
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion
