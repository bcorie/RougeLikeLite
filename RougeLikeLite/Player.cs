/*
 * Corie Beale
 * IGME 206
 * Midterm
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace RougeLikeLite
{
    /// <summary>
    /// Playable character for the user.
    /// </summary>
    internal class Player : ICreature
    {
        /// <summary>
        /// Creates a player.
        /// </summary>
        /// <param name="health">Health of the player. Is determined at run-time.</param>
        /// <param name="damage">Damage the player can deal. Is determined at run-time.</param>
        /// <param name="experience">Experience of the player. Is 0 when created.</param>
        /// <param name="level">Level of the player. Is 1 when created.</param>
        public Player(int health, int damage, int experience = 0, int level = 1)
        {
            Health = health;
            Damage = damage;
            Experience = experience;
            Level = level;
        }


        /// <summary>
        /// The health of the player. How many hits of
        /// damage the player can take before dying.
        /// </summary>
        public int Health
        {
            get; set;
        }

        /// <summary>
        /// How much damage the player deals.
        /// </summary>
        public int Damage
        {
            get; set;
        }

        /// <summary>
        /// Experience the player accumulates from interactions.
        /// Collecting a certain amount increases the player's level.
        /// </summary>
        public int Experience
        {
            get; set;
        }


        /// <summary>
        /// The player's level. Acts as a base for some interactions.
        /// Is increased based on experience gain.
        /// </summary>
        public int Level
        {
            get; set;
        }

        /// <summary>
        /// Attack a creature. Deal damage to the enemy.
        /// </summary>
        /// <param name="enemy">The entity the player is attacking.</param>
        public void attack(ICreature enemy)
        {
            enemy.Health -= Damage;
        }

        /// <summary>
        /// Adds experience to the player. For every ten experience,
        /// the player's level increases by one and experience is
        /// reset to zero.
        /// </summary>
        /// <param name="xp"></param>
        public void addExperience(int xp)
        {
            for (int i = 0; i < xp; i++)
            {
                Experience++;
                if (Experience % 10 == 0)
                {
                    Experience = 0;
                    Level++;
                }
            }
        }
    }
}
