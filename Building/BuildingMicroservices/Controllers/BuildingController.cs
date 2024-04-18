using BuildingMicroservices.Application.DTOs;
using BuildingMicroservices.Application.Features.Buildings.Requests.Commands;
using BuildingMicroservices.Application.Features.Buildings.Requests.Queries;
using BuildingMicroservices.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace BuildingMicroservices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BuildingDTO>> GetById(int id)
        {
            return await _mediator.Send(new GetBuildingByIdRequest { Id = id });
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<BuildingDTO>>> GetAll()
        {
            return await _mediator.Send(new GetAllBuildingsRequest());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<BuildingDTO>> Update (int id,[FromBody] CreateBuildingDTO createBuildingDTO)
        {
            return await _mediator.Send(new UpdateBuildingCommand { BuildingDTO = createBuildingDTO, Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<BuildingDTO>> Create([FromBody] CreateBuildingDTO createBuildingDTO)
        {
            var building =  await _mediator.Send(new CreateBuildingCommand { Building = createBuildingDTO });
            return StatusCode(StatusCodes.Status201Created, building);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id )
        {
            return Ok(await _mediator.Send(new DeleteBuildingCommand { Id = id }));
        }

    }
}
