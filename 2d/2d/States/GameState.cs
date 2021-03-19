using _2d.Managers;
using _2d.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _2d.States
{
    public class GameState : State
    {
        private EnemyManager _enemyManager;
        private ScoreManager _scoreManager;

        private List<Sprite> _sprites;
        private bool _hasStarted = false;

        private Texture2D _playerTexture;
        private Texture2D _alienTexture;
        private Texture2D _fireballTexture;

        private SpriteFont _gameFont;

        private Player _player;

        public GameState(Game1 game, ContentManager content) 
            : base(game, content)
        {

        }

        public override void LoadContent()
        {
            // Initialize managers.
            // todo: score manager
            _enemyManager = new EnemyManager();
            _scoreManager = ScoreManager.Load();

            _playerTexture = _content.Load<Texture2D>("player");
            _fireballTexture = _content.Load<Texture2D>("fireball");
            _alienTexture = _content.Load<Texture2D>("alien");

            _gameFont = _content.Load<SpriteFont>("game");

            Console.WriteLine("## loaded game content ##");

            Restart();
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.ChangeState(new MenuState(_game, _content));

            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            if (_player.HasDied)
                _game.ChangeState(new GameOverState(_game, _content));

            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    if (_sprites[i] is Player player)
                        if (player.HasDied)
                        {
                            _scoreManager.AddScore(player.Score);
                            ScoreManager.Save(_scoreManager);
                        }

                    if (_sprites[i] is Enemy enemy)
                    {
                        _enemyManager.RemoveEnemy(enemy);
                        // Spawn new enemy.
                        _sprites.Add(_enemyManager.SpawnAlien(_alienTexture));
                    }

                    _sprites.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw game entities.
            spriteBatch.Begin();
  
            foreach (var sprite in _sprites)
                sprite.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(_gameFont, _player.HealthPoints.ToString() + "/" + Player.MaxHealth.ToString(), 
                new Vector2(Game1.ScreenWidth / 2, 15), Color.Red);

            spriteBatch.End();
        }


        /// <summary>
        /// Restart the game.
        /// </summary>
        void Restart()
        {
            var alien = _enemyManager.SpawnAlien(_alienTexture);
            _player = new Player(_playerTexture)
            {
                Position = new Vector2(_game.graphics.PreferredBackBufferWidth / 2,
                        _game.graphics.PreferredBackBufferHeight / 2),
                Fireball = new Fireball(_fireballTexture),
            };

            EnemyManager.Enemies.Add(alien);

            _sprites = new List<Sprite>()
            {
                _player,
                alien
            };

            _hasStarted = true;
        }

    }
}
