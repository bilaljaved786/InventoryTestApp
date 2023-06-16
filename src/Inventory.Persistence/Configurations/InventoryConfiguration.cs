using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Persistence.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Domain.Entities.Inventory>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Inventory> builder)
        {
            builder.HasKey(sc => new { sc.Id });

            // builder.HasOne(sc => sc.Inventory)
            //        .WithMany(c => c!.InventoryCourses)
            //        .HasForeignKey(sc => sc.InventoryId)
            //        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
