using UnityEngine;
using TMPro;

public class HealthViewText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _haelthCountText;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.OnHealthChange += UpdateHealthView;
    }

    private void OnDisable()
    {
        _health.OnHealthChange -= UpdateHealthView;
    }

    private void UpdateHealthView(float healthCount, float maxHealthCount)
    {
        _haelthCountText.text = $"{healthCount} / {maxHealthCount}";
    }
}
