using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Additional_Service
{
    public long ID { get; set; }
    public string Service { get; set; }
    public long Price { get; set; }

    public List<Booking_DetailsAdditional_Service> Booking_DetailsAdditional_ServiceList { get; set; } = [];
}

public class Additional_ServiceMap
{
    public Additional_ServiceMap(EntityTypeBuilder<Additional_Service> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ID);
        entityTypeBuilder.Property(e => e.Service).IsRequired();
        entityTypeBuilder.Property(e => e.Price).IsRequired();
        entityTypeBuilder
            .HasMany(e => e.Booking_DetailsAdditional_ServiceList)
            .WithOne(e => e.Additional_Service);
    }
}