

using RealEstateProperties.Core.Entitites;
using RealEstateProperties.Core.Interfaces.Repositories;
using RealEstateProperties.Infrastructure.Data;

namespace RealEstateProperties.Infrastructure.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(RealEstatePropertiesDBContext context) : base(context)
        {
        }
    }
}
