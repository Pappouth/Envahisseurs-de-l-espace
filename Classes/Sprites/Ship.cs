using System.Drawing;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Envahisseurs_de_l_espace
{
    public class Ship: Sprite
    {
        // Attributs
        public Bullet Bullet;
        // public float CollidingDamages;

        // Constructeur
        public Ship(Texture2D SpriteTexture): base(SpriteTexture)
        {
            
        }

        public override void OnCollide(Sprite sprite)
        {
            
        }

        // Méthodes
        public override void Update(GameTime gameTime)
        {
            
        }

        public void shootBullet()
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Parent = this;
            // bullet.Position = this.Position;
            bullet.Position = new Vector2(this.Position.X, this.Position.Y - 150);
            bullet.Speed = 10f;
            bullet.Life = 2f;

            Children.Add(bullet);
        }
    }
}