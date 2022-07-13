using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] rawCommand = command.Split(';');
                string typeCommand = rawCommand[0];
                try
                {
                    if (typeCommand == "Team")
                    {
                        string teamName = rawCommand[1];

                        Team team = new Team(teamName);
                        teams.Add(teamName, team);

                    }
                    else if (typeCommand == "Add")
                    {
                        string teamName = rawCommand[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }

                        string playerName = rawCommand[2];
                        int playerEndurance = int.Parse(rawCommand[3]);
                        int playerSprint = int.Parse(rawCommand[4]);
                        int playerDribble = int.Parse(rawCommand[5]);
                        int playerPassing = int.Parse(rawCommand[6]);
                        int playerShooting = int.Parse(rawCommand[7]);

                        Player player = new Player(playerName, playerEndurance,    playerSprint, playerDribble, playerPassing, playerShooting);

                        teams[teamName].AddPlayer(player);

                    }
                    else if (typeCommand == "Remove")
                    {
                        string teamName = rawCommand[1];
                        string playerName = rawCommand[2];

                        teams[teamName].RemovePlayer(playerName);

                    }
                    else if (typeCommand == "Rating")
                    {
                        string teamName = rawCommand[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");

                            command = Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].TeamRating}");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }

        }
    }
}
