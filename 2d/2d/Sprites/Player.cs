using _2d.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _2d.Sprites
{
    public class Player : Sprite
    {
        public Fireball Fireball;

        public static Vector2 CurrentPosition;

        public int HealthPoints = 5;

        public bool HasDied = false;

        public Score Score { get; set; }

        public Player(Texture2D texture)
            :base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                _rotation -= MathHelper.ToRadians(RotationVelocity);
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                _rotation += MathHelper.ToRadians(RotationVelocity);

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                Position += Direction * LinearVelocity;

            if (_currentKey.IsKeyDown(Keys.Space) && _previousKey.IsKeyUp(Keys.Space))
                AddFireball(sprites);

            CurrentPosition = Position;

            CollisionHelper.CheckScreenBounds(this);

            // todo: this code is bugged.
            CollisionHelper.CheckCollisionWithEnemy(this, sprites);

            base.Update(gameTime, sprites);
        }

        internal void LooseHealth()
        {
            // todo: this code is bugged.
            HealthPoints--;
            if (HealthPoints <= 0)
                HasDied = true;

            Console.WriteLine("PLAYER HEALTH: " + HealthPoints);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        private void AddFireball(List<Sprite> sprites)
        {
            var fireball = Fireball.Clone() as Fireball;
            fireball.Direction = this.Direction;
            fireball.Position = this.Position;
            fireball.LinearVelocity = this.LinearVelocity * 2;
            fireball.LifeSpan = 2f;
            fireball.Parent = this;

            sprites.Add(fireball);
        }
    }
}
