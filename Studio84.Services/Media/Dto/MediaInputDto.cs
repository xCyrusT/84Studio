using Studio84.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services.Media.Dto
{
    public class MediaInputDto
    {
        public long? Id { get; set; }
        public long PostId { get; set; }
        public string ImgPath { get; set; }
    }
}
