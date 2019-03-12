using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MyLogbook.Abstractions;

namespace MyLogbook.Entities
{
    [Table("assessment")]
    public class Assessment : DbEntity
    {
        [Column("ball")]
        public int Ball { get; set; }
        public Guid id_Student { get; set; }
        public Guid id_Thing { get; set; }
        [ForeignKey("id_Student")]
        public virtual Student Student { get; set; }
        [ForeignKey("id_Thing")]
        public virtual Thing Thing { get; set; }
    }
}
