using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors.Monsters;
using Assets.Scripts.Persistence;
using UnityEngine;

namespace Assets.Scripts.Directors
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] Monster monsterPrefab;

        [SerializeField] int baseAmount;
        [SerializeField] float radius;
        List<Monster> monsters;

        public IEnumerable<Monster> SpawnedMonsters => monsters;

        public void Initialize() =>
            SpawnMonsters();

        void SpawnMonsters()
        {
            monsters = new List<Monster>();
            var amountToSpawn = 
                baseAmount + Mathf.FloorToInt(Random.Range(Mathf.Pow(SessionData.Level, 2), Mathf.Pow(SessionData.Level + 1, 2)));

            foreach (var _ in Enumerable.Range(0, amountToSpawn))
            {
                var monster = Instantiate(monsterPrefab, transform);
                var spawnPos = Random.insideUnitCircle * radius;
                monster.transform.position = new Vector3(spawnPos.x, 0, spawnPos.y);
                monsters.Add(monster);
            }

        }
    }
}
