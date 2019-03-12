using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MyLogbook.Abstractions;

namespace MyLogbook.Entities
{
    [Table("ThingsGroup")]
    public class ThingsGroup : DbEntity
    {

        public Guid id_Thing { get; set; }
        public Guid id_Group { get; set; }
        [ForeignKey("id_Thing")]
        public virtual Thing Thing { get; set; }
        [ForeignKey("id_Group")]
        public virtual Group Group { get; set; }
    }
}
