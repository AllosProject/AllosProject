using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace SpaceGame.Control
{
    public static class SoundControl
    {
        private static ContentManager content;

        public static void Init(ContentManager content)
        {
            SoundControl.content = content;
        }

        public static void PlaySoundEffect(string soundFile)
        {
            SoundEffect soundEffect;
            try
            {
                soundEffect = content.Load<SoundEffect>(@"sounds\" + soundFile);
                soundEffect.Play();
            }
            catch (Exception e)
            {

            }

        }
    }
}
