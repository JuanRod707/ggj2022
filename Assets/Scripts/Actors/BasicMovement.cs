using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class BasicMovement : MonoBehaviour
    {
        [SerializeField] float moveSpeed;

        public void MoveTowards(Vector2 moveDirection) => 
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
