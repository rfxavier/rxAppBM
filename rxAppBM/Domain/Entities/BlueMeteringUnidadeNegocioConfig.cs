﻿using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringUnidadeNegocioConfig: EntityTypeConfiguration<BlueMeteringUnidadeNegocio>
    {
        public BlueMeteringUnidadeNegocioConfig()
        {
            this.HasKey(t => t.BlueMeteringUnidadeNegocioId);

            HasRequired(u => u.BlueMeteringCliente)
                .WithMany(l => l.BlueMeteringUnidadeNegocios)
                .HasForeignKey(u => u.BlueMeteringClienteId);

            HasOptional(h => h.BlueMeteringUnidadeGerenciamentoRegional)
                .WithMany(l => l.BlueMeteringUnidadeNegocios)
                .HasForeignKey(h => h.BlueMeteringUnidadeGerenciamentoRegionalId);
        }
    }
}