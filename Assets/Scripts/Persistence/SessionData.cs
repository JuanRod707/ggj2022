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
        public static ActorStats playerStats;
        public static int Ruin;
        public static int Prosperity;

        public static int Level = 1;
        public static int DeltaAffinity => Mathf.Abs(Ruin - Prosperity);
    }
}
