using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;

    private float maxRotationAngle;
    private float minForce;
    private float maxForce;
    private float asteroidForce;
    private float timeToRespawn = 1f;
    private Coroutine coroutine;
    private int randomX, randomY;

    //positions outside of camera to respawn Asteroids
    private Vector3[] spawnPositions = new Vector3[] { new Vector3(1.2f, 0.5f, 10f),
                                               new Vector3(-0.2f, 0.5f, 10f),
                                               new Vector3(0.5f, 1.3f, 10f),
                                               new Vector3(0.5f, -0.3f, 10f)};

    private void Start()
    {
        StopAllCoroutines();
        SetupAsteroid();
    }

    private void SetupAsteroid()
    {
        rb = GetComponent<Rigidbody2D>();

        maxRotationAngle = 360f;
        minForce = 75f;
        maxForce = 175f;

        AsteroidRotation();
        AsteroidForce();
        AsteroidTorque();
    }

    //set a initial asteroid rotation
    private void AsteroidRotation()
    {
        float randomDirection = Random.Range(0, maxRotationAngle);
        transform.eulerAngles = new Vector3(0f, 0f, randomDirection);
    }

    //add force to the asteroid
    private void AsteroidForce()
    {
        asteroidForce = Random.Range(minForce, maxForce);
        rb.AddForce(transform.up * asteroidForce);
    }
    
    //add torque to the asteroid
    private void AsteroidTorque()
    {
        float torqueValue = asteroidForce <= (maxForce - minForce) / 2 ? Random.Range(0, 15) : Random.Range(20, 35);
        rb.AddTorque(torqueValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid" || collision.tag == "Spaceship" || collision.tag == "Projectile")
        {
            gameObject.transform.position = new Vector3(0, 0, -10);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            rb.velocity = Vector3.zero;
            coroutine = StartCoroutine(Respawn(timeToRespawn));
        }
    }

    //method to respawn the asteroid outside of camera view frustum
    private IEnumerator Respawn(float _timeToRespawn)
    {
        yield return new WaitForSeconds(_timeToRespawn);
        int index = Random.Range(0, spawnPositions.Length);
        Vector3 outsideCameraPos = Camera.main.ViewportToWorldPoint(spawnPositions[index]);

        int camSize = 50;//(int) Camera.main.orthographicSize;
        

        switch (index)
        {
            case 0:
                randomX = Random.Range((int) spawnPositions[0].x, (int)spawnPositions[0].x + camSize);
                randomY = Random.Range(-camSize, camSize);
                break;
            case 1:
                randomX = Random.Range((int)spawnPositions[0].x, (int)spawnPositions[0].x - camSize);
                randomY = Random.Range(-camSize, camSize);
                break;
            case 2:
                randomX = Random.Range(-camSize, camSize);
                randomY = Random.Range((int)spawnPositions[0].x, (int)spawnPositions[0].x + camSize);
                break;
            case 3:
                randomX = Random.Range(-camSize, camSize);
                randomY = Random.Range((int)spawnPositions[0].x, (int)spawnPositions[0].x - camSize);
                break;
            default:
                break;
        }

        gameObject.transform.position = new Vector3(outsideCameraPos.x + randomX,
                                                    outsideCameraPos.y + randomY,
                                                    outsideCameraPos.z);

        /*
        if(index <= 1)
        {
            int randomY = Random.Range(-camSize, camSize);
            gameObject.transform.position = new Vector3(outsideCameraPos.x,
                                                        outsideCameraPos.y + randomY,
                                                        outsideCameraPos.z);
        }
        else
        {
            int randomX = Random.Range(-camSize, camSize);
            gameObject.transform.position = new Vector3(outsideCameraPos.x + randomX,
                                                        outsideCameraPos.y,
                                                        outsideCameraPos.z);
        }
        */
        //gameObject.transform.position = outsideCameraPos;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        SetupAsteroid();
    }
}
