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
        public Enemy(IServiceProvider serviceProvider, BoundsHelper boundsHelper, GraphicsDeviceManager graphicsDevice) 
            : base(serviceProvider, boundsHelper, graphicsDevice)
        {
            LoadContent();
        }

        /// <summary>
        /// Initialize entity.
        /// </summary>
        public void Initialize()
        {
            Random rnd = new Random();
            var xPos = rnd.Next(1, GraphicsDevice.PreferredBackBufferWidth - Texture.Width);
            var yPos = rnd.Next(1, GraphicsDevice.PreferredBackBufferHeight - Texture.Height);

            Console.WriteLine("########### enemy pos ########");
            Console.WriteLine(xPos);
            Console.WriteLine(yPos);

            Position = new Vector2(xPos, yPos);
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            // TODO: random movement => check bounds
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
            Texture = Content.Load<Texture2D>("ball");
        }
    }
}
