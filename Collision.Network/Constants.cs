using System;
using System.Collections.Generic;
using System.Text;

namespace Collision.Network
{
    class Constants
    {
        public const int MAX_PLAYERS = 100;
        public const int TICKS_PER_SEC = 30;
        public const float MS_PER_TICK = 1000;
    }

    class Globals
    {
        public static bool serverIsRunning = false;
    }
}
