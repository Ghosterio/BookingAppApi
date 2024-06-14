using DTO.Main_ServiceDto;
using Repository.Main_ServiceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Main_ServiceService;

public class Main_ServiceService(IMain_ServiceRepository main_serviceRepository) : IMain_ServiceService
{
    private IMain_ServiceRepository _main_serviceRepository = main_serviceRepository;

    public Main_ServiceDto GetMain_Service(long id)
    {
        return _main_serviceRepository.Get(id);
    }

    public List<Main_ServiceDto> GetMain_Service()
    {
        return _main_serviceRepository.GetAll();
    }

    public void InsertMain_Service(CreateMain_ServiceDto dto)
    {
        _main_serviceRepository.Insert(dto);
    }

    public void UpdateMain_Service(UpdateMain_ServiceDto dto)
    {
        _main_serviceRepository.Update(dto);
    }

    public void DeleteMain_Service(long id)
    {
        _main_serviceRepository.Delete(id);
    }
}