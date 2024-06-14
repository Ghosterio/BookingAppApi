using Data;
using DTO.Booking_DetailsDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Booking_DetailsRepository;

public class Booking_DetailsRepository(ApplicationContext context) : IBooking_DetailsRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Booking_Details> _booking_details = context.Set<Booking_Details>();

    public Booking_DetailsDto Get(long id)
    {
        var booking_details = _booking_details.SingleOrDefault(a => a.ID == id);
        if (booking_details == null) return null;
        return new Booking_DetailsDto
        {
            ID = booking_details.ID,
            Chek_in_date = booking_details.Chek_in_date,
            Eviction_date = booking_details.Eviction_date,
            Prepayment = booking_details.Prepayment,
            Date_of_change = booking_details.Date_of_change,
            BookingID = booking_details.BookingID,
            UserID = booking_details.UserID,
            PaymentID = booking_details.PaymentID,
        };
    }
    public List<Booking_DetailsDto> GetAll()
    {
        var booking_detailss = _booking_details.ToList();
        List<Booking_DetailsDto> lbooking_detailss = new List<Booking_DetailsDto>();
        foreach (var booking_details in booking_detailss)
        {
            lbooking_detailss.Add(new Booking_DetailsDto
            {
                ID = booking_details.ID,
                Chek_in_date = booking_details.Chek_in_date,
                Eviction_date = booking_details.Eviction_date,
                Prepayment = booking_details.Prepayment,
                Date_of_change = booking_details.Date_of_change,
                PaymentID=booking_details.PaymentID,
                UserID = booking_details.UserID,
                BookingID=booking_details.BookingID,
            });
        }
        return lbooking_detailss;
    }
    public void Insert(CreateBooking_DetailsDto dto)
    {
        Booking_Details booking_details = new Booking_Details
        {
            Chek_in_date = dto.Chek_in_date,
            Eviction_date = dto.Eviction_date,
            Prepayment = dto.Prepayment,
            Date_of_change = dto.Date_of_change,
            PaymentID=dto.PaymentID,
            UserID = dto.UserID,
            BookingID = dto.BookingID,
        };
        _booking_details.Add(booking_details);
        context.SaveChanges();
    }
    public void Update(UpdateBooking_DetailsDto dto)
    {
        var booking_details = _booking_details.SingleOrDefault(a => a.ID == dto.ID);
        if (booking_details == null) return;
        booking_details.Chek_in_date = dto.Chek_in_date;
        booking_details.Eviction_date = dto.Eviction_date;
        booking_details.Prepayment = dto.Prepayment;
        booking_details.Date_of_change = dto.Date_of_change;
        booking_details.PaymentID = dto.PaymentID;
        booking_details.UserID = dto.UserID;
        booking_details.BookingID = dto.BookingID;
        _booking_details.Update(booking_details);
        context.SaveChanges();
    }
    public void Delete(long id)
    {
        var booking_details = _booking_details.SingleOrDefault(a => a.ID == id);
        if (booking_details == null) return;
        _booking_details.Remove(booking_details);
        context.SaveChanges();
    }
    public void SaveChanges()
    {
        context.SaveChanges();
    }
}