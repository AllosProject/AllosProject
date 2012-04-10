using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Classes;
using Microsoft.Xna.Framework;

namespace SpaceGame
{
    public class Events
    {
        public static void angleMove(GameObject gameObject)
        {
            float vx = 0;
            float vy = 0;
            if (gameObject.Body.LinearVelocity.X > gameObject.MaxSpeed * -1 && gameObject.Body.LinearVelocity.X < gameObject.MaxSpeed)
                vx = (float)(gameObject.Acceleration * Math.Sin(gameObject.Body.Rotation));
            if (gameObject.Body.LinearVelocity.Y > gameObject.MaxSpeed * -1 && gameObject.Body.LinearVelocity.Y < gameObject.MaxSpeed)
                vy = (float)(gameObject.Acceleration * Math.Cos(gameObject.Body.Rotation)) * -1;
            gameObject.Body.LinearVelocity += new Vector2(vx, vy);

        }
        

        public static void bulletAngleMove(GameObject gameObject)
        {
            float vx = 0;
            float vy = 0;
            if (gameObject.Speed.X > gameObject.MaxSpeed * -1 && gameObject.Speed.X < gameObject.MaxSpeed)
                vx = (float)(gameObject.Acceleration * Math.Sin(gameObject.Body.Rotation));
            if (gameObject.Speed.Y > gameObject.MaxSpeed * -1 && gameObject.Speed.Y < gameObject.MaxSpeed)
                vy = (float)(gameObject.Acceleration * Math.Cos(gameObject.Body.Rotation)) * -1;
            
            gameObject.Speed += new Vector2(vx, vy);
            gameObject.Body.Position += gameObject.Speed;
            gameObject.Body.LinearVelocity += gameObject.Speed;
        }

        public static void twoAxisMove(GameObject gameObject)
        {
            gameObject.Body.Position += gameObject.Speed;
        }

    }
}
