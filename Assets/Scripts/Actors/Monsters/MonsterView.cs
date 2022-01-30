using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actors.Monsters
{
    public class MonsterView : MonoBehaviour
    {
        [SerializeField] SpriteRenderer sprite;

        void Update() => 
            sprite.transform.rotation = Camera.main.transform.rotation;

        public void WakeUp()
        {
            
        }

        public void StopMoving()
        {
        }

        public void ShowMovement(Vector3 moveVector)
        {
            if (moveVector.magnitude > 0)
                sprite.flipX = moveVector.x < 0;
        }

        public void ShowAttack()
        {
        }

        public void ShowSpecialCast()
        {
        }

        public void ShowSpecialAttack()
        {
        }

        public void Initialize()
        {
        }
    }
}
