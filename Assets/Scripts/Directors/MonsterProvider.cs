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

        public void Initialize() { }

        public IEnumerable<Monster> GetMonstersInArea(ConeArea area) =>
            monsters.Where(a => area.IsInArea(a.transform.position));
    }
}
