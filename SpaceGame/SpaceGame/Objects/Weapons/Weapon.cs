using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Classes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SpaceGame.Structure;
using SpaceGame.Control;

namespace SpaceGame.Objects.Weapons
{
    public class Weapon : Basics
    {
        protected int damage;
        protected List<Bullet> bullets;
        protected double timeReload;
        protected double timeElapsed;


        protected bool canShoot()
        {
            if (timeElapsed > timeReload)
            {
                timeElapsed = 0;
                return true;
            }
            else
                return false;
        }

        public Weapon()
        {            
            bullets = new List<Bullet>();            
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            timeElapsed = 0;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            if (bullets != null)
            {
                foreach (Bullet item in bullets)
                {
                    item.draw(spriteBatch);
                }
            }
        }

        public virtual void addBullet(Vector2 position,float rotation,GraphicsDeviceManager graphics)
        {
            if (canShoot())
            {
                Bullet bullet = new Bullet();
                bullet.init(graphics);
                bullets.Add(bullet);
            }
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            timeElapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (bullets != null)
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].IsAlive)
                        bullets[i].update(gameTime);
                    else
                    {
                        GameControl.world.RemoveBody(bullets[i].Body);
                        bullets.RemoveAt(i);                        
                    }
                }
                
            }
        }

    }
}
