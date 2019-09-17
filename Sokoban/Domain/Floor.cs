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

        public void setCrate()
        {

        }
    }
}
