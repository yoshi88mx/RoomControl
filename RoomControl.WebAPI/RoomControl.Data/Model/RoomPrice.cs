using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Data.Model
{
    public class RoomPrice
    {
        public int Id { get; set; }
        public int ByHours { get; set; }
        public double Price { get; set; }

        public List<Room> Rooms { get; set; }

    }
}