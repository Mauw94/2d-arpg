using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2d.Sprites
{
    public class SpeedPotion : Item
    {
        public static float SpeedBonusTime = 2f;

        private readonly float _speed = 3f;

        public SpeedPotion(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void ExecuteEffectOnPlayer(Player player)
        {
            player.GainSpeedBonus(_speed);
        }
    }
}
