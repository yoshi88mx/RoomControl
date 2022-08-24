using System;
using System.Collections.Generic;
using System.Text;

namespace RoomControl.Data.Model
{
    public class RoomState
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string Color { get; set; }

        public List<Room> Rooms { get; set; }
        public List<RoomHistory> RoomMovements { get; set; }
        public List<QueueStack> QueueStacks { get; set; }
    }
}
