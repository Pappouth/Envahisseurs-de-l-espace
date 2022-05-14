using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Bullet: Sprite
    {
        private Ship _ship;

        public Bullet(Texture2D SpriteTexture, float Speed, Vector2 Position, Ship Ship): base(SpriteTexture, Speed, Position)
        {
            _ship = Ship;
            _position.X -= (float)_ship._bulletTexture.Width/2;
        }

        public override void Update()
        {
            _position.Y -= _speed;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}