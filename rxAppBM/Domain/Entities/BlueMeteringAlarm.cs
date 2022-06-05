using System;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringAlarm
    {
        public Guid BlueMeteringAlarmId { get; set; }
        public int PayloadAlarm { get; set; }
        public string PayloadAlarmDescription { get; set; }
    }
}