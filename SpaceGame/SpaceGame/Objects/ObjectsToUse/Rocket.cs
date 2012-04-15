using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Objects.Weapons;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using SpaceGame.Control;
using SpaceGame.Art.Particles;
using SpaceGame.Other;
using SpaceGame.Enums;

namespace SpaceGame.Objects.ObjectsToUse
{
    public class Rocket : Bullet
    {

        public Rocket(Vector2 position,float rotation)
        {
            this.Position = position;
            this.Rotation = rotation;
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            this.LaunchSound = @"Bullets\Launch\BottleRocket";
            this.CollideSound = @"Bullets\Collide\GranadeExplosion";
            Texture = Art.Images.getBulletSprite("Rocket");
            base.init(graphics);            
            Speed = new Vector2(1, 1);
            Acceleration = 0.2f;
            MaxSpeed = 300;
            float x = (float)(30 * Math.Sin(Rotation));
            float y = (float)(30 * Math.Cos(Rotation)) * -1;
            Body.Position = new Vector2(x, y) + Position;
            Body.Rotation = Rotation;
            Body.CollisionCategories = Category.Cat10;
            Body.CollidesWith = Category.All & ~Category.Cat2 & ~Category.Cat10;
            Body.Restitution = 5f;
            LifeTime = 1;
            Damage = 10;
            LifeTime = 1000;
        }

        public override bool myOnColision(Fixture f1, Fixture f2, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {
            createSelfParticles();
            return base.myOnColision(f1, f2, contact);
        }

        public override void createSelfParticles()
        {
            base.createSelfParticles();
            GameControl.particleManager.addParticle("Explosion", ParticleManager.createParticle(ParticleEnum.Explosion, Body.Position, (float)Util.getNextDouble(), Vector2.Zero));
            GameControl.particleManager.addParticle("ExplosionSmoke", ParticleManager.createParticle(ParticleEnum.Smoke, Body.Position, 5, Vector2.Zero));
            GameControl.particleManager.addParticle("ExplosionSmoke", ParticleManager.createParticle(ParticleEnum.Smoke, Body.Position, 5, Vector2.Zero));
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);

            if ((gameTime.TotalGameTime.TotalMilliseconds - Timer) > Factor)
            {
                float randomSize = (float)Util.getNextDouble() * Util.getNextInt(1, 3);
                Smoke smoke = new Smoke(Body.Position, randomSize, Body.LinearVelocity);
                GameControl.particleManager.addParticle("Smoke", smoke);
                Timer = (float)gameTime.TotalGameTime.TotalMilliseconds;
            }
        }
    }
}
