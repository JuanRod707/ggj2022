using UnityEngine;

namespace Assets.Scripts.Areas
{
    public class ConeArea : ShapedArea
    {
        [SerializeField] float length;
        [SerializeField] float angle;
        float k = 0.0175f;

        float Aperture => Mathf.Sin(angle / 2 * Mathf.Deg2Rad)
                          / Mathf.Cos(angle / 2 * Mathf.Deg2Rad);

        void OnDrawGizmos()
        {
            var arcLimitRight = new Vector3(Aperture, 0, 1) * length;
            var arcLimitLeft = new Vector3(-Aperture, 0, 1) * length;

            Debug.DrawLine(transform.position, transform.TransformPoint(arcLimitLeft), Color.yellow);
            Debug.DrawLine(transform.position, transform.TransformPoint(arcLimitRight), Color.yellow);
            //Handles.DrawWireArc(transform.position, -transform.up,transform.forward, angle/2, length * angle * k);
            //Handles.DrawWireArc(transform.position, transform.up, transform.forward, angle / 2, length * angle * k);
        }

        public override bool IsInArea(Vector3 target)
        {
            var targetRelative = transform.InverseTransformPoint(target);
            var inRange = Vector3.Distance(transform.position, target) < length;
            var inArcRight = targetRelative.x + Aperture * targetRelative.z > 0;
            var inArcLeft = targetRelative.x - Aperture * targetRelative.z < 0;

            var isInArc = inArcRight & inArcLeft;
            return inRange && isInArc;
        }

        public void SetDirection(Vector3 moveDirection)
        {
            var direction = transform.position + moveDirection;
            transform.LookAt(direction);
            var euler = transform.eulerAngles;
            euler.x = 0;
            euler.z = 0;

            transform.eulerAngles = euler;
        }

        public void SetConeTo(float area) => 
            angle = area;
    }
}
