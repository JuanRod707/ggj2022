using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class Health: MonoBehaviour
    {
        private int currentHitpoints;

        public void Initialize(int hitpoints)
        {
            currentHitpoints = hitpoints;

        }

        public void ReceiveDamage(int damage)
        {
            currentHitpoints -= damage;
            Debug.Log("current hp: " + currentHitpoints);
        }
    }
}
