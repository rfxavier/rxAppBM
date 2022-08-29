using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringConsumoPorDiaConfig: EntityTypeConfiguration<BlueMeteringConsumoPorDia>
    {
        public BlueMeteringConsumoPorDiaConfig()
        {
            this.HasKey(t => t.BlueMeteringConsumoPordiaId);
        }
    }
}