using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Areas;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Actors.Monsters
{
    public abstract class BaseAi : MonoBehaviour
    {
        [SerializeField] protected ConeArea cone;
        [SerializeField] protected AnimationEvents animationEvents;

        protected bool isPerformingAction;
        protected HeroCharacter hero;
        protected MonsterMovement movement;
        protected MonsterView view;
        protected ActorStats stats;

        public virtual void Initialize(HeroCharacter hero, ActorStats stats, MonsterMovement movement,
            MonsterView view)
        {
            this.hero = hero;
            this.movement = movement;
            this.view = view;
            this.stats = stats;
            this.animationEvents?.Initialize(OnSwing);
        }

        protected virtual void OnSwing()
        {
            if (cone.IsInArea(hero.Position))
                hero.ReceiveDamage(Random.Range(stats.MinDamage, stats.MaxDamage));
        }

        public void Disable()
        {
            StopAllCoroutines();
            enabled = false;
        }

        public virtual void Enable()
        {
            isPerformingAction = false;
            enabled = true;
        }
    }
}
