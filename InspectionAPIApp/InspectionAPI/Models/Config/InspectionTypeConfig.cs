using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspectionAPI.Models.Config
{
    public class InspectionTypeConfig : IEntityTypeConfiguration<InspectionType>
    {
        public void Configure(EntityTypeBuilder<InspectionType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InspectionName).IsRequired(true).HasMaxLength(20);
        }
    }
}
