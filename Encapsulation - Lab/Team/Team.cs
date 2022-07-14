namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Team
    {
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        private string name;
        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get
            {
                return this.reserveTeam;
            }
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get
            {
                return this.firstTeam;
            }
        }
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

    }
}
