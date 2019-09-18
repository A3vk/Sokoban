using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Floor : Tile
    {
        public Crate Crate { get; set; }
        public Forklift Forklift { get; set; }

        public override bool isValidForkliftLocation(Dir dir)
        {
            if(Crate == null)
            {
                return true;
            } else
            {
                return Crate.move(dir);
            }
        }

        public override bool isValidCrateLocation()
        {
            if(Crate == null)
                return true;

            return false;
        }
    }
}
