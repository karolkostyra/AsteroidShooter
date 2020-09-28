using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    ProjectilesFactory factory = new ProjectilesFactory();

    float timeToShoot = 0.5f;
    Coroutine coroutine;

    private void OnEnable()
    {
        coroutine = StartCoroutine(AutoShoot(timeToShoot));
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator AutoShoot(float _timeToShoot)
    {
        while (this.gameObject.activeSelf)
        {
            ShootBullet();
            yield return new WaitForSeconds(_timeToShoot);
        }
    }

    private void ShootBullet()
    {
        IProjectiles bullet = factory.GetProjectileType(ProjectileTypes.Bullet);

        bullet.InstantiateProjectile(gameObject.transform.position, gameObject.transform.rotation.eulerAngles.z);
    }
}
