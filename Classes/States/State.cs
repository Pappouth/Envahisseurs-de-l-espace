using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public abstract class State
    {
        protected ContentManager _content;

        protected Game1 _game;

        protected Texture2D _background;

        protected List<Component> _components;

        public State(Game1 game, ContentManager content)
        {
            _game = game;

            _content = content;
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
