using System;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringConsumoPorDiaView
    {
        public Guid BlueMeteringConsumoPordiaId { get; set; }
        public string PayloadId { get; set; }
        public DateTime TimestampDate { get; set; }
        public Guid BlueMeteringMessageIdStartOfMonthDay { get; set; }
        public Guid BlueMeteringMessageIdEndOfMonthDay { get; set; }
        public long? PayloadVolLitersDelta { get; set; }
        public DateTime? trackLastWriteTime { get; set; }
        public DateTime? trackCreationTime { get; set; }
        public string LigacaoId { get; set; }
        public string LigacaoRgi { get; set; }
        public string LigacaoEndereco { get; set; }
        public Nullable<decimal> LigacaoLatitude { get; set; }
        public Nullable<decimal> LigacaoLongitude { get; set; }
        public string ConsumidorIdConsumidor { get; set; }
        public string ConsumidorIdExternoConsumidor { get; set; }
        public string ConsumidorNomeCompleto { get; set; }
        public string ConsumidorCPF { get; set; }
        public string ConsumidorRG { get; set; }
        public string ConsumidorTipo { get; set; }
        public string HidrometroIdHidrometro { get; set; }
        public string HidrometroRedeIotId { get; set; }
        public string HidrometroNumeroSerie { get; set; }
        public string HidrometroTipoDescricao { get; set; }
        public Nullable<decimal> HidrometroCapacidade { get; set; }
        public string HidrometroNumeroSerieRelojoaria { get; set; }
        public Nullable<decimal> HidrometroMarcacaoInicial { get; set; }
        public string ValvulaCorteIdValvulaCorte { get; set; }
        public string ValvulaCorteNumeroSerie { get; set; }
        public string UnidadeNegocioIdUnidadeNegocio { get; set; }
        public string UnidadeNegocioNome { get; set; }
        public string UnidadeNegocioEndereco { get; set; }
        public Nullable<decimal> UnidadeNegocioLatitude { get; set; }
        public Nullable<decimal> UnidadeNegocioLongitude { get; set; }
        public string UnidadeGerenciamentoRegionalIdUnidadeGerenciamentoRegional { get; set; }
        public string UnidadeGerenciamentoRegionalNome { get; set; }
        public string UnidadeGerenciamentoRegionalEndereco { get; set; }
        public Nullable<decimal> UnidadeGerenciamentoRegionalLatitude { get; set; }
        public Nullable<decimal> UnidadeGerenciamentoRegionalLongitude { get; set; }
    }
}