using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class Health: MonoBehaviour
    {
        public int Current { get; private set; }
        Action onDeath;
        Action onHurt;

        bool isImmune;

        public void Initialize(int hitpoints, Action onDeath, Action onHurt)
        {
            this.onDeath = onDeath;
            this.onHurt = onHurt;
            Current = hitpoints;
        }

        public void ReceiveDamage(int damage)
        {
            if (isImmune)
                return;

            Current -= damage;
            onHurt();
            isImmune = true;
            StartCoroutine(BecomeImmune());

            if (Current <= 0)
                onDeath();
        }

        IEnumerator BecomeImmune()
        {
            yield return new WaitForSeconds(1.5f);
            isImmune = false;
        }
    }
}
