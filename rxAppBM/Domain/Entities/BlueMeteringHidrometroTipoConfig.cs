using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringHidrometroTipoConfig: EntityTypeConfiguration<BlueMeteringHidrometroTipo>
    {
        public BlueMeteringHidrometroTipoConfig()
        {
            this.HasKey(t => t.BlueMeteringHidrometroTipoId);
        }        
    }
}