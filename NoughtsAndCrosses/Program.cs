using System;

namespace NoughtsAndCrosses
{
    class Program
    {
        static bool win;
        static void Main(string[] args)
        {
            Console.Clear();
            TicTacToe ticTacToe = new TicTacToe();
            int counter = 0;
            Console.WriteLine("welcome to X-O game");
            while (counter < 9)
            {
                ticTacToe.Print();
                ticTacToe.GetInput();
                ticTacToe.SetArray();
                win = ticTacToe.CheckWinner();
                if (win)
                {
                    ticTacToe.Print();
                    ticTacToe.PrintResult(win);
                    Console.Write("Do you want to play next game:[Yes/No]");
                    string nextGameYN = Console.ReadLine();
                    if (nextGameYN?.ToUpper() == "YES")
                    {
                        ticTacToe = new TicTacToe();
                        ticTacToe.ChangePlayer();
                        counter = -1;
                    }
                    else 
                        break;
                }
                ticTacToe.ChangePlayer();
                counter++;
            }
        }
    }
}
