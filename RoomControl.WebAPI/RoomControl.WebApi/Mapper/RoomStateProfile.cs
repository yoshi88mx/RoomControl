using AutoMapper;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Shared.Mapper
{
    public class RoomStateProfile:Profile
    {
        public RoomStateProfile()
        {
            CreateMap<RoomState, RoomStateDto>();
        }
    }
}
