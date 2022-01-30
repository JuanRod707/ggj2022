﻿using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Actors.Hero
{
    public class Dash : MonoBehaviour
    {
        [SerializeField] float duration;
        [SerializeField] float speed;
        [SerializeField] NavMeshAgent agent;

        HeroMovement movement;
        Vector3 direction;
        float elapsedTime;

        public void Initialize(HeroMovement movement)
        {
            this.movement = movement;
            enabled = false;
        }

        public void Do(Vector3 direction)
        {
            if (!enabled && movement.enabled)
            {
                this.direction = direction.normalized;
                movement.Disable();
                elapsedTime = 0f;
                enabled = true;
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
        }
    }
}
