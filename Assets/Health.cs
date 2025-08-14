using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxCount;
    public float Count { get; private set; }

    public event Action<float, float> Changed;

    private void Start()
    {
        Count = _maxCount;
        Changed?.Invoke(Count, _maxCount);
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            Count -= damage;
            Changed?.Invoke(Count, _maxCount);
        }
    }

    public void Heal(float healCount)
    {
        if (healCount > 0)
        {
            Count += healCount;
            Changed?.Invoke(Count, _maxCount);
        }
    }
}
