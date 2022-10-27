/*
 * Corie Beale
 * IGME 206
 * Midterm
 */


using RougeLikeLite;


// create player with determined health and damage
Player p = new Player(10, 2); // experience and level will start from scratch

int bossCounter = 0;
String input;
int enemyChoice;
Random rand = new Random();
int attackDamage;

// gameplay loop
while (p.Health > 0) { // player must be alive
    Console.WriteLine("An enemy has been found!");
    bossCounter++;
    ICreature enemy;
    if (bossCounter == 5) { // boss
        Console.WriteLine("It is a boss!");
        enemy = new Boss(p);
        bossCounter = 0;
    }
    else
    {
        Console.WriteLine("It is a mini-boss!");
        enemy = new MiniBoss(p);
    }
    while (enemy.Health > 0) // boss fight
    {
        // print stats to weigh options
        Console.WriteLine("Player: " + p.Health + " HP, " + p.Damage + " DMG\n" +
            "Enemy: " + enemy.Health + " HP, " + enemy.Damage + " DMG");

        Console.WriteLine("Choose an action:\n >attack\t>defend"); // player choice
        input = Console.ReadLine();
        enemyChoice = rand.Next(0, 2); // 0 for attack, 1 for defend

        // player defaults to first attack
        if (enemyChoice == 1) { Console.WriteLine("The enemy is defending!"); }

        // event conditions
        if (input == "attack" && enemyChoice == 1) // player attack, enemy defend
        {
            attackDamage = p.Attack(enemy, false);
            Console.WriteLine("The enemy defends " + enemy.defend(attackDamage) + " damage!");
            enemy.Health -= enemy.defend(attackDamage);
        }
        else if (input == "attack") // player attack, enemy does not defend
        {
            Console.WriteLine("The enemy wants to attack, but you are too fast.");
            attackDamage = p.attack(enemy, true);
            Console.WriteLine("The enemy is hit for " + p.attack(enemy, true) + " damage!");
        }
        else if (input == "defend" && enemyChoice == 1) // both defend
        {
            Console.WriteLine("You and the enemy defend nothing...");
        }
        else if (input == "defend" && enemyChoice == 0)
        {
            attackDamage = enemy.attack(p, true);
            Console.WriteLine("You defend the attack for " + p.defend(attackDamage) + " damage!");
            p.Health -= p.defend(attackDamage);
        }

        // end turn, print stats
        if (p.Health <= 0) // player death
        {
            Console.WriteLine("Your health is " + p.Health + ". You fought hard, but your time is over.");
        }
        else if (enemy.health <= 0) // enemy killed
        {
            int priorLevel = p.Level;
            int exp = enemy.GetReward();
            int latterLevel = p.Level;
            Console.WriteLine("The enemy has been defeated! You collect " + exp + " experience!");
            if (priorLevel != latterLevel)
            {
                Console.WriteLine("Your level has increased by " + (latterLevel - priorLevel) + "! " + priorLevel + " -> " + latterLevel);
            }
        }
    }
}

// final output, stats of run
Console.WriteLine("You had a good run. Better luck next time!\n" +
                  "Final statistics:\n" +
                  "  Level: " + p.Level +
                  "\nExperience: " + p.Experience +
                  "\nDamage: " + p.Damage);
