using AutoMapper;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Shared.Mapper
{
    public class DisplayHistorieProfile:Profile
    {
        public DisplayHistorieProfile()
        {
            CreateMap<DisplayHistory, RoomAvailableByQueueDto>();
            CreateMap<RequestAddDisplayHistoryDto,DisplayHistory>();
            CreateMap<DisplayHistory, DisplayHistoryDto>();
        }
    }
}
