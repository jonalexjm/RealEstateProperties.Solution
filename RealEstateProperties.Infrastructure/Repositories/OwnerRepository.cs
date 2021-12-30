using RealEstateProperties.Core.Entitites;
using RealEstateProperties.Core.Interfaces.Repositories;
using RealEstateProperties.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Infrastructure.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(RealEstatePropertiesDBContext context) : base(context)
        {
        }
    }
}
