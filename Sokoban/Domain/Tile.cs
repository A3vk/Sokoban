using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public abstract class Tile
    {
        public Tile North { get; set; }
        public Tile East { get; set; }
        public Tile South { get; set; }
        public Tile West { get; set; }

        public void addEast(Tile addTile)
        {
            if(East == null)
            {
                East = addTile;
                East.addWest(this);
            } else
            {
                East.addEast(addTile);
            }
        }

        public void addWest(Tile tile)
        {
            West = tile;
        }
    }
}
