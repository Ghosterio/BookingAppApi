using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Room
{
    public long ID { get; set; }
    public string Room_Name { get; set; }
    public long BookingRoomID { get; set; }
    public Booking Booking {  get; set; }
}

public class RoomMap
{
    public RoomMap(EntityTypeBuilder<Room> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ID);
        entityTypeBuilder.Property(e => e.Room_Name).IsRequired();
        entityTypeBuilder
            .HasOne(e => e.Booking)
            .WithOne(e => e.Room)
            .HasForeignKey<Room>(e => e.BookingRoomID).IsRequired();
    }
}