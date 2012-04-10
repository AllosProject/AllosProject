using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Classes;
using Microsoft.Xna.Framework;
using SpaceGame.Control;
using FarseerPhysics.Factories;
using System.Collections;
using SpaceGame.Other;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;

namespace SpaceGame.Objects {
    public class Level : GameObject
    {
        private Rectangle bounds;
        private List<LevelStaticObject> objectList;
        private Texture2D backGround;

        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            foreach(LevelStaticObject item in objectList)
            {
                item.update(gameTime);
            }
        }

        public override void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            spriteBatch.Draw(backGround, new Vector2(0, 0), Color.White);
            foreach(LevelStaticObject item in objectList)
            {
                item.draw(spriteBatch);                
            }
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            bounds.X = 0;
            bounds.Y = 0;
            bounds.Width = 800;
            bounds.Height = 600;
            backGround = Art.Images.getBackGroundSprite("backGround1");
            objectList = new List<LevelStaticObject>();
        }

        public void addNewStaticObject(string textureName, Vector2 position)
        {
            LevelStaticObject obj = new LevelStaticObject(textureName, position);
            obj.init(Graphics);
            objectList.Add(obj);
        }

        public void addNewStaticObject(Texture2D texture, Vector2 position)
        {
            LevelStaticObject obj = new LevelStaticObject(texture, position);
            obj.init(Graphics);
            objectList.Add(obj);
        }

    }
}
