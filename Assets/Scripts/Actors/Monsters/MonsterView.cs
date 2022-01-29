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

        public void ShowMovement(object moveVector)
        {
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
