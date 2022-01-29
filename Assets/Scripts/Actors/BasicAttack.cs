using Assets.Scripts.Areas;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class BasicAttack : MonoBehaviour
    {
        ConeArea attackArea;

        public void Do()
        {
            //usar un proveedor de enemigos para saber cuales estan en el area de ataque

            Debug.Log("I attacked");
        }

        public void Initialize(ConeArea attackArea) => 
            this.attackArea = attackArea;
    }
}
