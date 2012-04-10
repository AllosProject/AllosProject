using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Structure;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SpaceGame.Objects.ObjectsToUse;

namespace SpaceGame.Objects.Weapons
{
    public class WeaponManager : Basics
    {
        private Dictionary<string, Weapon> weaponList;

        public void addNewWeapon(string objectSource,Weapon weapon)
        {
            if (weaponList == null)
                weaponList = new Dictionary<string, Weapon>();
            //Verify the type of weapon to return
            weaponList.Add(objectSource, getWeaponType(weapon));
        }

        private Weapon getWeaponType(Weapon weapon)
        {
            if (weapon is RocketLaucher)
            {
                RocketLaucher rocketLaucher = new RocketLaucher();
                rocketLaucher.init(null);
                return rocketLaucher;
            }
            return null;
        }

        public void addBullet(string objectSource,Vector2 position,float rotation,GraphicsDeviceManager graphics)
        {
            weaponList[objectSource].addBullet(position,rotation,graphics);           
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            string[] keys = weaponList.Keys.ToArray();
            for (int i = 0; i < weaponList.Count; i++)
            {
                weaponList[keys[i]].draw(spriteBatch);
            }
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            string[] keys = weaponList.Keys.ToArray();
            for (int i = 0; i < weaponList.Count; i++)
            {
                weaponList[keys[i]].update(gameTime);
            }
        }
    }
}
