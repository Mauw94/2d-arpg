using _2d.Sprites;
using System;
using System.Collections.Generic;

namespace _2d.Helpers
{
    public class CollisionHelper
    {
        public static void CheckScreenBounds(Sprite sprite)
        {
            if (sprite.Rectangle.Right - sprite.Rectangle.Width >= Game1.ScreenWidth)
                sprite.Position.X = 0 + sprite.Rectangle.Width;
            if (sprite.Rectangle.Left <= 0)
                sprite.Position.X = Game1.ScreenWidth;
            if (sprite.Rectangle.Top <= 0)
                sprite.Position.Y = Game1.ScreenHeight - sprite.Rectangle.Height;
            if (sprite.Rectangle.Bottom - sprite.Rectangle.Height >= Game1.ScreenHeight)
                sprite.Position.Y = 0;
        }

        public static void CheckCollisionWithEntities(Player player, List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite is Player)
                    continue;

                if (sprite is Enemy enemy)
                    if (enemy.Rectangle.Intersects(player.Rectangle))
                    {
                        enemy.IsRemoved = true;
                        enemy.IsDead = true;
                        player.LooseHealth();
                    }

                if (sprite is Item item)
                {
                    if (player.Rectangle.Intersects(item.Rectangle))
                    {
                        item.IsRemoved = true;
                        item.ExecuteEffectOnPlayer(player);
                    }
                }
            }
        }
    }
}
