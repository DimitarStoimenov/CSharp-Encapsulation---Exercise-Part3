using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;

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
        public int Endurance
        {
            get 
            { 
                return endurance; 
            }
            private set
            {
               
                RangeValidation(nameof(Endurance), value);
               
                endurance = value; 
            }
        }

        public int Sprint
        {
            get 
            { 
                return sprint;
            }
            private set 
            {
                RangeValidation(nameof(Sprint), value);
                sprint = value; 
            }
        }

      
        public int Dribble
        {
            get 
            { return dribble;
            }
            private set 
            {
                RangeValidation(nameof(Dribble), value);
                dribble = value; 
            }
        }
       

        public int Passing
        {
            get 
            { return passing; 
            }
            private set 
            {
                RangeValidation(nameof(Passing), value);
                passing = value; 
            }
        }
        
        public int Shooting
        {
            get 
            { return shooting; 
            }
            private set 
            {
                RangeValidation(nameof(Shooting), value);
                shooting = value; 
            }
        }

        public double PlayerSkillLevel
            => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
        private void RangeValidation(string varName, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{varName} should be between 0 and 100.");
            }

        }

    }
}
