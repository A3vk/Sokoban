using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Crate
    {
        public Floor Location { get; set; }

        public Crate(Floor location)
        {
            Location = location;
        }

        public bool move(Dir dir)
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

            // Later even naar kijken
            if (newLocation.isValidCrateLocation())
            {
                Location.Crate = null;
                ((Floor)newLocation).Crate = this;
                Location = (Floor)newLocation;

                return true;
            }

            return false;
        }
    }
}
