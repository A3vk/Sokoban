using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class VoidTile : Tile
    {
        public override bool isValidForkliftLocation(Dir dir)
        {
            return false;
        }

        public override bool isValidCrateLocation()
        {
            return false;
        }
    }
}
