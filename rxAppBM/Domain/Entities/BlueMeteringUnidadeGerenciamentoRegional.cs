using System;
using System.Collections.Generic;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringUnidadeGerenciamentoRegional
    {
        public Guid BlueMeteringUnidadeGerenciamentoRegionalId { get; set; }
        public string IdUnidadeGerenciamentoRegional { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<decimal> longitude { get; set; }
        public Guid BlueMeteringClienteId { get; set; }
        public BlueMeteringCliente BlueMeteringCliente { get; set; }
        public ICollection<BlueMeteringUnidadeNegocio> BlueMeteringUnidadeNegocios { get; set; }
    }
}