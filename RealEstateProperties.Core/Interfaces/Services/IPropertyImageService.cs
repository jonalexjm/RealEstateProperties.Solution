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
    public interface IPropertyImageService
    {
        /// <summary>
        /// Método para consultar todos los registros de PropertyImage con paginación
        /// </summary>
        /// <param name="OwnerQueryFilter"> Objeto para el filtro </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        Task<PagedList<PropertyImage>> GetAllPropertyImage(PropertyImageQueryFilter filters);

        /// <summary>
        /// Método para crear PropertyImage
        /// </summary>
        /// <param name="propertyImage"> Objeto con la información de propertyImage </param>
        /// <returns></returns>
        Task CreatePropertyImage(PropertyImage propertyImage);
    }
}
