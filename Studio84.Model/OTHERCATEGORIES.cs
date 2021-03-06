﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Model
{
    [Table("OtherCategories")]
    public class OTHERCATEGORIES
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        [Column(TypeName ="nvarchar")]
        public string Title { get; set; }

        public long? ParentCategoryId { get; set; }
        public string ThumbPath { get; set; }
        public bool IsRoot { get; set; }
        public bool IsActive { get; set; }
    }
}
