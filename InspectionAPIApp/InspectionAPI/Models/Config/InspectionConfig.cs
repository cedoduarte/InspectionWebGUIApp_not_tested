using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspectionAPI.Models.Config
{
    public class InspectionConfig : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.Comments).IsRequired(true).HasMaxLength(200);
        }
    }
}
