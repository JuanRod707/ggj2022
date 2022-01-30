using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Actors.Monsters
{
    public class MonsterMovement : MonoBehaviour
    {
        MonsterView view;
        NavMeshAgent agent;

        public void MoveTowards(Vector3 target)
        {
            var moveVector = (target - transform.position).normalized;
            agent.SetDestination(target);

            view.ShowMovement(moveVector);
        }

        public void Initialize(float speed, MonsterView view, NavMeshAgent agent)
        {
            this.agent = agent;
            this.view = view;
            this.agent.speed = speed;
        }

        public void Stop() =>
            view.StopMoving();
    }
}
