using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceGame.KeyboardHandler;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Factories;
using SpaceGame.Control;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Common.PolygonManipulation;
using FarseerPhysics.Common.Decomposition;
using SpaceGame.Other;
using SpaceGame.Art.Particles;
using SpaceGame.Enums;

namespace SpaceGame.Objects.ObjectsToUse
{
    class RX7Rocket : Ships
    {

        private double turningMoment;
        private double collisionMoment;
        private double gameTimeMilliseconds;

        public override void update(GameTime gameTime)
        {
            this.gameTimeMilliseconds = gameTime.TotalGameTime.TotalMilliseconds;

            KeyboardState ks = Keyboard.GetState();
            Keys[] keys = ks.GetPressedKeys();
            int keysSize = keys.Length;

            if (turningMoment + 50 < gameTimeMilliseconds)
            {
                stopAngularVelocity();
            }

            for (int i = 0; i < keysSize; i++)
            {
                if (keys[i] == PlayerKeyboard.UP)
                {
                    up();
                    Factor = 1;
                }
                else
                {                    
                    desaccel();
                }
                if (keys[i] == PlayerKeyboard.DOWN)
                {
                    down();
                }
                if (keys[i] == PlayerKeyboard.LEFT)
                {
                    turningMoment = this.gameTimeMilliseconds;
                    left();
                }
                if (keys[i] == PlayerKeyboard.RIGHT)
                {
                    turningMoment = this.gameTimeMilliseconds;
                    right();
                }
                if (keys[i] == PlayerKeyboard.SPACE)
                {
                    GameControl.weaponManager.addBullet(this.GetHashCode().ToString(), Body.Position, Body.Rotation, Graphics);
                }
            }
            if (keysSize == 0)
            {
                Factor = 150;
                desaccel();
            }

            if ((gameTime.TotalGameTime.TotalMilliseconds - Timer) > Factor)
            {
                GameControl.particleManager.addParticle("ShipEngineSmoke", ParticleManager.createParticle(ParticleEnum.Smoke, Body.Position, 1, Body.LinearVelocity));
                Timer = (float)gameTime.TotalGameTime.TotalMilliseconds;
            }
           
            base.update(gameTime);
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            Factor = 150;
            Texture = Art.Images.getShipSprite("nave3");
            Acceleration =4f;
            AngleIncrement = 0.06f;
            Desacceleration = 0.05f;
            MaxSpeed = 300;
            accelerate = delegate
            {
                Events.angleMove(this);
            };
            GameControl.weaponManager.addNewWeapon(this.GetHashCode().ToString(),new RocketLaucher());
            Util.convertToPolygon(this);
            Body.BodyType = BodyType.Dynamic;
            Body.Position = new Vector2(0,0);
            Body.CollisionCategories = Category.Cat2;
            Body.CollidesWith = Category.All & ~Category.Cat10;
            Body.Restitution = 0.4f;
            Body.Friction = 1f;
            Body.OnCollision += myOnColision;
            
            Body.ResetMassData(); 
            //Body.Mass = 1f;

        }

        public virtual bool myOnColision(Fixture f1, Fixture f2, Contact contact)
        {
            this.turningMoment += 2*1000; //2 segundos de giro(se possível)
            if (this.collisionMoment + 500 < this.gameTimeMilliseconds)
            {
                SoundControl.PlaySoundEffect(@"Ships\Collide\PunchCollide");
            }
            this.collisionMoment = this.gameTimeMilliseconds;
            return true;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            spriteBatch.Draw(Texture,
                new Rectangle((int)Body.Position.X,
                    (int)Body.Position.Y,
                    Texture.Width, Texture.Height),
                    new Rectangle(0, 0, Texture.Width,
                        Texture.Height),
                        Color.White, Body.Rotation,
                        Origin,
                        SpriteEffects.None,
                        0);
        }
    }
}
