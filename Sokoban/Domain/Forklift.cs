using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{

    public class Forklift
    {
        public Floor Location { get; set; }

        public Forklift(Floor location)
        {
            Location = location;
        }

        public virtual bool Move(Dir dir)
        {
            Tile newLocation = null;
            switch(dir)
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

            if(newLocation.IsValidForkliftLocation(dir))
            {
                Location.Forklift = null;
                ((Floor)newLocation).Forklift = this;
                Location = (Floor)newLocation;
                return true;
            }

            return false;
        }
    }
}
