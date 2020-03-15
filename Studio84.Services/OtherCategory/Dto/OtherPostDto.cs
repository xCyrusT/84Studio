using Studio84.Services.Media.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services.OtherCategory.Dto
{
    public class OtherPostDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long OtherCategoryId { get; set; }
        public string OtherCategoryName { get; set; }
        public bool IsActive { get; set; }

        public List<MediaDto> LstMedia { get; set; }
    }
}
