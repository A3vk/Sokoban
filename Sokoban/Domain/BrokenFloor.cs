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
            bool b =  base.IsValidCrateLocation();

            if (b && Strength >= 0)
                Strength--;

            return b;
        }

        public override bool IsValidForkliftLocation(Dir dir)
        {
            bool b = base.IsValidForkliftLocation(dir);

            if (b && Strength >= 0)
                Strength--;

            return b;
        }

        public override bool IsValidEmployeeLocation(Dir dir)
        {
            bool b = base.IsValidEmployeeLocation(dir);

            if (b && Strength >= 0)
                Strength--;

            return b;
        }
    }
}
