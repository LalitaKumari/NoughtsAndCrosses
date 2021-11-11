using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    class TicTacToe
    {
        int[,] array = {
                           {0,0,0},
                           {0,0,0},
                           {0,0,0}

                       };
        int row = 0;
        int col = 0;
        int player = 1;
        static bool win;

        //-------------<Print>-----------
        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Player" + player);
            Console.WriteLine("----------------------------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j] == 0)
                    {
                        Console.Write("-\t");
                    }
                    else if (array[i, j] == 1)
                    {
                        Console.Write("X\t");
                    }
                    else
                    {
                        Console.Write("O\t");
                    }
                }
                Console.WriteLine();
            }
        }
        //--------------<Input>--------------
        public void GetInput()
        {
            do
            {
                do
                {
                    Console.Write("Enter a Row:[1..3]");
                    string Rowstr = Console.ReadLine();
                    try
                    {
                        row = Convert.ToInt32(Rowstr);
                        if(row >3 || row <1)
                            Console.WriteLine("Invalid row.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input.");
                    }
                } while (row > 3 || row < 1);

                do
                {
                    Console.Write("Enter a Col:[1..3]");
                    string Colstr = Console.ReadLine();
                    try
                    {
                        col = Convert.ToInt32(Colstr);
                        if (col > 3 || col < 1)
                            Console.WriteLine("Invalid column.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input.");
                    }

                } while (col > 3 || col < 1);
                row--;
                col--;

                if (array[row, col] != 0)
                {
                    Console.WriteLine("This is already used. Please select next!");
                }
            } while (array[row, col] != 0);

        }
        //--------------<SetArray>--------------
        public void SetArray()
        {
            if (player == 1)
            {
                array[row, col] = 1;
            }
            else
            {
                array[row, col] = 10;
            }
        }

        //-------------<CheckWinner>-----------
        public bool CheckWinner()
        {
            //calculate sum of rows
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += array[i, j];
                }
                if (sum == 3 || sum == 30)
                {
                    return true;
                }
                sum = 0;
            }

            //calculate sum of cols
            for (int i = 0; i < 3; i++)
            {
                sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    sum += array[j, i];
                }
                if (sum == 3 || sum == 30)
                {
                    return true;
                }

            }
            //calculate sum of diameter \
            sum = array[1, 1] + array[2, 2] + array[0, 0];
            if (sum == 3 || sum == 30)
            {
                return true;
            }
            //calculate sum of sub diameter /
            sum = array[0, 2] + array[1, 1] + array[2, 0];
            if (sum == 3 || sum == 30)
            {
                return true;
            }
            return false;
        }
        //----------------<ChangePlayer>------------
        public void ChangePlayer()
        {
            if (player == 1)
            {
                player = 2;
            }
            else
            {
                player = 1;
            }
        }
        //-----------------<PrintResult>------------
        public void PrintResult(bool win)
        {
            if (win)
            {
                if (player == 1)
                {
                    Console.WriteLine("Player 1 won the game");
                }
                else
                {
                    Console.WriteLine("Player 2 won the game");
                }
            }
            else
            {
                Console.WriteLine("Nobody won");
            }
        }
    }
}
