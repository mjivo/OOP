namespace Football_Team_Generator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using IO.Contracts;
    using Core.Contracts;
    using System.Drawing;
    using System.Reflection;

    public class Engine : IEngine
    {
        private IReader _reader;
        private IWriter _writer;
        private List<FootballTeam> teams;
        private List<string> stats;

        private string _currentTeamName;
        public Engine(IReader reader, IWriter writer)
        {
            this._reader = reader;
            this._writer = writer;
            this.teams = new List<FootballTeam>();

            this.stats = new List<string>()
            {
            "Endurance",
            "Sprint",
            "Dribble",
            "Passing",
            "Shooting"
            };
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "end")
                        break;
                    string[] args = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    this._currentTeamName = args[1];
                    switch (args[0].ToLower())
                    {
                        case "team"://Should crate a team
                            if (IsAntherTeamWithThatName)
                            {
                                this._writer.WriteLine("There is alrady a team with that name.");
                                continue;
                            }
                            this.teams.Add(new FootballTeam(this._currentTeamName));
                            break;
                        case "add"://Should add players if team exists and values are correct
                            if (!IsAntherTeamWithThatName)
                            {
                                this._writer.WriteLine($"Team {this._currentTeamName} does not exist.");
                                continue;
                            }
                            string playerName = args[2];
                            string[] statsArgs = args.TakeLast(5).ToArray();
                            Stats currentStats = ValidateStats(statsArgs);
                            if (currentStats == null)
                                continue;
                            Player player = new Player(playerName, currentStats);
                            this.teams.First(t => t.Name == this._currentTeamName).Add(player);
                            break;
                        case "remove":
                            if (!IsAntherTeamWithThatName)
                            {
                                this._writer.WriteLine($"Team {this._currentTeamName} does not exist.");
                                continue;
                            }
                            if (!this.teams.First(t => t.Name == this._currentTeamName).Remove(args[2]))//args[2] == playerName
                            {
                                this._writer.WriteLine($"Player {args[2]} is not in {this._currentTeamName} team.");
                            }
                            break;
                        case "rating":
                            if (!IsAntherTeamWithThatName)
                            {
                                this._writer.WriteLine($"Team{this._currentTeamName} does not exist.");
                                continue;
                            }
                            this._writer.WriteLine($"{this._currentTeamName} - {this.teams.First(t => t.Name == this._currentTeamName).Rating}");
                            break;
                        default:
                            Console.WriteLine($"Not such a command {input}");
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    this._writer.WriteLine("A name should not be empty.");
                }
                catch (Exception e)
                {
                    this._writer.WriteLine(e.Message);
                }
            }
        }
        private Stats ValidateStats(string[] statsArgs)
        {
            if (!AreStatsValid(statsArgs))
            {
                return null;
            }
            int stats1 = int.Parse(statsArgs[0]);
            int stats2 = int.Parse(statsArgs[1]);
            int stats3 = int.Parse(statsArgs[2]);
            int stats4 = int.Parse(statsArgs[3]);
            int stats5 = int.Parse(statsArgs[4]);
            return new Stats(stats1, stats2, stats3, stats4, stats5);

            bool AreStatsValid(string[] statsArgs)
            {
                for (int i = 0; i < statsArgs.Length; i++)
                {
                    int stat = int.Parse(statsArgs[i]);
                    if (stat < 0 || stat > 100)
                    {
                        this._writer.WriteLine($"{this.stats[i]} should be between 0 and 100.");
                        return false;
                    }
                }
                return true;
            }
        }
        private bool IsAntherTeamWithThatName => this.teams.Any(t => t.Name == this._currentTeamName);
    }
}
