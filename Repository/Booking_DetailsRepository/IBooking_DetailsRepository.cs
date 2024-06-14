using DTO.Booking_DetailsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Booking_DetailsRepository;

public interface IBooking_DetailsRepository
{
    Booking_DetailsDto Get(long id);
    List<Booking_DetailsDto> GetAll();
    void Insert(CreateBooking_DetailsDto dto);
    void Update(UpdateBooking_DetailsDto dto);
    void Delete(long id);
    void SaveChanges();
}
