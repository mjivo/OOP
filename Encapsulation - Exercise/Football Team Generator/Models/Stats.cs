namespace Football_Team_Generator
{
    using System;
    public class Stats
    {
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance { get; private set; }
        public int Sprint { get; private set; }
        public int Dribble { get; private set; }
        public int Passing { get; private set; }
        public int Shooting { get; private set; }

        public int GetAvarage() => (int)Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.00, 0);
    }
}