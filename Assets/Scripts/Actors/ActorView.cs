using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class ActorView : MonoBehaviour
    {
        [SerializeField] SpriteRenderer sprite;

        public void OnMoved(Vector3 movementVector)
        {
            if (movementVector.magnitude > 0)
                sprite.flipX = movementVector.x < 0;
        }
    }
}
