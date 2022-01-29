using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors;
using Assets.Scripts.Areas;
using UnityEngine;

namespace Assets.Scripts.Directors
{
    public class MonsterProvider : MonoBehaviour
    {
        [SerializeField] Monster[] monsters;
        private HeroCharacter hero;

        public void Initialize()
        {
            foreach (var m in monsters)
                m.Initialize(hero, OnMonsterDied);
        }

        public IEnumerable<Monster> GetMonstersInArea(ConeArea area) =>
            monsters.Where(m => m.IsAlive && area.IsInArea(m.transform.position));

        void OnMonsterDied(Monster monster)
        {
           //if(!monsters.Any(m => m.IsAlive))
               //player wins
        }
    }
}
