using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Objects;
using SpaceGame.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame.Level
{
    public class LevelManager : Basics
    {
        private static Dictionary<string,LevelObject> levelList;

        private static LevelObject currentLevel;

        public void setInitialLevel(LevelObject levelObject)
        {
            currentLevel = levelObject;
        }

        public void addNewLevel(string levelName,LevelObject levelObject)
        {
            if (currentLevel == null)
                currentLevel = levelObject;
            levelList.Add(levelName, levelObject);
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            levelList = new Dictionary<string,LevelObject>();
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            currentLevel.update(gameTime);
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            currentLevel.draw(spriteBatch);
        }
    }
}
