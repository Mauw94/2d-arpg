using _2d.Engine.EntityHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2d.Engine.Entities
{
    /// <summary>
    /// Player class handling all player related stuff.
    /// </summary>
    public class Player : Entity, IEntity
    {
        private SpriteFont font;

        public Player(IServiceProvider serviceProvider, GameHelper gameHelper, GraphicsDeviceManager graphicsDevice) 
            : base(serviceProvider, gameHelper, graphicsDevice)
        {
            LoadContent();

            Health = 2;
        }

        /// <summary>
        /// Initialize entity.
        /// </summary>
        /// <param name="graphics">Graphics device.</param>
        public void Initialize(Entity? entity)
        {
            Position = new Vector2(GraphicsDevice.PreferredBackBufferWidth / 2, GraphicsDevice.PreferredBackBufferHeight / 2);
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            KeyInput(keyboardState, gameTime, 250f);

            // ApplyPhysics(gameTime);
        }

        /// <summary>
        /// Draw entity.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Health.ToString(), new Vector2(GraphicsDevice.PreferredBackBufferWidth / 2, 10), Color.Red);

            spriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                0f,
                new Vector2(Texture.Width / 2, Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
        }

        /// <summary>
        /// Load content.
        /// </summary>
        public void LoadContent()
        {
            Texture = Content.Load<Texture2D>("player");
            font = Content.Load<SpriteFont>("Score");
        }

        /// <summary>
        /// Apply 'physcis' so the player always moves with the same speed no matter the framerate.
        /// </summary>
        private void ApplyPhysics(GameTime gameTime)
        {
            // TODO: implemented later
        }

        /// <summary>
        /// Get key input.
        /// </summary>
        private void KeyInput(KeyboardState keyboardState, GameTime gameTime, float speed)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Movement = speed;
            
            if (keyboardState.IsKeyDown(Keys.Up))
                Position.Y -= Movement * elapsed;

            if (keyboardState.IsKeyDown(Keys.Down))
                Position.Y += Movement * elapsed;

            if (keyboardState.IsKeyDown(Keys.Left))
                Position.X -= Movement * elapsed;

            if (keyboardState.IsKeyDown(Keys.Right))
                Position.X += Movement * elapsed;

            GameHelper.CheckWindowBounds(this);
        }
    }
}
