using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Directors;
using Assets.Scripts.Persistence;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] HeroCharacter character;
        [SerializeField] PlayerInput input;
        [SerializeField] FillBar hpBar;
        [SerializeField] FillBar ruinBar;
        [SerializeField] FillBar prospBar;

        public HeroCharacter Hero => character;

        public void Initialize(MonsterProvider monsterProvider)
        {
            character.Initialize(monsterProvider, hpBar);
            input.Initialize(character);

            prospBar.Initialize(100);
            ruinBar.Initialize(100);

            prospBar.SetValue(SessionData.Prosperity);
            ruinBar.SetValue(SessionData.Ruin);
        }
    }
}
