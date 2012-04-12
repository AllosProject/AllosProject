using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;

namespace SpaceGame.Other
{
    public class LevelDynamicObject : GameObject{

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
            Body.BodyType = BodyType.Dynamic;
            Body.Position = position;
            Body.Restitution = 1f;
            Body.Friction = 1f;

            Body.ResetMassData();
 
        }

        

        public LevelDynamicObject(string textureName,Vector2 position)
        {
            Texture = Art.Images.getLevelObjectsSprite(textureName);
            this.position = position;
        }

        public LevelDynamicObject(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.position = position;
        }
    }
}
