using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class FillBar : MonoBehaviour
    {
        [SerializeField] Image bar;

        int maxValue;

        public void Initialize(int maxValue) =>
            this.maxValue = maxValue;

        public void InitializeFull(int maxValue)
        {
            this.maxValue = maxValue;
            SetValue(maxValue);
        }

        public void SetValue(int value)
        {
            bar.fillAmount =  value / (float)maxValue;
        }
    }
}
