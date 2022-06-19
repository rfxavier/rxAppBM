using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringHidrometroConfig: EntityTypeConfiguration<BlueMeteringHidrometro>
    {
        public BlueMeteringHidrometroConfig()
        {
            this.HasKey(t => t.BlueMeteringHidrometroId);
        }
    }
}