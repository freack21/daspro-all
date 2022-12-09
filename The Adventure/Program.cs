/*
Fikri Rivandi
2207112583
Adventure : The Game
*/
using System;

namespace The_Adventure
{
    class Program
    {
        private static int gameState = 0;
        static void Main(string[] args)
        {
            Console.Clear();

            while(true)
            {
                switch(gameState)
                {
                    case 0:
                    gameState = Resources.Menu();
                    continue;
                    case 1:
                    Play();
                    continue;
                    case 2:
                    Resources.Help();
                    Console.ReadKey();
                    gameState = 0;
                    continue;
                    case 3:
                    Resources.About();
                    Console.ReadKey();
                    gameState = 0;
                    continue;
                    case 4:
                    gameState = Resources.Exit();
                    continue;
                    default:
                    break;
                }
                break;
            }
        }

        static void Play()
        {
            string str = "";
            while(true)
            {
                Console.Clear();

                Console.WriteLine("Welcome, New Player!\nWhat is your name?");
                Console.Write(">> ");
                str = Console.ReadLine();
                if(str == "")
                    continue;
                break;
            }
            Console.Clear();

            Console.WriteLine($"Hello, {str}!\nDo you want to go on an amazing adventure? [y/n]");
            Console.Write(">> ");
            string input = Console.ReadLine();
            if(input == "n" || input == "N")
            {
                Console.Clear();
                Console.Write($"Goodbye, {str}!\nComeback here anytime you want {(char)2}{(char)2}");
                Console.ReadKey();
                gameState = 0;
            }
            else
            {
                Console.Clear();
                Console.Write("Loading World.");
                int i = 0;
                Player player = new Player();
                Enemy enemy = new Enemy();
                while(i < 4)
                {
                    if(i < 1)
                    {
                        player = new Player(str,0);
                        i++;
                        Console.Write(".");
                        Thread.Sleep(60);
                        enemy = new Enemy("Gollum",0);
                        i++;
                        Console.Write(".");
                        Thread.Sleep(60);
                        player.SetEnemy(enemy.name);
                        enemy.SetPlayer(player.name);
                    }
                    else
                    {
                        i++;
                        Console.Write(".");
                        Thread.Sleep(500);
                    }
                }
                Paint(player, enemy);
            }
        }

