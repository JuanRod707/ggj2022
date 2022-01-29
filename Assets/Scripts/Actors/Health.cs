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
        int currentHitpoints;
        Action onDeath;

        public void Initialize(int hitpoints, Action onDeath)
        {
            this.onDeath = onDeath;
            currentHitpoints = hitpoints;
        }

        public void ReceiveDamage(int damage)
        {
            currentHitpoints -= damage;
            if (currentHitpoints <= 0)
                onDeath();
        }
    }
}
