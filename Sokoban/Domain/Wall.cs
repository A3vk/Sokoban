using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Wall : Tile
    {
        public Wall(bool b)
        {
            Description = (b) ? ' ' : '█';
        }
        public override bool IsValidForkliftLocation(Dir dir)
        {
            return false;
        }

        public override bool IsValidCrateLocation()
        {
            return false;
        }
    }
}
