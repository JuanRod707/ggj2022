using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Directors;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] HeroCharacter character;
        [SerializeField] PlayerInput input;

        public HeroCharacter Hero => character;

        public void Initialize(MonsterProvider monsterProvider)
        {
            character.Initialize(monsterProvider);
            input.Initialize(character);
        }
    }
}
