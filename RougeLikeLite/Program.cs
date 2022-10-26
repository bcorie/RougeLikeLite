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

// gameplay loop
while (p.Health > 0) { // player must be alive
    Console.WriteLine("An enemy has been found!");
    bossCounter++;
    if (bossCounter == 5) { // boss
        Console.WriteLine("It is a boss!");
        Boss b = new Boss(p);
        while (b.Health > 0) // boss fight
        {
            Console.WriteLine("Choose an action:\n >attack\t>defend");
            input = Console.ReadLine();
            if (input == "attack")
            {
                p.attack(b);
            }
        }
    }
    else // mini-boss
    {
        Console.WriteLine("It is a mini-boss!");

    }
}

// final output, score/stats of run