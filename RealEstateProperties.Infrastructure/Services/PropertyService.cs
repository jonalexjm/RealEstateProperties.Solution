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
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Método para crear registro Property
        /// </summary>
        /// <param name="property"> Objeto property para crear </param>
        /// <returns> </returns>
        public async Task CreateProperty(Property property)
        {
            await _unitOfWork.PropertyRepository.Add(property);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Método para consultar todos los registros de PropertyImage con paginación
        /// </summary>
        /// <param name="filters"> Objeto para el filtro </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        public async Task<PagedList<Property>> GetAllProperty(PropertyQueryFilter filters)
        {
            var properties = this._unitOfWork.PropertyRepository.GetAll().ToList();

            if (filters.IdProperty != null)
            {
                properties = properties.Where(x => x.IdProperty == filters.IdProperty).ToList();
            }

            var pagedProperties = PagedList<Property>.Create(properties, filters.PageNumber, filters.PageSize);

            return pagedProperties;
        }

        public Task<Property> GetProperty(int id)
        {
            return _unitOfWork.PropertyRepository.GetById(id);
        }

        /// <summary>
        /// Método para consultar todos los registros de PropertyImage con paginación
        /// </summary>
        /// <param name="property"> Objeto property para actualizar </param>
        /// <returns> Retorna resutlado de operacion true o false</returns>
        public async Task<bool> UpdateProperty(Property property)
        {
            var propertyResult = await _unitOfWork.PropertyRepository.GetById(property.IdProperty);
            if (propertyResult != null)
            {
                propertyResult.Name = property.Name;
                propertyResult.Address = property.Address;
                propertyResult.Price = property.Price;
                propertyResult.CodeInternal = property.CodeInternal;
                propertyResult.Year = property.Year;        
                var updateHotel = await _unitOfWork.PropertyRepository.UpdateAsync(propertyResult);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Método para eliminar Property
        /// </summary>
        /// <param name="property"> Objeto property a eliminar </param>
        /// <returns> Retorna resutlado de operacion true</returns>
        public async Task<bool> DeleteProperty(Property property)
        {
            await _unitOfWork.PropertyRepository.DeleteAsync(property);

            return true;
        }
    }
}
