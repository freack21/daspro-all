/*
Fikri Rivandi
2207112583
Adventure : The Game
*/
class Enemy
{
    public int HP { get; set; }
    public int defaultDamage { get; set; }
    public int damage { get; set; }
    public int skillDamage { get; set; }
    public int lives { get; set; }
    public int exp { get; set; }
    public int energy { get; set; }
    public double instantDeathChance { get; set; }
    public string name { get; set; }
    public string playerName { get; set; }
    public bool isDead { get; set; }
    public int type { get; set; }
    public string role { get; set; }
    Random rdg = new Random();

    public Enemy()
    {
    }

    public Enemy(string n, int t)
    {
        name = n;
        type = t;
        lives = 3;
        role = "Creep";
        playerName = "Player";
        HP = 50;
        defaultDamage = 2;
        exp = 10;
        energy = 0;
        instantDeathChance = 0;
        setType(type);
    }

    public void setType(int t)
    {
        switch(t)
        {
            case 1:
            role = "Monster";
            HP = 150;
            defaultDamage = 5;
            exp = 10;
            energy = 1;
            break;

            case 2:
            role = "Lord";
            HP = 300;
            defaultDamage = 10;
            exp = 15;
            energy = 2;
            break;

            case 3:
            role = "World Boss";
            HP = 1000;
            defaultDamage = 10;
            exp = 25;
            instantDeathChance = 0.1;
            break;

            default:
            break;
        }
        isDead = false;
        skillDamage = defaultDamage;
        damage = defaultDamage;
        type = t;
    }

    public int SingleAttack()
    {
        if(damage == defaultDamage)
            damage = rdg.Next(defaultDamage, exp + 1);
        else
            damage += rdg.Next(defaultDamage, exp + 1);
        Console.WriteLine($"{name} is attacking.. ({damage} dmg)");
        skillDamage = damage;
        return damage;
    }

    public void Die()
    {
        Console.WriteLine($"{name} has been killed by {playerName}");
        isDead = true;
    }

    public void GetHit(int dmg)
    {
        Console.WriteLine($"{name} is damaged by {playerName} (-{dmg} HP)");
        damage = defaultDamage;
        HP -= dmg;
        if(HP <= 0)
        {
            HP = 0;
            Die();
        }
    }

    public void SetPlayer(string enemy)
    {
        playerName = enemy;
    }

    public int SetDamage(int dmg)
    {
        return skillDamage = dmg;
    }

    public void SkillAttack(int dmg)
    {
        if(energy > 0)
        {
            skillDamage += rdg.Next(dmg);
            Console.WriteLine($"{name} attacks the {playerName} with skill.. ({skillDamage} dmg)");
            energy--;
        }
        else
        {
            damage = defaultDamage;
            SingleAttack();
        }
    }

    public void LordAttack()
    {
        if(energy > 0)
        {
            //skillDamage += rdg.Next(exp * 2);
            Console.WriteLine($"{name} attacks the {playerName} with the Lord skill.. ({skillDamage} dmg)");
            energy--;
        }
        else
        {
            damage = defaultDamage;
            SingleAttack();
        }
    }

    public int Attack()
    {
        int attackType = rdg.Next(0,3);
        if(attackType == 1)
        {
            if(type == 1)
            {
                SkillAttack(15);
                return 1;
            }
            else if(type == 2)
            {
                SkillAttack(15);
                return 2;
            }
            else if(type == 3)
            {
                LordAttack();
                return 3;
            }
        }
        else if(attackType == 2)
        {
            if(type != 0 && energy < 3)
            {
                Heal();
                return 4;
            }
            else if(type != 0 && energy >= 3)
            {
                if(type == 1)
                {
                    SkillAttack(10);
                    return 1;
                }
                else if(type == 2)
                {
                    SkillAttack(15);
                    return 2;
                }
                else if(type == 3)
                {
                    LordAttack();
                    return 3;
                }
            }
        }
        return 0;
    }

    public void Heal()
    {
        energy++;
        Console.WriteLine($"{name} is Healing his Energy.. (+1 energy)");
    }
}