using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Actors.Hero;
using Assets.Scripts.Directors;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Actors.Monsters
{
    public class ProximityDetector : MonoBehaviour
    {
        public float ActivationDistance;

        private HeroCharacter hero;
        private BaseAi ai;
        private MonsterView view;

        bool HeroInRange => Vector3.Distance(transform.position, hero.Position) < ActivationDistance;

        public void Initialize(HeroCharacter hero, BaseAi ai, MonsterView view)
        {
            this.view = view;
            this.ai = ai;
            this.hero = hero;

            ai.Disable();
        }

        void Update()
        {
            if (HeroInRange)
            {
                ai.Enable();
                view.WakeUp();
                enabled = false;
            }
        }

        void OnDrawGizmos() => Handles.DrawWireDisc(transform.position, Vector3.up, ActivationDistance);
    }
}
