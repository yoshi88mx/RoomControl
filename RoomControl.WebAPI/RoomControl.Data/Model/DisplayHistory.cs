using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Data.Model
{
    public class DisplayHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string Number { get; set; } = "";

        public Queue Queue { get; set; }
        public int IdQueue { get; set; }

    }
}
