using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Ennemy: Ship
    {
        public Ennemy(Texture2D SpriteTexture, float Speed, Vector2 Position, Texture2D BulletTexture): base(SpriteTexture, Speed, Position, BulletTexture)
        {

        }

        public override void Update(List<Sprite> bulletsList)
        {
            shotBullet(bulletsList);
        }
    }
}