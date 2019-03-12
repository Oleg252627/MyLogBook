using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLogbook.Abstractions;
using MyLogbook.AppContext;
using MyLogbook.Entities;



namespace MyLogbook.Repositories
{
    public class FacultyRepositoty : DbRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepositoty(AppDbContext context) : base(context)
        {
        }
        public async Task<List<SelectListItem>> ShowFaculty()
        {
            var faculties = await ToListAsync();
            if (faculties == null)
            {
                return null;
            }
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var VARIABLE in faculties)
            {
                items.Add(new SelectListItem { Text = VARIABLE.Name, Value = $"{VARIABLE.Id}" });
            }

            return items;
        }
        public async Task<List<SelectListItem>> ShowFacultyEdit(Group group)
        {
            var faculties = await ToListAsync();
            if (faculties == null)
            {
                return null;
            }
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var VARIABLE in faculties)
            {
                if (group.id_Faculty.Equals(VARIABLE.Id))
                {
                    items.Add(new SelectListItem { Text = VARIABLE.Name, Value = $"{VARIABLE.Id}", Selected = true });
                }
                else
                {
                    items.Add(new SelectListItem { Text = VARIABLE.Name, Value = $"{VARIABLE.Id}", Selected = false });
                }

            }

            return items;
        }
    }
}
