using System;

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
    }
}