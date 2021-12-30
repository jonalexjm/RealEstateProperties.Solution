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

        public PropertyController(IPropertyService propertyService,
                               IMapper mapper)
        {
            _propertyService = propertyService;
            _mapper = mapper;
        }

        [HttpGet("GetAllProperties")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<PropertyDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<List<PropertyDto>>))]
        //[FromQuery] sirve para decirle que los filters vienen por query string
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

        [HttpPost("CreateProperty")]
        public async Task<IActionResult> CreateProperty(PropertyDto propertyDto)
        {
            var property = _mapper.Map<Property>(propertyDto);
            await _propertyService.CreateProperty(property);

            return Ok(propertyDto);
        }

    }
}
