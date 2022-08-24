using System;
using System.Collections.Generic;
using System.Text;

namespace RoomControl.Data.Model
{
    public class RoomHistory
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int IdRoom { get; set; }
        public Room Room { get; set; }

        public int IdRoomState { get; set; }
        public RoomState RoomState { get; set; }
    }
}
