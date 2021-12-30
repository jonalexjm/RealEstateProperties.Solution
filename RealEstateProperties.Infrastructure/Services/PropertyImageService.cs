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
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Método para crear PropertyImage
        /// </summary>
        /// <param name="propertyImage"> Objeto con la información de propertyImage </param>
        /// <returns></returns>
        public async Task CreatePropertyImage(PropertyImage propertyImage)
        {
            await _unitOfWork.PropertyImageRepository.Add(propertyImage);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Método para consultar todos los registros de PropertyImage con paginación
        /// </summary>
        /// <param name="PropertyImageQueryFilter"> Objeto para el filtro </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        public async Task<PagedList<PropertyImage>> GetAllPropertyImage(PropertyImageQueryFilter filters)
        {
            var propertyImages = this._unitOfWork.PropertyImageRepository.GetAll().ToList();

            if (filters.IdPropertyImage != null)
            {
                propertyImages = propertyImages.Where(x => x.IdPropertyImage == filters.IdPropertyImage).ToList();
            }

            var pagedPropertyImage = PagedList<PropertyImage>.Create(propertyImages, filters.PageNumber, filters.PageSize);

            return pagedPropertyImage;
        }

    }
}
