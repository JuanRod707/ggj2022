using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class FillBar : MonoBehaviour
    {
        [SerializeField] Image bar;

        int maxValue;
        float targetValue;

        public void Initialize(int maxValue) =>
            this.maxValue = maxValue;

        public void InitializeFull(int maxValue)
        {
            this.maxValue = maxValue;
            SetValue(maxValue);
        }

        public void SetValue(int value)
        {
            targetValue =  value / (float)maxValue;
        }

        void Update()
        {
            bar.fillAmount = Mathf.Lerp(bar.fillAmount, targetValue, 0.1f);
        }
    }
}
