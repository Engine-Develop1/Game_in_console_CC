using System;
using System.m;
using System.Collections.Generic;
using System.Text;

namespace game_in_console.sound
{
    class SoundPlayer
    {
        System.media soundPlayer = new System.Media.SoundPlayer();
        public string[] Path = new string[10];
        public void GetSoundInA(string path, int index)
        {
            Path[index] = Path[index] + path;
        }
        public void play(string path)
        {
            soundPlayer.SoundLocation = path;
            soundPlayer.Play();
        }
    }
}
