using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services.Price.Dto
{
    public class PricePostDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long PriceCategoryId { get; set; }
        public string PriceCategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
