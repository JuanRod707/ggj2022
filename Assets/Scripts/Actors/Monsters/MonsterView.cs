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
        [SerializeField] ParticleSystem trailVfx;

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
            if (trailVfx != null)
            {
                var emitter = trailVfx.emission;
                emitter.enabled = false;
            }
        }

        public void ShowTrailVfx()
        {
            var emitter = trailVfx.emission;
            emitter.enabled = true;
        }

        public void StopTrailVfx()
        {
            var emitter = trailVfx.emission;
            emitter.enabled = false;
        }
    }
}
