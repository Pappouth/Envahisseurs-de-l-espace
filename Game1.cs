using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Envahisseurs_de_l_espace
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private State _currentState;
        private State _nextState;

        public static int ScreenWidth;
        public static int ScreenHeight;

        private Song _gameMusic;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            _gameMusic = Content.Load<Song>("Sounds/quantum eraser");
            MediaPlayer.Play(_gameMusic);
            MediaPlayer.IsRepeating = true;

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, Content);
            _currentState.LoadContent();

            _nextState = null;
        }

        protected override void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _currentState = _nextState;
                _currentState.LoadContent();

                _nextState = null;
            }

            _currentState.Update(gameTime);

            base.Update(gameTime);
        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _currentState.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}
