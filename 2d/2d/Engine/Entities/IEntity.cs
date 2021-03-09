using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2d.Engine.Entities
{
    /// <summary>
    /// Interface defining entity methods.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Initialize entity.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Update entity.
        /// </summary>
        void Update(GameTime gameTime, KeyboardState keyboardState);

        /// <summary>
        /// Draw entity.
        /// </summary>
        void Draw(SpriteBatch spriteBatch);
    }
}
