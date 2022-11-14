using System.Data.Entity.ModelConfiguration;
using rxAppBM.Models;

namespace rxAppBM.Domain.Entities
{
    public class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {
            HasOptional(u => u.BlueMeteringCliente)
                .WithMany(l => l.ApplicationUsers)
                .HasForeignKey(u => u.BlueMeteringClienteId);
        }
    }
}