using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingUV : MonoBehaviour
{
    [SerializeField] private float parallax = 8f;

    void LateUpdate()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material material = meshRenderer.material;
        Vector2 offset = material.mainTextureOffset;

        offset.x = -transform.position.x / transform.localScale.x / parallax;
        offset.y = -transform.position.y / transform.localScale.y / parallax;

        material.mainTextureOffset = offset;
    }
}
