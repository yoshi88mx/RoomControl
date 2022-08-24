using AutoMapper;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;

namespace RoomControl.Shared.Mapper
{
    public class QueueProfile : Profile
    {
        public QueueProfile()
        {
            CreateMap<Queue, QueueDto>();
            CreateMap<RequestAddQueueDto, Queue>();
            CreateMap<RequestUpdateQueueDto, Queue>();
        }
    }
}