using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateProperties.Api.Responses;
using RealEstateProperties.Core.DTOs;
using RealEstateProperties.Core.Entitites;
using RealEstateProperties.Core.Interfaces.Services;
using RealEstateProperties.Core.QueryFilters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RealEstateProperties.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;

        #region Constructor
        public PropertyController(IPropertyService propertyService,
                               IMapper mapper)
        {
            _propertyService = propertyService;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Método para obtener la información todas las propiedades
        /// </summary>
        /// <param name="filters"> Filtros para paginación y busqueda por parametros</param>
        /// <returns>Todas las Properties de acuerdo a los filtros y parametros</returns>      
        [HttpGet("GetAllProperties")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<PropertyDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<List<PropertyDto>>))]
        public async Task<IActionResult> GetAllProperties([FromQuery] PropertyQueryFilter filters)
        {            
            var properties = await _propertyService.GetAllProperty(filters);
            var propertiesDto = _mapper.Map<IEnumerable<PropertyDto>>(properties);
            var response = new ApiResponse<IEnumerable<PropertyDto>>(propertiesDto);
            var metadata = new
            {
                properties.TotalCount,
                properties.PageSize,
                properties.CurrentPage,
                properties.TotalPages,
                properties.HasNextPage,
                properties.HasPreviousPage
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        /// <summary>
        /// Método para obtener la información todas las propiedades
        /// </summary>
        /// <param name="propertyDto"> Objeto Property para crear nuevo registro</param>
        /// <returns>Objeto Property creado</returns>
        [HttpPost("CreateProperty")]
        public async Task<IActionResult> CreateProperty(PropertyDto propertyDto)
        {
            var property = _mapper.Map<Property>(propertyDto);
            await _propertyService.CreateProperty(property);

            return Ok(propertyDto);
        }

        /// <summary>
        /// Método para actualizar propiedad
        /// </summary>
        /// <param name="id"> Id de property para actualizar</param>
        /// <param name="propertyDto"> Objeto Property para actualizar</param>
        /// <returns>Boolean para saber si se actualizo</returns>
        [HttpPut("UpdateProperty")]
        public async Task<IActionResult> UpdateProperty(int id, PropertyDto propertyDto)
        {
            var property = _mapper.Map<Property>(propertyDto);
            property.IdProperty = id;
            var result = await _propertyService.UpdateProperty(property);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Método para actualizar precio de propiedad
        /// </summary>
        /// <param name="id"> Id de property para actualizar</param>
        /// <param name="price"> Nuevo precio</param>
        /// <returns>Boolean para saber si se actualizo</returns>
        [HttpPut("UpdatePriceProperty")]
        public async Task<IActionResult> UpdateProperty(int id, decimal price)
        {            
            var result = await _propertyService.UpdatePrice(id, price);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        #endregion

    }
}
