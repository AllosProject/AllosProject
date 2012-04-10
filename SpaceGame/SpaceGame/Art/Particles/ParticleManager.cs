using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceGame.Structure;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Other;
using SpaceGame.Enums;

namespace SpaceGame.Art.Particles
{
    public class ParticleManager : Basics
    {
        private static Dictionary<string, List<Particle>> managerList;

        public static Particle createParticle(ParticleEnum particleType,Vector2 position, float size, Vector2 direction)
        {
            Particle particle = new Particle();
            particle.data.Position = position;
            particle.data.Scaling = size;
            particle.data.direction = direction;
            return createParticle(particle,particleType);
        }

        private static Particle createParticle(Particle particle,ParticleEnum particleType)
        {
            if (particleType == ParticleEnum.Smoke)
            {
                Smoke smoke = new Smoke(particle.data.Position, particle.data.Scaling, particle.data.direction);
                smoke.init(null);
                return smoke;
            }
            if (particleType == ParticleEnum.Explosion)
            {
                Explosion explosion = new Explosion(particle.data.Position,particle.data.Scaling,particle.data.direction);
                explosion.init(null);
                return explosion;
            }
            return null;
        }

        public void addParticle(string sourceObject, Particle particle)
        {
            //Verify if managerlist is null
            if (managerList == null)
                managerList = new Dictionary<string, List<Particle>>();
            //verify if the key entry already exist
            if (!managerList.Keys.Contains(sourceObject))
            {
                managerList.Add(sourceObject, new List<Particle>());
            }

            managerList[sourceObject].Add(getParticleType(particle));
        }

        private static Particle getParticleType(Particle particle)
        {
            if (particle is Smoke)
            {
                Smoke smoke = particle as Smoke;
                smoke.init(null);
                return smoke;
            }
            if (particle is Explosion)
            {
                Explosion explosion = particle as Explosion;
                explosion.init(null);
                return explosion;
            }
            return null;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            if (managerList != null)
            {
                string[] keys = managerList.Keys.ToArray();
                int totalParticleList = keys.Length;
                for (int i = 0; i < totalParticleList; i++)
                {
                    List<Particle> list = managerList[keys[i]];
                    int listSize = list.Count;
                    for (int j = 0; j < listSize; j++)
                    {
                        list.ElementAt(j).draw(spriteBatch);
                    }
                }
            }
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            if (managerList != null)
            {
                string[] keys = managerList.Keys.ToArray();
                int totalParticleList = keys.Length;
                for (int i = 0; i < totalParticleList; i++)
                {
                    List<Particle> list = managerList[keys[i]];
                    int listSize = list.Count;
                    for (int j = 0; j < listSize; j++)
                    {

                        Particle particle = list.ElementAt(j);
                        if (particle.isAlive())
                        {
                            particle.update(gameTime);
                        }
                        else
                        {
                            list.RemoveAt(j);
                            listSize--;
                        }
                    }
                }


            }

        }

        public static void getDirection(Particle particle)
        {
            float posXToSet = particle.data.direction.X > 0 ? (float)-Util.getNextDouble() : (float)Util.getNextDouble();
            float posYToSet = particle.data.direction.Y > 0 ? (float)-Util.getNextDouble() : (float)Util.getNextDouble();
            particle.data.direction = new Vector2(posXToSet,posYToSet);
        }

    }
}
