using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MmaApi.Models
{
    public class FightRecord
    {
        [Key]
        public int Id { get; set; }

        public int FighterId { get; set; }
        public int OpponentId { get; set; }

        public string EventName { get; set; } = "";
        public string Result { get; set; } = "";
        public string Date { get; set; } = "";


        [ForeignKey("FighterId")]
        public Fighter? Fighter { get; set; }

        [ForeignKey("OpponentId")]
        public Fighter? Opponent { get; set; }
    }
}
