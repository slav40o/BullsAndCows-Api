namespace BullsAndCows.Models
{
    using System;

    public class Game
    {
        public Game(string name)
        {
            this.Name = name;
            this.Status = Status.WaitingPlayer;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public DateTime? Started { get; set; }

        public DateTime? Ended { get; set; }

        public int? Password { get; set; }

        public int FirstPlayerId { get; set; }

        public virtual Player FirstPlayer { get; set; }

        public int SecondPlayerId { get; set; }

        public virtual Player SecondPlayer { get; set; }
    }
}
