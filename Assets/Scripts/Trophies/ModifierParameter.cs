using System;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Trophies
{
    [Serializable]
    public class ModifierParameter
    {
        public Stat Stat;
        public int MaxMod;
        public int MinMod;

        public int StatChange => Random.Range(MinMod, MaxMod + 1);
    }
}