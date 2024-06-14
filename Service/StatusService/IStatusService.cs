using DTO.StatusDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.StatusService;

public interface IStatusService
{
    StatusDto GetStatus(long id);
    List<StatusDto> GetStatus();
    void InsertStatus(CreateStatusDto dto);
    void UpdateStatus(UpdateStatusDto dto);
    void DeleteStatus(long id);
}