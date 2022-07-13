using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get 
            { return name; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value; 
            }
        }

        public int TeamRating
            => this.players.Count == 0 
            ? 0 
            : (int)Math.Round(this.players.Average(x => x.PlayerSkillLevel));
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string player)
        {
            Player playerToRemove = this.players.FirstOrDefault(x => x.Name == player);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException($"Player {player} is not in {this.Name} team.");
            }

            this.players.Remove(playerToRemove);
        }



    }
}
