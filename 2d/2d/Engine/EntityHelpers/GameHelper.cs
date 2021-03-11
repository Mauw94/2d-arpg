using _2d.Engine.Entities;
using _2d.Engine.Utils;
using Microsoft.Xna.Framework;
using System;

namespace _2d.Engine.EntityHelpers
{
    /// <summary>
    /// Game helper class.
    /// </summary>
    public class GameHelper
    {
        public bool Overlap;

        private readonly GraphicsDeviceManager _graphics;

        public GameHelper(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
        }
        
        /// <summary>
        /// Check window bounds.
        /// </summary>
        /// <param name="entity">Entity to check for.</param>
        public void CheckWindowBounds(Entity entity)
        {
            if (entity.Position.X > _graphics.PreferredBackBufferWidth - entity.Texture.Width / 2)
                entity.Position.X = _graphics.PreferredBackBufferWidth - entity.Texture.Width / 2;
            else if (entity.Position.X < entity.Texture.Width / 2)
                entity.Position.X = entity.Texture.Width / 2;

            if (entity.Position.Y > _graphics.PreferredBackBufferHeight - entity.Texture.Height / 2)
                entity.Position.Y = _graphics.PreferredBackBufferHeight - entity.Texture.Height / 2;
            else if (entity.Position.Y < entity.Texture.Height / 2)
                entity.Position.Y = entity.Texture.Height / 2;
        }

        /// <summary>
        /// Make sure an entity doesn't spawn on top of another entity.
        /// </summary>
        public void CheckEnemyOverlapWhenSpawning()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if entities collide.
        /// </summary>
        public void CheckCollisions(Entity player, Entity enemy)
        {
            if (enemy.BoundingRectangle.Intersects(player.BoundingRectangle))
            {
                enemy.Dispose();
                enemy.IsDead = true;
                Score.IncreaseScore();
                EntityManager.Enemies.Remove((Enemy)enemy);

                player.Health--;
            }

        }
    }
}
