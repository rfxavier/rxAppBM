using System;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringConsumoPorDia
    {
        public Guid BlueMeteringConsumoPordiaId { get; set; }
        public string PayloadId { get; set; }
        public DateTime TimestampDate { get; set; }
        public Guid BlueMeteringMessageIdStartOfMonthDay { get; set; }
        public Guid BlueMeteringMessageIdEndOfMonthDay { get; set; }
        public long? PayloadVolLitersDelta { get; set; }
        public DateTime? trackLastWriteTime { get; set; }
        public DateTime? trackCreationTime { get; set; }
    }
}