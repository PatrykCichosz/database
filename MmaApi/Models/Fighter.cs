using System.ComponentModel.DataAnnotations;

namespace MmaApi.Models
{
    public class Fighter
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";
        public string WeightClass { get; set; } = "";
        public string Nationality { get; set; } = "";

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }

        public string FighterImage { get; set; } = "";
    }
}
