using UnityEngine;

namespace Assets.Scripts.Actors.Stats
{
    [CreateAssetMenu(fileName="Stats", menuName="Stats/Hero")]
    public class HeroStats : ScriptableObject
    {
        public float moveSpeed;
        public float attackSpeed;
        public float damageArea;
        public float damagePower;
        public float health;
    }
}
