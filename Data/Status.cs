using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Status
{
    public long ID { get; set; }
    public string Status_Info { get; set; }

    public List<Booking> BookingStatus { get; set; } = [];
}

public class StatusMap
{
    public StatusMap(EntityTypeBuilder<Status> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ID);
        entityTypeBuilder.Property(e => e.Status_Info).IsRequired();
        entityTypeBuilder
            .HasMany(e => e.BookingStatus)
            .WithOne(e => e.Status);
    }
}