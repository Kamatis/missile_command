using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float reloadSpeed;
    public float rebuildSpeed;
    public Bullet bulletPrefab;

    private float _lastFire = 0f;
    private bool _canFire = true;

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
        return _canFire;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        _canFire = true;
    }
}
