using DTO.Booking_DetailsDto;
using Repository.Booking_DetailsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Booking_DetailsService;

public class Booking_DetailsService(IBooking_DetailsRepository booking_detailsRepository) : IBooking_DetailsService
{
    private IBooking_DetailsRepository _booking_detailsRepository = booking_detailsRepository;

    public Booking_DetailsDto GetBooking_Details(long id)
    {
        return _booking_detailsRepository.Get(id);
    }

    public List<Booking_DetailsDto> GetBooking_Details()
    {
        return _booking_detailsRepository.GetAll();
    }

    public void InsertBooking_Details(CreateBooking_DetailsDto dto)
    {
        _booking_detailsRepository.Insert(dto);
    }

    public void UpdateBooking_Details(UpdateBooking_DetailsDto dto)
    {
        _booking_detailsRepository.Update(dto);
    }

    public void DeleteBooking_Details(long id)
    {
        _booking_detailsRepository.Delete(id);
    }
}