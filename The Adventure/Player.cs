/*
Fikri Rivandi
2207112583
Adventure : The Game
*/
class Player
{
    public int HP { get; set; }
    public int defaultDamage { get; set; }
    public int damage { get; set; }
    public int lives { get; set; }
    public int exp { get; set; }
    public int mana { get; set; }
    public int energy { get; set; }
    public string name { get; set; }
    public string skillName { get; set; }
    public string enemyName { get; set; }
    public bool isDead { get; set; }
    public bool isBash { get; set; }
    public int type { get; set; }
    public string role { get; set; }
    Random rdg = new Random();

    public Player()
    {
    }

    public Player(string n, int t)
    {
        name = n;
        type = t;
        lives = 3;
        role = "Novice";
        enemyName = "Enemy";
        HP = 100;
        defaultDamage = 3;
        exp = 10;
        energy = 2;
        mana  = 10;
        skillName = "Swing Attack";
        setType(type);
    }

    public void setType(int t)
    {
        switch(t)
        {
            case 1:
            role = "Knight";
            HP += 120;
            defaultDamage = 5;
            isBash = false;
            skillName = "Bash Attack";
            break;

            case 2:
            role = "Wizard";
            HP += 80;
            defaultDamage = 5;
            skillName = "Lightning Bold";
            break;

            case 3:
            role = "Priest";
            HP += 100;
            defaultDamage = 20;
            skillName = "Heal";
            break;

            case 4:
            role = "Rogue";
            HP += 75;
            defaultDamage = 10;
            skillName = "Raging Blow";
            break;

            default:
            break;
        }
        isDead = false;
        type = t;
        damage = defaultDamage;
    }

    public int SingleAttack()
    {
        if(isBash)
        {
            damage += rdg.Next(exp + 1);
        }
        else
        {
            damage = rdg.Next(defaultDamage, exp + 1);
        }
        Console.WriteLine($"{name} is attacking.. ({damage} dmg)");
        return damage;
    }

    public void Die()
    {
        Console.WriteLine($"{name} has been killed by {enemyName}");
        isDead = true;
    }

    public void RunAway()
    {
        Console.WriteLine($"{name} has ran from {enemyName}, {name} lose!");
        isDead = true;
    }

    public void GetHit(int dmg)
    {
        Console.WriteLine($"{name} is damaged by {enemyName} (-{dmg} HP)");
        HP -= dmg;
        if(HP <= 0)
        {
            HP = 0;
            Die();
        }
    }

    public int addExp(int e)
    {
        Console.WriteLine($"{name} got +{e} EXP point!");
        return exp += e;
    }

    public void SetEnemy(string enemy)
    {
        enemyName = enemy;
    }

    public bool SwingAttack()
    {
        if(energy > 0)
        {
            damage += rdg.Next(defaultDamage, exp + 1);
            System.Console.WriteLine("SHRAKKKH!!!!");
            Console.WriteLine($"{name} attacks the {enemyName} with the {skillName}.. ({damage} dmg)");
            energy--;
            return true;
        }
        else
        {
            Console.WriteLine($"{name} has no energy. Restore your energy first.");
            damage = defaultDamage;
            return false;
        }
    }

    public int Bash()
    {
        if(energy > 0 && !isBash)
        {
            System.Console.WriteLine("BASH!!!!");
            Console.WriteLine($"{name} attacks the {enemyName} with the {skillName}.. ({enemyName} stunned, {name} damage enhanced)");
            energy--;
            isBash = true;
            return 1;
        }
        else if(isBash)
        {
            Console.WriteLine($"{name} has activated the Bash. Attack with Single Attack first.");
            return 2;
        }
        else
        {
            damage = defaultDamage;
            Console.WriteLine($"{name} has no energy. Restore your energy first.");
        }
        return 0;
    }

    public bool LightningBold()
    {
        if(mana >= 30)
        {
            damage += rdg.Next(exp, exp * 2);
            Console.WriteLine($"{name} attacks the {enemyName} with the {skillName}.. ({damage} dmg)");
            mana -= 30;
            return true;
        }
        else
        {
            Console.WriteLine($"{name} has no energy. Restore your energy first.");
            damage = defaultDamage;
            return false;
        }
    }

    public void SkillHeal()
    {
        if(mana >= 30)
        {
            int heal = damage + rdg.Next(exp * 2);
            Console.WriteLine($"{name} is Healing his HP.. (+{heal} HP)");
            HP += heal;
            mana -= 30;
        }
        else
        {
            Console.WriteLine($"{name} has no energy. Restore your energy first.");
            damage = defaultDamage;
        }
    }

    public int RagingBlow()
    {
        if(energy >= 3)
        {
            int dmg = 0;
            Console.WriteLine($"{name} attacks the {enemyName} with the {skillName}..");
            for(int i = 0; i < 3; i++)
            {
                damage += rdg.Next(exp / 2 + 1);
                Console.WriteLine($"SLASSHHH!!! ({damage} dmg)");
                energy--;
                dmg += damage;
            }
            return dmg;
        }
        else
        {
            Console.WriteLine($"{name}'s energy is less than 3. Restore your energy first.");
            damage = defaultDamage;
            return 0;
        }
    }

    public void Heal()
    {
        int up = 0;
        switch(type)
        {
            case 0:
            up = 1;
            break;
            case 1:
            up = 2;
            break;
            case 4:
            up = 2;
            break;
            default:
            mana += 30;
            Console.WriteLine($"{name} is Healing his Mana.. (+30 mana)");
            break;
        }
        if(up != 0)
        {
            energy += up;
            Console.WriteLine($"{name} is Healing his Energy.. (+{up} energy)");
        }
    }
}
