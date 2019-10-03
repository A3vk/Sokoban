using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class BrokenFloor : Floor
    {
        public override Crate Crate
        {
            get
            {
                return _crate;
            }
            set
            {
                if (Strength >= 0)
                    _crate = value;

                if(value == null)
                    _crate = value;

                setDescription();
            }
        }

        public int Strength { get; set; }

        public BrokenFloor() : base(false)
        {
            Strength = 3;
            setDescription();
        }

        public override void setDescription()
        {
            if (Crate != null)
            {
                Description = 'O';
            } else if (Forklift != null)
            {
                Description = '@';
            } else if (Employee != null) {
                Description = (Employee.IsAwake) ? '$' : 'Z';
            } else
            {
                Description = (Strength > 0) ? '~' : ' ';
            }
        }

        public override bool IsValidCrateLocation()
        {
            if(Strength >= 0)
                Strength--;

            return base.IsValidCrateLocation();
        }

        public override bool IsValidForkliftLocation(Dir dir)
        {
            if(Strength >= 0)
                Strength--;

            return base.IsValidForkliftLocation(dir);
        }

        public override bool IsValidEmployeeLocation(Dir dir)
        {
            if (Strength >= 0)
                Strength--;

            return base.IsValidEmployeeLocation(dir);
        }
    }
}
