using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Enemy: Ship
    {
        private int _shotTimer ;
        private bool _xDirection;
        private bool _yDirection;
        private float _yInitialPos;

        private int _accelarationTimer;

        private int _shotIntervalTimer;
        public int ShotInterval;

        public Enemy(Texture2D SpriteTexture): base(SpriteTexture)
        {
            _yInitialPos = 200;
            _shotTimer = 0;
            _shotIntervalTimer = 120;
        }

        public override void Update(GameTime gameTime)
        {
            _accelarationTimer += 1;
            // accélération
            if (_accelarationTimer == 120)
            {
                Speed += 1f;
                _accelarationTimer = 0;
            }

            // déplacement horizontal
            if (Position.X <= 0 + Texture.Width/2)
                _xDirection = true;

            if (Position.X >= 1920 - Texture.Width/2)
                _xDirection = false;

            if (_xDirection)
                Position.X += Speed;
            else
                Position.X -= Speed;

            // déplacement vertical
            if (Position.Y <= _yInitialPos - 150)
                _yDirection = false;
                
            if (Position.Y >= _yInitialPos + 150)
                _yDirection = true;

            if (!_yDirection)
                Position.Y += Speed;
            else
                Position.Y -= Speed;

            // interval de tir
            if (_shotIntervalTimer == 0)
            {
                ShotInterval += 1;
                _shotIntervalTimer = 120;
            }
            _shotIntervalTimer--;


            if (_shotTimer <= 0)
            {
                shootBullet();
                if (_shotTimer >= 0)
                    _shotTimer = 30 - ShotInterval;
                else
                    _shotTimer = 0;
            }
            _shotTimer--;
        }
    }
}