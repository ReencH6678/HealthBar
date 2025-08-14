using UnityEngine;
using System.Collections;

public class HealthViewSliderSmoothly : HealthViewSlider
{
    [SerializeField] private float _deley;

    override public void UpdateHealthView(float healthCount, float maxHealthCount)
    {
        StopCoroutine(SmothLine(healthCount, maxHealthCount));
        StartCoroutine(SmothLine(healthCount, maxHealthCount));
    }

    private IEnumerator SmothLine(float healthCount, float maxHealCount)
    {
        float divisor = 100;
        float targetVelue = healthCount / divisor;

        float step = 0.01f;
        float stepsCount = Mathf.Abs(targetVelue - _slider.value) / step;

        var waitForSeconds = new WaitForSeconds(_deley);

        if (healthCount <= maxHealCount)
        {
            for (int i = 0; i <= stepsCount; i++)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, targetVelue, step);

                UpdateHealthVisibility(_slider.value);

                yield return waitForSeconds;
            }
        }
    }
}
