/*
 * Corie Beale
 * IGME 206
 * Midterm
 */


using RougeLikeLite;


// create player with determined health and damage
Player p = new Player(10, 5); // experience and level will start from scratch

int bossCounter = 0;
String input;
int enemyChoice;
Random rand = new Random();
int attackDamage;

// gameplay loop
while (p.Health > 0) { // player must be alive
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("An enemy has been found!");
    bossCounter++;
    if (bossCounter == 5) { // boss
        Console.WriteLine("It is a boss!");
        Boss enemy = new Boss(p);
        bossCounter = 0;

        while (enemy.Health > 0) // boss fight
        {
            // print stats to weigh options
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Player: " + p.Health + " HP, " + p.Damage + " DMG\n" +
                "Boss: " + enemy.Health + " HP, " + enemy.Damage + " DMG");

            Console.WriteLine("Choose an action:\n >attack\t>defend"); // player choice
            input = Console.ReadLine()!;
            while (input.ToLower() != "attack" && input.ToLower() != "defend")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid action.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Choose an action:\n >attack\t>defend");
                input = Console.ReadLine()!;
            }
            enemyChoice = rand.Next(0, 2); // 0 for attack, 1 for defend

            // player defaults to first attack
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (enemyChoice == 1) { Console.WriteLine("The boss is defending!"); }

            // event conditions
            if (input == "attack" && enemyChoice == 1) // player attack, enemy defend
            {
                attackDamage = p.Attack(enemy, false);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You attack for " + attackDamage + " damage.");
                Console.WriteLine("The boss defends and takes " + enemy.Defend(attackDamage) + " damage!");
                enemy.Health -= enemy.Defend(attackDamage);
            }
            else if (input == "attack") // player attack, enemy does not defend
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The boss wants to attack, but you are too fast.");
                attackDamage = p.Attack(enemy, true);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The boss is hit for " + p.Attack(enemy, true) + " damage!");
            }
            else if (input == "defend" && enemyChoice == 1) // both defend
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You and the boss defend nothing...");
            }
            else if (input == "defend" && enemyChoice == 0)
            {
                attackDamage = enemy.Attack(p, true);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You defend the attack for " + p.Defend(attackDamage) + " damage!");
                p.Health -= p.Defend(attackDamage);
            }

            Console.ForegroundColor = ConsoleColor.White;

            // end turn, print stats
            if (p.Health <= 0) // player death
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your health is " + p.Health + ". You fought hard, but your time is over.");
            }
            else if (enemy.Health <= 0) // enemy killed
            {
                int priorLevel = p.Level;
                int exp = enemy.GetReward();
                p.AddExperience(exp);
                int latterLevel = p.Level;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The boss has been defeated! You collect " + exp + " experience!");
                if (priorLevel != latterLevel)
                {
                    Console.WriteLine("Your level has increased by " + (latterLevel - priorLevel) + "! " + priorLevel + " -> " + latterLevel);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    else // miniboss
    {
        Console.WriteLine("It is a mini-boss!");
        MiniBoss enemy = new MiniBoss(p);

        while (enemy.Health > 0) // boss fight
        {
            // print stats to weigh options
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Player: " + p.Health + " HP, " + p.Damage + " DMG\n" +
                "Mini-boss: " + enemy.Health + " HP, " + enemy.Damage + " DMG");

            Console.WriteLine("Choose an action:\n >attack\t>defend"); // player choice
            input = Console.ReadLine()!;
            while (input.ToLower() != "attack" && input.ToLower() != "defend")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid action.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Choose an action:\n >attack\t>defend");
                input = Console.ReadLine()!;
            }
            enemyChoice = rand.Next(0, 2); // 0 for attack, 1 for defend

            // player defaults to first attack
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (enemyChoice == 1) { Console.WriteLine("The mini-boss is defending!"); }

            // event conditions
            if (input == "attack" && enemyChoice == 1) // player attack, enemy defend
            {
                attackDamage = p.Attack(enemy, false);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You attack for " + attackDamage + " damage.");
                Console.WriteLine("The mini-boss defends and takes " + enemy.Defend(attackDamage) + " damage!");
                enemy.Health -= enemy.Defend(attackDamage);
            }
            else if (input == "attack") // player attack, enemy does not defend
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The mini-boss wants to attack, but you are too fast.");
                attackDamage = p.Attack(enemy, true);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The mini-boss is hit for " + p.Attack(enemy, true) + " damage!");
            }
            else if (input == "defend" && enemyChoice == 1) // both defend
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You and the mini-boss defend nothing...");
            }
            else if (input == "defend" && enemyChoice == 0)
            {
                attackDamage = enemy.Attack(p, true);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You defend the attack for " + p.Defend(attackDamage) + " damage!");
                p.Health -= p.Defend(attackDamage);
            }

            Console.ForegroundColor = ConsoleColor.White;

            // end turn, print stats
            if (p.Health <= 0) // player death
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your health is " + p.Health + ". You fought hard, but your time is over.");
                break;
            }
            else if (enemy.Health <= 0) // enemy killed
            {
                int priorLevel = p.Level;
                int exp = enemy.GetReward();
                p.AddExperience(exp);
                int latterLevel = p.Level;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The mini-boss has been defeated! You collect " + exp + " experience!");
                if (priorLevel != latterLevel)
                {
                    Console.WriteLine("Your level has increased by " + (latterLevel - priorLevel) + "! " + priorLevel + " -> " + latterLevel);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    
}

// final output, stats of run
Console.WriteLine("You had a good run. Better luck next time!\n" +
                  "Final statistics:\n" +
                  "  Level: " + p.Level +
                  "\nExperience: " + p.Experience +
                  "\nDamage: " + p.Damage);
Console.ForegroundColor = ConsoleColor.White;