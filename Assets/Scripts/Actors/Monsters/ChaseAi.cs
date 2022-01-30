using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Actors.Monsters
{
    public class ChaseAi : BaseAi
    {
        [SerializeField] float proximityThreshold;
        [SerializeField] float attackFrequency;
        [SerializeField] float frequencyModifier;

        private float attackInterval => attackFrequency + Random.Range(-frequencyModifier, frequencyModifier);

        private bool AtMeleeDistance =>
            Vector3.Distance(transform.position, hero.Position) < proximityThreshold;
        
        void Update()
        {
            if (!isPerformingAction)
            {
                if (AtMeleeDistance)
                    Attack();
                else
                    movement.MoveTowards(hero.Position);
                
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
