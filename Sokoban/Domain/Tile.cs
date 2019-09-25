using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public abstract class Tile
    {
        public Tile North { get; set; } = null;
        public Tile East { get; set; }
        public Tile South { get; set; }
        public Tile West { get; set; }
        public char Description { get; set; }

        public void AddEast(Tile tile)
        {
            if(East == null)
            {
                East = tile;
                East.AddWest(this);
            } else
            {
                East.AddEast(tile);
            }
        }

        public void AddWest(Tile tile)
        {
            West = tile;
        }

        public void AddSouth(Tile tile)
        {
            if(South == null)
            {
                South = tile;
                South.AddNorth(this);
            } else
            {
                South.AddSouth(tile);
            }
        }

        public void AddNorth(Tile tile)
        {
            North = tile;
        }

        public abstract bool IsValidForkliftLocation(Dir dir);
        public abstract bool IsValidCrateLocation();
    }
}
