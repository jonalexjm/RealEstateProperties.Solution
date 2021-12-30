using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Core.DTOs
{
    public class PropertyImageDto
    {
        public int IdPropertyImage { get; set; }
        public string File { get; set; }
        public bool? Enable { get; set; }
        public int? IdProperty { get; set; }
    }
}
