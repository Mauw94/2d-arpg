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

        public const int MaxHealth = 5;

        // todo: should be equal to MaxHealth in final version
        public int HealthPoints = 2;

        public bool HasDied = false;

        public static Score Score = new Score();

        private float _currentTime = 0f;

        private float _previousLinearVelocity;

        private bool _speedBonusActive = false;

        public Player(Texture2D texture)
            :base(texture)
        {
            
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            _previouseMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            Vector2 mousePos = new Vector2(_currentMouseState.X, _currentMouseState.Y);
            Vector2 dPos = mousePos - this.Position;

            _rotation = (float) Math.Atan2(dPos.Y, dPos.X);

            //if (Keyboard.GetState().IsKeyDown(Keys.A))
            //    _rotation -= MathHelper.ToRadians(RotationVelocity);
            //else if (Keyboard.GetState().IsKeyDown(Keys.D))
            //    _rotation += MathHelper.ToRadians(RotationVelocity);

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                Position += Direction * LinearVelocity;

            if (_currentMouseState.LeftButton == ButtonState.Pressed && _previouseMouseState.LeftButton == ButtonState.Released)
            {
                AddFireball(sprites);
            }

            if (_currentKey.IsKeyDown(Keys.Space) && _previousKey.IsKeyUp(Keys.Space))
                AddFireball(sprites);

            CurrentPosition = Position;

            CollisionHelper.CheckScreenBounds(this);

            CollisionHelper.CheckCollisionWithEntities(this, sprites);

            CheckAndApplySpeedBonus(gameTime);

            base.Update(gameTime, sprites);
        }

        public void LooseHealth()
        {
            HealthPoints--;
            if (HealthPoints <= 0)
            {
                IsRemoved = true;
                HasDied = true;
            }
        }

        public void GainHealth(int health)
        {
            HealthPoints += health;
            if (HealthPoints >= MaxHealth)
                HealthPoints = MaxHealth;
        }

        public void GainSpeedBonus(float speed)
        {
            if (_speedBonusActive)
                return;

            _previousLinearVelocity = LinearVelocity;
            _speedBonusActive = true;
            LinearVelocity += speed;
        }

        public void GainDamage(int damage)
        {
            Console.WriteLine("not implemented yet." + damage);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        private void CheckAndApplySpeedBonus(GameTime gameTime)
        {
            if (_speedBonusActive)
            {
                _currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_currentTime >= SpeedPotion.SpeedBonusTime)
                {
                    _speedBonusActive = false;
                    _currentTime = 0f;
                    LinearVelocity = _previousLinearVelocity;
                }
            }
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
