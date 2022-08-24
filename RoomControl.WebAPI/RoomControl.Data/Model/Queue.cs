using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomControl.Data.Model
{
    public class Queue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int MinutesSpentOnCleanUp { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<QueueImage> Images { get; set; }

        public int IdQueueStack { get; set; }
        public QueueStack QueueStack { get; set; }

        public List<DisplayHistory> DisplayHistoryes { get; set; }

    }
}
