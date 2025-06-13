using System;
using UnityEngine;
// Colocar isso no player e adaptar
public class PlayerHealth : DamageableEntity
{
    [SerializeField] private float invencibleTime = 2.5f;

    private Vector2 originalPosition;
    private float invencibleTimeEnd;
    public static Action <int> OnLifeChanged;

    private void Awake()
    {
        originalPosition = transform.position;
    }

    public override void TakeDamage(int value)
    {
        if (Time.time < invencibleTimeEnd) return;
        invencibleTimeEnd = Time.time + invencibleTime;
        transform.position = originalPosition;
        base.TakeDamage(value);
        OnLifeChanged?.Invoke(life);
    }
}
