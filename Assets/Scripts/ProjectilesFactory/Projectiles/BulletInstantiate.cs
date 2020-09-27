using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiate : MonoBehaviour, IProjectiles
{
    [SerializeField] GameObject bulletPrefab;

    public void InstantiateProjectile(Vector3 position, float angle)
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.position = position;
        obj.transform.rotation = Quaternion.Euler(0, 0, angle);
        obj.gameObject.name = "Bullet";
    }
}
