using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTO
{
 public   class FilePathWithTimeRangeDto
    {
        [Required]
        public string filePath { get; set; }
        [Required]
        public  DateTime start { get; set; }
        [Required]
        public   DateTime end { get; set; }
    }
}
