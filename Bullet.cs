using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Bullet: Sprite
    {
        public Bullet(Texture2D SpriteTexture, float Speed, Vector2 Position): base(SpriteTexture, Speed, Position)
        {
            
        }

        public override void Update(List<Sprite> sprites)
        {
            _position.Y -= _speed;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}