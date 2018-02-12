using Abp.Domain.Entities;
using AbpBasic.DB2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbpBasic.DB2.ACTS
{
    [Table("ACT", Schema="TANGDEZHOU")]
    public class ACT : Entity<short>
    {
        [Key]
        public virtual short ACTNO { get; set; }

        [Required]
        [StringLength(6)]
        public virtual string ACTKWD { get; set; }

        [Required]
        [StringLength(20)]
        public virtual string ACTDESC { get; set; }

        [NotMapped]
        public override short Id { get => ACTNO; set => ACTNO = value; }


    }
}
