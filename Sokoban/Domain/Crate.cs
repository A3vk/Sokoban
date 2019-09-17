using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Crate
    {
        public Floor Location { get; set; }

        public Crate(Floor location)
        {
            Location = location;
        }
    }
}
