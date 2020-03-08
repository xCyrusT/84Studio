using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Model
{
    [Table("Banners")]
    public class BANNERS
    {
        [Key]
        public long Id { get; set; }
        public string ImgPath { get; set; }
        public bool IsActive { get; set; }
    }
}
