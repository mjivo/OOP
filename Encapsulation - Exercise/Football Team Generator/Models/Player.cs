namespace Football_Team_Generator.Models
{
    using System;
    public class Player
    {
        private string _name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A name should not be empty.");
                this._name = value;
            }
        }
        public Stats Stats { get; set; }

        public int GetStatsScore => Stats.GetAvarage();
    }
}
