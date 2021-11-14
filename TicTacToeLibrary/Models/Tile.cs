using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    public struct Tile
    {
        public States BoardState { get; set; } = new States();
        public string X { get; set; }

        public Tile(string x)
        {
            X = x;
            BoardState = States.Empty; 
        }
    }
}
