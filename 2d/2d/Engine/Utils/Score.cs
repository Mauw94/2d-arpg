using _2d.Engine.Entities;
using _2d.Engine.EntityHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2d.Engine.Utils
{
    /// <summary>
    /// Game score class.
    /// </summary>
    public class Score : Entity, IEntity
    {
        public const int MaxScore = 5;

        public static int CurrentScore { get; private set; } = 0;

        public static bool GameEnd { get; private set; }

        public SpriteFont Font { get; private set; }

        public Score(IServiceProvider serviceProvider, GameHelper gameHelper, GraphicsDeviceManager graphicsDevice)
            : base(serviceProvider, gameHelper, graphicsDevice)
        {
            LoadContent();
        }

        /// <summary>
        /// Load content.
        /// </summary>
        public void LoadContent()
        {
            Font = Content.Load<SpriteFont>("Score");
        }

        /// <summary>
        /// Initialize entity.
        /// </summary>
        public void Initialize(Entity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Draw entity.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, CurrentScore + " / " + MaxScore, new Vector2(10, 10), Color.Black);
        }

        /// <summary>
        /// Increase score.
        /// </summary>
        public static void IncreaseScore()
        {
            CurrentScore++;
            if (CurrentScore >= MaxScore)
            {
                CurrentScore = MaxScore;
                GameEnd = true;
            }
        }

        /// <summary>
        /// Decrease score.
        /// </summary>
        public static void DecreaseScore()
        {
            CurrentScore--;
        }

    }
}
