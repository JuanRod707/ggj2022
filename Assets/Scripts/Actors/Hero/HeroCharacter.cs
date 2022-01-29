using Assets.Scripts.Areas;
using Assets.Scripts.Directors;
using UnityEngine;

namespace Assets.Scripts.Actors.Hero
{
    public class HeroCharacter : MonoBehaviour
    {
        [SerializeField] HeroMovement movement;
        [SerializeField] HeroView view;
        [SerializeField] HeroAttack attack;
        [SerializeField] ConeArea attackArea;
        [SerializeField] ActorStats baseStats;
        [SerializeField] Dash dash;
        [SerializeField] Health health;

        public Vector3 Position => transform.position;

        ActorStats currentStats;

        public void Initialize(MonsterProvider monsterProvider)
        {
            currentStats = baseStats.CopyTo();
            movement.Initialize(attackArea, view, currentStats.MoveSpeed);
            attack.Initialize(currentStats, view, attackArea, monsterProvider);
            dash.Initialize(movement);
            health.Initialize(currentStats.Health, OnDeath);
        }

        void OnDeath()
        {
            
        }

        public void MoveTowards(Vector3 movementVector) => 
            movement.Do(movementVector);

        public void Attack() => attack.Do();
        public void Dash(Vector3 movementVector) => dash.Do(movementVector);

        public void ReceiveDamage(int damage)
        {
            health.ReceiveDamage(damage);
        }
    }
}
