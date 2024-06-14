using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Booking
{
    public long ID { get; set; }
    public Status Status { get; set; }
    public long StatusID { get; set; }
    public Room Room { get; set; }
    public List<Booking_Details> Booking_DetailsBooking { get; set; } = [];
}

public class BookingMap
{
    public BookingMap(EntityTypeBuilder<Booking> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ID);
        entityTypeBuilder
            .HasOne(e => e.Status)
            .WithMany(e => e.BookingStatus)
            .HasForeignKey(e => e.StatusID);
        entityTypeBuilder
            .HasMany(e => e.Booking_DetailsBooking)
            .WithOne(e => e.Booking);
        entityTypeBuilder
            .HasOne(e => e.Room)
            .WithOne(e => e.Booking)
            .HasForeignKey<Room>(e => e.BookingRoomID);
    }
}