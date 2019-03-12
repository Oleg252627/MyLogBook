using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyLogbook.AppContext;
using MyLogbook.Entities;
using MyLogbook.Repositories.Interfaces;

namespace MyLogbook.Repositories
{
    public class TeacherRepository : DbRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {

        }
    }
}
