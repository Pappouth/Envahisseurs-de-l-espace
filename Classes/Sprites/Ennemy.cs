using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Ennemy: Ship
    {
        public Ennemy(Texture2D SpriteTexture): base(SpriteTexture)
        {

        }

        public override void Update(GameTime gameTime)
        {
            // shootBullet();
        }
    }
}