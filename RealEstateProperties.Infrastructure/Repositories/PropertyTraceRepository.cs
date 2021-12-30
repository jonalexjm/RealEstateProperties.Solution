using RealEstateProperties.Core.Entitites;
using RealEstateProperties.Core.Interfaces.Repositories;
using RealEstateProperties.Infrastructure.Data;

namespace RealEstateProperties.Infrastructure.Repositories
{
    public class PropertyTraceRepository : BaseRepository<PropertyTrace>, IPropertyTraceRepository
    {
        public PropertyTraceRepository(RealEstatePropertiesDBContext context) : base(context)
        {
        }
    }
}
