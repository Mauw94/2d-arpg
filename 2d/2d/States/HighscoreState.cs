using _2d.Controls;
using _2d.Managers;
using _2d.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _2d.States
{
    public class HighscoreState : State
    {
        private SpriteFont _font;
        private ScoreManager _scoreManager;
        private List<Component> _components;

        public HighscoreState(Game1 game, ContentManager content)
            : base(game, content)
        {

        }

        public override void LoadContent()
        {
            var bg = _content.Load<Texture2D>("bg");
            var buttonTexture = _content.Load<Texture2D>("button");

            _font = _content.Load<SpriteFont>("game");
            _scoreManager = ScoreManager.Load();

            _components = new List<Component>()
            {
                new Sprite(bg)
                {
                    Layer = 0f,
                    Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2)
                },
                new Button(buttonTexture, _font)
                {
                    Text = "To mainscreen",
                    Position = new Vector2(Game1.ScreenWidth / 2, 550),
                    Click = new EventHandler(Button_Mainscreen_Clicked),
                    Layer = 0.1f
                }
            };
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var comp in _components)
                comp.Update(gameTime, null);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var comp in _components)
                comp.Draw(gameTime, spriteBatch);

            for (int i = 0; i < _scoreManager.HighScores.Count; i++)
            {
                var scoreText = (i + 1) + "." + " Player: " +
                    _scoreManager.HighScores[i].PlayerName + " - Score: " + _scoreManager.HighScores[i].Value.ToString();

                spriteBatch.DrawString(_font, scoreText, 
                    new Vector2(Game1.ScreenWidth / 2 - _font.MeasureString(scoreText).X / 2, 200 + (i * 20)), Color.White);
            }

            spriteBatch.End();
        }

        private void Button_Mainscreen_Clicked(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _content));
        }

    }
}
