using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame.Structure
{
    public abstract class Basics
    {
        public virtual void update(GameTime gameTime)
        {
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
        }

        public virtual void init(GraphicsDeviceManager graphics)
        {
        }
    }
}
