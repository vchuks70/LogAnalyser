using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTO
{
 public   class FilePathWithSizeRangeDto
    {
        [Required]
        public string filePath { get; set; }
        [Required]
        public int smallSize { get; set; }
        [Required]
        public int LargeSize     { get; set; }
    }
}
