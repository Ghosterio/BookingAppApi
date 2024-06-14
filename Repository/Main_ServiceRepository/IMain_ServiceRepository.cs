using DTO.Main_ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Main_ServiceRepository;

public interface IMain_ServiceRepository
{
    Main_ServiceDto Get(long id);
    List<Main_ServiceDto> GetAll();
    void Insert(CreateMain_ServiceDto dto);
    void Update(UpdateMain_ServiceDto dto);
    void Delete(long id);
    void SaveChanges();
}