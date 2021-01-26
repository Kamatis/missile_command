using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public bool canAttack;

    protected virtual void Update()
    {
        Move();

        if(canAttack)
        {
            Attack();
        }
    }

    public abstract void Move();
    public abstract void Attack();
}
