using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyLogbook.AppContext;
using MyLogbook.Entities;
using MyLogbook.Repositories.Interfaces;

namespace MyLogbook.Repositories
{
    public class ThingRepository : DbRepository<Thing>, IThingRepository
    {
        public ThingRepository(AppDbContext context) : base(context)
        {

        }
    }
}
