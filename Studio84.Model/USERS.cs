using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Model
{
    [Table("Users")]
    public class USERS
    {
        [Key]
        public long Id { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        public string Fullname { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImgUrl { get; set; }
        public long RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
