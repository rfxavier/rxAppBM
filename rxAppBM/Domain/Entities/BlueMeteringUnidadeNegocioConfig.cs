using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringUnidadeNegocioConfig: EntityTypeConfiguration<BlueMeteringUnidadeNegocio>
    {
        public BlueMeteringUnidadeNegocioConfig()
        {
            this.HasKey(t => t.BlueMeteringUnidadeNegocioId);
        }
    }
}