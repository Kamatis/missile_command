using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    public OnDeath onDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            onDeath?.Invoke();
        }
    }

    [System.Serializable]
    public class OnDeath : UnityEvent { }
}
