using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomControl.Data.Model.NotMapped
{
    [NotMapped]
    public class RoomByQueue
    {
        [Key]
        public int IdRoom { get; set; }
        public string RoomDescription { get; set; }
        public int RoomNumber { get; set; }
        public string RoomState { get; set; }

        public override string ToString()
        {
            return $"{RoomDescription} {RoomNumber}";
        }
    }
}
