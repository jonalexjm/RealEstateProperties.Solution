using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class PropertyImageController : ControllerBase
    {
        private readonly IPropertyImageService _propertyImageService;
        private readonly IMapper _mapper;

        public PropertyImageController(IPropertyImageService propertyImageService,
                               IMapper mapper)
        {
            _propertyImageService = propertyImageService;
            _mapper = mapper;
        }

        #region Methods
        /// <summary>
        /// Método para consultar la información del PropertyImage
        /// </summary>
        /// <param name="PropertyImageQueryFilter"> Objeto para el filtro </param>
        /// <returns> Resultado de la petición </returns>
        [HttpGet("GetAllpropertyImages")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<PropertyImageDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<List<PropertyImageDto>>))]
        public async Task<IActionResult> GetAllPropertyImage([FromQuery] PropertyImageQueryFilter filters)
        {            
            var propertyImages = await _propertyImageService.GetAllPropertyImage(filters);
            var propertyImagesDto = _mapper.Map<IEnumerable<PropertyImageDto>>(propertyImages);
            var response = new ApiResponse<IEnumerable<PropertyImageDto>>(propertyImagesDto);
            var metadata = new
            {
                propertyImages.TotalCount,
                propertyImages.PageSize,
                propertyImages.CurrentPage,
                propertyImages.TotalPages,
                propertyImages.HasNextPage,
                propertyImages.HasPreviousPage
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        /// <summary>
        /// Método para crear PropertyImage
        /// </summary>
        /// <param name="propertyImageDto"> Objeto PropertyImage para crear nuevo registro</param>
        /// <returns>Objeto PropertyImage creado</returns>
        [HttpPost("CreatePropertyImage")]
        public async Task<IActionResult> CreatePropertyImage(PropertyImageDto propertyImageDto)
        {
            var propertyImage = _mapper.Map<PropertyImage>(propertyImageDto);            
            await _propertyImageService.CreatePropertyImage(propertyImage);

            return Ok(propertyImage);
        }
        #endregion
    }
}
