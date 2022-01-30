using UnityEngine;

namespace Assets.Scripts.Areas
{
    public class CircleArea : ShapedArea
    {
        public float Radius;

        //void OnDrawGizmos() =>
        //    Handles.DrawWireDisc(transform.position, Vector3.up, Radius);

        public override bool IsInArea(Vector3 target) =>
            Vector3.Distance(transform.position, target) <= Radius;
    }
}
