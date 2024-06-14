using DTO.Booking_DetailsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Booking_DetailsService;

public interface IBooking_DetailsService
{
    Booking_DetailsDto GetBooking_Details(long id);
    List<Booking_DetailsDto> GetBooking_Details();
    void InsertBooking_Details(CreateBooking_DetailsDto dto);
    void UpdateBooking_Details(UpdateBooking_DetailsDto dto);
    void DeleteBooking_Details(long id);
}