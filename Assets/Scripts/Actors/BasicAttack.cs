using Assets.Scripts.Areas;
using UnityEngine;
using Assets.Scripts.Directors;

namespace Assets.Scripts.Actors
{
    public class BasicAttack : MonoBehaviour
    {
        ConeArea attackArea;
        private Provider provider;
        public void Do()
        {

            var hits = provider.GetMonstersInArea(attackArea);
            foreach (var monster in hits)
            {
                //var damage = Random.Range(stats.MinDamage, stats.MaxDamage);
                //monster.ReceiveDamage(damage);
            }

            Debug.Log("I attacked");
        }

        public void Initialize(ConeArea attackArea) => 
            this.attackArea = attackArea;
    }
}
