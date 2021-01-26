using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public List<Cannon> cannons;
    public float fireRate = 5f;
    public float bulletSpeed = 5f;
    public float bulletPower = 2f;

    public void OnTappedScreen(Vector2 position)
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
        GetNearestAvailableCannon(worldPosition)?.Fire(worldPosition, bulletSpeed, bulletPower);
    }

    private Cannon GetNearestAvailableCannon(Vector2 targetPosition)
    {
        Cannon cannonToFire = null;
        float minimumDistance = float.MaxValue;
        foreach(Cannon cannon in cannons)
        {
            if(cannon.CanFire())
            {
                float distance = Mathf.Abs(cannon.transform.position.x - targetPosition.x);
                if (distance < minimumDistance)
                {
                    cannonToFire = cannon;
                    minimumDistance = distance;
                }
            }
        }

        return cannonToFire;
    }
}
