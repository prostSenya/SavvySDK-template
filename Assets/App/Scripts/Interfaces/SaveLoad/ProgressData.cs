using System;

namespace App.Scripts.Interfaces.SaveLoad
{
    [Serializable]
    public struct ProgressData
    {
        public long PlayTimeSec;
        public int Gems;
        public int Coins;
    }
}