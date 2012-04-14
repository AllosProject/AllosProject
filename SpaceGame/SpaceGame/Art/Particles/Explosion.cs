using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceGame.Other;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame.Art.Particles
{
    public class Explosion : Particle
    {
        private float angle;

        private double timer;

        private double lifeTime;

        public Explosion(Vector2 position, float size, Vector2 direction)
        {
            Texture = Art.Images.getParticleSprite("explosion");
            ParticleManager.getDirection(this);
            data.Position = position;
            data.Scaling = size > 0.3f ? 0.3f : size;
            data.ModColor = Util.getNextInt(0,2) == 1 ? Color.White : Color.Gray;
            angle = (float)Util.getNextDouble();
            timer = 0;
            lifeTime = 500;
        }

        public override void update(GameTime gameTime)
        {
            
            angle += 0.02f;
            data.Scaling += 0.005f;
            timer += gameTime.ElapsedGameTime.Milliseconds;

            data.ModColor = Util.getNextInt(0,2) < 1 ? Color.Gray : Color.White;
            base.update(gameTime);
        }

        public override bool isAlive()
        {
            return timer < lifeTime;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, data.Position, null, data.ModColor,angle, new Vector2(texture.Width / 2, texture.Height / 2), data.Scaling, SpriteEffects.None, 0);  
        }
    }
}
