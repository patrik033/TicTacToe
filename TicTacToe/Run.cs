using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Run
    {

        public Player Player1 { get; private set; } = new Player();
        public Player Player2 { get; private set; } = new Player();
        public Player ActivePlayer { get; private set; } = new Player();

        public void RunGame()
        {
            Board game = new();
            Player1.SetPlayerState(States.X);
            Player2.SetPlayerState(States.O);
            Player1.SetName();
            Player2.SetName();
            int shotCount = 0;
            bool isValid = false;
            while (game.BoardWinner(ActivePlayer.PlayerStates) != true || shotCount != 9)
            {
                if (shotCount % 2 == 0)
                    ActivePlayer = Player1;
                else
                    ActivePlayer = Player2;
                isValid = game.GetBoardPlacement(ActivePlayer, ActivePlayer.PlayerStates);
                if (isValid)
                {
                    shotCount++;
                    game.PrintBoard();
                    if (game.BoardWinner(ActivePlayer.PlayerStates) == true || shotCount == 9)
                    {
                        break;
                    }
                }
            }
            if (shotCount == 9)
                Console.WriteLine("There is a draw");
            else
                Console.WriteLine($"{ActivePlayer.PlayerName} is winner!");
        }
    }
}
