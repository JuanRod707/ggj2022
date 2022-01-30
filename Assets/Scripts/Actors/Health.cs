using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Directors;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class Health: MonoBehaviour
    {
        public int Current { get; private set; }
        Action onDeath;
        Action onHurt;

        public void Initialize(int hitpoints, Action onDeath, Action onHurt)
        {
            this.onDeath = onDeath;
            this.onHurt = onHurt;
            Current = hitpoints;
        }

        public void ReceiveDamage(int damage)
        {
            Current -= damage;
            onHurt();
            if (Current <= 0)
                onDeath();
        }
    }
}
