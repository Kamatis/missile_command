using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public List<Cannon> cannons;

    public void OnTappedScreen(Vector2 position)
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
        GetNearestAvailableCannon(worldPosition)?.Fire(worldPosition, 1f, 1f);
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
