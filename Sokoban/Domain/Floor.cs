using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Floor : Tile
    {
        protected Crate _crate;
        public virtual Crate Crate {
            get
            {
                return _crate;
            }
            set
            {
                _crate = value;
                setDescription();
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
                _forklift = value;
                setDescription();
            }
        }

        private Employee _employee;
        public Employee Employee {
            get
            {
                return _employee; 
            }
            set
            {
                _employee = value;
                setDescription();
            }
        }

        public bool IsDestination { get; set; }

        public Floor(bool b)
        {
            IsDestination = b;
            setDescription();
        }

        public override void setDescription()
        {
            if(Forklift != null)
            {
                Description = '@';
            } else if(Crate != null)
            {
                Description = (IsDestination) ? '0' : 'O';
            } else
            {
                Description = (IsDestination) ? 'X' : '.';
            }
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

        public override bool IsValidEmployeeLocation(Dir dir)
        {
            if (Forklift != null)
            {
                return Forklift.Move(dir);
            } else if (Crate != null)
            {
                return Crate.Move(dir);
            } else
            {
                return true;
            }
        }
    }
}
