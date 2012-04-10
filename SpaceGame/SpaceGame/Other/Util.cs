using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Classes;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using FarseerPhysics.Common.PolygonManipulation;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Factories;
using SpaceGame.Control;

namespace SpaceGame.Other
{
    public static class Util
    {
        public enum GameState { GameMainMenu, GamePlaying, GamePaused };

        private static Random rand;

        public static void convertToPolygon(GameObject gameObject)
        {
            uint[] data = new uint[gameObject.Texture.Width * gameObject.Texture.Height];
            gameObject.Texture.GetData(data);
            Vertices verts = PolygonTools.CreatePolygon(data, gameObject.Texture.Width, false);

            Vector2 centroid = -verts.GetCentroid();
            verts.Translate(ref centroid);
            gameObject.Origin = -centroid;

            verts = SimplifyTools.ReduceByDistance(verts, 4f);

            List<Vertices> list = BayazitDecomposer.ConvexPartition(verts);
            gameObject.Body = BodyFactory.CreateCompoundPolygon(GameControl.world, list, 1f);
                        
        }

        public static int getNextInt()
        {
            if (rand == null)
                rand = new Random(DateTime.Now.Millisecond);
            return rand.Next();
        }

        public static int getNextInt(int min,int max)
        {
            if (rand == null)
                rand = new Random(DateTime.Now.Millisecond);
            return rand.Next(min,max);
        }

        public static double getNextDouble()
        {
            if (rand == null)
                rand = new Random(DateTime.Now.Millisecond);
            return rand.NextDouble();
        }
    }
}
