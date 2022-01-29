using Assets.Scripts.Areas;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Actors
{
    public class BasicMovement : MonoBehaviour
    {
        [SerializeField] NavMeshAgent agent;

        ConeArea attackArea;
        float moveSpeed;

        public void Do(Vector3 moveDirection)
        {
            if (enabled && agent.isOnNavMesh)
            {
                agent.Move(moveDirection * moveSpeed * Time.fixedDeltaTime);
                attackArea.SetDirection(moveDirection);
            }
        }

        public void Initialize(ConeArea attackArea, float moveSpeed)
        {
            this.attackArea = attackArea;
            this.moveSpeed = moveSpeed;
        }

        public void Disable() => 
            enabled = false;

        public void Enable() => 
            enabled = true;
    }
}
