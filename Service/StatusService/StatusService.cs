using DTO.StatusDto;
using Repository.StatusRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.StatusService;

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private IStatusRepository _statusRepository = statusRepository;

    public StatusDto GetStatus(long id)
    {
        return _statusRepository.Get(id);
    }

    public List<StatusDto> GetStatus()
    {
        return _statusRepository.GetAll();
    }

    public void InsertStatus(CreateStatusDto dto)
    {
        _statusRepository.Insert(dto);
    }

    public void UpdateStatus(UpdateStatusDto dto)
    {
        _statusRepository.Update(dto);
    }

    public void DeleteStatus(long id)
    {
        _statusRepository.Delete(id);
    }
}