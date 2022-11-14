using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringHidrometroConfig: EntityTypeConfiguration<BlueMeteringHidrometro>
    {
        public BlueMeteringHidrometroConfig()
        {
            this.HasKey(t => t.BlueMeteringHidrometroId);

            HasRequired(u => u.BlueMeteringCliente)
                .WithMany(l => l.BlueMeteringHidrometros)
                .HasForeignKey(u => u.BlueMeteringClienteId);

            HasOptional(u => u.BlueMeteringHidrometroTipo)
                .WithMany(l => l.BlueMeteringHidrometros)
                .HasForeignKey(u => u.BlueMeteringHidrometroTipoId);

            HasOptional(h => h.BlueMeteringLigacao)
                .WithMany(l => l.BlueMeteringHidrometros)
                .HasForeignKey(h => h.BlueMeteringLigacaoId);

            HasOptional(h => h.BlueMeteringValvulaCorte)
                .WithMany(l => l.BlueMeteringHidrometros)
                .HasForeignKey(h => h.BlueMeteringValvulaCorteId);
        }
    }
}