using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Wall : Tile
    {
        public bool IsVoid { get; set; }

        public Wall(bool b)
        {
            IsVoid = b;
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
