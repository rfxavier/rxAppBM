using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringMessageConfig: EntityTypeConfiguration<BlueMeteringMessage>
    {
        public BlueMeteringMessageConfig()
        {
            this.HasKey(t => t.BlueMeteringMessageId);
        }
    }
}