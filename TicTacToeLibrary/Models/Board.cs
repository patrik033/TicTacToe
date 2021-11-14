using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        private Tile[,] MyGameBoard { get;  set; } = new Tile[3, 3];
        public States GameState { get; private set; } = new States();

        public Board()
        {
            InitBoard();
            PrintBoard();
        }


        private void InitBoard()
        {
            string num = "0";
            GameState = States.Empty;

            for (int i = 0; i < MyGameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < MyGameBoard.GetLength(1); j++)
                {
                    MyGameBoard[i, j] = new Tile(num);
                }
            }
        }

        public void PrintBoard()
        {

            for (int i = 0; i < MyGameBoard.GetLength(0); i++)
            {
                Console.WriteLine("------------");
                for (int j = 0; j < MyGameBoard.GetLength(1); j++)
                {
                    if (MyGameBoard[i, j].BoardState == States.Empty)
                    {

                        MyGameBoard[i, j].X = "   ";
                        Console.Write($"{MyGameBoard[i, j].X}");
                    }
                    if (MyGameBoard[i, j].BoardState == States.O)
                    {
                        MyGameBoard[i, j].X = " O ";
                        Console.Write($"{MyGameBoard[i, j].X}");
                    }
                    if (MyGameBoard[i, j].BoardState == States.X)
                    {
                        MyGameBoard[i, j].X = " X ";
                        Console.Write($"{MyGameBoard[i, j].X}");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------");
        }

        //loopa 
        public bool GetBoardPlacement(Player ActivePlayer, States currentPlayerState)
        {
            bool isValidShot = false;
            Console.WriteLine("Please use your numpad to enter a shot location: ");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.NumPad1)
            {
                isValidShot = ValidateBoardShot(0, 0, currentPlayerState);
            }
            if (key.Key == ConsoleKey.NumPad2)
            {
                isValidShot = ValidateBoardShot(0, 1, currentPlayerState);
            }
            if (key.Key == ConsoleKey.NumPad3)
            {
                isValidShot = ValidateBoardShot(0, 2, currentPlayerState);
            }
            if (key.Key == ConsoleKey.NumPad4)
            {
                isValidShot = ValidateBoardShot(1, 0, currentPlayerState);
            }
            if (key.Key == ConsoleKey.NumPad5)
            {
                isValidShot = ValidateBoardShot(1, 1, currentPlayerState);
            }
            if (key.Key == ConsoleKey.NumPad6)
            {
                isValidShot = ValidateBoardShot(1, 2, currentPlayerState);
            }
            if (key.Key == ConsoleKey.NumPad7)
            {
                isValidShot = ValidateBoardShot(2, 0, currentPlayerState);
            }
            if (key.Key == ConsoleKey.NumPad8)
            {
                isValidShot = ValidateBoardShot(2, 1, currentPlayerState);
            }
            if (key.Key == ConsoleKey.NumPad9)
            {
                isValidShot = ValidateBoardShot(2, 2, currentPlayerState);
            }
            return isValidShot;
        }

        private bool ValidateBoardShot(int x, int y, States currentPlayerStatus)
        {
            bool isValid = false;
            if (MyGameBoard[x, y].BoardState == States.Empty)
            {
                PlaceBoardShot(x, y, currentPlayerStatus);
                isValid = true;
            }
            return isValid;
        }

        private void PlaceBoardShot(int x, int y, States currentPlayerStatus)
        {
            MyGameBoard[x, y].BoardState = currentPlayerStatus;
        }


        public bool BoardWinner(States activePlayerState)
        {
            bool isWinner = false;

            if (MyGameBoard[0, 0].BoardState == activePlayerState && MyGameBoard[0, 1].BoardState == activePlayerState && MyGameBoard[0, 2].BoardState == activePlayerState)
                isWinner = true;// first line horizontial
            
            else if (MyGameBoard[1, 0].BoardState == activePlayerState && MyGameBoard[1, 1].BoardState == activePlayerState && MyGameBoard[1, 2].BoardState == activePlayerState)
                isWinner = true; //second line horizontial
           
            else if (MyGameBoard[2, 0].BoardState == activePlayerState && MyGameBoard[2, 1].BoardState == activePlayerState && MyGameBoard[2, 2].BoardState == activePlayerState)
                isWinner = true; //third line horizontial
           
            else if (MyGameBoard[0, 0].BoardState == activePlayerState && MyGameBoard[1, 0].BoardState == activePlayerState && MyGameBoard[2, 0].BoardState == activePlayerState)
                isWinner = true; //first line vertical
            
            else if (MyGameBoard[0, 1].BoardState == activePlayerState && MyGameBoard[1, 1].BoardState == activePlayerState && MyGameBoard[2, 1].BoardState == activePlayerState)
                isWinner = true;//second line vertical
           
            else if (MyGameBoard[0, 2].BoardState == activePlayerState && MyGameBoard[1, 2].BoardState == activePlayerState && MyGameBoard[2, 2].BoardState == activePlayerState)
                isWinner = true; //third line vertical
           
            else if (MyGameBoard[0, 0].BoardState == activePlayerState && MyGameBoard[1, 1].BoardState == activePlayerState && MyGameBoard[2, 2].BoardState == activePlayerState)
                isWinner = true; // left top to right bottom
           
            else if (MyGameBoard[0, 2].BoardState == activePlayerState && MyGameBoard[1, 1].BoardState == activePlayerState && MyGameBoard[2, 0].BoardState == activePlayerState)
                isWinner = true;//left bottom to right top
            else 
                isWinner=false;
            return isWinner;
        }
    }
}
