using Assets.Scripts.Trophies;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    [CreateAssetMenu(fileName="Stats", menuName="Configuration/ActorStats")]
    public class ActorStats : ScriptableObject
    {
        public int movement;
        public int dexterity;
        public int strength;
        public int vitality;

        public float MoveSpeed => movement * 0.4f;

        public float AttackArea => (strength + dexterity) * 3;
        public float AttackSpeed => 1 / (dexterity / 5f);

        public int Health => vitality * 3;

        public int MinDamage => Mathf.FloorToInt(strength - (strength * 0.2f));
        public int MaxDamage => Mathf.FloorToInt(strength + (strength * 0.2f));

        public ActorStats CopyTo()
        {
            return new ActorStats
            {
                movement = this.movement,
                dexterity = this.dexterity,
                strength = this.strength,
                vitality = this.vitality
            };
        }

        public ActorStats WithTrophy(Trophy trophy)
        {
            return new ActorStats
            {
                movement = this.movement + trophy.ModFor(Stat.Movement),
                dexterity = this.dexterity + trophy.ModFor(Stat.Dexterity),
                strength = this.strength + trophy.ModFor(Stat.Strength),
                vitality = this.vitality + trophy.ModFor(Stat.Vitality)
            };
        }
    }
}
