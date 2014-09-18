namespace BullsAndCows.Services.Models
{
    using System;

    using BullsAndCows.Models;

    public class GameInfoModel
    {
        public Guid Id { get; set; }

        public string FirstPlayerName { get; set; }

        public string SecondPlayerName { get; set; }

        public Status GameStatus { get; set; }
    }
}