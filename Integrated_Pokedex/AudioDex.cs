using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Integrated_Pokedex
{

    internal class AudioDex
    {
        MediaPlayer scrollSound = new MediaPlayer();

        private string _scrollPath;

        public string ScrollPath
        {
            get { return _scrollPath; }
            set { _scrollPath = value; }
        }
        public AudioDex()
        {
            ScrollPath = @"..\..\DexAudio\scrollSound.mp3";
        }

        public void PlayScrollScround()
        {
            scrollSound.Open(new Uri(ScrollPath, UriKind.Relative));
            scrollSound.Play();
        }

    }
}
