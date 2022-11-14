using System;
using System.Collections.Generic;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringHidrometroTipo
    {
        public Guid BlueMeteringHidrometroTipoId { get; set; }
        public string IdHidrometroTipo { get; set; }
        public string Descricao { get; set; }
        public ICollection<BlueMeteringHidrometro> BlueMeteringHidrometros { get; set; }
        public Guid BlueMeteringClienteId { get; set; }
        public BlueMeteringCliente BlueMeteringCliente { get; set; }
    }
}