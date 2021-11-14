using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public string? PlayerName { get; private set; }
        public States PlayerStates { get; private set; }
       
        public void SetName()
        {
            Console.WriteLine("Please enter a name: ");
            PlayerName = Console.ReadLine();
        }

        public void SetPlayerState(States playerState)
        {
            PlayerStates = playerState;
        }
    }
}
