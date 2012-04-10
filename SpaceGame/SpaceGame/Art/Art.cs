using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace SpaceGame.Art
{
    public class Images
    {
        //Arrays with all game images
        private static Dictionary<string, Texture2D> ships;
        private static Dictionary<string, Texture2D> levelObjects;
        private static Dictionary<string, Texture2D> particles;
        private static Dictionary<string, Texture2D> backGrounds;
        private static Dictionary<string, Texture2D> bullets;
        //Content Manager
        private static ContentManager artContent;

        //Main method to load all images from images folder in content
        #region LoadArt
        public static void loadArt(ContentManager content)
        {
            artContent = content;
            
            //Load ship images
            DirectoryInfo dirInfo = new DirectoryInfo(content.RootDirectory + @"\images\ships");
            FileInfo[] fileInfo = dirInfo.GetFiles();
            ships = new Dictionary<string, Texture2D>(fileInfo.Length);
            foreach (FileInfo item in fileInfo)
            {
                ships.Add(Path.GetFileNameWithoutExtension(item.Name), artContent.Load<Texture2D>(@"images\ships\" + Path.GetFileNameWithoutExtension(item.FullName)));
            }

            //Load level static objects images
            dirInfo = new DirectoryInfo(content.RootDirectory + @"\images\LevelImages");
            fileInfo = dirInfo.GetFiles();
            levelObjects = new Dictionary<string, Texture2D>(fileInfo.Length);
            foreach(FileInfo item in fileInfo)
            {
                levelObjects.Add(Path.GetFileNameWithoutExtension(item.Name), artContent.Load<Texture2D>(@"images\LevelImages\" + Path.GetFileNameWithoutExtension(item.FullName)));
            }

            //Load particle images
            dirInfo = new DirectoryInfo(content.RootDirectory + @"\images\Particles");
            fileInfo = dirInfo.GetFiles();
            particles = new Dictionary<string, Texture2D>(fileInfo.Length);
            foreach (FileInfo item in fileInfo)
            {
                particles.Add(Path.GetFileNameWithoutExtension(item.Name), artContent.Load<Texture2D>(@"images\Particles\" + Path.GetFileNameWithoutExtension(item.FullName)));
            }

            //Load particle images
            dirInfo = new DirectoryInfo(content.RootDirectory + @"\images\BackGrounds");
            fileInfo = dirInfo.GetFiles();
            backGrounds = new Dictionary<string, Texture2D>(fileInfo.Length);
            foreach (FileInfo item in fileInfo)
            {
                backGrounds.Add(Path.GetFileNameWithoutExtension(item.Name), artContent.Load<Texture2D>(@"images\BackGrounds\" + Path.GetFileNameWithoutExtension(item.FullName)));
            }

            //Load particle images
            dirInfo = new DirectoryInfo(content.RootDirectory + @"\images\Bullets");
            fileInfo = dirInfo.GetFiles();
            bullets = new Dictionary<string, Texture2D>(fileInfo.Length);
            foreach (FileInfo item in fileInfo)
            {
                bullets.Add(Path.GetFileNameWithoutExtension(item.Name), artContent.Load<Texture2D>(@"images\Bullets\" + Path.GetFileNameWithoutExtension(item.FullName)));
            }
        }
        #endregion

        //Methods to get any image
        #region get Methods
        public static Texture2D getShipSprite(string name)
        {
            return ships[name];
        }

        public static Texture2D getLevelObjectsSprite(string name)
        {
            return levelObjects[name];
        }

        public static Texture2D getParticleSprite(string name)
        {
            return particles[name];
        }

        public static Texture2D getBackGroundSprite(string name)
        {
            return backGrounds[name];
        }

        public static Texture2D getBulletSprite(string name)
        {
            return bullets[name];
        }

        #endregion
    }
}
