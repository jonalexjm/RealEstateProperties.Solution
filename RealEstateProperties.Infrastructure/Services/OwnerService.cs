using RealEstateProperties.Core.CustomEntities;
using RealEstateProperties.Core.Entitites;
using RealEstateProperties.Core.Interfaces;
using RealEstateProperties.Core.Interfaces.Services;
using RealEstateProperties.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Infrastructure.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OwnerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Método para crear Owner
        /// </summary>
        /// <param name="owner"> Objeto con la información de owner </param>
        /// <returns></returns>
        public async Task CreateOwner(Owner owner)
        {
            await _unitOfWork.OwnerRepository.Add(owner);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Método para consultar todos los registros de Owner con paginación
        /// </summary>
        /// <param name="OwnerQueryFilter"> Objeto para el filtro </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        public async Task<PagedList<Owner>> GetAllOwner(OwnerQueryFilter filters)
        {
            var owners = this._unitOfWork.OwnerRepository.GetAll().ToList();

            if (filters.IdOwner != null)
            {
                owners = owners.Where(x => x.IdOwner == filters.IdOwner).ToList();
            }

            var pagedOwners = PagedList<Owner>.Create(owners, filters.PageNumber, filters.PageSize);

            return pagedOwners;
        }
    }
}
