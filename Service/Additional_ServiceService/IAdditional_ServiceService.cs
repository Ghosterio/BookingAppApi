using DTO.Additional_ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Additional_ServiceService;

public interface IAdditional_ServiceService
{
    Additional_ServiceDto GetAdditional_Service(long id);
    List<Additional_ServiceDto> GetAdditional_Service();
    void InsertAdditional_Service(CreateAdditional_ServiceDto dto);
    void UpdateAdditional_Service(UpdateAdditional_ServiceDto dto);
    void DeleteAdditional_Service(long id);
}