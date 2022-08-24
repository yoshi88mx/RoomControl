using AutoMapper;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Shared.Mapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>();
            CreateMap<RequestUpdateRoomDto, Room>();
            CreateMap<RequestAddRoomDto, Room>();
            CreateMap<Room, RoomAvailableByQueueDto>();
        }
    }
}