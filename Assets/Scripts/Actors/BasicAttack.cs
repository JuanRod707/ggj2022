using Assets.Scripts.Areas;
using UnityEngine;
using Assets.Scripts.Directors;

namespace Assets.Scripts.Actors
{
    public class BasicAttack : MonoBehaviour
    {
        ConeArea attackArea;
        MonsterProvider monsterProvider;
        public void Do()
        {

            var hits = monsterProvider.GetMonstersInArea(attackArea);
            foreach (var monster in hits)
            {
                Debug.Log("Le pegué a un monstruo");
                //var damage = Random.Range(stats.MinDamage, stats.MaxDamage);
                monster.ReceiveDamage(5);
            }

            Debug.Log("I attacked");
        }

        public void Initialize(ConeArea attackArea, MonsterProvider monsterProvider)
        {
            this.monsterProvider = monsterProvider;
            this.attackArea = attackArea;
        }
    }
}
