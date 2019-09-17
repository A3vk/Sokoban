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

        public void addEast(Tile tile)
        {
            if(East == null)
            {
                East = tile;
                East.addWest(this);
            } else
            {
                East.addEast(tile);
            }
        }

        public void addWest(Tile tile)
        {
            West = tile;
        }

        public void addSouth(Tile tile)
        {
            if(South == null)
            {
                South = tile;
                South.addNorth(this);
            } else
            {
                South.addSouth(tile);
            }
        }

        public void addNorth(Tile tile)
        {
            North = tile;
        }
    }
}
