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
    public class LevelObject : GameObject
    {
        private Rectangle bounds;
        private List<LevelStaticObject> staticObjectList;
        private List<LevelDynamicObject> dynamicObjectList;
        private string levelName;

        public string LevelName
        {
            get { return levelName; }
            set { levelName = value; }
        }

        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public LevelObject(string name)
        {
            this.levelName = name;
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            foreach(LevelStaticObject item in staticObjectList)
            {
                item.update(gameTime);
            }

            foreach (LevelDynamicObject item in dynamicObjectList)
            {
                item.update(gameTime);
            }
        }

        public override void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            spriteBatch.Draw(Texture, Vector2.Zero,null, Color.White,0,Origin,1f,SpriteEffects.None,0);

            foreach(LevelStaticObject item in staticObjectList)
            {
                item.draw(spriteBatch);                
            }

            foreach (LevelDynamicObject item in dynamicObjectList)
            {
                item.draw(spriteBatch);
            }
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            staticObjectList = new List<LevelStaticObject>();
            dynamicObjectList = new List<LevelDynamicObject>();
        }

        public void addNewStaticObject(string textureName, Vector2 position)
        {
            LevelStaticObject obj = new LevelStaticObject(textureName, position);
            obj.init(Graphics);
            staticObjectList.Add(obj);
        }

        public void addNewDynamicObject(string textureName, Vector2 position)
        {
            LevelDynamicObject obj = new LevelDynamicObject(textureName, position);
            obj.init(Graphics);
            dynamicObjectList.Add(obj);
        }

        public void addBackGround(string imageName)
        {
            Texture = Art.Images.getBackGroundSprite(imageName);
            bounds.X = 0;
            bounds.Y = 0;
            bounds.Width = Texture.Width;
            bounds.Height = Texture.Height;
            Origin = new Vector2(bounds.Center.X,bounds.Center.Y);
            
        }

    }
}
