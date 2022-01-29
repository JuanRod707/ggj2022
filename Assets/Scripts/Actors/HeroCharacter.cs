using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class HeroCharacter : MonoBehaviour
    {
        [SerializeField] BasicMovement movement;

        public void MoveTowards(Vector2 movementVector) => 
            movement.MoveTowards(movementVector);
    }
}
