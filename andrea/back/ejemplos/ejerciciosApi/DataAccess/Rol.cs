using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ejerciciosApi.DataAccess
{
    [Table("rol")]
    public partial class Rol
    {
        public Rol()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("rolid")]
        public int Rolid { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column("creationdate", TypeName = "timestamp without time zone")]
        public DateTime Creationdate { get; set; }
        [Column("updateddate", TypeName = "timestamp without time zone")]
        public DateTime? Updateddate { get; set; }
        [Required]
        [Column("isactive")]
        public bool? Isactive { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
