using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ShipController shipController;

    private void LateUpdate()
    {
        if (shipController != null && !shipController.IsDestroyed())
        {
            gameObject.transform.position =
                new Vector3(shipController.transform.position.x, shipController.transform.position.y, gameObject.transform.position.z);
        }
    }
}
