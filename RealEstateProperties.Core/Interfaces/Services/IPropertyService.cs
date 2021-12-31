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
        /// <summary>
        /// Método para consultar todos los registros de PropertyImage con paginación
        /// </summary>
        /// <param name="property"> Objeto property para actualizar </param>
        /// <returns> Retorna resutlado de operacion true o false</returns>
        Task<bool> UpdateProperty(Property property);
        /// <summary>
        /// Método para eliminar Property
        /// </summary>
        /// <param name="property"> Objeto property a eliminar </param>
        /// <returns> Retorna resutlado de operacion true</returns>
        Task<bool> DeleteProperty(Property property);
        /// <summary>
        /// Método cambiar de precio una property
        /// </summary>
        /// <param name="idProperty"> Id Property </param>
        /// <param name="price"> Nuevo precio property </param>
        /// <returns> Retorna resutlado de operacion</returns>
        Task<bool> UpdatePrice(int idProperty, decimal price);

    }
}
