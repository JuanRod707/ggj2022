using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors;
using Assets.Scripts.Areas;
using UnityEngine;

namespace Assets.Scripts.Directors
{
    public class MonsterProvider : MonoBehaviour
    {
        private IEnumerable<Monster> monsters;
        private HeroCharacter hero;

        public void Initialize(IEnumerable<Monster> monsters) =>
            this.monsters = monsters;

        public IEnumerable<Monster> GetMonstersInArea(ConeArea area) =>
            monsters.Where(a => area.IsInArea(a.transform.position));
    }
}
