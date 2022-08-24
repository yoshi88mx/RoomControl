using RoomControl.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using RoomControl.Shared.Dtos;
using RoomControl.Data.Model;

namespace RoomControl.Shared.Controllers
{
    [ApiController]
    [Route("api/v1/roomsprices")]
    public class RoomsPricesController : ControllerBase
    {
        private readonly IServiceRoomsPrices serviceRoomsPrices;
        private readonly ILogger<RoomsPricesController> logger;
        private readonly IMapper mapper;

        public RoomsPricesController(IServiceRoomsPrices serviceRoomsPrices, ILogger<RoomsPricesController> logger, IMapper mapper)
        {
            this.serviceRoomsPrices = serviceRoomsPrices ?? throw new System.ArgumentNullException(nameof(serviceRoomsPrices));
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomPriceDto>>> GetAll()
        {
            logger.LogInformation(nameof(GetAll));
            var result = mapper.Map<List<RoomPriceDto>>(await serviceRoomsPrices.GetAllAsync());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RoomPriceDto>> AddRoomPrice([FromBody] RequestAddRoomPriceDTO roomPrice)
        {
            logger.LogInformation(nameof(AddRoomPrice));
            var dto = mapper.Map<RoomPrice>(roomPrice);
            var result = await serviceRoomsPrices.AddAsync(dto);
            return Ok(mapper.Map<RoomPriceDto>(result));
        }

        [HttpGet]
        [Route(("{id}"))]
        public async Task<ActionResult<RoomPriceDto>> GetRoomPriceByID(int id)
        {
            logger.LogInformation(nameof(GetRoomPriceByID));
            if (await serviceRoomsPrices.ExistByIdAsync(id))
            {
                var result = mapper.Map<RoomPriceDto>(await serviceRoomsPrices.GetByIdAsync(id));
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPut]
        [Route(("{id}"))]
        public async Task<ActionResult<RoomPriceDto>> UpdateRoomPrice(int id,[FromBody] RequestUpdateRoomPriceDto dto)
        {
            logger.LogInformation(nameof(UpdateRoomPrice));
            if (await serviceRoomsPrices.ExistByIdAsync(id))
            {
                var entity = mapper.Map<RoomPrice>(dto);
                entity.Id = id;
                var result = await serviceRoomsPrices.UpdateAsync(entity);
                return Ok(result);
            }
            return NoContent();
        }
    }
}
