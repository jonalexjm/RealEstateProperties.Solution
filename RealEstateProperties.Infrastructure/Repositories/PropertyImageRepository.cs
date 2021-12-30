using RealEstateProperties.Core.Entitites;
using RealEstateProperties.Core.Interfaces.Repositories;
using RealEstateProperties.Infrastructure.Data;

namespace RealEstateProperties.Infrastructure.Repositories
{
    public class PropertyImageRepository : BaseRepository<PropertyImage>, IPropertyImageRepository
    {
        public PropertyImageRepository(RealEstatePropertiesDBContext context) : base(context)
        {
        }
    }
}
