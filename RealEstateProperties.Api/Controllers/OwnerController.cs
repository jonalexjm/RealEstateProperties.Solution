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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerService ownerService,
                               IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        [HttpGet("GetAllOwners")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<OwnerDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<List<OwnerDto>>))]
        //[FromQuery] sirve para decirle que los filters vienen por query string
        public async Task<IActionResult> GetAllOwners([FromQuery] OwnerQueryFilter filters)
        {
            var owners = await _ownerService.GetAllOwner(filters);
            var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            var response = new ApiResponse<IEnumerable<OwnerDto>>(ownersDto);
            var metadata = new
            {
                owners.TotalCount,
                owners.PageSize,
                owners.CurrentPage,
                owners.TotalPages,
                owners.HasNextPage,
                owners.HasPreviousPage
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpPost("CreateOwner")]
        public async Task<IActionResult> CreateOwner(OwnerDto ownerDto)
        {
            var owner = _mapper.Map<Owner>(ownerDto);            
            await _ownerService.CreateOwner(owner);

            return Ok(ownerDto);
        }
    }
}
