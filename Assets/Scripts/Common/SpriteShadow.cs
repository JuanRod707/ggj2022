using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Common
{
    public class SpriteShadow : MonoBehaviour
    {
        void Start()
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.shadowCastingMode = ShadowCastingMode.TwoSided;
            renderer.receiveShadows = true;
        }
    }
}
