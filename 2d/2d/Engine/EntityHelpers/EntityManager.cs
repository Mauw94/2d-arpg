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
        public List<Enemy> Enemies { get; }

        private readonly IServiceProvider ServiceProvider;
        private readonly BoundsHelper _boundsHelper;
        private readonly GraphicsDeviceManager _graphicsDevice;

        public EntityManager(IServiceProvider serviceProvider, BoundsHelper boundsHelper, GraphicsDeviceManager graphicsDevice)
        {
            ServiceProvider = serviceProvider;
            _boundsHelper = boundsHelper;
            _graphicsDevice = graphicsDevice;

            Enemies = new List<Enemy>();
        }

        /// <summary>
        /// Add a new enemy.
        /// </summary>
        public Enemy AddEnemyEntity()
        {
            var enemy = new Enemy(ServiceProvider, _boundsHelper, _graphicsDevice);
            Enemies.Add(enemy);

            return enemy;
        }
    }
}
