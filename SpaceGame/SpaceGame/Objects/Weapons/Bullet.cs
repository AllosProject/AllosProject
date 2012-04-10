using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Structure;
using SpaceGame.Classes;
using Microsoft.Xna.Framework;
using FarseerPhysics.Factories;
using SpaceGame.Control;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using SpaceGame.Other;

namespace SpaceGame.Objects.Weapons
{
    public class Bullet : GameObject
    {
        private bool isAlive = true;
        private int damage;
        private Vector2 position;
        private float rotation;
        private double lifeTime;
        private double timer;

        public double LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            spriteBatch.Draw(Texture,Body.Position,null,Color.White,Body.Rotation,Origin,1f,SpriteEffects.None,1f);
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);            
            Util.convertToPolygon(this);
            Body.BodyType = BodyType.Dynamic;            
            accelerate = Events.bulletAngleMove;
            Body.OnCollision += myOnColision;
            timer = 0;
            lifeTime = 0;
        }

        public virtual bool myOnColision(Fixture f1, Fixture f2, Contact contact)
        {
            lifeTime--;
            Speed = Body.LinearVelocity;
            isAlive = false;
            return false;
        }

        public virtual void createSelfParticles()
        {
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            accelerate(this);
            if (timer > lifeTime)
            {
                isAlive = false;
                createSelfParticles();
            }
            timer += gameTime.ElapsedGameTime.Milliseconds;
            move();
            
        }
    }
}
