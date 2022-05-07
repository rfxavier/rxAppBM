﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using rxApp.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace rxApp.Models
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

        public long? GetLockLojaId { get; set; }
        public GetLockLoja GetLockLoja { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<RsData> RsDatas { get; set; }

        public DbSet<GetLockMessage> GetLockMessages { get; set; }
        public DbSet<GetLockCofre> GetLockCofres { get; set; }
        public DbSet<GetLockCofreUser> GetLockCofreUsers { get; set; }
        public DbSet<GetLockCliente> GetLockClientes { get; set; }
        public DbSet<GetLockLoja> GetLockLojas { get; set; }
        public DbSet<GetLockRede> GetLockRedes { get; set; }
        public DbSet<GetLockMovimento> GetLockMovimentos { get; set; }
        public DbSet<GetLockMessageView> GetLockMessageViews { get; set; }
        public DbSet<GetLockLojaClienteRedeView> GetLockLojaClienteRedeViews { get; set; }

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

            modelBuilder.Configurations.Add(new RsDataConfig());

            //modelBuilder.ComplexType<AppImageType>()
            //    .Ignore(r => r.Name);

            modelBuilder.Configurations.Add(new ApplicationUserConfig());
            modelBuilder.Configurations.Add(new GetLockMessageConfig());
            modelBuilder.Configurations.Add(new GetLockCofreConfig());
            modelBuilder.Configurations.Add(new GetLockCofreUserConfig());
            modelBuilder.Configurations.Add(new GetLockClienteConfig());
            modelBuilder.Configurations.Add(new GetLockLojaConfig());
            modelBuilder.Configurations.Add(new GetLockRedeConfig());
            modelBuilder.Configurations.Add(new GetLockMovimentoConfig());
            modelBuilder.Configurations.Add(new GetLockMessageViewConfig());
            modelBuilder.Configurations.Add(new GetLockLojaClienteRedeViewConfig());

            base.OnModelCreating(modelBuilder);
        }

    }
}

#region Helpers
namespace rxApp
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
