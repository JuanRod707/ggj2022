using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Persistence;
using Assets.Scripts.Player;
using Assets.Scripts.Trophies;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Directors
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField] PlayerEntity player;
        [SerializeField] MonsterProvider monsterProvider;
        [SerializeField] TrophyGenerator trophySpawner;

        void Start()
        {
            player.Initialize(monsterProvider, EndLevel);
            monsterProvider.Initialize(player.Hero, OnAllMonstersDead);
        }

        void EndLevel()
        {
            SessionData.Level++;
            Invoke("NextLevel", 2f);
        }

        void NextLevel() => SceneManager.LoadScene("Encounter");

        void OnAllMonstersDead()
        {
            trophySpawner.transform.position = player.Hero.Position;
            trophySpawner.Show();
            player.EnableSelectTrophy(new [] { trophySpawner.ProsperityTrophy, trophySpawner.RuinTrophy });
        }
    }
}
