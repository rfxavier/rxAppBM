using System;
using System.Collections.Generic;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringValvulaCorte
    {
        public Guid BlueMeteringValvulaCorteId { get; set; }
        public string IdValvulaCorte { get; set; }
        public string NumeroSerie { get; set; }
        public ICollection<BlueMeteringHidrometro> BlueMeteringHidrometros { get; set; }
        public Guid BlueMeteringClienteId { get; set; }
        public BlueMeteringCliente BlueMeteringCliente { get; set; }
    }
}