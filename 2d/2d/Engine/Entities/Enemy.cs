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

        public Enemy(IServiceProvider serviceProvider, Player player, GameHelper gameHelper, GraphicsDeviceManager graphicsDevice) 
            : base(serviceProvider, gameHelper, graphicsDevice)
        {
            LoadContent();

            Health = 1;
            Movement = GetMovementSpeed();

            _player = player;
        }

        /// <summary>
        /// Initialize entity.
        /// </summary>
        public void Initialize(Entity? player)
        {
            var xPos = RngHelper.GetRandomNr(1, GraphicsDevice.PreferredBackBufferWidth - Texture.Width);
            var yPos = RngHelper.GetRandomNr(1, GraphicsDevice.PreferredBackBufferHeight - Texture.Height);

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
            GameHelper.CheckCollisions(_player, this);
        }

        /// <summary>
        /// Have enemy move to a new location.
        /// </summary>
        public void AttackPlayer()
        {
            Vector2 direction = _player.Position - Position;
            direction.Normalize();
            Position += direction * Movement;
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

        /// <summary>
        /// Get a random movement speed.
        /// </summary>
        float GetMovementSpeed()
        {
            var speed = RngHelper.GetRandomNr(3, 12);
            return speed / 10f;
        }
    }
}
