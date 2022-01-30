using System;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Areas;
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

        Action<Monster> onDeath;

        public bool IsAlive { get; private set; }

        public void Initialize(HeroCharacter hero, Action<Monster> onDeath)
        {
            view.Initialize();
            movement.Initialize(baseStats.MoveSpeed, view, agent);
            brain.Initialize(hero, baseStats, movement, view);
            health.Initialize(baseStats.Health, OnDeath, OnHurt);
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
            onDeath(this);
            IsAlive = false;
            brain.Disable();
        }
    }
}
