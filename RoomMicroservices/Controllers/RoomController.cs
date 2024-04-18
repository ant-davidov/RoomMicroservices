using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomMicroservices.Application.DTOs.Rooms;
using RoomMicroservices.Application.Features.Rooms.Requests.Commands;
using RoomMicroservices.Application.Features.Rooms.Requests.Queries;

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
        [HttpGet("all")]
        public async Task<ActionResult<List<RoomDTO>>> GetAll()
        {
            return await _mediator.Send(new GetAllRoomsRequest());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<RoomDTO>> Update(int id, [FromBody] UpdateRoomDTO updateRoomDTO)
        {
            return await _mediator.Send(new UpdateRoomCommand {  RoomDTO = updateRoomDTO, Id = id });
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
    }
}
