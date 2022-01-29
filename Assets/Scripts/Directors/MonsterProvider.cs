using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Actors.Monsters;
using Assets.Scripts.Areas;
using UnityEngine;

namespace Assets.Scripts.Directors
{
    public class MonsterProvider : MonoBehaviour
    {
        IEnumerable<Monster> monsters;

        public void Initialize(HeroCharacter hero)
        {
            monsters = GetComponentsInChildren<Monster>();

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
