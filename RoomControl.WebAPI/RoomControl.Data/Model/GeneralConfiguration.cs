using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Data.Model
{
    public class GeneralConfiguration
    {
        public int Id { get; set; }
        public int IdRoomStateOnQueue { get; set; }
        public bool IsAutomaticAssignationOnDisplay { get; set; }
    }
}
