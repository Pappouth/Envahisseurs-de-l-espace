using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Bullet: Sprite
    {
        public Bullet(Texture2D Texture, float Speed): base(Texture, Speed)
        {

        }

        public override void Update()
        {
            _position.Y += _speed;
        }
    }
}