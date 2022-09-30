using System;
using System.Collections.Generic;
using Envahisseurs_de_l_espace.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Envahisseurs_de_l_espace
{
    public class MenuState: State
    {
        public MenuState(Game1 game, ContentManager content): base(game, content)
        {
            
        }

        public override void LoadContent()
        {
            // Background
            _background = _content.Load<Texture2D>("Backgrounds/main menu");

            // Buttons
            var buttonTexture = _content.Load<Texture2D>("Controls/blue button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var buttonXPos = Game1.ScreenWidth/2 - buttonTexture.Width/2;

            var playButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(buttonXPos, 350),
                Text = "Play"
            };
            playButton.Click += PlayButton_Click;

            var scoresButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(buttonXPos, 500),
                Text = "Scores"
            };
            scoresButton.Click += Scores_Click;

            var commandsButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(buttonXPos, 650),
                Text = "Commands"
            };
            commandsButton.Click += Commands_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(buttonXPos, 800),
                Text = "Quit Game",
            };
            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                playButton,
                scoresButton,
                quitGameButton,
                commandsButton
            };
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _content));
        }

        private void Scores_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new ScoresState(_game, _content));
        }

        private void Commands_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new CommandsState(_game, _content));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
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

            spriteBatch.End();
        }
    }
}
