using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Sprite
    {
        public Texture2D _texture;
        public Vector2 _position;
        public float _speed;
        public Rectangle _rect;

        public Sprite(Texture2D SpriteTexture, float Speed, Vector2 Position)
        {
            _texture = SpriteTexture;
            _speed = Speed;
            _position = Position;
            _rect = new Rectangle((int)this._position.X, (int)this._position.Y, this._texture.Width, this._texture.Height);
        }

        public virtual void Update(List<Sprite> sprites)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}