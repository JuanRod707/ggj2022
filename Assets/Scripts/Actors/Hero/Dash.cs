using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Actors.Hero
{
    public class Dash : MonoBehaviour
    {
        [SerializeField] float duration;
        [SerializeField] NavMeshAgent agent;

        float speed;
        HeroMovement movement;
        Vector3 direction;
        float elapsedTime;
        HeroView view;

        public void Initialize(HeroMovement movement, HeroView view, ActorStats stats)
        {
            this.view = view;
            this.movement = movement;
            enabled = false;
            speed = stats.MoveSpeed * 3;
        }

        public void Do(Vector3 direction)
        {
            if (!enabled && movement.enabled)
            {
                this.direction = direction.normalized;
                movement.Disable();
                elapsedTime = 0f;
                enabled = true;
                view.OnDash();
            }

        }

        void FixedUpdate()
        {
            var moveVector = direction * speed * Time.fixedDeltaTime;

            if(agent.isOnNavMesh)
                agent.Move(moveVector);

            elapsedTime += Time.fixedDeltaTime;
            if (elapsedTime > duration)
                OnDashComplete();
        }

        void OnDashComplete()
        {
            movement.Enable();
            enabled = false;
            view.OnStopDash();
        }
    }
}
