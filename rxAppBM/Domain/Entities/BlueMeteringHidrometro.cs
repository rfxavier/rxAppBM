using System;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringHidrometro
    {
        public Guid BlueMeteringHidrometroId { get; set; }
        public string IdHidrometro { get; set; }
        public string RedeIotId { get; set; }
        public string NumeroSerie { get; set; }
        public string IdHidrometroTipo { get; set; }
        public decimal Capacidade { get; set; }
        public string NumeroSerieRelojoaria { get; set; }
        public decimal MarcacaoInicial { get; set; }
    }
}