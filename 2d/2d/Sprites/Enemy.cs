using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _2d.Sprites
{
    public class Enemy : Sprite
    {
        public int Health { get; set; }

        public bool IsDead = false;

        public bool DropsItem = false;

        private readonly Dictionary<bool, int> _itemDropChance;

        public Enemy(Texture2D texture)
            : base(texture)
        {
            _itemDropChance = new Dictionary<bool, int>()
            {
                { true, 20 },
                { false, 80 }
            };
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public void DetermineItemDropChance()
        {
            // todo: increase drop chance by increased difficulty
            var weight = Game1.Random.Next(100);

            foreach (var drop in _itemDropChance)
            {
                var value = drop.Value;

                if (weight >= value)
                {
                    weight -= value;
                }
                else
                {
                    if (drop.Key == true)
                    {
                        DropsItem = true;
                        break;
                    } 
                    else
                    {
                        DropsItem = false;
                    }
                }
            }

            Console.WriteLine("Can drop item? " + DropsItem.ToString());
        }
    }
}
