using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Main_Service
{
    public long ID { get; set; }
    public string Service { get; set; }

    public List<Booking_DetailsMain_Service> Booking_DetailsMain_ServiceList { get; set; } = [];
}

public class Main_ServiceMap
{
    public Main_ServiceMap(EntityTypeBuilder<Main_Service> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ID);
        entityTypeBuilder.Property(e => e.Service).IsRequired();
        entityTypeBuilder
            .HasMany(e => e.Booking_DetailsMain_ServiceList)
            .WithOne(e => e.Main_Service);
    }
}