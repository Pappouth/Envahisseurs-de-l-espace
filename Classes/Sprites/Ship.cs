using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Ship: Sprite
    {
        public Bullet Bullet;

        public Ship(Texture2D SpriteTexture): base(SpriteTexture)
        {
            
        }

        public override void OnCollide(Sprite sprite, GameTime gameTime)
        {
            
        }
        
        public override void Update(GameTime gameTime)
        {
            
        }

        public void shootBullet()
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Parent = this;
            bullet.Speed = 10f;
            bullet.Life = 2f;
            bullet.Damages = this.Damages;

            if (bullet.Parent is Player)
                bullet.Position = new Vector2(this.Position.X, this.Position.Y - 150);
            if (bullet.Parent is Enemy)
                bullet.Position = new Vector2(this.Position.X, this.Position.Y + 150);

            Children.Add(bullet);
        }
    }
}