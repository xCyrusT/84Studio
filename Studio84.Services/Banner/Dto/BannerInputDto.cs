using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services.Banner.Dto
{
    public class BannerInputDto
    {
        public long? Id { get; set; }
        public string ImgPath { get; set; }
        public bool IsActive { get; set; }
    }
}
