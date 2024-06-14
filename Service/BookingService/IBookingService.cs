using DTO.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BookingService;

public interface IBookingService
{
    BookingDto GetBooking(long id);
    List<BookingDto> GetBooking();
    void InsertBooking(CreateBookingDto dto);
    void UpdateBooking(UpdateBookingDto dto);
    void DeleteBooking(long id);
}