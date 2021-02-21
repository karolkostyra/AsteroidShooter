using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSensor : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform sensorTransform;
    //[SerializeField] private Transform playerTransform;
    [SerializeField] private float rangeSpeed;
    [SerializeField] private float rangeMax;
    private float range;

    private List<Collider2D> alreadyPingedColliderList;

    private void Awake()
    {
        alreadyPingedColliderList = new List<Collider2D>();
    }

    private void Update()
    {
        range += rangeSpeed * Time.deltaTime;

        if(range > rangeMax)
        {
            range = 0f;
            alreadyPingedColliderList.Clear();
        }
        sensorTransform.localScale = new Vector3(range, range);

        RaycastHit2D[] raycastHit2DArray = Physics2D.CircleCastAll(transform.position, range * 2.5f, Vector2.zero);

        foreach(RaycastHit2D raycastHit2D in raycastHit2DArray)
        {
            if (raycastHit2D.collider.isTrigger &&
                raycastHit2D.collider.gameObject.GetComponent<Asteroid>() != null)
            {
                //Debug.Log(raycastHit2D.collider.name);
                if (!alreadyPingedColliderList.Contains(raycastHit2D.collider))
                {
                    alreadyPingedColliderList.Add(raycastHit2D.collider);
                    Transform radarPing = Instantiate(prefab, raycastHit2D.point, Quaternion.identity);
                }
            }
        }
    }
}
