using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNeMai
{
    public class MusicPlayer
    {
        public delegate void MusicStartHandler(object source, MusicStartEventArgs arg);
        public static event MusicStartHandler eventMusicStart;

        public static void OnMusicStart()
        {
            MusicStartEventArgs arg = new MusicStartEventArgs();
            if (eventMusicStart != null)
            {
                eventMusicStart(null, arg);
            }
        }

        public delegate void MusicStopHandler(object source, MusicStopEventArgs arg);
        public static event MusicStopHandler eventMusicStop;

        public static void OnMusicStop()
        {
            MusicStopEventArgs arg = new MusicStopEventArgs();
            if (eventMusicStop != null)
            {
                eventMusicStop(null, arg);
            }
        }

    }

    public class MusicStartEventArgs : EventArgs
    {
    }

    public class MusicStopEventArgs : EventArgs
    {
    }
}
