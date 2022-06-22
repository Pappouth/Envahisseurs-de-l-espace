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
        public Bullet _bullet;
        public Texture2D _bulletTexture;
        private Vector2 _bulletPosition;

        // Constructeur
        public Ship(Texture2D SpriteTexture, float Speed, Vector2 Position, Texture2D BulletTexture): base(SpriteTexture, Speed, Position)
        {
            _bulletTexture = BulletTexture;
        }

        // Méthodes
        public override void Update(List<Sprite> bulletsList)
        {
            
        }

        public void shotBullet(List<Sprite> bulletsList)
        {
            var bulletPositionX = this._position.X + this._texture.Width/2 - this._bulletTexture.Width/2;
            var bulletPositionY = this._position.Y /*- this._bulletTexture.Height*/;
            _bulletPosition = new Vector2(bulletPositionX, bulletPositionY);
            _bullet = new Bullet(this._bulletTexture, 10f, this._bulletPosition, this);
            // this._bullet.Update();
            bulletsList.Add(_bullet);
        }
    }
}