using UnityEngine;

namespace Assets.Scripts.Actors.Stats
{
    [CreateAssetMenu(fileName="Stats", menuName="Stats/Actors")]
    public class ActorStats : ScriptableObject
    {
        public float moveSpeed;
        public float attackSpeed;
        public float damageArea;
        public int damagePower;
        public int health;
    }
}
