using System.Collections.Generic;

namespace RoomControl.Shared.Dtos
{
    public class QueueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int MinutesSpentOnCleanUp { get; set; }
        public List<QueueImageDto> Images { get; set; } = new List<QueueImageDto>();
    }
}