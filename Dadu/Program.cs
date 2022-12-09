using System;

namespace Dadu
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] d1=new int[3];
            int[] d2=new int[3];
            int r;
            int[] s=new int[2];
            String n="P1";
            String n2="CPU";

            while(true)
            {
                Console.Clear();
                Console.WriteLine("MENU");
                Console.WriteLine("----");
                Console.WriteLine("1. P1 vs CPU");
                Console.WriteLine("2. P1 vs P2");
                Console.Write("\nPilih: ");
                if(Console.ReadKey().KeyChar == '1')
                {
                    Console.Clear();
                    Console.WriteLine("Halo, P1!\n");
                    Console.Write("Masukkan IGN: "); n=Console.ReadLine();
                    break;
                }
                else if(Console.ReadKey().KeyChar == '2')
                {
                    Console.Clear();
                    Console.WriteLine("Halo, P1 dan P2!\n");
                    Console.Write("Masukkan IGN P1: "); n=Console.ReadLine();
                    Console.Write("Masukkan IGN P2: "); n2=Console.ReadLine();
                    break;
                }
                else
                {
                    continue;
                }
            }

            Console.Clear();
            Console.Write("Selamat datang, "+n+" dan "+n2+"!\n\n");
            Console.Write("Loading...   ");
            int t = 5;
            while(t > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft-3,Console.CursorTop);
                Console.Write(" "+t+"s");
                t--;
                Thread.Sleep(1000);
            }

            Random rng = new Random();
            Random rng2 = new Random();

            for(r = 1; r<=10;r++)
            {
                Console.Clear();
                Console.WriteLine("Ronde "+r);
                Console.WriteLine("----");
                Console.WriteLine("Skor "+n+": "+s[0]);
                Console.Write("Skor "+n2+": "+s[1]);
                Console.WriteLine("\n----");
                Console.WriteLine("Pada game ini, "+n+" dan "+n2+" akan mengocok 2 dadu.");
                Console.WriteLine("Jumlah mata dadu akan ditambahkan, yang jumlah nya paling tinggi,");
                Console.WriteLine("dialah pemenangnya.\n");

                Console.Write("Mulai? [y/n] ");
                if(Console.ReadKey().KeyChar == 'n')
                {
                    break;
                }

                Console.WriteLine("\n\n-Giliran "+n+"-");
                Console.Write("Mengocok...    ");
                t = 0;
                while(t < 2)
                {
                    for(int i=0;i<13;i++)
                    {
                        Console.SetCursorPosition(Console.CursorLeft-4,Console.CursorTop);
                        d1[t] = rng.Next(1,7);
                        Console.Write(" ("+(d1[t])+")");
                        Thread.Sleep(60);
                    }
                    t++;
                    Thread.Sleep(1000);
                }
                //Console.SetCursorPosition(Console.CursorLeft-3,Console.CursorTop);
                Console.WriteLine("    ");
                Console.WriteLine("Dadu 1: "+d1[0]);
                Console.WriteLine("Dadu 2: "+d1[1]);
                Console.WriteLine("Jumlah: "+(d1[2]=d1[1]+d1[0]));
                Console.WriteLine(" ");

                Thread.Sleep(1000);

                Console.WriteLine("-Giliran "+n2+"-");
                Console.Write("Mengocok...    ");
                t = 0;
                while(t < 2)
                {
                    for(int i=0;i<13;i++)
                    {
                        Console.SetCursorPosition(Console.CursorLeft-4,Console.CursorTop);
                        d2[t] = rng2.Next(1,7);
                        Console.Write(" ("+(d2[t])+")");
                        Thread.Sleep(60);
                    }
                    t++;
                    Thread.Sleep(1000);
                }
                //Console.SetCursorPosition(Console.CursorLeft-3,Console.CursorTop);
                Console.WriteLine("    ");
                Console.WriteLine("Dadu 1: "+d2[0]);
                Console.WriteLine("Dadu 2: "+d2[1]);
                Console.WriteLine("Jumlah: "+(d2[2]=d2[1]+d2[0]));
                Console.WriteLine(" ");

                Thread.Sleep(1000);

                Console.WriteLine("-Hasil-");
                if(d1[2] > d2[2])
                {
                    Console.WriteLine(n +" -> ("+d1[2]+" > "+d2[2]+") <- "+n2);
                    Console.WriteLine(n+" Menang!");
                    s[0]++;
                }
                else if(d1[2] < d2[2])
                {
                    Console.WriteLine(n +" -> ("+d1[2]+" < "+d2[2]+") <- "+n2);
                    Console.WriteLine(n2+" Menang!");
                    s[1]++;
                }
                else
                {
                    Console.WriteLine(n +" -> ("+d1[2]+" = "+d2[2]+") <- "+n2);
                    Console.WriteLine("Seri!");
                }

                Console.Write("\nLanjut? [y/n] ");
                if(Console.ReadKey().KeyChar == 'n')
                {
                    break;
                }

            }
            Console.Clear();
            if(r>=10)
            {
                Console.Write("Skor "+n+": "+s[0]+"\nSkor "+n2+": "+s[1]);
                Console.WriteLine("\n----");
                Console.WriteLine(" ");
                if(s[0]<s[1])
                {
                    Console.WriteLine(n2.ToUpper()+" MENANG!");
                    Console.WriteLine(" ");
                    Console.WriteLine(n2+" memenangkan game.\nTetap semangat "+n+"!");
                }
                else if(s[0]>s[1])
                {
                    Console.WriteLine(n.ToUpper()+" MENANG!");
                    Console.WriteLine(" ");
                    Console.WriteLine(n+" memenangkan game.\nTetap semangat "+n2+"!");
                }
                else
                {
                    Console.WriteLine("SERI!");
                    Console.WriteLine(" ");
                    Console.WriteLine(n2+" dan "+n+" memiliki skor yang sama.\nCoba lagi!");
                }
            }
            else
            {
                Console.Write("Skor "+n+": "+s[0]+"\nSkor "+n2+": "+s[1]);
                Console.WriteLine("\n----");
                Console.WriteLine(" ");
                Console.WriteLine("-GAME OVER-");
                Console.WriteLine("\nGame berakhir di Ronde "+r+".");
                Console.WriteLine("Ayo main lagi dan kalahkan musuh kalian!");
            }
            Console.WriteLine("\n(c) 2022 - Fikri Rivandi"); Console.ReadKey();
        }
    }
}