/*
 * Creature Interface
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RougeLikeLite
{
    /// <summary>
    /// Creature in the game.
    /// </summary>
    internal interface ICreature
    {
        /// <summary>
        /// The health a creature has.
        /// How much damage it can take without dying.
        /// </summary>
        int Health
        {
            get;
            set;
        }

        /// <summary>
        /// How much damage a creature deals.
        /// </summary>
        int Damage
        {
            get;
            set;
        }

        /// <summary>
        /// Attacks a creature to deal the creature's
        /// amount of damage.
        /// </summary>
        /// <param name="c">Creature to attack</param>
        /// <param name="commit">True if the attack should be executed, false if it should be calculated.</param>
        /// <returns>The damage in the attack.</returns>
        public int Attack(ICreature c, bool commit);

        /// <summary>
        /// Defend against an attack
        /// </summary>
        /// <param name="attack">Value of the attack attempt.</param>
        /// <returns>Damage that goes through the defense. 0 if the attack if completely defended.</returns>
        public int Defend(int attack);
    }
}
