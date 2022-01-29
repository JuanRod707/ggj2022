using System.Collections;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Areas;
using UnityEngine;

namespace Assets.Scripts.Actors.Monsters
{
    public class BossAi : BaseAi
    {
        [SerializeField] float ProximityThreshold;
        [SerializeField] float AttackFrequency;
        [SerializeField] float FrequencyModifier;
        [SerializeField] float BaseSpecialInterval;
        [SerializeField] float SpecialIntervalModifier;
        [SerializeField] ShapedArea SpecialAttackArea;
        [SerializeField] int SpecialAttackDamage;

        private float SpecialAttackInterval =>
            BaseSpecialInterval + Random.Range(-SpecialIntervalModifier, SpecialIntervalModifier);

        public override void Initialize(HeroCharacter hero, ActorStats stats, MonsterMovement movement, MonsterView view)
        {
            base.Initialize(hero, stats, movement, view);
            this.animationEvents?.Initialize(OnSwing, OnSpecialCast);
        }

        private IEnumerator WaitForSpecialAttack()
        {
            yield return new WaitForSeconds(SpecialAttackInterval);
            CastSpecialAttack();
        }

        private float AttackInterval => AttackFrequency + Random.Range(-FrequencyModifier, FrequencyModifier);

        private bool IsFarFromHero =>
            Vector3.Distance(transform.position, hero.Position) > ProximityThreshold;
        
        void Update()
        {
            if (!isPerformingAction)
            {
                if (IsFarFromHero)
                    movement.MoveTowards(hero.Position);
                else
                    Attack();
            }
        }

        private void Attack()
        {
            movement.MoveTowards(hero.Position);
            cone.LookAt(hero.Position);
            isPerformingAction = true;
            view.ShowAttack();
            StartCoroutine(WaitForNextAttack());
        }

        private IEnumerator WaitForNextAttack()
        {
            yield return new WaitForSeconds(AttackInterval);
            isPerformingAction = false;
        }

        public override void Enable()
        {
            base.Enable();
            StartCoroutine(WaitForSpecialAttack());
        }

        private void CastSpecialAttack()
        {
            StopAllCoroutines();
            isPerformingAction = true;
            movement.Stop();
            view.ShowSpecialCast();
            StartCoroutine(WaitForNextAttack());
            StartCoroutine(WaitForSpecialAttack());
        }

        private void OnSpecialCast()
        {
            view.ShowSpecialAttack();
            if (SpecialAttackArea.IsInArea(hero.Position))
                hero.ReceiveDamage(SpecialAttackDamage);
        }
    }
}
