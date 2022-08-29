using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringConsumoPorDiaViewConfig: EntityTypeConfiguration<BlueMeteringConsumoPorDiaView>
    {
        public BlueMeteringConsumoPorDiaViewConfig()
        {
            this.HasKey(t => t.BlueMeteringConsumoPordiaId);

            this.ToTable("consumoPorDia_view");
        }
    }
}