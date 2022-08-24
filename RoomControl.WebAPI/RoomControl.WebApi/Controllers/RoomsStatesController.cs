using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoomControl.Core.Contracts;
using RoomControl.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomControl.Shared.Controllers
{
    [ApiController]
    [Route("api/v1/roomstates")]
    public class RoomsStatesController: ControllerBase
    {
        private readonly ILogger<RoomsStatesController> logger;
        private readonly IServiceRoomsStates serviceRoomsStates;
        private readonly IMapper mapper;

        public RoomsStatesController(ILogger<RoomsStatesController> logger, IServiceRoomsStates serviceRoomsStates, IMapper mapper)
        {
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            this.serviceRoomsStates = serviceRoomsStates ?? throw new System.ArgumentNullException(nameof(serviceRoomsStates));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<RoomStateDto>> GetAll()
        {
            logger.LogInformation(nameof(GetAll));
            return Ok(mapper.Map<List<RoomStateDto>>(await serviceRoomsStates.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomStateDto>> GetById(int id)
        {
            logger.LogInformation(nameof(GetById));
            if (await serviceRoomsStates.ExistByIdAsync(id))
            {
                return Ok(mapper.Map<RoomStateDto>(await serviceRoomsStates.GetByIdAsync(id)));
            }
            return NotFound();
            
        }
    }
}
