using _2d.Engine.EntityHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2d.Engine.Entities
{
    /// <summary>
    /// Enemy class.
    /// </summary>
    public class Enemy : Entity, IEntity
    {
        private readonly Player _player;

        public Enemy(IServiceProvider serviceProvider, Player player, GameHelper boundsHelper, GraphicsDeviceManager graphicsDevice) 
            : base(serviceProvider, boundsHelper, graphicsDevice)
        {
            LoadContent();
            _player = player;
        }

        /// <summary>
        /// Initialize entity.
        /// </summary>
        public void Initialize(Entity? player)
        {
            Random rnd = new Random();
            var xPos = rnd.Next(1, GraphicsDevice.PreferredBackBufferWidth - Texture.Width);
            var yPos = rnd.Next(1, GraphicsDevice.PreferredBackBufferHeight - Texture.Height);

            var playerRectangle = new Rectangle(
                (int)player.Position.X, 
                (int)player.Position.Y, 
                player.Texture.Width, 
                player.Texture.Height);

            if (playerRectangle.Contains(xPos, yPos))
                yPos += player.Texture.Height * 2;

            Position = new Vector2(xPos, yPos);
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            // TODO: random movement => check bounds
            BoundsHelper.DetectEnemyCollision(_player, this);
        }

        /// <summary>
        /// Draw entity.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        /// <summary>
        /// Load content.
        /// </summary>
        void LoadContent()
        {
            Texture = Content.Load<Texture2D>("enemy1");
        }
    }
}
