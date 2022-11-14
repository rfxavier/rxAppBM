using System;
using System.Collections.Generic;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringLigacao
    {
        public Guid BlueMeteringLigacaoId { get; set; }
        public string LigacaoId { get; set; }
        public string Rgi { get; set; }
        public string Endereco { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<decimal> longitude { get; set; }
        public Guid? BlueMeteringConsumidorId { get; set; }
        public BlueMeteringConsumidor BlueMeteringConsumidor { get; set; }
        public Guid? BlueMeteringUnidadeNegocioId { get; set; }
        public BlueMeteringUnidadeNegocio BlueMeteringUnidadeNegocio { get; set; }
        public ICollection<BlueMeteringHidrometro> BlueMeteringHidrometros { get; set; }
        public Guid BlueMeteringClienteId { get; set; }
        public BlueMeteringCliente BlueMeteringCliente { get; set; }
    }
}