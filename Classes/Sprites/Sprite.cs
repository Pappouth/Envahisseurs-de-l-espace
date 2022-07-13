using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Envahisseurs_de_l_espace
{
    public class Sprite: ICloneable
    {
        protected Texture2D _texture;
        public Vector2 Position;
        public Vector2 Origin;
        // public float Rotation;
        // protected KeyboardState _currentKey;
        // protected KeyboardState _previousKey;
        public float Speed;
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
            }
        }
        public List<Sprite> Children { get; set; }
        // public Color Color;
        // public Vector2 Direction;
        // public float RotationVelocity = 3f;
        public Sprite Parent;
        public float Life;
        public float CollidingDamages;
        public bool IsDead = false;
        public readonly Color[] TextureData;
        public Matrix SpriteTransform
        {
            get
            {
                return
                    Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                    // Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateTranslation(new Vector3(Position, 0));
            }
        }

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

        // public bool Intersects(Sprite sprite)
        // {
        //     var TransformAToB = this.SpriteTransform * Matrix.Invert(sprite.SpriteTransform);

        //     var stepX = Vector2.TransformNormal(Vector2.UnitX, TransformAToB);
        //     var stepY = Vector2.TransformNormal(Vector2.UnitY, TransformAToB);

        //     var yPosinB = Vector2.Transform(Vector2.Zero, TransformAToB);

        //     for (int yA = 0; yA < this.Rect.Height; yA++)
        //     {
        //         var posInB = yPosinB;

        //         for (int xA = 0; xA < this.Rect.Width; xA++)
        //         {
        //             var xB = (int)Math.Round(posInB.X);
        //             var yB = (int)Math.Round(posInB.Y);

        //             if (0 <= xB && xB < sprite.Rect.Width && 0<= yB && yB < sprite.Rect.Height)
        //             {
        //                 var colorA = this.TextureData[xA + yA * this.Rect.Width];
        //                 var colorB = sprite.TextureData[xB + yB * this.Rect.Width];

        //                 if (colorA.A != 0 && colorB.A != 0)
        //                 {
        //                     return true;
        //                 }
        //             }
        //             posInB += stepX;
        //         }
        //         yPosinB += stepY;
        //     }
        //     return false;
        // }

        public virtual void OnCollide(Sprite sprite)
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}