/*
Fikri Rivandi
2207112583
Adventure : The Game
*/
class Resources
{
    public static int Menu()
    {
        Console.Clear();

        string str = "|--------------------|";
        Console.WriteLine(str);
        Console.WriteLine("{0,-9}{1,-12}{2}", "|", "MENU", "|");
        Console.WriteLine("{0,-21}{1}", "| 1. Play", "|");
        Console.WriteLine("{0,-21}{1}", "| 2. Help", "|");
        Console.WriteLine("{0,-21}{1}", "| 3. About", "|");
        Console.WriteLine("{0,-21}{1}", "| 4. Exit", "|");
        Console.WriteLine(str);
        Console.Write(">> ");
        try
        {
            int retVal = Convert.ToInt16(Console.ReadLine());
            if(retVal < 0 || retVal > 4)
            {
                retVal = 0;
            }
            return retVal;
        }
        catch(Exception)
        {
            Console.WriteLine("!! Input not valid! Type the valid input !!");
            return 0;
        }
    }

    public static void Help()
    {
        Console.Clear();

        string str = "|----------------------------------------------------------------------|";
        Console.WriteLine(str);
        Console.WriteLine("{0,-34}{1,-37}{2}", "|", "HELP", "|");
        Console.WriteLine("{0,-71}{1}", "| Pada game ini, Player akan masuk ke dunia petualangan yang sangat", "|");
        Console.WriteLine("{0,-71}{1}", "| gelap.", "|");
        Console.WriteLine("{0,-71}{1}", "|", "|");
        Console.WriteLine("{0,-71}{1}", "| Player akan menemukan anak buah dan raja kegelapan.", "|");
        Console.WriteLine("{0,-71}{1}", "| Player ditugaskan untuk merebut dunia kegelapan dari raja kegelapan", "|");
        Console.WriteLine("{0,-71}{1}", "| dan menjadi raja didunia tersebut.", "|");
        Console.WriteLine(str);
        Console.Write(">> Press any key..");
    }

    public static void About()
    {
        Console.Clear();

        string str = "|----------------------------------------------------------------------|";
        Console.WriteLine(str);
        Console.WriteLine("{0,-34}{1,-37}{2}", "|", "ABOUT", "|");
        Console.WriteLine("{0,-71}{1}", "| Adventure : The Game", "|");
        Console.WriteLine("{0,-71}{1}", "| Version 1.0", "|");
        Console.WriteLine("{0,-71}{1}", "|", "|");
        Console.WriteLine("{0,-22}{1,-49}{2}", "| Author", " : Fikri Rivandi", "|");
        Console.WriteLine("{0,-71}{1}", "| Supporting Lecturer  : Rahmat Rizal Andhi, ST, MT", "|");
        Console.WriteLine("{0,-22}{1,-49}{2}", "| Class", " : S1 Teknik Informatika B", "|");
        Console.WriteLine("{0,-22}{1,-49}{2}", "| Project", " : Task 5 (Access Modifier & Class)", "|");
        Console.WriteLine("{0,-71}{1}", "|", "|");
        Console.WriteLine("{0,-25}{1,-46}{2}", "| ", "(c) 2022 Fikri Rivandi", "|");
        Console.WriteLine("{0,-25}{1,-46}{2}", "| ", "  All Right Deserved", "|");
        Console.WriteLine(str);
        Console.Write(">> Press any key..");
    }

    public static int Exit()
    {
        Console.Clear();

        string str = "|------------------------------|";
        Console.WriteLine(str);
        Console.WriteLine("{0,-13}{1,-18}{2}", "|", "EXIT", "|");
        Console.WriteLine("{0,-31}{1}", "| Are you sure to exit?  [y/n]", "|");
        Console.WriteLine(str);
        Console.Write(">>  ");
        int retVal = 5;
        string input = Console.ReadLine();
        if(input == "n" || input == "N")
        {
            retVal = 0;
        }
        return retVal;
    }

    public static void Conversation(int level, string name1, string name2)
    {
        if(level == 0)
        {
            Console.Write(name1 + " enters the world of darkness...");
            Console.ReadKey();
            Console.WriteLine();
            Console.Write(name1 + " is walking through the forest of darkness..");
            Console.ReadKey();
            Console.WriteLine();
            Console.Write(name2 + " is approaching....");
            Console.ReadKey();
            Console.WriteLine();
        }
        else if(level == 1)
        {
            Console.Write(name1 + " was success through the forest of darkness..");
            Console.ReadKey();
            Console.WriteLine();
            Console.Write(name1 + " enters the Dol Guldur, the Orc Empire...");
            Console.ReadKey();
            Console.WriteLine();
            Console.Write(name2 + " is approaching....");
            Console.ReadKey();
            Console.WriteLine();
        }
        else if(level == 2)
        {
            Console.Write(name1 + " was success to destroy the Dol Guldur..");
            Console.ReadKey();
            Console.WriteLine();
            Console.Write(name1 + " enters the Isengard, the " + name2 + "'s Empire...");
            Console.ReadKey();
            Console.WriteLine();
            Console.Write(name2 + " is approaching....");
            Console.ReadKey();
            Console.WriteLine();
        }
        else if(level == 3)
        {
            Console.Write(name1 + " has been destroy the Isengard..");
            Console.ReadKey();
            Console.WriteLine();
            Console.Write(name1 + " went to Mordor, the strongest dark Empire...");
            Console.ReadKey();
            Console.WriteLine();
            Console.Write(name1 + " will face the King of Darknest, " + name2 + "...");
            Console.ReadKey();
            Console.WriteLine();
            Console.Write(name2 + " is approaching....");
            Console.ReadKey();
            Console.WriteLine();
        }
        Console.Clear();
    }
}