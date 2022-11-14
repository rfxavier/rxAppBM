﻿using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringUnidadeGerenciamentoRegionalConfig: EntityTypeConfiguration<BlueMeteringUnidadeGerenciamentoRegional>
    {
        public BlueMeteringUnidadeGerenciamentoRegionalConfig()
        {
            this.HasKey(t => t.BlueMeteringUnidadeGerenciamentoRegionalId);

            HasRequired(u => u.BlueMeteringCliente)
                .WithMany(l => l.BlueMeteringUnidadeGerenciamentoRegionais)
                .HasForeignKey(u => u.BlueMeteringClienteId);
        }
    }
}