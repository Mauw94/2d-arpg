using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2d.Sprites
{
    public class Alien : Enemy
    {
        public Alien(Texture2D texture)
            : base(texture)
        {
            // todo: spawn x and y in the opposite squares of where the player is atm.
            // todo: enemy cannot spawn near or on top of the player.
            int xPos = Game1.Random.Next(0, Game1.ScreenWidth - texture.Width);
            int yPos = Game1.Random.Next(0, Game1.ScreenHeight - texture.Height);
            int speed = Game1.Random.Next(3, 8);

            Position = new Vector2(xPos, yPos);
            LinearVelocity = speed / 10f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Vector2 direction = Player.CurrentPosition - Position;
            direction.Normalize();
            Position += direction * LinearVelocity;

            base.Update(gameTime, sprites);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
