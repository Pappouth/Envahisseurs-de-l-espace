using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Envahisseurs_de_l_espace
{
    public class Player: Ship
    {
        private KeyboardState _previousKey;
        private KeyboardState _currentKey;

        public Player(Texture2D SpriteTexture): base(SpriteTexture)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            // déplacement
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                this.Position.Y -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                this.Position.Y += Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                this.Position.X -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.Position.X += Speed;
            }

            // tir bullet
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();
            if (_previousKey.IsKeyUp(Keys.Space) && _currentKey.IsKeyDown(Keys.Space))
            {
                shootBullet();
            }
        }
    }
}