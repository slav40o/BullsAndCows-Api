namespace BullsAndCows.Models
{
    using System;

    public class Game
    {
        public Game() : this("B&C") { }

        public Game(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Status = Status.WaitingPlayer;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public DateTime? Started { get; set; }

        public DateTime? Ended { get; set; }

        public string Password { get; set; }

        public string FirstPlayerId { get; set; }

        public virtual Player FirstPlayer { get; set; }

        public string SecondPlayerId { get; set; }

        public virtual Player SecondPlayer { get; set; }
    }
}
