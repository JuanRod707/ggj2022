using Assets.Scripts.Areas;
using Assets.Scripts.Directors;
using Assets.Scripts.Persistence;
using Assets.Scripts.UI;
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
        FillBar hpBar;

        public Vector3 Position => transform.position;

        public ActorStats currentStats { get; private set; }

        public void Initialize(MonsterProvider monsterProvider, FillBar hpBar)
        {
            this.hpBar = hpBar;

            currentStats = SessionData.playerStats != null ? SessionData.playerStats.CopyTo() : baseStats.CopyTo();
            SessionData.playerStats = currentStats.CopyTo();

            hpBar.InitializeFull(currentStats.Health);
            movement.Initialize(attackArea, view, currentStats.MoveSpeed);
            attack.Initialize(currentStats, view, attackArea, monsterProvider, movement);
            dash.Initialize(movement, view);
            health.Initialize(currentStats.Health, OnDeath, OnHurt);
            view.Initialize();
        }

        void OnHurt() => 
            hpBar.SetValue(health.Current);

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

        public void StopMoving() => movement.StopMoving();
    }
}
