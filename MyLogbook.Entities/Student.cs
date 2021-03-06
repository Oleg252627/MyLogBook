﻿using MyLogbook.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyLogbook.Entities
{
    [Table("students")]
    public class Student : DbEntity
    {
        [Column("firstName")]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Column("lastName")]
        [StringLength(64)]
        public string LastName { get; set; }
        public Guid id_Group { get; set; }
        [ForeignKey("id_Group")]
        public virtual Group Group { get; set; }
        public virtual List<Assessment> Assessments { get; set; }
    }
}
