using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Classes;
using SpaceGame.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceGame.Objects
{
    public class Ships : GameObject
    {

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            refreshAngularSpeed();
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
        }

        private void refreshAngularSpeed()
        {
            if (Body.AngularVelocity > 0)
                Body.AngularVelocity -= 0.05f;
            else
                Body.AngularVelocity += 0.05f;
        }
    }
}
