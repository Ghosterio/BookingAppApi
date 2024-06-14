using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Data;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new BookingMap(modelBuilder.Entity<Booking>());
        new Additional_ServiceMap(modelBuilder.Entity<Additional_Service>());
        new Booking_DetailsMap(modelBuilder.Entity<Booking_Details>());
        new Booking_DetailsAdditional_ServiceMap(modelBuilder.Entity<Booking_DetailsAdditional_Service>());
        new Booking_DetailsMain_ServiceMap(modelBuilder.Entity<Booking_DetailsMain_Service>());
        new Main_ServiceMap(modelBuilder.Entity<Main_Service>());
        new PaymentMap(modelBuilder.Entity<Payment>());
        new StatusMap(modelBuilder.Entity<Status>());
        new RoomMap(modelBuilder.Entity<Room>());
    }
}
