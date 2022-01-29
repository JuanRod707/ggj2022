using UnityEngine;

namespace Assets.Scripts.Trophies
{
    [CreateAssetMenu(fileName = "Set", menuName = "Configuration/ModifierParameterSet")]
    public class ModifierParameterSet : ScriptableObject
    {
        public int MaxAffinity;
        public int MinAffinity;

        public ModifierParameter[] parameters;

        public int Affinity => Random.Range(MinAffinity, MaxAffinity);
    }
}
