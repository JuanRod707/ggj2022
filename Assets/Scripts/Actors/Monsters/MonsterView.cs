﻿using Assets.Scripts.Audio;
using UnityEngine;

namespace Assets.Scripts.Actors.Monsters
{
    public class MonsterView : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] SpriteRenderer sprite;
        [SerializeField] ParticleSystem trailVfx;
        [SerializeField] AudioPlayer audio;

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
            audio.PlayAttack();
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

        public void OnDash()
        {
            animator.SetTrigger("Attack");
            var emitter = trailVfx.emission;
            emitter.enabled = true;
            audio.PlayDash();
        }

        public void OnStopDash()
        {
            var emitter = trailVfx.emission;
            emitter.enabled = false;
        }

        public void OnHurt() =>
            audio.PlayHit();
    }
}
