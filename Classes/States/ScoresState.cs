using System;
using System.Collections.Generic;
using System.IO;
using Envahisseurs_de_l_espace.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace Envahisseurs_de_l_espace
{
    public class ScoresState: State
    {
        private TextBox _scoresTextBox;
        private List<int> _scoresList;

        public ScoresState(Game1 game, ContentManager content): base(game, content)
        {

        }

        public override void LoadContent()
        {
            // Background
            _background = _content.Load<Texture2D>("Backgrounds/piste décollage");

            // Scores
            var scores = JsonConvert.DeserializeObject<List<Dictionary<string, int>>>(File.ReadAllText("Scores.json"));
            string json = JsonConvert.SerializeObject(scores);
            File.WriteAllText("Scores.json", json);
            
            _scoresList = new List<int>();
            foreach (var score in scores)
            {
                _scoresList.Add(score["score"]);
            }
            _scoresList.Sort((a, b) => b.CompareTo(a));

            _scoresTextBox = new TextBox(_content.Load<Texture2D>("Controls/scores"), _content.Load<SpriteFont>("Fonts/Font"))
            {

            };
            _scoresTextBox.Position = new Vector2(Game1.ScreenWidth/2 - _scoresTextBox.Texture.Width/2, Game1.ScreenHeight/2 - _scoresTextBox.Texture.Height/2);

            foreach (var score in _scoresList)
            {
                _scoresTextBox.Text += score.ToString() + "\n";
            }

            // buttons
            var buttonTexture = _content.Load<Texture2D>("Controls/blue button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var buttonXPos = Game1.ScreenWidth/2 - buttonTexture.Width/2;

            var mainMenuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(buttonXPos, /*Game1.ScreenHeight / 3*/100),
                Text = "Main menu"
            };
            mainMenuButton.Click += MainMenuButton_Click;

            _components = new List<Component>()
            {
                mainMenuButton
            };
        }

        public void MainMenuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _content));
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            _scoresTextBox.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}