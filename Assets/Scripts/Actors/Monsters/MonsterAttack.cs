using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Areas;
using UnityEngine;

namespace Assets.Scripts.Actors.Monsters
{
    public class MonsterAttack : MonoBehaviour
    {
        ConeArea attackArea;
        HeroCharacter hero;
        public void Do()
        {

            var hits = attackArea.IsInArea(hero.transform.position);
            if(hits)
                Debug.Log("I attacked the hero");
        }

        public void Initialize(ConeArea attackArea, HeroCharacter hero)
        {
            this.hero = hero;
            this.attackArea = attackArea;
        }
    }
}
