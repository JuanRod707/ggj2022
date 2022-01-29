using Assets.Scripts.Areas;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class HeroCharacter : MonoBehaviour
    {
        [SerializeField] BasicMovement movement;
        [SerializeField] BasicAttack attack;
        [SerializeField] ConeArea attackArea;

        public void Initialize()
        {
            movement.Initialize(attackArea);
            attack.Initialize(attackArea);
        }

        public void MoveTowards(Vector3 movementVector) => 
            movement.Do(movementVector);

        public void Attack() => attack.Do();
    }
}
