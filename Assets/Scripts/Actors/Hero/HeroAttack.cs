using System.Collections;
using Assets.Scripts.Areas;
using Assets.Scripts.Directors;
using UnityEngine;

namespace Assets.Scripts.Actors.Hero
{
    public class HeroAttack : MonoBehaviour
    {
        ConeArea attackArea;
        MonsterProvider monsterProvider;
        HeroView view;
        ActorStats stats;

        bool canAttack;

        public void Do()
        {
            if (canAttack)
            {
                canAttack = false;
                view.OnAttack();
                var hits = monsterProvider.GetMonstersInArea(attackArea);
                foreach (var monster in hits)
                {
                    var damage = Random.Range(stats.MinDamage, stats.MaxDamage + 1);
                    monster.ReceiveDamage(damage);
                }

                StartCoroutine(AttackCooldown());
            }
        }

        public IEnumerator AttackCooldown()
        {
            yield return new WaitForSeconds(stats.AttackSpeed);
            canAttack = true;
        }


        public void Initialize(ActorStats stats, HeroView view, ConeArea attackArea, MonsterProvider monsterProvider)
        {
            this.stats = stats;
            this.view = view;
            this.monsterProvider = monsterProvider;
            this.attackArea = attackArea;

            canAttack = true;
        }
    }
}
