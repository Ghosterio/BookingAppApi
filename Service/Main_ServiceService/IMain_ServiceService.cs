using DTO.Main_ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Main_ServiceService;

public interface IMain_ServiceService
{
    Main_ServiceDto GetMain_Service(long id);
    List<Main_ServiceDto> GetMain_Service();
    void InsertMain_Service(CreateMain_ServiceDto dto);
    void UpdateMain_Service(UpdateMain_ServiceDto dto);
    void DeleteMain_Service(long id);
}