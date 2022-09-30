using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Envahisseurs_de_l_espace
{
    public class Sprite: ICloneable
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Origin;
        public float Speed;
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, Texture.Width, Texture.Height);
            }
        }
        public List<Sprite> Children { get; set; }
        public Sprite Parent;
        public float Life;
        public bool IsDead = false;
        public float Damages;
        public int Score;
        public int Combo;
        public int ComboCoolDown;
        public int HitTimer = 0;

        public Sprite(Texture2D spriteTexture)
        {
            Texture = spriteTexture;

            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2); // origine du centre du sprite

            Children = new List<Sprite>();
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
        
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0, Origin, 1, SpriteEffects.None, 0);
        }

        public virtual void OnCollide(Sprite sprite, GameTime gameTime)
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}