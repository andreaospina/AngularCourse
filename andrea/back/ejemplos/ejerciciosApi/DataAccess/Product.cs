using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ejerciciosApi.DataAccess
{
    [Keyless]
    [Table("products")]
    public partial class Product
    {
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; } = null!;
        [Column("code")]
        [StringLength(10)]
        public string Code { get; set; } = null!;
        [Column("buyprice")]
        public decimal Buyprice { get; set; }
        [Column("sellprice")]
        public decimal Sellprice { get; set; }
        [Column("margin")]
        public decimal Margin { get; set; }
        [Column("issubtype")]
        public bool Issubtype { get; set; }
        [Column("creationdate", TypeName = "timestamp without time zone")]
        public DateTime Creationdate { get; set; }
        [Column("updatedate", TypeName = "timestamp without time zone")]
        public DateTime Updatedate { get; set; }
        [Required]
        [Column("isactive")]
        public bool? Isactive { get; set; }
    }
}
