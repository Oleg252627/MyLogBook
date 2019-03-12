using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MyLogbook.Abstractions;

namespace MyLogbook.Entities
{
    [Table("things")]
    public class Thing : DbEntity
    {
        [Column("Title")]
        [StringLength(64)]
        public string Title { get; set; }
        public Guid id_Teacher { get; set; }
        [ForeignKey("id_Teacher")]
        public virtual Teacher Teacher { get; set; }
        public virtual List<ThingsGroup> ThingsGroups { get; set; }
        public virtual List<Assessment> Assessments { get; set; }
    }
}
