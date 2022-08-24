using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Data.Model
{
    public class QueueStack
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int IdRoom { get; set; }
        public Room Room { get; set; }

        public int IdRoomState { get; set; }
        public RoomState RoomState { get; set; }

        public int IdQueue { get; set; }
        public Queue Queue { get; set; }
    }
}
