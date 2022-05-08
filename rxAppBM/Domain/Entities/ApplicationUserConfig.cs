using System.Data.Entity.ModelConfiguration;
using rxAppBM.Models;

namespace rxAppBM.Domain.Entities
{
    public class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {
            HasOptional(u => u.Company)
                .WithMany(c => c.ApplicationUsers)
                .HasForeignKey(u => u.CompanyId);
        }        
    }
}