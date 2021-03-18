using _2d.Sprites;
using System.Collections.Generic;

namespace _2d.Helpers
{
    public class CollisionHelper
    {
        public static void CheckScreenBounds(Sprite sprite)
        {
            if (sprite.Rectangle.Right - sprite.Rectangle.Width >= Game1.ScreenWidth)
                sprite.Position.X = Game1.ScreenWidth;
            if (sprite.Rectangle.Left <= 0)
                sprite.Position.X = 0;
            if (sprite.Rectangle.Top <= 0)
                sprite.Position.Y = 0;
            if (sprite.Rectangle.Bottom - sprite.Rectangle.Height >= Game1.ScreenHeight)
                sprite.Position.Y = Game1.ScreenHeight;
        }

        public static void CheckCollisionWithEnemy(Player player, List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite is Player)
                    continue;

                // todo: this code is bugged.
                if (sprite is Enemy)
                    if (sprite.Rectangle.Intersects(player.Rectangle))
                        player.LooseHealth();
            }
        }
    }
}
