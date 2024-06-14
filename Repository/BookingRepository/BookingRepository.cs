using Data;
using DTO.BookingDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BookingRepository;

public class BookingRepository(ApplicationContext context) : IBookingRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Booking> _bookings = context.Set<Booking>();

    public BookingDto Get(long id)
    {
        var booking = _bookings.SingleOrDefault(a => a.ID == id);
        if (booking == null) return null;
        return new BookingDto
        {
            ID = booking.ID,
            StatusID = booking.StatusID,
        };
    }
    public List<BookingDto> GetAll()
    {
        var bookings = _bookings.ToList();
        List<BookingDto> lbookings = new List<BookingDto>();
        foreach (var booking in bookings)
        {
            lbookings.Add(new BookingDto
            {
                ID = booking.ID,
                StatusID = booking.StatusID,
            });
        }
        return lbookings;
    }
    public void Insert(CreateBookingDto dto)
    {
        Booking booking = new Booking
        {
            StatusID = dto.StatusID,
        };
        _bookings.Add(booking);
        context.SaveChanges();
    }
    public void Update(UpdateBookingDto dto)
    {
        var booking = _bookings.SingleOrDefault(a => a.ID == dto.ID);
        if (booking == null) return;
        booking.StatusID = dto.StatusID;
        _bookings.Update(booking);
        context.SaveChanges();
    }
    public void Delete(long id)
    {
        var booking = _bookings.SingleOrDefault(a => a.ID == id);
        if (booking == null) return;
        _bookings.Remove(booking);
        context.SaveChanges();
    }
    public void SaveChanges()
    {
        context.SaveChanges();
    }
}