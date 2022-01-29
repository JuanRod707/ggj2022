using Assets.Scripts.Actors.Stats;
using Assets.Scripts.Areas;
using Assets.Scripts.Directors;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class HeroCharacter : MonoBehaviour
    {
        [SerializeField] BasicMovement movement;
        [SerializeField] ActorView view;
        [SerializeField] BasicAttack attack;
        [SerializeField] ConeArea attackArea;
        [SerializeField] ActorStats baseStats;
        [SerializeField] Dash dash;

        public void Initialize(MonsterProvider monsterProvider)
        {
            movement.Initialize(attackArea, view, baseStats.moveSpeed);
            attack.Initialize(view, attackArea, monsterProvider);
            dash.Initialize(movement);
        }

        public void MoveTowards(Vector3 movementVector) => 
            movement.Do(movementVector);

        public void Attack() => attack.Do();
        public void Dash(Vector3 movementVector) => dash.Do(movementVector);
    }
}
