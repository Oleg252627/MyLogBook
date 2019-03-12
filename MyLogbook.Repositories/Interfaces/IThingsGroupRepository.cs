using System;
using System.Collections.Generic;
using System.Text;
using MyLogbook.Abstractions;
using MyLogbook.Entities;

namespace MyLogbook.Repositories.Interfaces
{
    public interface IThingsGroupRepository : IDbRepository<ThingsGroup>
    {
    }
}
