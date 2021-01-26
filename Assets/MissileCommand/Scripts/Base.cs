using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : Building
{
    public OnDeath onDeath;

    private bool _isDead;

    public override bool IsAlive()
    {
        return !_isDead;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            _isDead = true;
            onDeath?.Invoke();
        }
    }


    [System.Serializable]
    public class OnDeath : UnityEvent { }
}
