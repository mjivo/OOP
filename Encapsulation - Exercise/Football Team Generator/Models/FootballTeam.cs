namespace Football_Team_Generator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FootballTeam
    {
        private string _name;
        private List<Player> _players;
        private FootballTeam()
        {
            this._players = new List<Player>();
        }
        public FootballTeam(string name) : this()
        {
            this.Name = name;
        }
        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A name should not be empty.");
                this._name = value;
            }
        }
        public int Rating => this.GetRating();
        public bool Remove(string name) => this._players.Remove(this._players.FirstOrDefault(p => p.Name == name));
        public void Add(Player player) => this._players.Add(player);
        private int GetRating()
        {
            int rating = 0;
            foreach (Player player in this._players)
            {
                rating += player.GetStatsScore;
            }
            return rating;
        }
    }
}
