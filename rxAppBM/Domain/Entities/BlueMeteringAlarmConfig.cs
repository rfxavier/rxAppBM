using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringAlarmConfig: EntityTypeConfiguration<BlueMeteringAlarm>
    {
        public BlueMeteringAlarmConfig()
        {
            this.HasKey(t => t.BlueMeteringAlarmId);
        }
    }
}