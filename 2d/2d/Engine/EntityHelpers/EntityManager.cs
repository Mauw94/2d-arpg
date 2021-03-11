using _2d.Engine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace _2d.Engine.EntityHelpers
{
    /// <summary>
    /// Entity manager.
    /// EM is used to generate a new entity and give it a place in the game.
    /// </summary>
    public class EntityManager
    {
        public static List<Enemy> Enemies { get; private set; }

        public Player Player { get; private set; }

        private readonly IServiceProvider ServiceProvider;
        private readonly GameHelper _boundsHelper;
        private readonly GraphicsDeviceManager _graphicsDevice;

        public EntityManager(IServiceProvider serviceProvider, GameHelper boundsHelper, GraphicsDeviceManager graphicsDevice)
        {
            ServiceProvider = serviceProvider;
            _boundsHelper = boundsHelper;
            _graphicsDevice = graphicsDevice;

            Enemies = new List<Enemy>();
        }

        /// <summary>
        /// Create the player.
        /// </summary>
        public Player CreatePlayer()
        {
            Player = new Player(ServiceProvider, _boundsHelper, _graphicsDevice);

            return Player;
        }

        /// <summary>
        /// Add a new enemy.
        /// </summary>
        public Enemy AddEnemyEntity()
        {
            var enemy = new Enemy(ServiceProvider, Player, _boundsHelper, _graphicsDevice);
            Enemies.Add(enemy);

            // todo: create a new helper for randoms. (rng)

            return enemy;
        }

        /// <summary>
        /// Add multiple enemies.
        /// </summary>
        public List<Enemy> AddMultipleEnemies(int numberOfEnemies)
        {
            var enemies = new List<Enemy>();
            for (int i = 0; i < numberOfEnemies; i++)
            {
                var e = new Enemy(ServiceProvider, Player, _boundsHelper, _graphicsDevice);
                enemies.Add(e);
                Enemies.Add(e);
            }

            return enemies;
        }
    }
}
