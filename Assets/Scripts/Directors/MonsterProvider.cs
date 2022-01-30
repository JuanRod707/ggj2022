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
        [SerializeField] Monster monsterPrefab;
        [SerializeField] int amount;
        [SerializeField] float radius;

        List<Monster> monsters;
        Action onAllMonstersDead;

        public void Initialize(HeroCharacter hero, Action onAllMonstersDead)
        {
            monsters = new List<Monster>();
            SpawnMonsters();

            this.onAllMonstersDead = onAllMonstersDead;

            foreach (var m in monsters)
                m.Initialize(hero, OnMonsterDied);
        }

        void SpawnMonsters()
        {
            foreach (var _ in Enumerable.Range(0, amount))
            {
                var monster = Instantiate(monsterPrefab, transform);
                var spawnPos = Random.insideUnitCircle * radius;
                monster.transform.position = new Vector3(spawnPos.x, 0, spawnPos.y);
                monsters.Add(monster);
            }

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
