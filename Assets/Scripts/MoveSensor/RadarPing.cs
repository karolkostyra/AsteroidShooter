using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPing : MonoBehaviour
{
    [SerializeField] private SpriteRenderer pingSprite;
    [SerializeField] private Color pingColor;
    [SerializeField] private float disappearTimeMax;

    private float time;

    private void Awake()
    {
        pingSprite = GetComponent<SpriteRenderer>();
        pingColor = Color.red;
        if(disappearTimeMax <= 0)
        {
            disappearTimeMax = 1f;
        }
        time = 0.0f;
    }
    
    private void Update()
    {
        time += Time.deltaTime;

        pingColor.a = Mathf.Lerp(disappearTimeMax, 0f, time / disappearTimeMax);
        pingSprite.color = pingColor;

        if(time >= disappearTimeMax)
        {
            Destroy(this.gameObject);
        }
    }
}
