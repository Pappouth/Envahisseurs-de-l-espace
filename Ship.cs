using System.Drawing;
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

        // Constructeur
        public Ship(Texture2D SpriteTexture, float Speed, Vector2 Position, Texture2D BulletTexture): base(SpriteTexture, Speed, Position)
        {
            _bulletTexture = BulletTexture;
        }

        // Méthodes
        public override void Update()
        {
            // déplacement
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                _position.Y -= _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _position.Y += _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                _position.X -= _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _position.X += _speed;
            }

            // tir bullet
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                shotBullet();
            }
        }

        public void shotBullet()
        {
            // _bullet._position.X = this._position.X + this._texture.Width;
            _bullet = new Bullet(this._bulletTexture, 10f, this._position, this);
            this._bullet.Update();
        }
    }
}