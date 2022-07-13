using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Bullet: Sprite
    {
        private float _timer;

        public Bullet(Texture2D SpriteTexture): base(SpriteTexture)
        {
            
        }

        public override void OnCollide(Sprite sprite)
        {
            if (sprite == this.Parent)
                return;
            
            if (sprite is Bullet)
                return;
            
            IsDead = true;
        }

        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= Life)
                IsDead = true;
                
            if (Parent.GetType() == typeof(Player))
                Position.Y -= Speed;
            
            else if (Parent.GetType() == typeof(Ennemy))
                Position.Y += Speed;
        }
    }
}