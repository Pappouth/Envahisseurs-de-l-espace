using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;

namespace Envahisseurs_de_l_espace
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> _spritesList;

        private Texture2D _background;
        
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

            _background = Content.Load<Texture2D>("ciel");
            
            var playerShipTexture = Content.Load<Texture2D>("player ship");
            var playerBulletTexture = Content.Load<Texture2D>("small player bullet");
            var playerBullet = new Bullet(playerBulletTexture);

            var ennemyShipTexture = Content.Load<Texture2D>("ennemy ship");
            var ennemyBulletTexture = Content.Load<Texture2D>("ennemy bullet");
            var ennemyBullet = new Bullet(ennemyBulletTexture);

            _spritesList = new List<Sprite>()
            {
                new Player(playerShipTexture)
                {
                    Bullet = playerBullet,
                    Position = new Vector2(200, 500),
                    Life = 100f,
                    Speed = 5f
                },
                // new Ennemy(ennemyShipTexture)
                // {
                //     Bullet = ennemyBullet,
                //     Position = new Vector2(200, 200)
                // },
                new Sprite(ennemyShipTexture)
                {
                    Position = new Vector2(200, 200),
                    CollidingDamages = 10f
                }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //     Exit();
            
            foreach (var sprite in _spritesList)
                sprite.Update(gameTime);

            PostUpdate();

            base.Update(gameTime);
        }

        protected void PostUpdate()
        {
            foreach (var spriteA in _spritesList)
            {
                foreach (var spriteB in _spritesList)
                {
                    if (spriteA == spriteB)
                        continue;
                    
                    if (spriteA.Rect.Intersects(spriteB.Rect))
                        spriteA.OnCollide(spriteB);
                }
            }

            int count = _spritesList.Count;
            for (int i = 0; i < count; i++)
            {
                foreach(var child in _spritesList[i].Children)
                    _spritesList.Add(child);
                
                _spritesList[i].Children.Clear();
            }

            for (int i = 0; i < _spritesList.Count; i++)
            {
                if (_spritesList[i].IsDead)
                {
                    _spritesList.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            foreach (var sprite in _spritesList)
                sprite.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
