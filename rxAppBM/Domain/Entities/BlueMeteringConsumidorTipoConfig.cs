using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringConsumidorTipoConfig: EntityTypeConfiguration<BlueMeteringConsumidorTipo>
    {
        public BlueMeteringConsumidorTipoConfig()
        {
            this.HasKey(t => t.BlueMeteringConsumidorTipoId);

            HasRequired(u => u.BlueMeteringCliente)
                .WithMany(l => l.BlueMeteringConsumidorTipos)
                .HasForeignKey(u => u.BlueMeteringClienteId);
        }
    }
}