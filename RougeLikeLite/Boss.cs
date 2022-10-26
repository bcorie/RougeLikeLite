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
        /// <summary>
        /// Creates a boss. Determines how
        /// to scale boss stats based on
        /// the player.
        /// </summary>
        /// <param name="p">The player to scale off of.</param>
        public Boss(Player p)
        {
            baseCalc = p.Level;
        }

        private int health;
        /// <summary>
        /// The health of the boss. Is scaled by 2
        /// by the level of the player.
        /// </summary>
        public int Health
        {
            get => health; set => health = (int)(baseCalc * 2.0);
        }

        private int damage;
        /// <summary>
        /// The damage the boss can deal. Is scaled
        /// by 2.5 of the level of the player.
        /// </summary>
        public int Damage
        {
            get => damage; set => damage = (int)(baseCalc * 2.5);
        }

        /// <summary>
        /// Attacks a creature to deal the boss's
        /// amount of damage.
        /// </summary>
        /// <param name="c"></param>
        public void attack(ICreature c)
        {
            c.Health -= Damage;
        }

        /// <summary>
        /// The experience reward for the player to receive.
        /// </summary>
        /// <returns>The half of the health and damage of the boss.</returns>
        public int getReward()
        {
            return (Health + Damage) / 2;
        }
    }
}
