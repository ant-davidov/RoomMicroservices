using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomMicroservices.Application.DTOs.Buildings;
using RoomMicroservices.Application.DTOs.Rooms;
using RoomMicroservices.Application.Features.Buildings.Requests.Queries;
using RoomMicroservices.Application.Features.Rooms.Requests.Commands;
using RoomMicroservices.Application.Features.Rooms.Requests.Queries;
using RoomMicroservices.Domain;

namespace RoomMicroservices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoomDTO>> GetById(int id)
        {
            return await _mediator.Send(new GetRoomByIdRequest { Id = id });
        }
        [HttpGet("Search")]
        public async Task<ActionResult<SearchRoomResponse>> Search(int? buildongId, int? floor, RoomType? roomType, int skip = 0, int size = 20)
        {
            return await _mediator.Send(new SearchRoomsRequest { SearchRoomDTO = new SearchRoomDTO { BuildongId = buildongId, Floor = floor, RoomType = roomType, Size = size, Skip = skip } });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<RoomDTO>> Update(int id, [FromBody] UpdateRoomDTO updateRoomDTO)
        {
            return await _mediator.Send(new UpdateRoomCommand { RoomDTO = updateRoomDTO, Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<RoomDTO>> Create([FromBody] CreateRoomDTO createBuildingDTO)
        {
            var building = await _mediator.Send(new CreateRoomCommand { CreateRoomDTO = createBuildingDTO });
            return StatusCode(StatusCodes.Status201Created, building);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteRoomCommand { Id = id }));
        }
        [HttpGet("building")]
        public async Task<ActionResult<List<BuildingDTO>>> GetAllBuilding()
        {
            return Ok(await _mediator.Send(new GetAllBuildingQuerie()));
        }
    }
}
