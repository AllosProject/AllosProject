using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceGame.Classes;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Factories;
using FarseerPhysics.Common;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Dynamics;
using SpaceGame.Control;
using FarseerPhysics.Common.PolygonManipulation;
using FarseerPhysics.Dynamics.Contacts;

namespace SpaceGame.Other {
    class LevelStaticObject : GameObject{

        private Vector2 position;

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            spriteBatch.Draw(Texture, Body.Position, null, Color.White, Body.Rotation,Origin,1f,SpriteEffects.None,0f);
        }

        public override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);     

            Util.convertToPolygon(this);
            Body.BodyType = BodyType.Static;
            Body.Position = position;
 
        }

        

        public LevelStaticObject(string textureName,Vector2 position)
        {
            Texture = Art.Images.getLevelObjectsSprite(textureName);
            this.position = position;
        }

        public LevelStaticObject(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.position = position;
        }

    }
}
