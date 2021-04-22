using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class FileProperty
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public long Size { get; set; }
    }
}
