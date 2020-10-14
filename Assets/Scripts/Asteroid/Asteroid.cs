using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;

    private float maxRotationAngle;
    private float maxSpeed;
    private float timeToRespawn = 1f;
    private Coroutine coroutine;

    //positions outside of camera to respawn Asteroids
    private Vector3[] spawnPositions = new Vector3[] { new Vector3(1.2f, 0.5f, 10f),
                                               new Vector3(-0.2f, 0.5f, 10f),
                                               new Vector3(0.5f, 1.3f, 10f),
                                               new Vector3(0.5f, -0.3f, 10f)};


    private void Start()
    {
        SetupAsteroid();
    }

    private void SetupAsteroid()
    {
        StopAllCoroutines();

        rb = GetComponent<Rigidbody2D>();
        maxRotationAngle = 360f;
        maxSpeed = 175f;

        float randomDirection = Random.Range(0, maxRotationAngle);
        float randomSpeed = Random.Range(75f, maxSpeed);

        transform.eulerAngles = new Vector3(0f, 0f, randomDirection);
        rb.AddForce(transform.up * randomSpeed);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid" || collision.tag == "Spaceship" || collision.tag == "Projectile")
        {
            gameObject.transform.position = new Vector3(0, 0, -10);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            rb.velocity = Vector3.zero;
            coroutine = StartCoroutine(Respawn(timeToRespawn));
        }
    }

    private IEnumerator Respawn(float _timeToRespawn)
    {
        yield return new WaitForSeconds(_timeToRespawn);
        int index = Random.Range(0, spawnPositions.Length);
        Vector3 outsideCameraPos = Camera.main.ViewportToWorldPoint(spawnPositions[index]);
        gameObject.transform.position = outsideCameraPos;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        SetupAsteroid();
    }
}
