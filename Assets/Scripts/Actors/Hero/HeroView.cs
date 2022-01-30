using UnityEngine;

namespace Assets.Scripts.Actors.Hero
{
    public class HeroView : MonoBehaviour
    {
        [SerializeField] SpriteRenderer sprite;
        [SerializeField] Animator swordSwing;
        [SerializeField] Animator animator;
        [SerializeField] float moveSpeedFactor;

        [SerializeField] ParticleSystem dashVfx;

        public void Initialize()
        {
            OnStopDash();
        }

        public void OnMoved(Vector3 movementVector)
        {
            animator.SetFloat("MoveSpeed", movementVector.magnitude * moveSpeedFactor);

            if (movementVector.magnitude > 0)
                sprite.flipX = movementVector.x < 0;
        }

        public void OnAttack() => 
            swordSwing.SetTrigger("Swing");

        public void OnDash()
        {
            var emission = dashVfx.emission;
            emission.enabled = true;
        }

        public void OnStopDash()
        {
            var emission = dashVfx.emission;
            emission.enabled = false;
        }

        public void OnStop() => 
            animator.SetFloat("MoveSpeed", 0);
    }
}
