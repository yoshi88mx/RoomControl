namespace RoomControl.Shared.Dtos
{
    public class RoomAvailableByQueueDto
    {
        public bool IsAvailable { get; set; }
        public string Description { get; set; } = "";
        public string Number { get; set; } = "";
    }
}
