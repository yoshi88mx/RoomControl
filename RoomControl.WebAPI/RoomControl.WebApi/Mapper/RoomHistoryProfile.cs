using AutoMapper;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Shared.Mapper
{
    public class RoomHistoryProfile:Profile
    {
        public RoomHistoryProfile()
        {
            CreateMap<RoomHistory, RoomHistoryDto>();
        }
    }
}
