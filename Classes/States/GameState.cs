﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Envahisseurs_de_l_espace
{
    public class GameState: State
    {
        private List<Sprite> _spritesList;

        private Texture2D _background;
        public GameState(Game1 game, ContentManager content): base(game, content)
        {

        }

        public override void LoadContent()
        {
            _background = _content.Load<Texture2D>("ciel");

            var playerShipTexture = _content.Load<Texture2D>("player ship");
            var playerBulletTexture = _content.Load<Texture2D>("small player bullet");
            var playerBullet = new Bullet(playerBulletTexture);

            var ennemyShipTexture = _content.Load<Texture2D>("ennemy ship");
            var ennemyBulletTexture = _content.Load<Texture2D>("small player bullet");
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

        public override void PostUpdate(GameTime gameTime)
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
                foreach (var child in _spritesList[i].Children)
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

        public override void Update(GameTime gameTime)
        {
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //     Exit();

            foreach (var sprite in _spritesList)
                sprite.Update(gameTime);

            PostUpdate(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            foreach (var sprite in _spritesList)
                sprite.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}