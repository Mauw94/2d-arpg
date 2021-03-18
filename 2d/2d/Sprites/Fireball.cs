using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _2d.Sprites
{
    public class Fireball : Sprite
    {
        private float _timer;

        public Fireball(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move(gameTime);

            CheckForEnemyHit(sprites);

            base.Update(gameTime, sprites);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        void Move(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= LifeSpan)
                IsRemoved = true;

            Position += Direction * LinearVelocity;
        }

        void CheckForEnemyHit(List<Sprite> sprites)
        {
            // todo: rework hit
            // todo: player needs score increased
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if (sprite is GreenAlien)
                {
                    if (this.Rectangle.Intersects(sprite.Rectangle))
                        sprite.IsRemoved = true;
                }
            }
        }
    }
}
