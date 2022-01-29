using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class ElasticAnchor : MonoBehaviour
    {
        [SerializeField] Transform anchor;
        [SerializeField] float elasticity;

        void Update() => 
            transform.position = Vector3.Lerp(transform.position, anchor.position, elasticity * Time.deltaTime);
    }
}
