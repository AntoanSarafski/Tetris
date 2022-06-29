using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        // Settings
        static int TetrisRows = 30;
        static int TetrisCols = 15;
        static int InfoCols = 15;
        static int ConsoleRows = 1 + TetrisRows + 1;
        static int ConsoleCols = 1 + TetrisCols + 1 + InfoCols + 1;

        // State
        static int score = 0;
        private static object thread;

        static void Main(string[] args)
        {
            Console.Title = "Tetris v1.0";
            Console.CursorVisible = false;
            Console.WindowHeight = ConsoleRows + 1;
            Console.WindowWidth = ConsoleCols;
            Console.BufferHeight = ConsoleRows + 1;
            Console.BufferWidth = ConsoleCols;
            DrawBoard();
            DrawInfo();
            while (true)
            {
                score++;
                // user input
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    
                }

                // change state

                // redraw UI
                DrawBoard();
                DrawInfo();
                Thread.Sleep(40);
            }
        }


        static void DrawBoard()
        {
            Console.SetCursorPosition(0, 0);
            string line = "╔";
            line += new string('═', TetrisCols);
            /* for (int i = 0; i < TetrisCols; i++)
            {
                line += "═";
            } */
            line += "╦";
            line += new string('═', InfoCols);
            line += "╗";
            Console.WriteLine(line);

            for (int i = 0; i < TetrisRows; i++)
            {
                string middleLine = "║";
                middleLine += new string(' ', TetrisCols);
                middleLine += "║";
                middleLine += new string(' ', InfoCols);
                middleLine += "║";
                Console.WriteLine(middleLine);
            }

            string endLine = "╚";
            endLine += new string('═', TetrisCols);
            endLine += "╩";
            endLine += new string('═', InfoCols);
            endLine += "╝";
            Console.WriteLine(endLine);
        }

        static void DrawInfo()
        {
            Write("Score:", 1, 3 + TetrisCols);
            Write(score.ToString(), 2, 3 + TetrisCols);
        }

        static void Write(string text,int row,int col,ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
