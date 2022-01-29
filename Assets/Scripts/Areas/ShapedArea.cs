using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Areas
{
    public abstract class ShapedArea : MonoBehaviour
    {
        public virtual bool IsInArea(Vector3 target) => false;

        public void LookAt(Vector3 target)
        {
            transform.LookAt(target);
            var euler = transform.eulerAngles;
            euler.z = 0f;
            euler.x = 0f;
            transform.eulerAngles = euler;
        }
    }
}
