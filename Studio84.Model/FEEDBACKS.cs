using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Model
{
    [Table("Feedbacks")]
    public class FEEDBACKS
    {
        [Key]
        public long Id { get; set; }

        [StringLength(50)]
        [Column(TypeName ="nvarchar")]
        public string Fullname { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        [StringLength(200)]
        [Column(TypeName ="nvarchar")]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }
    }
}
