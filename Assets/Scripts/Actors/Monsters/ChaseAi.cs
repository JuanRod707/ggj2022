using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Actors.Monsters
{
    public class ChaseAi : BaseAi
    {
        [SerializeField] float ProximityThreshold;
        [SerializeField] float AttackFrequency;
        [SerializeField] float FrequencyModifier;

        private float attackInterval => AttackFrequency + Random.Range(-FrequencyModifier, FrequencyModifier);

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

            OnSwing();

            StartCoroutine(WaitForNextAttack());
        }

        private IEnumerator WaitForNextAttack()
        {
            yield return new WaitForSeconds(attackInterval);
            isPerformingAction = false;
        }
    }
}
