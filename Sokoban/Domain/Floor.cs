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
        public bool IsDestination { get; set; }

        public Floor(bool b)
        {
            IsDestination = b;
        }
        public override bool IsValidForkliftLocation(Dir dir)
        {
            if(Crate == null)
            {
                return true;
            } else
            {
                return Crate.Move(dir);
            }
        }

        public override bool IsValidCrateLocation()
        {
            if(Crate == null)
                return true;

            return false;
        }
    }
}
