using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Private Fields
    [SerializeField] float speed = 5f;
    [SerializeField] float timeToDestroy = 3f;

    Rigidbody2D rb;
    #endregion

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
