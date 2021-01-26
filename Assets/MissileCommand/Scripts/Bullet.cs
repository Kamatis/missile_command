using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public float power;
    public Vector3 target;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);

        if(transform.position == target)
        {
            Explode();    
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
