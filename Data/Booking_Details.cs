using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Booking_Details
{
    public long ID { get; set; }
    public DateTime Chek_in_date { get; set; }
    public DateTime Eviction_date { get; set; }
    public bool Prepayment { get; set; }
    public DateTime Date_of_change { get; set; }
    public Payment Payment { get; set; }
    public long PaymentID { get; set; }
    public Booking Booking {  get; set; }
    public long BookingID { get; set; }
    public User User { get; set; }
    public string UserID { get; set; }

    public List<Booking_DetailsMain_Service> Booking_DetailsMain_ServiceList { get; set; } = [];
    public List<Booking_DetailsAdditional_Service> Booking_DetailsAdditional_ServiceList { get; set; } = [];
}

public class Booking_DetailsMap
{
    public Booking_DetailsMap(EntityTypeBuilder<Booking_Details> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ID);
        entityTypeBuilder.Property(e => e.Chek_in_date).IsRequired();
        entityTypeBuilder.Property(e => e.Eviction_date).IsRequired();
        entityTypeBuilder.Property(e => e.Prepayment).IsRequired();
        entityTypeBuilder.Property(e => e.Date_of_change).IsRequired();
        entityTypeBuilder
            .HasOne(e => e.Booking)
            .WithMany(e => e.Booking_DetailsBooking)
            .HasForeignKey(e => e.BookingID);
        entityTypeBuilder
            .HasMany(e => e.Booking_DetailsMain_ServiceList)
            .WithOne(e => e.Booking_Details);
        entityTypeBuilder
            .HasMany(e => e.Booking_DetailsAdditional_ServiceList)
            .WithOne(e => e.Booking_Details);
        entityTypeBuilder
            .HasOne(e => e.Payment)
            .WithMany(e => e.Booking_DetailsPay)
            .HasForeignKey(e => e.PaymentID);
        entityTypeBuilder
            .HasOne(e => e.User)
            .WithMany(e => e.Booking_DetailsUser)
            .HasForeignKey(e => e.UserID);
    }
}
