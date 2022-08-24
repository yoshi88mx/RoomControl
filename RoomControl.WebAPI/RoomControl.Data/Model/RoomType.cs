using System;
using System.Collections.Generic;
using System.Text;

namespace RoomControl.Data.Model
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
