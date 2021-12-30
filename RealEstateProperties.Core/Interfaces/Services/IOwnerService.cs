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
    public interface IOwnerService
    {
        /// <summary>
        /// Método para consultar todos los registros de Owner con paginación
        /// </summary>
        /// <param name="OwnerQueryFilter"> Objeto para el filtro </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        Task<PagedList<Owner>> GetAllOwner(OwnerQueryFilter filters);

        /// <summary>
        /// Método para crear Owner
        /// </summary>
        /// <param name="owner"> Objeto con la información de owner </param>
        /// <returns></returns>
        Task CreateOwner(Owner owner);
    }
}
