using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airBnB.models
{
    public class RoomBooking
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string room_name { get; set; }
        [StringLength(100)]
        public string room_desc { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public Nullable<decimal> price_per_night { get; set; }
        [StringLength(250)]
        public string image_desc{ get; set; }

        public byte[] image_data { get; set; }
    }
    }
