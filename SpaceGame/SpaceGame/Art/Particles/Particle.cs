using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame.Art.Particles
{
    public class Particle : Basics
    {
        //Struct with all attributes about the particle
        public ParticleData data;
        //Particle texture
        protected Texture2D texture;
        

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);

            spriteBatch.Draw(texture, data.Position, null, data.ModColor, 0f, new Vector2(texture.Width / 2, texture.Height / 2), data.Scaling, SpriteEffects.None, 1f);  
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            //Each update, time is increase
            data.BirthTime++;
            //Position is updated to move tha particle around the space
            data.Position += data.direction;
            
        }

        public virtual bool isAlive()
        {
            //Test if particle is alive
            return data.BirthTime < data.MaxAge;          
        }

        public struct ParticleData
        {
            public float BirthTime;
            public float MaxAge;
            public Vector2 direction;
            public Vector2 Position;
            public float Scaling;
            public Color ModColor;
        }
    }
}
