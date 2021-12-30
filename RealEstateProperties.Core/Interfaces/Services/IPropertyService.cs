using RealEstateProperties.Core.CustomEntities;
using RealEstateProperties.Core.Entitites;
using RealEstateProperties.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Core.Interfaces.Services
{
    public interface IPropertyService
    {
        /// <summary>
        /// Método para consultar todos los registros de Property con paginación
        /// </summary>
        /// <param name="OwnerQueryFilter"> Objeto para el filtro </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        Task<PagedList<Property>> GetAllProperty(PropertyQueryFilter filters);

        /// <summary>
        /// Método para crear Property
        /// </summary>
        /// <param name="property"> Objeto con la información de property </param>
        /// <returns></returns>
        Task CreateProperty(Property property);

        /// <summary>
        /// Método para obtener propiedad con id
        /// </summary>
        /// <param name="id"> Id property </param>
        /// <returns></returns>
        Task<Property> GetProperty(int id);
        Task<bool> UpdateProperty(Property property);
        Task<bool> DeleteProperty(Property property);
    }
}
