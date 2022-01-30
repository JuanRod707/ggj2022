using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Actors.Monsters;
using Assets.Scripts.Areas;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Directors
{
    public class MonsterProvider : MonoBehaviour
    {
        [SerializeField] MonsterSpawner spawner;

        IEnumerable<Monster> monsters;
        Action onAllMonstersDead;

        public void Initialize(HeroCharacter hero, Action onAllMonstersDead)
        {
            spawner.Initialize();
            monsters = spawner.SpawnedMonsters;

            this.onAllMonstersDead = onAllMonstersDead;

            foreach (var m in monsters)
                m.Initialize(hero, OnMonsterDied);
        }

        public IEnumerable<Monster> GetMonstersInArea(ConeArea area) =>
            monsters.Where(m => m.IsAlive && area.IsInArea(m.transform.position));

        void OnMonsterDied(Monster monster)
        {
            if (monsters.All(m => !m.IsAlive))
                onAllMonstersDead();
        }
    }
}
