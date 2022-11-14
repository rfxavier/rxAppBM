using System;
using System.Collections.Generic;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringUnidadeNegocio
    {
        public Guid BlueMeteringUnidadeNegocioId { get; set; }
        public string IdUnidadeNegocio { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<decimal> longitude { get; set; }
        public Guid? BlueMeteringUnidadeGerenciamentoRegionalId { get; set; }
        public BlueMeteringUnidadeGerenciamentoRegional BlueMeteringUnidadeGerenciamentoRegional { get; set; }
        public Guid BlueMeteringClienteId { get; set; }
        public BlueMeteringCliente BlueMeteringCliente { get; set; }
        public ICollection<BlueMeteringLigacao> BlueMeteringLigacoes { get; set; }
    }
}