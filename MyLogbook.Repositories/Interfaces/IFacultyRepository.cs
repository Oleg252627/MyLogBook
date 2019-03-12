using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLogbook.Abstractions;
using MyLogbook.Entities;

namespace MyLogbook.Repositories
{
    public interface IFacultyRepository: IDbRepository<Faculty>
    {
        Task<List<SelectListItem>> ShowFaculty();
        Task<List<SelectListItem>> ShowFacultyEdit(Group group);
    }
}
