using RealEstateProperties.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstateProperties.Core.Entitites
{
    public partial class Property : BaseEntity
    {
        public Property()
        {
            PropertyImages = new HashSet<PropertyImage>();
            PropertyTraces = new HashSet<PropertyTrace>();
        }

        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
        public string CodeInternal { get; set; }
        public int? Year { get; set; }
        public int? IdOwner { get; set; }

        public virtual Owner IdOwnerNavigation { get; set; }
        public virtual ICollection<PropertyImage> PropertyImages { get; set; }
        public virtual ICollection<PropertyTrace> PropertyTraces { get; set; }
    }
}
