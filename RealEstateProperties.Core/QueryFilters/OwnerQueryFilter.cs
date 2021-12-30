using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Core.QueryFilters
{
    public class OwnerQueryFilter
    {
        public int? IdOwner { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
