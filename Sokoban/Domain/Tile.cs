using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public abstract class Tile
    {
        private Tile _tileNorth;
        private Tile _tileEast;
        private Tile _tileSouth;
        private Tile _tileWest;
    }
}
