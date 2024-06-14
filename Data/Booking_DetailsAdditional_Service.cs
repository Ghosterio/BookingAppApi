using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Booking_DetailsAdditional_Service
{
    public long ID { get; set; }
    public long Booking_DetailsID { get; set; }
    public Booking_Details Booking_Details { get; set; }
    public long Additional_ServiceID { get; set; }
    public Additional_Service Additional_Service { get; set; }
}

public class Booking_DetailsAdditional_ServiceMap
{
    public Booking_DetailsAdditional_ServiceMap(EntityTypeBuilder<Booking_DetailsAdditional_Service> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ID);
        entityTypeBuilder
            .HasOne(e => e.Booking_Details)
            .WithMany(e => e.Booking_DetailsAdditional_ServiceList)
            .HasForeignKey(e => e.Booking_DetailsID);
        entityTypeBuilder
            .HasOne(e => e.Additional_Service)
            .WithMany(e => e.Booking_DetailsAdditional_ServiceList)
            .HasForeignKey(e => e.Additional_ServiceID);
    }
}
