using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Model
{
    [Table("CameraCategories")]
    public class CAMERACATEGORIES
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        [Column(TypeName ="nvarchar")]
        public string Title { get; set; }

        public string ThumbPath { get; set; }
        public string VideoUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
