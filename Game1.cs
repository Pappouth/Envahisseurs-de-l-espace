using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
    
        private Ship _ship;
        private Bullet _bullet;

        private List<Sprite> _bulletsList =  new List<Sprite>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            var shipTexture = Content.Load<Texture2D>("spaceship");
            var bulletTexture = Content.Load<Texture2D>("bullet");

            Vector2 shipPos = new Vector2(100, 100);
            _ship = new Ship(shipTexture, 5f, shipPos, bulletTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //     Exit();

            _ship.Update(_bulletsList);
            foreach (var bullet in _bulletsList)
            {
                bullet.Update(_bulletsList);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _ship.Draw(_spriteBatch);
            foreach (var bullet in _bulletsList)
            {
                bullet.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
