using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Actors.Monsters
{
    public class BlitzAi : BaseAi
    {
        [SerializeField] float ProximityThreshold;
        [SerializeField] float BaseAttackFrequency;
        [SerializeField] float FrequencyModifier;
        [SerializeField] float BaseRetreatTimer;
        [SerializeField] float RetreatModifier;

        private float attackInterval => BaseAttackFrequency + Random.Range(-FrequencyModifier, FrequencyModifier);
        private float retreatInterval => BaseRetreatTimer + Random.Range(-RetreatModifier, RetreatModifier);

        private bool IsFarFromHero =>
            Vector3.Distance(transform.position, hero.Position) > ProximityThreshold;

        private bool isRetreating;
        private bool isChasing = true;
        private Vector3 retreatTarget;

        void Update()
        {
            if (isRetreating)
            {
                movement.MoveTowards(retreatTarget);
            }
            else if (isChasing)
            {
                if (!isPerformingAction)
                {
                    if (IsFarFromHero)
                        movement.MoveTowards(hero.Position);
                    else
                        Attack();
                }
            }
        }

        private void Attack()
        {
            movement.MoveTowards(hero.Position);
            cone.SetDirection(hero.Position);
            isPerformingAction = true;
            view.ShowAttack();
            StartCoroutine(WaitForNextAttack());
        }

        private IEnumerator WaitForNextAttack()
        {
            yield return new WaitForSeconds(attackInterval);
            isPerformingAction = false;
        }

        protected override void OnSwing()
        {
            if (cone.IsInArea(hero.Position))
            {
                hero.ReceiveDamage(10);
                StartCoroutine(Retreat());
            }
        }

        private IEnumerator Retreat()
        {
            isRetreating = true;
            isChasing = false;
            retreatTarget = transform.position + (Random.insideUnitSphere.normalized * 10);
            yield return new WaitForSeconds(retreatInterval);
            isRetreating = false;
            StartCoroutine(IdleAndResumeAttack());
        }

        private IEnumerator IdleAndResumeAttack()
        {
            retreatTarget = transform.position;
            movement.Stop();
            yield return new WaitForSeconds(retreatInterval);
            isChasing = true;
        }
    }
}
