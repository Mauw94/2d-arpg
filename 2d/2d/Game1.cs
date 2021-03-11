using System.Collections.Generic;
using _2d.Engine.Entities;
using _2d.Engine.EntityHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2d
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private EntityManager _entityManager;
        private GameHelper _boundsHelper;
        private KeyboardState KeyboardState;
        private Player _player;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();

            _boundsHelper = new GameHelper(_graphics);

            _entityManager = new EntityManager(Services, _boundsHelper, _graphics);
            _player = _entityManager.CreatePlayer();
            _entityManager.AddMultipleEnemies(5);

            _player.Initialize(null);

            foreach (var enemy in EntityManager.Enemies.ToArray())
            {
                enemy.Initialize(_player);
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            _player.Update(gameTime, KeyboardState);

            foreach (var enemy in EntityManager.Enemies.ToArray())
            {
                enemy.Update(gameTime, KeyboardState);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _player.Draw(_spriteBatch);

            foreach (var enemy in EntityManager.Enemies.ToArray())
            {
                enemy.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
