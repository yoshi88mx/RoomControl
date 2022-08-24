using System;

namespace RoomControl.Shared.Dtos
{
    public class DisplayHistoryDto
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string Number { get; set; } = "";
        public int IdQueue { get; set; }
    }
}
