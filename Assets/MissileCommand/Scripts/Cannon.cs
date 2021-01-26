using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Building
{
    public float reloadSpeed;
    public float rebuildSpeed;
    public Bullet bulletPrefab;

    private float _lastFire = 0f;
    private bool _canFire = true;

    private bool _isDead = false;
    private bool _isRebuilding = false;

    public void Fire(Vector2 target, float moveSpeed, float power)
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.moveSpeed = moveSpeed;
        bullet.power = power;
        bullet.target = target;

        _canFire = false;
        StartCoroutine(Reload());
    }

    public bool CanFire()
    {
        return _canFire && IsAlive();
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        _canFire = true;
    }

    private IEnumerator Rebuild()
    {
        _isRebuilding = true;
        yield return new WaitForSeconds(rebuildSpeed);
        _isRebuilding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            if(!_isRebuilding && !_isDead)
            {
                StartCoroutine(Rebuild());
            } else if(_isRebuilding)
            {
                onDeath?.Invoke();
                Die();
            }
        }
    }

    private void Die()
    {
        _isDead = true;
        Destroy(gameObject);
    }

    public override bool IsAlive()
    {
        return !_isDead && !_isRebuilding;
    }
}
