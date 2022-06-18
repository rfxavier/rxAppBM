using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringConsumidorConfig: EntityTypeConfiguration<BlueMeteringConsumidor>
    {
        public BlueMeteringConsumidorConfig()
        {
            this.HasKey(t => t.BlueMeteringConsumidorId);
        }
    }
}