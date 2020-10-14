using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeToDestroy = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        StartCoroutine(SelfDestruction(timeToDestroy));
    }

    private IEnumerator SelfDestruction(float _timeToDestroy)
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
