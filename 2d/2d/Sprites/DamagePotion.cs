using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2d.Sprites
{
    public class DamagePotion : Item
    {
        private readonly int _damage = 1;

        public DamagePotion(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void ExecuteEffectOnPlayer(Player player)
        {
            player.GainDamage(_damage);
        }
    }
}
