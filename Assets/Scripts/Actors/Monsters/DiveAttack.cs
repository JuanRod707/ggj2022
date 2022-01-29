using Assets.Scripts.Actors.Monsters;
using Assets.Scripts.Areas;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Actors.AI
{
    public class DiveAttack : MonoBehaviour
    {
        [SerializeField] float duration;
        [SerializeField] float speed;
        [SerializeField] NavMeshAgent agent;

        float elapsed;
        MonsterView view;
        Vector3 direction;

        public void Initialize(ConeArea cone, MonsterView view)
        {
            this.view = view;
            enabled = false;
        }

        public void Do(Vector3 direction)
        {
            this.direction = direction.normalized;
            view.ShowAttack();
            elapsed = duration;
            enabled = true;
        }

        void Update()
        {
            var moveVector = direction * speed * Time.deltaTime;
            agent.Move(moveVector);

            view.ShowMovement(moveVector);
            elapsed -= Time.deltaTime;
            if(elapsed <= 0)
                OnDashFinised();
        }

        void OnDashFinised()
        {
            enabled = false;
        }
    }
}
