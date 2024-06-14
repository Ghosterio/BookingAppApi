using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Additional_ServiceDto;

namespace Repository.Additional_ServiceRepository;

public interface IAdditional_ServiceRepository
{
    Additional_ServiceDto Get(long id);
    List<Additional_ServiceDto> GetAll();
    void Insert(CreateAdditional_ServiceDto dto);
    void Update(UpdateAdditional_ServiceDto dto);
    void Delete(long id);
    void SaveChanges();
}
