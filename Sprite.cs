using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Sprite: ICloneable
    {
        public Texture2D _texture;
        public Vector2 _position;
        public float _speed;

        public Sprite(Texture2D Texture, float Speed)
        {
            _texture = Texture;
            _speed = Speed;
        }

        public virtual void Update()
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}