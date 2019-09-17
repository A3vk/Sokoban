using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class Maze
    {
        public Tile Head { get; set; }
        public Forklift Forklift { get; set; }
        public List<Crate> Crates { get; set; }

        public Maze()
        {
            Crates = new List<Crate>();
        }
    }
}
