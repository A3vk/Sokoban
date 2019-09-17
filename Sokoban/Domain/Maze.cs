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
        private Forklift _forklift;
        private List<Crate> _crates;

        public Maze(Tile tile)
        {
            Head = tile;
        }
    }
}
