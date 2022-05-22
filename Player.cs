using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Envahisseurs_de_l_espace
{
    public class Player: Ship
    {
        KeyboardState _previousKey;
        KeyboardState _currentKey;

        public Player(Texture2D SpriteTexture, float Speed, Vector2 Position, Texture2D BulletTexture): base(SpriteTexture, Speed, Position, BulletTexture)
        {

        }

        public override void Update(List<Sprite> bulletsList)
        {
            // déplacement
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                this._position.Y -= _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                this._position.Y += _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                this._position.X -= _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this._position.X += _speed;
            }

            // tir bullet
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();
            if (_previousKey.IsKeyUp(Keys.Space) && _currentKey.IsKeyDown(Keys.Space))
            {
                shotBullet(bulletsList);
            }
        }              
    }
}