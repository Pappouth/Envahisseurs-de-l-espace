using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Envahisseurs_de_l_espace
{
    public class Bullet: Sprite
    {
        private float _timer;

        public Bullet(Texture2D spriteTexture): base(spriteTexture)
        {
            
        }

        public override void OnCollide(Sprite sprite, GameTime gameTime)
        {
            if (this.Parent == sprite || this.Parent == sprite.Parent || (this.Parent is Player && sprite is Bullet) || (this.Parent is Enemy && sprite is Enemy))
                return;

            if ((this.Parent is Player && sprite is Enemy) || (this.Parent is Enemy && sprite is Player))
                sprite.Life -= this.Damages;

            if (this.Parent is Player)
            {
                // Combo
                var hitTimer = this.Parent.HitTimer;
                if (hitTimer >= this.Parent.ComboCoolDown)
                    this.Parent.Combo = 1;
                else
                    this.Parent.Combo += 1;

                this.Parent.HitTimer = 0;

                this.Parent.Score += 10*this.Parent.Combo;
            }
            IsDead = true;
        }

        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= Life)
                IsDead = true;
                
            if (this.Parent is Player)
                Position.Y -= Speed;
            
            else if (this.Parent is Enemy)
                Position.Y += Speed;
        }
    }
}