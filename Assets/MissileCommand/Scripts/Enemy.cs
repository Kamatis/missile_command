using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public bool canAttack;
    public float moveSpeed = 2f;
    public Vector3 target;
    public bool hasTarget;

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
