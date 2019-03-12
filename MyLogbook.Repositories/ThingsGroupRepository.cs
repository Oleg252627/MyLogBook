using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyLogbook.AppContext;
using MyLogbook.Entities;
using MyLogbook.Repositories.Interfaces;

namespace MyLogbook.Repositories
{
    public class ThingsGroupRepository : DbRepository<ThingsGroup>, IThingsGroupRepository
    {
        public ThingsGroupRepository(AppDbContext context) : base(context)
        {

        }
    }
}
