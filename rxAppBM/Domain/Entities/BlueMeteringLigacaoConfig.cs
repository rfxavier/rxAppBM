using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringLigacaoConfig : EntityTypeConfiguration<BlueMeteringLigacao>
    {
        public BlueMeteringLigacaoConfig()
        {
            this.HasKey(t => t.BlueMeteringLigacaoId);
        }
    }
}