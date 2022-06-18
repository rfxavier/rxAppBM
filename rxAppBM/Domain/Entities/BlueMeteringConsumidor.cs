using System;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringConsumidor
    {
        public Guid BlueMeteringConsumidorId { get; set; }
        public string IdConsumidor { get; set; }
        public string IdExternoConsumidor { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime? trackLastWriteTime { get; set; }
        public DateTime? trackCreationTime { get; set; }
    }
}