using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceGame.Other;

namespace SpaceGame.Art.Particles
{
    class Smoke : Particle
    {
        public Smoke(Vector2 position, float size, Vector2 direction)
        {
            Texture = Art.Images.getParticleSprite("smoke");
            data.MaxAge = 60;
            data.BirthTime = 0;
            ParticleManager.getDirection(this);
            data.Position = position;
            data.Scaling = size;
            data.ModColor = Util.getNextInt(0,2) == 1 ? Color.White : Color.Gray;            
        }
    }
}
