using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoomControl.Core.Contracts;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/queues")]
    public class QueuesController : ControllerBase
    {
        private readonly IServiceQueues _serviceQueues;
        private readonly IMapper _mapper;
        private readonly ILogger<QueuesController> _logger;
        
        public QueuesController(IServiceQueues serviceQueues,
                                IMapper mapper,
                                ILogger<QueuesController> logger)
        {
            _mapper = mapper;
            _serviceQueues = serviceQueues;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<QueueDto>>> GetAll()
        {
            _logger.LogInformation(nameof(GetAll));
            var result = _mapper.Map<List<QueueDto>>(await _serviceQueues.GetAllAsync());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<QueueDto>> GetById(int id)
        {
            _logger.LogInformation(nameof(GetById));
            if (await _serviceQueues.ExistByIdAsync(id))
            {
                var result = _mapper.Map<QueueDto>(await _serviceQueues.GetByIdAsync(id));
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<QueueDto>> Add([FromBody] RequestAddQueueDto dto)
        {
            _logger.LogInformation(nameof(Add));
            var entity = _mapper.Map<Queue>(dto);
            var result = await _serviceQueues.AddAsync(entity);
            return Ok(_mapper.Map<QueueDto>(result));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<QueueDto>> Update([FromBody] RequestUpdateQueueDto dto, int id)
        {
            _logger.LogInformation($"{nameof(Update)}");
            var entity = _mapper.Map<Queue>(dto);
            entity.Id = id;

            if (await _serviceQueues.ExistByIdAsync(id))
            {
                var result = await _serviceQueues.UpdateAsync(entity);
                return Ok(_mapper.Map<QueueDto>(result));
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id}/roomAvailable")]
        public async Task<ActionResult<RoomAvailableByQueueDto>> GetRoomAvailableByQueueId(int id)
        {
            _logger.LogInformation(nameof(GetRoomAvailableByQueueId));
            return Ok(await _serviceQueues.GetRoomAvailable(id));
        }
    }
}