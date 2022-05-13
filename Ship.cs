using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Envahisseurs_de_l_espace
{
    public class Ship: Sprite
    {
        // Attributs
        public Bullet _bullet;

        // Constructeur
        public Ship(Texture2D Texture, float Speed): base(Texture, Speed)
        {
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
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                addBullet();
            }
        }

        public void addBullet()
        {
            var boullette = _bullet.Clone() as Bullet;
            boullette._position = this._position;
        }
    }
}