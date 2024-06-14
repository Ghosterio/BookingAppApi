using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Payment
{
    public long ID { get; set; }
    public string Payment_Info { get; set; }

    public List<Booking_Details> Booking_DetailsPay { get; set; } = [];
}

public class PaymentMap
{
    public PaymentMap(EntityTypeBuilder<Payment> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ID);
        entityTypeBuilder.Property(e => e.Payment_Info).IsRequired();
        entityTypeBuilder
            .HasMany(e => e.Booking_DetailsPay)
            .WithOne(e => e.Payment);
    }
}
