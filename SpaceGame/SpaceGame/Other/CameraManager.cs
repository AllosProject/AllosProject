using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceGame.Structure;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame.Control
{
    public class CameraManager : Basics
    {
        private Vector2 position;
        private Matrix matrix;
        private float rotation;
        private float zoom;

        public float Zoom
        {
            get { return zoom; }
            set { zoom = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Matrix Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public CameraManager()
        {
            position = Vector2.Zero;
        }

        public CameraManager(Vector2 position)
        {
            this.position = position;
            zoom = 1;
        }

        public void moveCamera(Vector2 positionToMove)
        {
            position = positionToMove;
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            matrix =   
              Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));
            return matrix;
        }
    }
}
