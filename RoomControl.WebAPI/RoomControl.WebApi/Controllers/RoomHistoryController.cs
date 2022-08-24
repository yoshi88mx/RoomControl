using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoomControl.Core.Contracts;
using RoomControl.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomControl.Shared.Controllers
{
    [ApiController]
    [Route("api/v1/roomhistory")]
    public class RoomHistoryController:ControllerBase
    {
        private readonly IServiceRoomHistory _serviceRoomHistory;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomHistoryController> _logger;

        public RoomHistoryController(IServiceRoomHistory serviceRoomHistory, IMapper mapper, ILogger<RoomHistoryController> logger)
        {
            _serviceRoomHistory = serviceRoomHistory ?? throw new ArgumentNullException(nameof(serviceRoomHistory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomHistoryDto>>> GetByDate([FromQuery] DateTime date)
        {
            _logger.LogInformation(nameof(GetByDate));
            var result = await _serviceRoomHistory.GetByDate(date);
            return Ok(_mapper.Map<List<RoomHistoryDto>>(result));
        }
    }
}
