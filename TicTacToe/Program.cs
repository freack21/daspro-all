using System;

namespace Fix
{
    class Program
    {
        static bool gameOver;
        static int x, y, turn, count, current, stateEnd;
        static char[] XO = new char[9];
        static int[,] posXO = new int[9,2];
        static string map = "";
        static Random rtc = new Random();

        static void Main(string[] args)
        {
            Init();

            while(count <= XO.Length)
            {
                Console.Clear();

                int cxo = CekXO();
                if(cxo != -1)
                {
                    stateEnd = cxo;
                    gameOver = true;
                }

                if(gameOver)
                {
                    DrawMap();
                    if(stateEnd == 1)
                        System.Console.WriteLine("Anda Kalah.");
                    else if(stateEnd == 2)
                        System.Console.WriteLine("Anda Menang.");
                    else if(stateEnd == 0)
                        System.Console.WriteLine("Seri.");
                    Console.WriteLine("Main lagi [enter], atau keluar [delete]?");
                    var key = Console.ReadKey();
                    if(key.Key == ConsoleKey.Enter)
                        Init();
                    else if(key.Key == ConsoleKey.Delete)
                        break;
                    continue;
                }
                else if(!gameOver)
                {
                    DrawMap();
                    Console.Write("\nPilih posisi lalu tekan Enter.");
                    UpdateCurrent();
                    Console.SetCursorPosition(x, y);
                    if(turn == 0)
                    {
                        var key = Console.ReadKey();
                        if(key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                        {
                            if(current > 2)
                                current -= 3;
                            else
                                current += 6;
                        }
                        else if(key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                        {
                            if(current < 6)
                                current += 3;
                            else
                                current -= 6;
                        }
                        else if(key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                        {
                            if(current > 0)
                                current--;
                            else
                                current = 8;
                        }
                        else if(key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                        {
                            if(current < 8)
                                current++;
                            else
                                current = 0;
                        }
                        else if(key.Key == ConsoleKey.Enter)
                        {
                            if(XO[current] == ' ')
                            {
                                XO[current] = 'X';
                                UpdateCurrent();
                                posXO[current, 0] = x;
                                posXO[current, 1] = y;
                                count++;
                                turn = 1;
                            }
                        }
                    }
                    else
                    {
                        while(turn == 1)
                        {
                            int ch = rtc.Next(9);
                            if(XO[ch] == ' ')
                            {
                                XO[ch] = 'O';
                                current = ch;
                                UpdateCurrent();
                                posXO[current, 0] = x;
                                posXO[current, 1] = y;
                                count++;
                                turn = 0;
                            }
                        }
                        current = 0;
                    }
                }
            }
        }

        static void Init()
        {
            gameOver = false;
            x = 0;
            y = 0;
            turn = 0;
            count = 0;
            current = 0;
            stateEnd = -1;
            XO = new char[9];
            for(int i = 0; i < 9; i++)
                XO[i] = ' ';
            posXO = new int[9,2];
            map = "   |     |   \n   |     |   \n___|_____|___\n   |     |   \n   |     |   \n___|_____|___\n   |     |   \n   |     |   \n   |     |   ";
        }

        static int CekXO()
        {
            bool line = false;
            if(CekLine(0, 1, 2) || CekLine(3, 4, 5) || CekLine(6, 7, 8) || CekLine(0, 3, 6) || CekLine(0, 4, 8) || CekLine(1, 4, 7) || CekLine(2, 5, 8) || CekLine(2, 4, 6))
                line = true;

            if(line)
            {
                if(XO[current] == 'X')
                {
                    return 2;
                }
                else if(XO[current] == 'O')
                {
                    return 1;
                }
            }
            else if(count >= XO.Length)
            {
                return 0;
            }

            return -1;
        }

        static void UpdateCurrent()
        {
            switch(current)
            {
                case 0:
                y = 0; x = 0;
                break;
                case 1:
                y = 0; x = 6;
                break;
                case 2:
                y = 0; x = 12;
                break;
                case 3:
                y = 4; x = 0;
                break;
                case 4:
                y = 4; x = 6;
                break;
                case 5:
                y = 4; x = 12;
                break;
                case 6:
                y = 7; x = 0;
                break;
                case 7:
                y = 7; x = 6;
                break;
                case 8:
                y = 7; x = 12;
                break;
            }
        }

        static bool CekLine(int x, int y, int z)
        {
            return (XO[z] == XO[y] && XO[x] == XO[y]) && (current == x || current == y || current == z) && (XO[z] == 'X' || XO[z] == 'O');
        }

        static void DrawMap()
        {
            Console.WriteLine(map);
            int X = Console.CursorLeft;
            int Y = Console.CursorTop;

            for(int i=0; i<XO.Length;i++)
            {
                if(XO[i] != ' ')
                {
                    Console.SetCursorPosition(posXO[i,0], posXO[i,1]);
                    Console.Write(XO[i]);
                }
            }

            Console.SetCursorPosition(X, Y);
        }
    }
}