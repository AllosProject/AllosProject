using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Objects.Weapons;
using Microsoft.Xna.Framework;

namespace SpaceGame.Objects.ObjectsToUse
{
    public class RocketLaucher : Weapon
    {
        public RocketLaucher()
            :base()
        {
        }

        public override void addBullet(Vector2 position, float rotation, GraphicsDeviceManager graphics)
        {
            if (canShoot())
            {
                Rocket bullet = new Rocket(position,rotation);
                bullet.init(graphics);
                bullets.Add(bullet);
            }
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            timeReload = 200;
        }
    }
}
