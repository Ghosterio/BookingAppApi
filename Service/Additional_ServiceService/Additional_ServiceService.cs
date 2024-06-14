using DTO.Additional_ServiceDto;
using Repository.Additional_ServiceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Additional_ServiceService;

public class Additional_ServiceService(IAdditional_ServiceRepository additional_serviceRepository) : IAdditional_ServiceService
{
    private IAdditional_ServiceRepository _additional_serviceRepository = additional_serviceRepository;

    public Additional_ServiceDto GetAdditional_Service(long id)
    {
        return _additional_serviceRepository.Get(id);
    }

    public List<Additional_ServiceDto> GetAdditional_Service()
    {
        return _additional_serviceRepository.GetAll();
    }

    public void InsertAdditional_Service(CreateAdditional_ServiceDto dto)
    {
        _additional_serviceRepository.Insert(dto);
    }

    public void UpdateAdditional_Service(UpdateAdditional_ServiceDto dto)
    {
        _additional_serviceRepository.Update(dto);
    }

    public void DeleteAdditional_Service(long id)
    {
        _additional_serviceRepository.Delete(id);
    }
}