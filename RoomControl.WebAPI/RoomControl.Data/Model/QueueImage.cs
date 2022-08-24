using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Data.Model
{
    public class QueueImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public int IdQueue { get; set; }
        public Queue Queue { get; set; }
    }
}
