namespace BullsAndCows.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PlayerGuessModel
    {
        public int Id { get; set; }

        [StringLength(4)]
        public string Number { get; set; }
    }
}