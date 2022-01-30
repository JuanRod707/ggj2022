using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Directors;
using Assets.Scripts.Persistence;
using Assets.Scripts.Trophies;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] HeroCharacter character;
        [SerializeField] PlayerInput input;
        [SerializeField] SelectTrophyInput trophyInput;
        [SerializeField] FillBar hpBar;
        [SerializeField] FillBar ruinBar;
        [SerializeField] FillBar prospBar;
        [SerializeField] StatPanel statPanel;

        IEnumerable<Trophy> trophies;
        Action onEndLevel;

        public HeroCharacter Hero => character;

        public void EnableSelectTrophy(IEnumerable<Trophy> trophies)
        {
            this.trophies = trophies;
            input.enabled = false;
            trophyInput.enabled = true;
        }

        public void Initialize(MonsterProvider monsterProvider, Action onEndLevel)
        {
            this.onEndLevel = onEndLevel;
            trophyInput.enabled = false;
            input.enabled = true;
            character.Initialize(monsterProvider, hpBar);
            input.Initialize(character);
            trophyInput.Initialize(SelectRuin, SelectProsperity);

            prospBar.Initialize(100);
            ruinBar.Initialize(100);

            prospBar.SetValue(SessionData.Prosperity);
            ruinBar.SetValue(SessionData.Ruin);

            statPanel.SetValues(Hero.currentStats);
        }

        void SelectProsperity()
        {
            var trophy = trophies.First(t => t.Alignment == Alignment.Prosperity);
            SessionData.playerStats = Hero.currentStats.WithTrophy(trophy);
            SessionData.Prosperity += trophy.Affinity;

            statPanel.SetValues(SessionData.playerStats);
            prospBar.SetValue(SessionData.Prosperity);
            
            onEndLevel();
        }

        void SelectRuin()
        {
            var trophy = trophies.First(t => t.Alignment == Alignment.Ruin);
            SessionData.playerStats = Hero.currentStats.WithTrophy(trophy);
            SessionData.Ruin += trophy.Affinity;

            statPanel.SetValues(SessionData.playerStats);
            ruinBar.SetValue(SessionData.Ruin);

            onEndLevel();
        }
    }
}
