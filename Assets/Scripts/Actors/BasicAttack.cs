using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class BasicAttack : MonoBehaviour
    {
        public void Do() => 
            Debug.Log("I attacked");
    }
}
