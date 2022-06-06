using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
    
        private Player _playerShip;
        private Ennemy _ennemyShip;

        private List<Sprite> _bulletsList =  new List<Sprite>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width; 
            int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // PLAYER
            var playerShipTexture = Content.Load<Texture2D>("player ship");
            var playerBulletTexture = Content.Load<Texture2D>("player bullet");
            Vector2 playerShipPos = new Vector2(_graphics.PreferredBackBufferWidth /2 - 100, _graphics.PreferredBackBufferHeight-200);
            _playerShip = new Player(playerShipTexture, 5f, playerShipPos, playerBulletTexture);

            // ENNEMY
            var ennemyShipTexture = Content.Load<Texture2D>("ennemy ship");
            var ennemyBulletTexture = Content.Load<Texture2D>("ennemy bullet");
            Vector2 ennemyShipPos = new Vector2(200, 200);
            _ennemyShip = new Ennemy(ennemyShipTexture, 5f, ennemyShipPos, ennemyBulletTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //     Exit();

            _playerShip.Update(_bulletsList);
            foreach (var bullet in _bulletsList)
            {
                bullet.Update(_bulletsList);
            }

            _ennemyShip.Update(_bulletsList);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            _playerShip.Draw(_spriteBatch); 
            _ennemyShip.Draw(_spriteBatch);

            foreach (var bullet in _bulletsList)
            {
                bullet.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
