﻿using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWanderer.Core
{
    public static class BasicAudioPlayer
    {
        private static Dictionary<String,SoundEffect> sounds=new Dictionary<String, SoundEffect>();
        public static void Initialize(ContentManager manager)
        {
            sounds["sound_jump"]=manager.Load<SoundEffect>("sound_jump");
            MediaPlayer.Play(manager.Load<Song>("wote_old"));
            MediaPlayer.IsRepeating = true;
        }
        public static void PlaySound(String soundName)
        {
            sounds[soundName].Play(1.0f,0f,0f);
        }
    }
}
