using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringClienteConfig: EntityTypeConfiguration<BlueMeteringCliente>
    {
        public BlueMeteringClienteConfig()
        {
            this.HasKey(t => t.BlueMeteringClienteId);
        }
    }
}