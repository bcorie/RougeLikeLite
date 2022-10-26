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
        int Health
        {
            get;
            set;
        }

        int Damage
        {
            get;
            set;
        }
        void attack(ICreature creature);
    }
}
