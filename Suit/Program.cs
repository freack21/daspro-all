using System;

namespace Fix
{
    class Program
    {
        static void Main()
        {
            bool exit = false;
            int player, cpu;
            int[] skor = new int[3];
            while(!exit)
            {
                do
                {
                    Console.Clear();
                    player = PlayerChoose();
                } while (player == -1);
                if(player == 3)
                    break;
                cpu = CpuChoose();
                skor[Check(player, cpu)]++;
                Console.WriteLine($"Skor: {skor[1]} menang, {skor[2]} kalah, {skor[0]} seri\nTekan Enter untuk melanjutkan permainan...");
                Console.ReadKey();
            }
            Console.Clear();
        }

        static int PlayerChoose()
        {
            Console.WriteLine("Batu, Gunting, Kertas\n");
            Console.Write("Choose [b]atu, [g]unting, [k]ertas, or [e]xit:");
            string input = Console.ReadLine();
            if(input == "b")
                return 0;
            else if(input == "g")
                return 1;
            else if(input == "k")
                return 2;
            else if(input == "e")
                return 3;
            return -1;
        }

        static int CpuChoose()
        {
            Random rsg = new Random();
            int s = rsg.Next(3);
            switch(s)
            {
                case 0:
                Console.WriteLine("Komputer memilih Batu.");
                break;
                case 1:
                Console.WriteLine("Komputer memilih Gunting.");
                break;
                case 2:
                Console.WriteLine("Komputer memilih Kertas.");
                break;
            }
            return s;
        }

        static int Check(int player, int cpu)
        {
            int result = -1;
            if(player == cpu)
                result = 0;
            else if((player == 0 && cpu == 1) || (player == 1 && cpu == 2) || (player == 2 && cpu == 0))
                result = 1;
            else
                result = 2;

            switch(result)
            {
                case 0:
                Console.WriteLine("Seri.");
                break;
                case 1:
                Console.WriteLine("Anda menang.");
                break;
                case 2:
                Console.WriteLine("Anda kalah.");
                break;
            }
            return result;
        }
    }
}