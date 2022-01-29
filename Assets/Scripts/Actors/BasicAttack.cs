using Assets.Scripts.Areas;
using UnityEngine;
using Assets.Scripts.Directors;

namespace Assets.Scripts.Actors
{
    public class BasicAttack : MonoBehaviour
    {
        ConeArea attackArea;
        MonsterProvider monsterProvider;
        ActorView view;

        public void Do()
        {
            view.OnAttack();
            var hits = monsterProvider.GetMonstersInArea(attackArea);
            foreach (var monster in hits)
            {
                Debug.Log("Le pegué a un monstruo");
                //var damage = Random.Range(stats.MinDamage, stats.MaxDamage);
                monster.ReceiveDamage(5);
            }

            Debug.Log("I attacked");
        }

        public void Initialize(ActorView view, ConeArea attackArea, MonsterProvider monsterProvider)
        {
            this.view = view;
            this.monsterProvider = monsterProvider;
            this.attackArea = attackArea;
        }
    }
}
