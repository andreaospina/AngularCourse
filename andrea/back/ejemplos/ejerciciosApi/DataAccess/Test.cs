using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ejerciciosApi.DataAccess
{
    [Table("test")]
    public partial class Test
    {
        public Test()
        {
            Secondarytabletests = new HashSet<Secondarytabletest>();
        }

        [Key]
        [Column("testid")]
        public int Testid { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column("lastname")]
        [StringLength(50)]
        public string? Lastname { get; set; }

        [InverseProperty("Test")]
        public virtual ICollection<Secondarytabletest> Secondarytabletests { get; set; }
    }
}
