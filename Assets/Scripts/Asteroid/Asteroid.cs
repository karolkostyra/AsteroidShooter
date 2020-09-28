using UnityEngine;

public class Asteroid : MonoBehaviour
{
    #region Private Fields
    Rigidbody2D rb;

    float maxRotationAngle;
    float maxSpeed;
    #endregion

    private void Start()
    {
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
            Destroy(gameObject);
        }
    }
}
