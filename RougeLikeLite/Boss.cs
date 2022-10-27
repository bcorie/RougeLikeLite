using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RougeLikeLite
{
    /// <summary>
    /// A strong enemy.
    /// </summary>
    internal class Boss : ICreature
    {
        private int baseCalc = 0;
        private Random rand = new Random();
        private int reward;

        /// <summary>
        /// Creates a boss. Determines how
        /// to scale boss stats based on
        /// the player.
        /// </summary>
        /// <param name="p">The player to scale off of.</param>
        public Boss(Player p)
        {
            baseCalc = p.Level;
            health = (int)(baseCalc * 2.0);
            damage = (int)(baseCalc * 2.5);
            reward = health + damage;
        }

        private int health;
        /// <summary>
        /// The health of the boss. Is scaled by 2
        /// by the level of the player.
        /// </summary>
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        private int damage;
        /// <summary>
        /// The damage the boss can deal. Is scaled
        /// by 2.5 of the level of the player.
        /// </summary>
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        /// <summary>
        /// Attacks a creature to deal the boss's
        /// amount of damage.
        /// </summary>
        /// <param name="c">Creature to attack</param>
        /// <param name="commit">True if the attack should be executed, false if it should be calculated.</param>
        /// <returns>The damage in the attack.</returns>
        public int Attack(ICreature c, bool commit)
        {
            int damage = rand.Next((Damage / 3) + 1, (Damage * 2 / 3) + 1);
            if (commit)
            {
                c.Health -= damage;
            }
            return damage;
        }

        /// <summary>
        /// Defend against an attack.
        /// </summary>
        /// <param name="attack">How much damage is in the attack.</param>
        /// <returns>How much damage gets through the defense.</returns>
        public int Defend(int attack)
        {
            int defense = Damage / 3;
            int result = attack - defense;
            if (result <= 0) { return 0; }
            return result;
        }

        /// <summary>
        /// The experience reward for the player to receive.
        /// </summary>
        /// <returns>The half of the health and damage of the boss.</returns>
        public int GetReward()
        {
            return reward;
        }
    }
}
