using Assets.Scripts.Actors;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] HeroCharacter character;
        [SerializeField] PlayerInput input;

        public void Initialize()
        {
            character.Initialize();
            input.Initialize(character);
        }
    }
}
