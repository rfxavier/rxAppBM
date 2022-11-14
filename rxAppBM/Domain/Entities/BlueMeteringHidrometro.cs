using System;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringHidrometro
    {
        public Guid BlueMeteringHidrometroId { get; set; }
        public string IdHidrometro { get; set; }
        public string RedeIotId { get; set; }
        public string NumeroSerie { get; set; }
        public Guid? BlueMeteringHidrometroTipoId { get; set; }
        public BlueMeteringHidrometroTipo BlueMeteringHidrometroTipo { get; set; }
        public decimal Capacidade { get; set; }
        public string NumeroSerieRelojoaria { get; set; }
        public decimal MarcacaoInicial { get; set; }
        public string DeviceId { get; set; }
        public Guid? BlueMeteringLigacaoId { get; set; }
        public BlueMeteringLigacao BlueMeteringLigacao { get; set; }
        public Guid? BlueMeteringValvulaCorteId { get; set; }
        public BlueMeteringValvulaCorte BlueMeteringValvulaCorte { get; set; }
        public Guid BlueMeteringClienteId { get; set; }
        public BlueMeteringCliente BlueMeteringCliente { get; set; }
    }
}