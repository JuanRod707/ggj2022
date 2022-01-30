using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Actors;
using UnityEngine;

namespace Assets.Scripts.Persistence
{
    public static class SessionData
    {
        public static ActorStats PlayerStats;
        public static int Ruin;
        public static int Prosperity;

        public static int Level = 1;
        public static int DeltaAffinity => Mathf.Abs(Ruin - Prosperity);

        public static void Reset()
        {
            Ruin = 0;
            Prosperity = 0;
            Level = 1;
            PlayerStats = null;
        }
    }
}
