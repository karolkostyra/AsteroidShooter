using UnityEngine;

public class ProjectilesFactory
{
    public virtual IProjectiles GetProjectileType(ProjectileTypes type)
    {
        IProjectiles projectileTypes = null;

        switch (type)
        {
            case ProjectileTypes.Bullet:
                projectileTypes = GameObject.FindObjectOfType<BulletInstantiate>();
                break;
            default:
                break;
        }

        return projectileTypes;
    }
}
