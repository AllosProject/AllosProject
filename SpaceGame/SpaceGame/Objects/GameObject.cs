using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using SpaceGame.Control;
using FarseerPhysics.Collision.Shapes;

namespace SpaceGame.Classes
{
    public class GameObject : Basics
    {

        private GraphicsDeviceManager graphics;
        private Body body;
        private Vector2 speed;
        private float acceleration;
        private float desacceleration;
        private Texture2D texture;
        private float angleIncrement;
        private float maxSpeed;
        private Vector2 origin;
        public SpaceGame.Delegates.Delegates.Accelerate accelerate;
        private float timer;
        private float factor;

        public float Factor
        {
            get { return factor; }
            set { factor = value; }
        }


        public float Timer
        {
            get { return timer; }
            set { timer = value; }
        }




        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public float MaxSpeed
        {

            get { return maxSpeed; }
            set { maxSpeed = value; }
        }

        public float Desacceleration
        {
            get { return desacceleration; }
            set { desacceleration = value; }
        }

        public GraphicsDeviceManager Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }

        public float AngleIncrement
        {
            get { return angleIncrement; }
            set { angleIncrement = value; }
        }

        public Vector2 Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Body Body
        {
            get { return body; }
            set { body = value; }
        }


        public float Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public override void update(GameTime gameTime)
        {

        }

        public override void draw(SpriteBatch spriteBatch)
        {

        }

        public override void init(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            timer = 0;
        }

        public void right()
        {
            body.Rotation += angleIncrement;
        }

        public void left()
        {
            body.Rotation -= angleIncrement;
        }

        public void up()
        {
            accelerate(this);
        }

        public void down()
        {
            if (speed.X > 1)
                speed.X = speed.Y -= acceleration;
        }

        public void desaccel()
        {
            float speed_X = body.LinearVelocity.X * 0.98f;
            float speed_Y = body.LinearVelocity.Y * 0.98f;
            if (speed_X < 0.1f && speed_X > -0.1f)
                speed_X = 0;
            if (speed_Y < 0.1f && speed_Y > 0.1f)
                speed_Y = 0;
            body.LinearVelocity = new Vector2(speed_X,speed_Y);
        }

        virtual public void move()
        {
            Body.LinearVelocity += Speed;
        }

    }
}
