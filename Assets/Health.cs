using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealthCount;
    public float HealthCount { get; private set; }

    public event Action<float, float> OnHealthChange;

    private void Start()
    {
        HealthCount = _maxHealthCount;
        OnHealthChange?.Invoke(HealthCount, _maxHealthCount);
    }

    public void TakeDamage(float damage)
    {
        HealthCount -= damage;
        OnHealthChange?.Invoke(HealthCount, _maxHealthCount);
    }

    public void Heal(float healCount)
    {
        HealthCount += healCount;
        OnHealthChange?.Invoke(HealthCount, _maxHealthCount);
    }
}
