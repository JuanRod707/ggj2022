using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class ActorView : MonoBehaviour
    {
        [SerializeField] SpriteRenderer sprite;
        [SerializeField] Animator swordSwing;
        public void OnMoved(Vector3 movementVector)
        {
            if (movementVector.magnitude > 0)
                sprite.flipX = movementVector.x < 0;
        }

        public void OnAttack()
        {
            swordSwing.SetTrigger("Swing");
        }
    }
}
