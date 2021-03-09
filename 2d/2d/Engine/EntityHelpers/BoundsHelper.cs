using _2d.Engine.Entities;
using Microsoft.Xna.Framework;
using System;

namespace _2d.Engine.EntityHelpers
{
    /// <summary>
    /// Check bounds for entities.
    /// </summary>
    public class BoundsHelper
    {
        public bool Overlap;

        private readonly GraphicsDeviceManager _graphics;

        public BoundsHelper(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
        }
        
        /// <summary>
        /// Check bounds.
        /// </summary>
        /// <param name="entity">Entity to check for.</param>
        public void CheckBounds(Entity entity)
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

        public void CheckEnemyPosition(Entity player, Entity enemy)
        {
            var playerRec = new Rectangle((int)player.Position.X, 
                (int)player.Position.Y, 
                player.Texture.Width, 
                player.Texture.Height);

            var enemyRec = new Rectangle((int)enemy.Position.X,
                (int)enemy.Position.Y,
                enemy.Texture.Width,
                enemy.Texture.Height);

            if (playerRec.Intersects(enemyRec))
                Console.WriteLine("### intersecting ###");
        }
    }
}
