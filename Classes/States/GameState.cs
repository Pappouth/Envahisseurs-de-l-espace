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
    public class GameState: State
    {
        private List<Sprite> _spritesList;
        private List<TextBox> _textBoxesList;

        private TextBox _playerLife;
        private TextBox _playerScore;
        private TextBox _playerCombo;
        private Player _player;
        private Enemy _enemy;

        private Texture2D _gameOverOverlay;
        private TextBox _gameOverText;

        private Button _mainMenuButton;

        public GameState(Game1 game, ContentManager content): base(game, content)
        {

        }

        public override void LoadContent()
        {
            _background = _content.Load<Texture2D>("Backgrounds/ciel");

            // Load save
            var saveData = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("Save.json"));

            // Sprites
            var playerShipTexture = _content.Load<Texture2D>("Sprites/player ship");
            var playerBulletTexture = _content.Load<Texture2D>("Sprites/small player bullet");
            var playerBullet = new Bullet(playerBulletTexture);
            _player = new Player(playerShipTexture)
            {
                Bullet = playerBullet,
                Life = (float)saveData["playerLife"],
                Speed = 8f,
                Damages = 10f,
                ShotCoolDown = 25,
                ComboCoolDown = 90,
                Score = saveData["playerScore"],
                Combo = saveData["playerCombo"]
            };
            _player.Position = new Vector2(Game1.ScreenWidth/2 - _player.Texture.Width/2, Game1.ScreenHeight - _player.Texture.Height/2);

            var ennemyShipTexture = _content.Load<Texture2D>("Sprites/ennemy ship");
            var ennemyBulletTexture = _content.Load<Texture2D>("Sprites/small ennemy bullet");
            var ennemyBullet = new Bullet(ennemyBulletTexture);
            _enemy = new Enemy(ennemyShipTexture)
            {
                Bullet = ennemyBullet,
                Life = 10000000000000000000000000f,
                Speed = (float)saveData["enemySpeed"],
                Damages = 10f,
                ShotInterval = saveData["enemyShotInterval"]
            };
            _enemy.Position = new Vector2(saveData["enemyXPos"], saveData["enemyYPos"]);

            _spritesList = new List<Sprite>()
            {
                _player,
                _enemy
            };
            
            // Text boxes
            _playerLife = new TextBox(_content.Load<Texture2D>("Controls/combo"), _content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(0, 0),
                Text = _player.Life.ToString()
            };

            _playerScore = new TextBox(_content.Load<Texture2D>("Controls/score"), _content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(173, 0),
                Text = _player.Score.ToString()
            };

            _playerCombo = new TextBox(_content.Load<Texture2D>("Controls/combo"), _content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(487, 0),
                Text = "x" + _player.Combo.ToString()
            };

            _textBoxesList = new List<TextBox>
            {
                _playerLife,
                _playerScore,
                _playerCombo
            };

            // Buttons
            var buttonTexture = _content.Load<Texture2D>("Controls/blue button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var buttonXPos = Game1.ScreenWidth - buttonTexture.Width;

            _mainMenuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(buttonXPos, 0),
                Text = "Main menu"
            };
            _mainMenuButton.Click += MainMenuButton_Click;

            _components = new List<Component>()
            {
                _mainMenuButton
            };
        }

        public void MainMenuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _content));

            if (!_player.IsDead)
            {
                var saveData = new Dictionary<String, int>()
                {
                    ["playerLife"] = (int)_player.Life,
                    ["playerScore"] = _player.Score,
                    ["playerCombo"] = _player.Combo,
                    ["enemySpeed"] = (int)_enemy.Speed,
                    ["enemyShotInterval"] = _enemy.ShotInterval,
                    ["enemyXPos"] = (int)_enemy.Position.X,
                    ["enemyYPos"] = (int)_enemy.Position.Y
                };
            
                string json = JsonConvert.SerializeObject(saveData);
                File.WriteAllText("Save.json", json);
            }
        }

        public override void Update(GameTime gameTime)
        {
            // Buttons
            foreach (var component in _components)
                component.Update(gameTime);

            // Chargement des sprites
            foreach (var sprite in _spritesList)
            {
                sprite.Update(gameTime);
                if (sprite is Player)
                {
                    // Combo
                    sprite.HitTimer++;
                    if (sprite.HitTimer >= sprite.ComboCoolDown)
                        sprite.Combo = 1;
                    
                    _playerLife.Text = sprite.Life.ToString();
                    _playerScore.Text = sprite.Score.ToString();
                    _playerCombo.Text = "x" + sprite.Combo.ToString();
                }
            }
            
            // Collisions
            foreach (var spriteA in _spritesList)
            {
                foreach (var spriteB in _spritesList)
                {
                    if (spriteA == spriteB)
                        continue;

                    if (spriteA.Rect.Intersects(spriteB.Rect))
                        spriteA.OnCollide(spriteB, gameTime);
                }
            }

            // Bullets
            int count = _spritesList.Count;
            for (int i = 0; i < count; i++)
            {
                foreach (var child in _spritesList[i].Children)
                    _spritesList.Add(child);

                _spritesList[i].Children.Clear();
            }

            // Mort de sprite
            for (int i = 0; i < _spritesList.Count; i++)
            {
                if (_spritesList[i].Life <= 0f)
                    _spritesList[i].IsDead = true;

                if (_spritesList[i].IsDead)
                {
                    if (_spritesList[i] is Player)
                    {
                        _playerLife.Text = "0";

                        // écriture du score
                        var scores = JsonConvert.DeserializeObject<List<Dictionary<string, int>>>(File.ReadAllText("Scores.json"));
                        var newScore = new Dictionary<String, int>{ ["score"] = _spritesList[i].Score };
                        scores.Add(newScore);
                        string scoreJson = JsonConvert.SerializeObject(scores);
                        File.WriteAllText("Scores.json", scoreJson);

                        // écriture de la save
                        var saveData = new Dictionary<String, int>()
                        {
                            ["playerLife"] = 1000,
                            ["playerScore"] = 0,
                            ["playerCombo"] = 1,
                            ["enemySpeed"] = 10,
                            ["enemyShotInterval"] = 0,
                            ["enemyXPos"] = Game1.ScreenWidth/2 - _enemy.Texture.Width/2,
                            ["enemyYPos"] = 200
                        };
                        string json = JsonConvert.SerializeObject(saveData);
                        File.WriteAllText("Save.json", json);

                        // game over overlay
                        _gameOverOverlay = _content.Load<Texture2D>("overlays/game over");
                        _gameOverText = new TextBox(_gameOverOverlay, _content.Load<SpriteFont>("Fonts/Font"))
                        {
                            Position = new Vector2(0, 0),
                            Text = "GAME OVER"
                        };
                    }

                    _spritesList.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            foreach (var sprite in _spritesList)
                sprite.Draw(gameTime, spriteBatch);

            foreach (var textBox in _textBoxesList)
                textBox.Draw(gameTime, spriteBatch);

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            if(!(_gameOverText is null))
            {
                _gameOverText.Draw(gameTime, spriteBatch);

                foreach (var component in _components)
                    component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
