using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTO
{
  public  class FilePathDto
    {
        [Required]
        public string filePath { get; set; }
    }
}
    