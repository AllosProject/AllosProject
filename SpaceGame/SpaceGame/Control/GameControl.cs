using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SpaceGame.Other;
using SpaceGame.Objects.ObjectsToUse;
using SpaceGame.Structure;
using SpaceGame.Objects;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Art.Particles;
using SpaceGame.Objects.Weapons;
using SpaceGame.Level;

namespace SpaceGame.Control
{
    public class GameControl : Basics
    {
        //Farseer world for phisics
        public static World world;
        //Game state
        Util.GameState gameState = Util.GameState.GamePlaying;
        //Game level (just an example)
        LevelManager levelManager;
        //Game particle System
        public static ParticleManager particleManager;
        //Game camera
        public static CameraManager camera;
        //Game weaponManager
        public static WeaponManager weaponManager;

        RX7Rocket rx7Rocket;

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            world.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);
            levelManager.update(gameTime);
            rx7Rocket.update(gameTime);            
            particleManager.update(gameTime);
            camera.moveCamera(rx7Rocket.Body.Position);
            weaponManager.update(gameTime);
        }

        public override void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);

            levelManager.draw(spriteBatch);            
            rx7Rocket.draw(spriteBatch);
            particleManager.draw(spriteBatch);
            weaponManager.draw(spriteBatch);
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            
            particleManager = new ParticleManager();

            weaponManager = new WeaponManager();
            weaponManager.init(graphics);
            
            world = new World(new Vector2(0,20));
            
            levelManager = new LevelManager();
            levelManager.init(graphics);
            //---------------Insert levels here-----------------
            LevelObject level1 = new LevelObject("level1");
            level1.init(graphics);
            level1.addBackGround("backGroundBlue");
            level1.addNewStaticObject("planet", Vector2.Zero);

            levelManager.addNewLevel(level1.LevelName, level1);

            //--------------------------------------------------
            
            rx7Rocket = new RX7Rocket();
            rx7Rocket.init(graphics);
            
            camera = new CameraManager(rx7Rocket.Body.Position);
            
            
        }
    }
}
