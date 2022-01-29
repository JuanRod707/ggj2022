using UnityEngine;

namespace Assets.Scripts.Actors.Hero
{
    public class HeroView : MonoBehaviour
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
