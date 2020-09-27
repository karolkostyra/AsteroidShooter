using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    ProjectilesFactory factory = new ProjectilesFactory();

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        IProjectiles bullet = factory.GetProjectileType(ProjectileTypes.Bullet);

        bullet.InstantiateProjectile(gameObject.transform.position, gameObject.transform.rotation.eulerAngles.z);
    }
}
