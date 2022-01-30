using System;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Areas;
using Assets.Scripts.Persistence;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Actors.Monsters
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] ActorStats baseStats;

        [SerializeField] MonsterMovement movement;
        [SerializeField] MonsterView view;
        [SerializeField] Health health;
        [SerializeField] NavMeshAgent agent;
        [SerializeField] BaseAi brain;
        [SerializeField] ProximityDetector detector;

        ActorStats currentStats;
        Action<Monster> onDeath;

        public bool IsAlive { get; private set; }

        public void Initialize(HeroCharacter hero, Action<Monster> onDeath)
        {
            currentStats = baseStats.Leveled(SessionData.Level);

            view.Initialize();
            movement.Initialize(currentStats.MoveSpeed, view, agent);
            brain.Initialize(hero, currentStats, movement, view);
            health.Initialize(currentStats.Health, OnDeath, OnHurt);
            detector.Initialize(hero, brain, view);

            IsAlive = true;
            this.onDeath = onDeath;
        }

        void OnHurt()
        {
        }

        public void ReceiveDamage(int damage)
        {
            if(IsAlive)
                health.ReceiveDamage(damage);
        }
        
        void OnDeath()
        {
            IsAlive = false;
            onDeath(this);
            brain.Disable();
        }
    }
}
