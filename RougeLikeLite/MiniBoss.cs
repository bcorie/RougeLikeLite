using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RougeLikeLite
{
    /// <summary>
    /// Semi-strong enemy.
    /// </summary>
    internal class MiniBoss : ICreature
    {
        private Random rand = new Random();

        private int baseCalc = 0;
        /// <summary>
        /// Creates a mini-boss. Determines how
        /// to scale mini-boss stats based on
        /// the player.
        /// </summary>
        /// <param name="p">The player to scale off of.</param>
        public MiniBoss(Player p)
        {
            baseCalc = p.Level;
        }

        private int health;
        /// <summary>
        /// The health of the mini-boss. Is scaled by 1.2
        /// by the level of the player.
        /// </summary>
        public int Health
        {
            get => health; set => health = (int)(baseCalc * 1.2);
        }

        private int damage;
        /// <summary>
        /// The damage the mini-boss can deal. Is scaled
        /// by 1.5 of the level of the player.
        /// </summary>
        public int Damage
        {
            get => damage; set => damage = (int)(baseCalc * 1.5);
        }

        /// <summary>
        /// Attacks a creature to deal the mini-boss's
        /// amount of damage.
        /// </summary>
        /// <param name="c">Creature to attack</param>
        /// <param name="commit">True if the attack should be executed, false if it should be calculated.</param>
        /// <returns>The damage in the attack.</returns>
        public int attack(ICreature c, bool commit)
        {
            int damage = rand.Next(Damage / 3, Damage * 2 * 3);
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
        public int defend(int attack)
        {
            int defense = Damage / 3;
            int result = attack - defense;
            if (result <= 0) { return 0; }
            return result;
        }

        /// <summary>
        /// The experience reward for the player to receive.
        /// </summary>
        /// <returns>The half of the health and damage of the mini-boss.</returns>
        public int getReward()
        {
            return (Health + Damage) / 2;
        }

    }
}
