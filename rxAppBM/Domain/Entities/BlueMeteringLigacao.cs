using System;

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
        public string IdConsumidor { get; set; }
        public string IdValvulaCorte { get; set; }
    }
}