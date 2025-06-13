using UnityEngine;

// Herdar para criar o sistema de vida dos inimigos
public abstract class DamageableEntity : MonoBehaviour
{
    [SerializeField] protected int life;

    protected bool isDead;

    public virtual void TakeDamage(int value)
    {
        life -= value;
        if (life <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if (isDead) return;
        isDead = true;
    }
}
