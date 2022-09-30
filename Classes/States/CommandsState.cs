using System;
using System.Collections.Generic;
using Envahisseurs_de_l_espace.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class CommandsState: State
    {
        public CommandsState(Game1 game, ContentManager content): base(game, content)
        {

        }

        public override void LoadContent()
        {
            _background = _content.Load<Texture2D>("Backgrounds/commandes 2");

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

            spriteBatch.End();
        }
    }
}