using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RoomControl.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Shared.Controllers
{
    [ApiController]
    [Route("api/v1/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IServiceRooms serviceRooms;
        private readonly IMapper mapper;
        private readonly ILogger<RoomsController> looger;

        public RoomsController(IServiceRooms serviceRooms,
                               IMapper mapper,
                               ILogger<RoomsController> looger)
        {
            this.serviceRooms = serviceRooms ?? throw new System.ArgumentNullException(nameof(serviceRooms));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            this.looger = looger ?? throw new System.ArgumentNullException(nameof(looger));
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomDto>>> GetAll()
        {
            looger.LogInformation(nameof(GetAll));
            return Ok(mapper.Map<List<RoomDto>>(await serviceRooms.GetAllAsync()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RoomDto>> GetById(int id)
        {
            looger.LogInformation(nameof(GetById));
            if (await serviceRooms.ExistByIdAsync(id))
            {
                var entity = await serviceRooms.GetByIdAsync(id);
                var result = mapper.Map<RoomDto>(entity);
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> Add([FromBody] RequestAddRoomDto dto)
        {
            looger.LogInformation(nameof(Add));
            var entity = mapper.Map<Room>(dto);
            var result = await serviceRooms.AddAsync(entity);
            return Ok(mapper.Map<RoomDto>(result));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<RoomDto>> Update(int id, [FromBody] RequestUpdateRoomDto dto)
        {
            looger.LogInformation(nameof(Update));
            if (await serviceRooms.ExistByIdAsync(id))
            {
                var entity = mapper.Map<Room>(dto);
                entity.Id = id;
                var result = await serviceRooms.UpdateAsync(entity);
                return Ok(mapper.Map<RoomDto>(result));
            }
            return NotFound();
        }

        [HttpGet]
        [Route("nextState/{idRoom}")]
        public async Task<ActionResult<RoomDto>> GoToNextState(string idRoom)
        {
            looger.LogInformation(nameof(GoToNextState));
            return(mapper.Map<RoomDto>(await serviceRooms.NextState(idRoom)));
        }
    }
}