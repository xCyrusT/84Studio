﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services.Camera.Dto
{
    public class CameraPostInputDto
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public long CameraCategoryId { get; set; }
        public string ThumbPath { get; set; }
        public string VideoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
