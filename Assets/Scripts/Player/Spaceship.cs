using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] float rotateSpeed;
    [SerializeField] float maxVelocity = 4;

    Transform _shipTransform;
    Rigidbody2D _rb;
    #endregion

    private void Start()
    {
        _shipTransform = this.gameObject.transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!IsDestroyed())
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        SimulateRocketEngine(yAxis);
        ClampVelocity();
        Rotate(xAxis * rotateSpeed);
        Debug.Log(_rb.velocity.magnitude);
    }

    //method to move spaceship
    private void SimulateRocketEngine(float value)
    {
        Vector2 force = _shipTransform.up * value * 2;

        _rb.AddForce(force.normalized);
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(_rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(_rb.velocity.y, -maxVelocity, maxVelocity);

        Vector2 velocity = new Vector2(x, y);
        _rb.velocity = Vector2.ClampMagnitude(velocity, maxVelocity);
    }

    private void Rotate(float amount)
    {
        _shipTransform.Rotate(0, 0, -amount);
    }

    //check if spaceship is destroyed
    public bool IsDestroyed()
    {
        return !this.gameObject.activeSelf;
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            this.gameObject.SetActive(false);
        }
    }
    */
}
