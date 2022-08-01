using System;

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
        public string IdUnidadeGerenciamentoRegional { get; set; }
    }
}