using UnityEngine;

public class TargetingEnemy : Enemy
{

    public override void Attack()
    {
        
    }

    public override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
