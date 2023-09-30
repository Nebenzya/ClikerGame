using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ClikerGame.Logic
{
    internal class SoundDispatcher
    {
        private Random random = new Random();
        private string[] soundFiles = { @"Sound\clickb1.wav", @"Sound\clickb2.wav", @"Sound\clickb3.wav", @"Sound\clickb4.wav", @"Sound\clickb5.wav", @"Sound\clickb6.wav", @"Sound\clickb7.wav" };
        public void CookieSound()
        {
            string randomSound = soundFiles[random.Next(soundFiles.Length)];

            using (SoundPlayer player = new SoundPlayer(randomSound))
            {
                player.Play();
            }
        }
    }
}
