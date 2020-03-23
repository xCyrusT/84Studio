using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services.OtherCategory.Dto
{
    public class OtherCategoryWithChildDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public string ThumbPath { get; set; }
        public bool IsRoot { get; set; }
        public bool IsActive { get; set; }

        public List<OtherCategoryDto> LstOtherCategory { get; set; }
    }

    public class OtherCategoryDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public string ThumbPath { get; set; }
        public bool IsRoot { get; set; }
        public bool IsActive { get; set; }
    }
}
