using DTO.StatusDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StatusRepository;

public interface IStatusRepository
{
    StatusDto Get(long id);
    List<StatusDto> GetAll();
    void Insert(CreateStatusDto dto);
    void Update(UpdateStatusDto dto);
    void Delete(long id);
    void SaveChanges();
}

