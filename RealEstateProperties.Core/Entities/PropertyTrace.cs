using RealEstateProperties.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstateProperties.Core.Entitites
{
    public partial class PropertyTrace : BaseEntity
    {
        public int IdPropertyTrace { get; set; }
        public DateTime? DataSale { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public decimal? Tax { get; set; }
        public int? IdProperty { get; set; }

        public virtual Property IdPropertyNavigation { get; set; }
    }
}
