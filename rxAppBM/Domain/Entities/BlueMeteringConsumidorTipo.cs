using System;
using System.Collections.Generic;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringConsumidorTipo
    {
        public Guid BlueMeteringConsumidorTipoId { get; set; }
        public string IdConsumidorTipo { get; set; }
        public string Descricao { get; set; }
        public Guid BlueMeteringClienteId { get; set; }
        public BlueMeteringCliente BlueMeteringCliente { get; set; }
        public ICollection<BlueMeteringConsumidor> BlueMeteringConsumidores { get; set; }
    }
}