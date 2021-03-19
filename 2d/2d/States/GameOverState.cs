using _2d.Controls;
using _2d.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _2d.States
{
    public class GameOverState : State
    {
        private List<Component> _components;
        private SpriteFont _font;
        private readonly string _gameOverText = "GAME OVER!";

        public GameOverState(Game1 game, ContentManager content)
            : base(game, content)
        {
            
        }

        public override void LoadContent()
        {
            var bg = _content.Load<Texture2D>("bg");
            var buttonTexture = _content.Load<Texture2D>("button");
            _font = _content.Load<SpriteFont>("game");

            _components = new List<Component>()
            {
                new Sprite(bg)
                {
                    Layer = 0f,
                    Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2)
                },
                new Button(buttonTexture, _font )
                {
                    Text = "To mainscreen",
                    Position = new Vector2(Game1.ScreenWidth / 2, 400),
                    Click = new EventHandler(Button_Mainscreen_Clicked),
                    Layer = 0.1f
                },
                new Button(buttonTexture, _font )
                {
                    Text = "Quit",
                    Position = new Vector2(Game1.ScreenWidth / 2, 440),
                    Click = new EventHandler(Button_Exit_Clicked),
                    Layer = 0.1f
                },
            };
        }

        private void Button_Mainscreen_Clicked(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _content));
        }

        private void Button_Exit_Clicked(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime, null);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(_font, _gameOverText, 
                new Vector2((Game1.ScreenWidth / 2) - (_font.MeasureString(_gameOverText).X / 2), 300), Color.White);

            spriteBatch.End();
        }
    }
}
