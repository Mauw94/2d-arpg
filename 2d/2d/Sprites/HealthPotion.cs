using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2d.Sprites
{
    public class HealthPotion : Item
    {
        private readonly int _health = 1;

        public HealthPotion(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void ExecuteEffectOnPlayer(Player player)
        {
            player.GainHealth(_health);
        }
    }
}
