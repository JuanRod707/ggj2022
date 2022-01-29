using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Areas
{
    public class ConeArea : MonoBehaviour
    {
        [SerializeField] float length;
        [SerializeField] float angle;

        float Aperture => Mathf.Sin(angle / 2 * Mathf.Deg2Rad)
                          / Mathf.Cos(angle / 2 * Mathf.Deg2Rad);

        void OnDrawGizmos()
        {
            var arcLimitRight = new Vector2(Aperture, 1) * length;
            var arcLimitLeft = new Vector2(-Aperture, 1) * length;

            Debug.DrawLine(transform.position, transform.TransformPoint(arcLimitLeft), Color.yellow);
            Debug.DrawLine(transform.position, transform.TransformPoint(arcLimitRight), Color.yellow);
            //Handles.DrawWireArc(transform.position, transform.forward, transform.up, angle, length);
        }

        public bool IsInArea(Vector2 target)
        {
            var targetRelative = transform.InverseTransformPoint(target);
            var inRange = Vector2.Distance(transform.position, target) < length;
            var inArcRight = targetRelative.x + Aperture * targetRelative.y > 0;
            var inArcLeft = targetRelative.x - Aperture * targetRelative.y < 0;

            var isInArc = inArcRight & inArcLeft;
            return inRange && isInArc;
        }
    }
}
