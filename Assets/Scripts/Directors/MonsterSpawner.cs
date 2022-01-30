using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors.Monsters;
using Assets.Scripts.Common;
using Assets.Scripts.Persistence;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Directors
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] MonsterWeightedList monsterPrefabs;

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
                var prefab = monsterPrefabs.TakeOne();
                var monster = Instantiate(prefab, transform);
                var spawnPos = Random.insideUnitCircle * radius;
                monster.transform.position = new Vector3(spawnPos.x, 0, spawnPos.y);
                monsters.Add(monster);
            }

        }

        [Serializable]
        public class MonsterWeightPair
        {
            public Monster Monster;
            public int Weight;
        }

        [Serializable]
        public class MonsterWeightedList
        {
            [SerializeField] MonsterWeightPair[] materialWeights;

            public Monster TakeOne()
            {
                var flatList = new List<Monster>();
                foreach (var mw in materialWeights)
                {
                    foreach (var _ in Enumerable.Range(0, mw.Weight))
                        flatList.Add(mw.Monster);
                }

                return flatList.PickOne();
            }
        }
    }
}
