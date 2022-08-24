using AutoMapper;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Shared.Mapper
{
    public class QueueImageProfile:Profile
    {
        public QueueImageProfile()
        {
            CreateMap<QueueImage, QueueImageDto>();
        }
    }
}
