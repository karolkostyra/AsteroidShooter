using System.Collections;
using UnityEngine;

public class AsteroidTest : MonoBehaviour
{
    #region Private Fields
    Rigidbody2D rb;

    float maxRotationAngle;
    float maxSpeed;
    float timeToRespawn = 1f;
    Coroutine coroutine;
    int randomX, randomY;

    //positions outside of camera to respawn Asteroids
    Vector3[] spawnPositions = new Vector3[] { new Vector3(1.2f, 0.5f, 10f),
                                               new Vector3(-0.2f, 0.5f, 10f),
                                               new Vector3(0.5f, 1.3f, 10f),
                                               new Vector3(0.5f, -0.3f, 10f)};
    #endregion

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
        if (collision.tag == "Asteroid" || collision.tag == "Spaceship" || collision.tag == "Projectile")
        {
            gameObject.transform.position = new Vector3(0, 0, -10);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            rb.velocity = Vector3.zero;
            coroutine = StartCoroutine(Respawn(timeToRespawn));
        }
    }

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
