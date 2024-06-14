using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace Data;

public class User : IdentityUser
{
    public string Gender { get; set; }
    public List<Booking_Details> Booking_DetailsUser { get; set; } = [];
}

public class UserMap
{
    public UserMap(EntityTypeBuilder<User> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder
            .HasMany(e => e.Booking_DetailsUser)
            .WithOne(e => e.User);
    }
}