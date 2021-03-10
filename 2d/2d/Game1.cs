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
        private BoundsHelper _boundsHelper;

        private KeyboardState KeyboardState;
        private Player _player;
        private Enemy _enemy;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _boundsHelper = new BoundsHelper(_graphics);
            _entityManager = new EntityManager(Services, _boundsHelper, _graphics);
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();

          
            _player = new Player(Services, _boundsHelper, _graphics);
            _enemy = _entityManager.AddEnemyEntity();

            _player.Initialize();
            _enemy.Initialize();

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
            _enemy.Update(gameTime, KeyboardState);

            _boundsHelper.DetectEnemyCollision(_player, _enemy);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _player.Draw(_spriteBatch);
            _enemy.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
