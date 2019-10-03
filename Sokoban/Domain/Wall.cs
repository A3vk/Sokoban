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
            setDescription();
        }

        public override void setDescription()
        {
            Description = (IsVoid) ? ' ' : '█';
        }

        public override bool IsValidForkliftLocation(Dir dir)
        {
            return false;
        }

        public override bool IsValidCrateLocation()
        {
            return false;
        }

        public override bool IsValidEmployeeLocation(Dir dir)
        {
            return false;
        }
    }
}
