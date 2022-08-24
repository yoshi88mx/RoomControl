namespace RoomControl.Shared.Dtos
{
    public class RequestAddDisplayHistoryDto
    {
        public bool IsAvailable { get; set; }
        public int Number { get; set; }
        public int IdQueue { get; set; }
        public int IdRoomPrice { get; set; }
    }
}
