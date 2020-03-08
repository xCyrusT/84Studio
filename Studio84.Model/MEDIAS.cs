using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Model
{
    [Table("Medias")]
    public class MEDIAS
    {
        [Key]
        public long Id { get; set; }

        public long PostId { get; set; }
        public string ImgPath { get; set; }
    }
}
