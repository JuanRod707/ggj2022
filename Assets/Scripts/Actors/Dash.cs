using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Actors
{
    public class Dash : MonoBehaviour
    {
        [SerializeField] float duration;
        [SerializeField] float speed;
        [SerializeField] NavMeshAgent agent;

        BasicMovement movement;
        Vector3 direction;
        float elapsedTime;

        public void Initialize(BasicMovement movement)
        {
            this.movement = movement;
        }

        public void Do(Vector3 direction)
        {
            if (!enabled)
            {
                this.direction = direction.normalized;
                movement.Disable();
                elapsedTime = 0f;
                enabled = true;
            }

        }

        void FixedUpdate()
        {
            var moveVector = direction * speed * Time.fixedDeltaTime;
            agent.Move(moveVector);
            elapsedTime += Time.fixedDeltaTime;
            if (elapsedTime > duration)
                OnDashComplete();
        }

        void OnDashComplete()
        {
            movement.Enable();
            enabled = false;
        }
    }
}
