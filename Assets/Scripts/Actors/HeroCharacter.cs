using Assets.Scripts.Actors.Stats;
using Assets.Scripts.Areas;
using Assets.Scripts.Directors;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class HeroCharacter : MonoBehaviour
    {
        [SerializeField] BasicMovement movement;
        [SerializeField] BasicAttack attack;
        [SerializeField] ConeArea attackArea;
        [SerializeField] HeroStats baseStats;

        public void Initialize(MonsterProvider monsterProvider)
        {
            movement.Initialize(attackArea, baseStats.moveSpeed);
            attack.Initialize(attackArea, monsterProvider);
        }

        public void MoveTowards(Vector3 movementVector) => 
            movement.Do(movementVector);

        public void Attack() => attack.Do();
    }
}
