using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class HealthViewSliderSmoothly : HealthView
{
    [SerializeField] private float _deley;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public override void UpdateHealthView(float healthCount, float maxHealthCount)
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

        _slider.fillRect.gameObject.SetActive(healthCount <= 0);

        if (healthCount <= maxHealCount)
        {
            for (int i = 0; i <= stepsCount; i++)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, targetVelue, step);

                yield return waitForSeconds;
            }
        }
    }
}
