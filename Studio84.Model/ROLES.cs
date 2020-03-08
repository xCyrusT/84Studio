using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Model
{
    [Table("Roles")]
    public class ROLES
    {
        [Key]
        public long Id { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        public string RoleNamme { get; set; }

        public bool IsActive { get; set; }
    }
}
