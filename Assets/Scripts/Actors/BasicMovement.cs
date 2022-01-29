using Assets.Scripts.Areas;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class BasicMovement : MonoBehaviour
    {
        [SerializeField] float moveSpeed;
        ConeArea attackArea;

        public void Do(Vector3 moveDirection)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            attackArea.SetDirection(moveDirection);
        }

        public void Initialize(ConeArea attackArea) => this.attackArea = attackArea;

    }
}
