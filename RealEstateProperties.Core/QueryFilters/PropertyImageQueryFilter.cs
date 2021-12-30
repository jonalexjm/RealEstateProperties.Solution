using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Core.QueryFilters
{
    public class PropertyImageQueryFilter
    {
        public int? IdPropertyImage { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
