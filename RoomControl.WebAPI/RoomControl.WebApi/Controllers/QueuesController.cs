using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoomControl.Core.Contracts;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomControl.Shared.Controllers
{
    [ApiController]
    [Route("api/v1/queues")]
    public class QueuesController : ControllerBase
    {
        private readonly IServiceQueues ServiceQueues;
        private readonly IMapper Mapper;
        private readonly ILogger<QueuesController> _logger;
        private readonly IServiceRoomsPrices _serviceRoomsPrices;
        private readonly IServiceConfiguration _serviceConfiguration;
        private readonly IServiceDisplayHistorye _serviceDisplay;

        public QueuesController(IServiceQueues serviceQueues,
                                IMapper mapper,
                                ILogger<QueuesController> logger,
                                IServiceRoomsPrices serviceRoomsPrices,
                                IServiceConfiguration serviceConfiguration,
                                IServiceDisplayHistorye serviceDisplay)
        {
            Mapper = mapper;
            ServiceQueues = serviceQueues;
            _logger = logger;
            _serviceRoomsPrices = serviceRoomsPrices ?? throw new System.ArgumentNullException(nameof(serviceRoomsPrices));
            _serviceConfiguration = serviceConfiguration;
            _serviceDisplay = serviceDisplay;
        }

        [HttpGet]
        public async Task<ActionResult<List<QueueDto>>> GetAll()
        {
            _logger.LogInformation(nameof(GetAll));
            var result = Mapper.Map<List<QueueDto>>(await ServiceQueues.GetAllAsync());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<QueueDto>> GetById(int id)
        {
            _logger.LogInformation(nameof(GetById));
            if (await ServiceQueues.ExistByIdAsync(id))
            {
                var result = Mapper.Map<QueueDto>(await ServiceQueues.GetByIdAsync(id));
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<QueueDto>> Add([FromBody] RequestAddQueueDto dto)
        {
            _logger.LogInformation(nameof(Add));
            var entity = Mapper.Map<Queue>(dto);
            var result = await ServiceQueues.AddAsync(entity);
            return Ok(Mapper.Map<QueueDto>(result));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<QueueDto>> Update([FromBody] RequestUpdateQueueDto dto, int id)
        {
            _logger.LogInformation($"{nameof(Update)}");
            var entity = Mapper.Map<Queue>(dto);
            entity.Id = id;

            if (await ServiceQueues.ExistByIdAsync(id))
            {
                var result = await ServiceQueues.UpdateAsync(entity);
                return Ok(Mapper.Map<QueueDto>(result));
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id}/roomAvailable")]
        public async Task<ActionResult<RoomAvailableByQueueDto>> GetRoomAvailableByQueueId(int id)
        {
            _logger.LogInformation(nameof(GetRoomAvailableByQueueId));
            return Ok(await ServiceQueues.GetRoomAvailable(id));
        }
    }
}