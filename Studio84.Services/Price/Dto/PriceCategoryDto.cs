using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services.Price.Dto
{
    public class PriceCategoryDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbPath { get; set; }
        public bool IsActive { get; set; }
    }
}
