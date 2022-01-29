using Assets.Scripts.Areas;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Actors.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] NavMeshAgent agent;
        [SerializeField] HeroView view;

        ConeArea attackArea;
        float moveSpeed;

        public void Do(Vector3 moveDirection)
        {
            if (enabled && agent.isOnNavMesh)
            {
                var moveVector = moveDirection * moveSpeed * Time.fixedDeltaTime;
                agent.Move(moveVector);
                attackArea.SetDirection(moveDirection);
                view.OnMoved(moveVector);
            }
        }

        public void Initialize(ConeArea attackArea, HeroView view, float moveSpeed)
        {
            this.view = view;
            this.attackArea = attackArea;
            this.moveSpeed = moveSpeed;
        }

        public void Disable() => 
            enabled = false;

        public void Enable() => 
            enabled = true;
    }
}
