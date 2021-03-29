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
        private ItemManager _itemManager;

        private List<Sprite> _sprites;
        private bool _hasStarted = false;

        private Texture2D _playerTexture;
        private Texture2D _fireballTexture;

        private List<Texture2D> _alienTextures;

        private SpriteFont _gameFont;

        private Player _player;

        public GameState(Game1 game, ContentManager content) 
            : base(game, content)
        {

        }

        public override void LoadContent()
        {
            // Initialize managers.
            _enemyManager = new EnemyManager();
            _itemManager = new ItemManager(_content);
            _scoreManager = ScoreManager.Load();

            _playerTexture = _content.Load<Texture2D>("player");
            _fireballTexture = _content.Load<Texture2D>("fireball");

            _alienTextures = new List<Texture2D>
            {
                _content.Load<Texture2D>("alien"),
                _content.Load<Texture2D>("redalien")
            };

            _gameFont = _content.Load<SpriteFont>("game");

            Player.Score.PlayerName = "Johny";

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
            {
                _scoreManager.AddScore(Player.Score);
                ScoreManager.Save(_scoreManager);
                _game.ChangeState(new GameOverState(_game, _content));
            }

            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    if (_sprites[i] is Enemy enemy)
                    {
                        if (enemy.IsDead)
                        {
                            if (enemy.DropsItem)
                                _sprites.Add(_itemManager.GenerateItem(ItemGenerator.GetItemToDrop(), enemy.Position));

                            _enemyManager.RemoveEnemy(enemy);
                            _sprites.Add(_enemyManager.SpawnAlien(_alienTextures));
                        }
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

            spriteBatch.DrawString(_gameFont, "Score: " + Player.Score.Value, new Vector2(10, 15), Color.White);

            spriteBatch.DrawString(_gameFont, "Health: " + _player.HealthPoints.ToString(), 
                new Vector2(Game1.ScreenWidth / 2, 15), Color.White);

            spriteBatch.End();
        }


        /// <summary>
        /// Restart the game.
        /// </summary>
        void Restart()
        {
            var alien = _enemyManager.SpawnAlien(_alienTextures);
            var alien2 = _enemyManager.SpawnAlien(_alienTextures);

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
                alien,
                alien2
            };

            _hasStarted = true;
        }

    }
}
