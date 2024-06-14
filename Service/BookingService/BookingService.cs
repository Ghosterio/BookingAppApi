using DTO.BookingDto;
using Repository.BookingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BookingService;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    private IBookingRepository _bookingRepository = bookingRepository;

    public BookingDto GetBooking(long id)
    {
        return _bookingRepository.Get(id);
    }

    public List<BookingDto> GetBooking()
    {
        return _bookingRepository.GetAll();
    }

    public void InsertBooking(CreateBookingDto dto)
    {
        _bookingRepository.Insert(dto);
    }

    public void UpdateBooking(UpdateBookingDto dto)
    {
        _bookingRepository.Update(dto);
    }

    public void DeleteBooking(long id)
    {
        _bookingRepository.Delete(id);
    }
}
