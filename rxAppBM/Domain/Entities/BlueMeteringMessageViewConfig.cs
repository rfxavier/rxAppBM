using System.Data.Entity.ModelConfiguration;

namespace rxAppBM.Domain.Entities
{
    public class BlueMeteringMessageViewConfig: EntityTypeConfiguration<BlueMeteringMessageView>
    {
        public BlueMeteringMessageViewConfig()
        {
            this.HasKey(t => t.BlueMeteringMessageId);

            this.ToTable("message_view");
        }
    }
}