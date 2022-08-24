using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomControl.Core.Contracts;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;
using System.Threading.Tasks;

namespace RoomControl.Shared.Controllers
{
    [ApiController]
    [Route("api/v1/displayhistory")]
    public class DisplayHistoryController: ControllerBase
    {
        private readonly IServiceDisplayHistorye _serviceDisplay;
        private readonly IMapper _mapper;

        public DisplayHistoryController(IServiceDisplayHistorye serviceDisplay, IMapper mapper)
        {
            _serviceDisplay = serviceDisplay;
            _mapper = mapper;
        }

        
        [HttpPost]
        public async Task<ActionResult> AddDisplayHistory([FromBody] RequestAddDisplayHistoryDto dto)
        {
            var entity = _mapper.Map<DisplayHistory>(dto);
            await _serviceDisplay.AddAsync(entity, dto.IdRoomPrice, dto.IdQueue);
            return Ok();
        }
    }
}
