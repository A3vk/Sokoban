using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Floor : Tile
    {
        private Crate _crate;
        public Crate Crate {
            get
            {
                return _crate;
            }
            set
            {
                Description = (value == null) ? (IsDestination) ? 'X' : '.' : (IsDestination) ? '0' : 'O';
                _crate = value;
            }
        }
        private Forklift _forklift;
        public Forklift Forklift {
            get
            {
                return _forklift;
            }
            set
            {
                Description = (value == null) ? (IsDestination) ? 'X' : '.' : '@';
            }
        }
        public bool IsDestination { get; set; }

        public Floor(bool b)
        {
            IsDestination = b;

            Description = (b) ? 'X' : '.';
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
