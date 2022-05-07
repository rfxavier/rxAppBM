using System.Data.Entity.ModelConfiguration;
using rxApp.Models;

namespace rxApp.Domain.Entities
{
    public class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {
            HasOptional(u => u.Company)
                .WithMany(c => c.ApplicationUsers)
                .HasForeignKey(u => u.CompanyId);

            HasOptional(u => u.GetLockLoja)
                .WithMany(l => l.ApplicationUsers)
                .HasForeignKey(u => u.GetLockLojaId);
        }        
    }
}