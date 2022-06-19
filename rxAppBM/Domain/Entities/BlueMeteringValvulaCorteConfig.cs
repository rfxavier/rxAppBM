using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringValvulaCorteConfig: EntityTypeConfiguration<BlueMeteringValvulaCorte>
    {
        public BlueMeteringValvulaCorteConfig()
        {
            this.HasKey(v => v.BlueMeteringValvulaCorteId);
        }
    }
}