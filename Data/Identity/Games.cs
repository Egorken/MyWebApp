using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApp.Data.Identity
{
    [Table("Games", Schema = "data")]
    public class Games
    {
        public int Id { get; set; }
        
        public string NameOfTheGame { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; } //количество в наличии

        public bool Avalible { get; set; }


    }
}
