using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Envahisseurs_de_l_espace
{
    public class Sprite: ICloneable
    {
        protected Texture2D _texture;
        public Vector2 Position;
        public Vector2 Origin;
        public float Speed;
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
            }
        }
        public List<Sprite> Children { get; set; }
        public Sprite Parent;
        public float Life;
        public float CollidingDamages;
        public bool IsDead = false;
        public readonly Color[] TextureData;

        public Sprite(Texture2D SpriteTexture)
        {
            _texture = SpriteTexture;

            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2); // origine du centre du sprite

            Children = new List<Sprite>();

            TextureData = new Color[_texture.Width * _texture.Height];
            _texture.GetData(TextureData);
        }

        public virtual void Update(GameTime gameTime)
        {

        }
        
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0, Origin, 1, SpriteEffects.None, 0);
        }

        public virtual void OnCollide(Sprite sprite)
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}