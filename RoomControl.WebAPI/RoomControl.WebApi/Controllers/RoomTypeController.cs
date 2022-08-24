using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RoomControl.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoomControl.Shared.Dtos;

namespace RoomControl.Shared.Controllers
{
    [ApiController]
    [Route("api/v1/roomstypes")]
    public class RoomsTypesController : ControllerBase
    {
        private readonly IServiceRoomsTypes serviceRoomTypes;
        private readonly ILogger<RoomsTypesController> logger;
        private readonly IMapper mapper;

        public RoomsTypesController(IServiceRoomsTypes serviceRoomTypes,
                                  ILogger<RoomsTypesController> logger,
                                  IMapper mapper)
        {
            this.serviceRoomTypes = serviceRoomTypes ?? throw new System.ArgumentNullException(nameof(serviceRoomTypes));
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomTypeDto>>> GetAll()
        {
            logger.LogInformation(nameof(GetAll));
            var result = await serviceRoomTypes.GetAllAsync();
            return Ok(mapper.Map<List<RoomTypeDto>>(result));
        }
    }
}