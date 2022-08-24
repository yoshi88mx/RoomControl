namespace RoomControl.Shared.Dtos
{
    public class RequestUpdateQueueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int MinutesSpentOnCleanUp { get; set; }
    }
}