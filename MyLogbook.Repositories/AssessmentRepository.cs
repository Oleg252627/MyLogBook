using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyLogbook.AppContext;
using MyLogbook.Entities;
using MyLogbook.Repositories.Interfaces;

namespace MyLogbook.Repositories
{
    public class AssessmentRepository : DbRepository<Assessment>, IAssessmentRepository
    {
        public AssessmentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
