using AutoMapper;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Shared.Mapper
{
    public class RoomPriceProfile : Profile
    {
        public RoomPriceProfile()
        {
            CreateMap<RoomPrice, RoomPriceDto>();
            CreateMap<RequestUpdateRoomPriceDto, RoomPrice>();
            CreateMap<RequestAddRoomPriceDTO, RoomPrice>();

        }
    }
}
