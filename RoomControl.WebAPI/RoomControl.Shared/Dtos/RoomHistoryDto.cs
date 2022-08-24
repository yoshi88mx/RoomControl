using System;

namespace RoomControl.Shared.Dtos
{
    public class RoomHistoryDto
    {
        public string RoomId { get; set; }
        public string RoomNumber { get; set; }
        public DateTime Date { get; set; }
        public string RoomDescription { get; set; }
        public string RoomStateDescription { get; set; }
    }
}
