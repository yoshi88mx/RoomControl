using System;
using System.Collections.Generic;
using System.Text;

namespace RoomControl.Data.Model
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public int IdRoomType { get; set; }
        public RoomType RoomType { get; set; }

        public int IdRoomState { get; set; }
        public RoomState RoomState { get; set; }

        public int IdQueue { get; set; }
        public Queue Queue { get; set; }

        public int IdRoomPrice { get; set; }
        public RoomPrice RoomPrice { get; set; }

        public List<RoomHistory> RoomMovements { get; set; }

        public List<QueueStack> QueueStacks { get; set; }
    }
}
