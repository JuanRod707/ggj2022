using System;
using UnityEngine;

namespace Assets.Scripts.Actors.Monsters
{
    public class AnimationEvents : MonoBehaviour
    {
        Action onDamage;
        Action onSpecialCast;

        public void Initialize(Action onDamage) => this.onDamage = onDamage;

        public void Initialize(Action onDamage, Action onSpecialCast)
        {
            this.onDamage = onDamage;
            this.onSpecialCast = onSpecialCast;
        }

        public void OnDamageFrame() => onDamage();
        public void OnSpecialCastFrame() => onSpecialCast();

    }
}
