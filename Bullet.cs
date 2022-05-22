using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Bullet: Sprite
    {
        public Ship _ship;

        public Bullet(Texture2D SpriteTexture, float Speed, Vector2 Position, Ship Ship): base(SpriteTexture, Speed, Position)
        {
            _ship = Ship;
        }

        public override void Update(List<Sprite> sprites)
        {
            if (_ship.GetType() == typeof(Player))
            {
                _position.Y -= _speed;
            }
            else if (_ship.GetType() == typeof(Ennemy))
            {
                _position.Y += _speed;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}