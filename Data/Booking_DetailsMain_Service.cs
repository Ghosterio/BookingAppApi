using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Booking_DetailsMain_Service
{
    public long ID { get; set; }
    public long Booking_DetailsID { get; set; }
    public Booking_Details Booking_Details { get; set; }
    public long Main_ServiceID { get; set; }
    public Main_Service Main_Service { get; set; }
}

public class Booking_DetailsMain_ServiceMap
{
    public Booking_DetailsMain_ServiceMap(EntityTypeBuilder<Booking_DetailsMain_Service> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ID);
        entityTypeBuilder
            .HasOne(e => e.Booking_Details)
            .WithMany(e => e.Booking_DetailsMain_ServiceList)
            .HasForeignKey(e => e.Booking_DetailsID);
        entityTypeBuilder
            .HasOne(e => e.Main_Service)
            .WithMany(e => e.Booking_DetailsMain_ServiceList)
            .HasForeignKey(e => e.Main_ServiceID);
    }
}