using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstateProperties.Core.Entitites
{
    public partial class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public string File { get; set; }
        public bool? Enable { get; set; }
        public int? IdProperty { get; set; }

        public virtual Property IdPropertyNavigation { get; set; }
    }
}
