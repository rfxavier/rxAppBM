using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringConsumidorConfig: EntityTypeConfiguration<BlueMeteringConsumidor>
    {
        public BlueMeteringConsumidorConfig()
        {
            this.HasKey(t => t.BlueMeteringConsumidorId);

            HasRequired(u => u.BlueMeteringCliente)
                .WithMany(l => l.BlueMeteringConsumidores)
                .HasForeignKey(u => u.BlueMeteringClienteId);

            HasOptional(h => h.BlueMeteringConsumidorTipo)
                .WithMany(l => l.BlueMeteringConsumidores)
                .HasForeignKey(h => h.BlueMeteringConsumidorTipoId);
        }
    }
}