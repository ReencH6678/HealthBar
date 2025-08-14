using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthViewSlider : MonoBehaviour
{
    [SerializeField] protected Health _health;
    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.OnHealthChange += UpdateHealthView;
    }

    private void OnDisable()
    {
        _health.OnHealthChange -= UpdateHealthView;
    }

    virtual public void UpdateHealthView(float healthCount, float maxHealthCount)
    {
        float divisor = 100;
        _slider.value = healthCount / divisor;

        UpdateHealthVisibility(_slider.value);
    }

    public void UpdateHealthVisibility(float sliderVelue)
    {
        if (sliderVelue <= 0)
            _slider.fillRect.gameObject.SetActive(false);
        else
            _slider.fillRect.gameObject.SetActive(true);
    }
}
