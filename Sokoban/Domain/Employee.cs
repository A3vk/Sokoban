using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Employee : Forklift
    {
        public bool IsAwake { get; set; }

        public Employee(Floor floor) : base(floor)
        {
            IsAwake = false;
        }

        public void DoSomething()
        {
            Random random = new Random();
            if (IsAwake)
            {
                if (random.NextDouble() <= 0.25)
                {
                    IsAwake = false;
                    return;
                }
                else
                {
                    Dir[] dirs = { Dir.UP, Dir.RIGHT, Dir.DOWN, Dir.LEFT };

                    Move(dirs[random.Next(4)]);
                }
            }
            else
            {
                if (random.NextDouble() <= 0.1)
                {
                    IsAwake = true;
                }

            }

            Location.setDescription();
        }

        public void Wake()
        {
            IsAwake = true;
        }

        public override bool Move(Dir dir)
        {
            Tile newLocation = null;
            switch (dir)
            {
                case Dir.UP:
                    newLocation = Location.North;
                    break;
                case Dir.RIGHT:
                    newLocation = Location.East;
                    break;
                case Dir.DOWN:
                    newLocation = Location.South;
                    break;
                case Dir.LEFT:
                    newLocation = Location.West;
                    break;
            }

            if (newLocation.IsValidEmployeeLocation(dir))
            {
                Location.Employee = null;
                ((Floor)newLocation).Employee = this;
                Location = (Floor)newLocation;
                return true;
            }

            return false;
        }
    }
}
