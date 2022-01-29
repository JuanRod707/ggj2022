using System.Collections;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Actors.Monsters;
using Assets.Scripts.Directors;
using UnityEngine;

namespace Assets.Scripts.Actors.AI
{
    public class DiverAi : BaseAi
    {
        [SerializeField] float proximityThreshold;
        [SerializeField] float attackFrequency;
        [SerializeField] float frequencyModifier;
        [SerializeField] DiveAttack diveAttack;
        [SerializeField] float hoverOffsetDistance;

        private float attackInterval => attackFrequency + Random.Range(-frequencyModifier, frequencyModifier);
        private Vector3 targetPositionOffset;

        private bool IsFarFromHero =>
            Vector3.Distance(transform.position, hero.Position) > proximityThreshold;

        public override void Initialize(HeroCharacter hero, ActorStats stats, MonsterMovement movement,
            MonsterView view)
        {
            base.Initialize(hero, stats, movement, view);
            diveAttack.Initialize(cone, view);
            GenerateRandomOffset();
        }

        void Update()
        {
            if (!isPerformingAction)
            {
                if (IsFarFromHero)
                    movement.MoveTowards(hero.Position + targetPositionOffset);
                else
                    Dive();
            }

            if(diveAttack.enabled)
                OnSwing();
        }

        private void Dive()
        {
            diveAttack.Do(hero.Position - transform.position);
            cone.LookAt(hero.Position);
            isPerformingAction = true;
            view.ShowAttack();
            StartCoroutine(WaitForNextAttack());
        }

        private IEnumerator WaitForNextAttack()
        {
            GenerateRandomOffset();
            yield return new WaitForSeconds(attackInterval);
            isPerformingAction = false;
        }

        private void GenerateRandomOffset() => targetPositionOffset =
            new Vector3(Random.Range(-hoverOffsetDistance, hoverOffsetDistance), 0f,
                Random.Range(-hoverOffsetDistance, hoverOffsetDistance));
    }
}
