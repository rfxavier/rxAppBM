using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringLigacaoConfig : EntityTypeConfiguration<BlueMeteringLigacao>
    {
        public BlueMeteringLigacaoConfig()
        {
            this.HasKey(t => t.BlueMeteringLigacaoId);

            HasRequired(u => u.BlueMeteringCliente)
                .WithMany(l => l.BlueMeteringLigacoes)
                .HasForeignKey(u => u.BlueMeteringClienteId);

            HasOptional(h => h.BlueMeteringConsumidor)
                .WithMany(l => l.BlueMeteringLigacoes)
                .HasForeignKey(h => h.BlueMeteringConsumidorId);

            HasOptional(h => h.BlueMeteringUnidadeNegocio)
                .WithMany(l => l.BlueMeteringLigacoes)
                .HasForeignKey(h => h.BlueMeteringUnidadeNegocioId);
        }
    }
}