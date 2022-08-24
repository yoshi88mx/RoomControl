using System.Collections.Generic;

namespace RoomControl.Shared.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int IdRoomType { get; set; }
        public int IdRoomState { get; set; }
        public int IdQueue { get; set; }
        public int IdRoomPrice { get; set; }
    }
}