        static void Paint(Player player, Enemy enemy)
        {
            int level = 0;
            int bashed = 0;
            int expPlayer = 0;
            bool firstTime = true;
            bool conversation = true;
            int attackTurn = 0;
            int attackType = 0;
            string playerType = "";
            int typeEnergy = 0;
            Console.Clear();

            while(level != -1)
            {
                if(conversation)
                {
                    Resources.Conversation(level, player.name, enemy.name);
                    conversation = false;
                }
                int pl = player.name.Length;
                int el = enemy.name.Length;
                int l = Math.Max(pl, el);
                int k = l + 22;
                if(player.type == 2 || player.type == 3)
                {
                    playerType = "MANA";
                    typeEnergy = player.mana;
                } else
                {
                    playerType = "ENERGY";
                    typeEnergy = player.energy;
                }
                //System.Console.WriteLine(str.Length);
                Console.WriteLine("{0,-" + (l) + "} {1,-11} {2,-11} {3, -13} {4}", player.name, $"| HP : {player.HP}", $"| EXP : {player.exp}", $"| {playerType} : {typeEnergy}", $"| ROLE : {player.role}");
                Console.WriteLine("{0,-" + (l) + "} {1,-11} {2,-11} {3, -13} {4}", enemy.name, $"| HP : {enemy.HP}", $"| EXP : {enemy.exp}", $"| ENERGY : {enemy.energy}", $"| ROLE : {enemy.role}");
                Console.WriteLine("LEVEL " + (level + 1));
                Console.WriteLine("-------");

                if(firstTime)
                {
                    if(level >= 3)
                        Console.WriteLine("LAST ROUND!!\n");
                    Console.WriteLine($"{player.name.ToUpper()} vs {enemy.name.ToUpper()}");
                    Console.WriteLine("BATTLE START!!!\n");
                }

                if(player.isBash)
                {
                    bashed++;
                    if(bashed > 1)
                    {
                        player.isBash = false;
                        bashed = 0;
                    }
                }

                if(attackTurn == 0 && !player.isDead)
                {
                    Console.WriteLine(player.name.ToUpper() + " TURN!");
                    if(player.isBash)
                        Console.WriteLine("(Bash is still active)");
                    //Console.WriteLine("Choose your action:");
                    Console.WriteLine("[1] Single Attack [2] " + player.skillName + " [3] Rest [4] Run Away");
                    Console.Write(">> ");
                    try {
                        attackType = int.Parse(Console.ReadLine());
                        if(attackType < 1 || attackType > 4)
                        {
                            Console.Clear();
                            continue;
                        }

                        attackTurn = 1;
                        firstTime = false;
                    } catch (Exception) {Console.Clear();continue;}

                    switch(attackType)
                    {
                        case 1:
                        enemy.GetHit(player.SingleAttack());
                        break;
                        case 2:
                        if(player.type == 0)
                        {
                            if(player.SwingAttack())
                            {
                                attackTurn = 2;
                                enemy.GetHit(player.damage);
                            }
                        }
                        else if(player.type == 1)
                        {
                            int b = player.Bash();
                            if(b == 1)
                            {
                                attackTurn = 0;
                                bashed = 0;
                            }
                            else if(b == 2)
                            {
                                bashed--;
                            }
                        }
                        else if(player.type == 2)
                        {
                            if(player.LightningBold())
                                enemy.GetHit(player.damage);
                        }
                        else if(player.type == 3)
                        {
                            player.SkillHeal();
                        }
                        else if(player.type == 4)
                        {
                            int r = player.RagingBlow();
                            if(r != 0)
                                enemy.GetHit(r);
                        }
                        break;
                        case 3:
                        player.Heal();
                        break;
                        case 4:
                        player.RunAway();
                        Console.WriteLine();
                        break;
                        default:
                        break;
                    }
                }

                if(attackTurn == 1 && !enemy.isDead && !player.isBash && !player.isDead)
                {
                    Console.WriteLine();
                    Console.WriteLine(enemy.name.ToUpper() + " TURN!");
                    //Console.WriteLine("Choose your action:");
                    if(enemy.type == 3)
                    {
                        enemy.damage = 3 * player.damage;
                        enemy.SetDamage(30 * player.HP / 100);
                    }
                    int s = enemy.Attack();
                    if(s != 4 && s != 0)
                        player.GetHit(enemy.skillDamage);
                    else if(s == 0)
                        player.GetHit(enemy.SingleAttack());
                    attackTurn = 0;
                    Console.WriteLine();
                }

                if((attackTurn == 2 || player.isBash) && !enemy.isDead)
                {
                    Console.WriteLine();
                    Console.WriteLine(enemy.name.ToUpper() + " TURN!");
                    Console.WriteLine(enemy.name + $" can't attack {player.name}.");
                    if(player.isBash)
                        Console.WriteLine(enemy.name + $" is stunned. (Bash is still active)");
                    attackTurn = 0;
                    Console.WriteLine();
                }

                if(enemy.isDead)
                {
                    expPlayer = 10;
                    Console.WriteLine();
                    player.Heal();
                    player.addExp(expPlayer);
                    Console.WriteLine();
                }

                if(!player.isDead && !enemy.isDead)
                    Console.WriteLine("[ENTER] Continue Battle [R] Run Away");
                else
                    Console.WriteLine("[ENTER] Continue");
                Console.Write(">> ");
                string str = Console.ReadLine();
                if((str == "R" || str == "r") && (!enemy.isDead && !player.isDead))
                {
                    Console.Clear();
                    player.RunAway();
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                }

                while(enemy.isDead || player.isDead)
                {
                    if(enemy.isDead && level != 3)
                    {
                        Console.WriteLine($"{player.name} won this battle! Excelent!\n");
                        Console.WriteLine("Continue to next level?");
                        Console.WriteLine("[1] Next Level [2] Back To Menu [3] Exit");
                        Console.Write(">> ");
                        try {
                            int input = int.Parse(Console.ReadLine());
                            if(input < 1 || input > 3)
                            {
                                Console.Clear();
                                continue;
                            }
                            switch(input)
                            {
                                case 1:
                                Console.Clear();
                                Console.WriteLine("Choose your new role:");
                                Console.WriteLine("[1] Knight [2] Wizard [3] Priest [4] Rogue");
                                Console.Write(">> ");
                                try {
                                    int role = int.Parse(Console.ReadLine());
                                    if(role < 1 || role > 4)
                                        continue;
                                    player.setType(role);
                                    level++;
                                    conversation = true;
                                    string enemyName = "";
                                    if(level == 1)
                                        enemyName = "Azog";
                                    else if(level == 2)
                                        enemyName = "Saruman";
                                    else if(level == 3)
                                        enemyName = "Sauron";
                                    enemy.setType(level);
                                    player.SetEnemy(enemyName);
                                    enemy.name = enemyName;
                                    firstTime = true;
                                    attackTurn = 0;
                                } catch (Exception) {Console.Clear();continue;}
                                Console.Clear();
                                break;
                                case 2:
                                gameState = 0;
                                level = -1;
                                break;
                                case 3:
                                gameState = 5;
                                level = -1;
                                break;
                            }
                        } catch (Exception) {Console.Clear();continue;}
                    }
                    else if(level >= 3 && enemy.isDead)
                    {
                        Console.WriteLine($"Congratulations, {player.name}! YOU WON!\nYou're the new king of Light World!!\n");
                        Console.WriteLine("[1] Back To Menu [2] Exit");
                        Console.Write(">> ");
                        try {
                            int input = int.Parse(Console.ReadLine());
                            if(input < 1 || input > 2)
                            {
                                Console.Clear();
                                continue;
                            }
                            switch(input)
                            {
                                case 1:
                                gameState = 0;
                                level = -1;
                                break;
                                case 2:
                                gameState = 5;
                                level = -1;
                                break;
                            }
                        } catch (Exception) {Console.Clear();continue;}
                    }
                    else
                    {
                        Console.WriteLine($"GAME OVER!!\n{player.name}, you failed to finish game!\nThe World is still dark. We need you to comeback and destroy the evil in this World!\n");
                        Console.WriteLine("[1] Back To Menu [2] Exit");
                        Console.Write(">> ");
                        try {
                            int input = int.Parse(Console.ReadLine());
                            if(input < 1 || input > 2)
                            {
                                Console.Clear();
                                continue;
                            }
                            switch(input)
                            {
                                case 1:
                                gameState = 0;
                                level = -1;
                                break;
                                case 2:
                                gameState = 5;
                                level = -1;
                                break;
                            }
                        } catch (Exception) {Console.Clear();continue;}
                    }
                    break;
                }
            }
        }
    }
}