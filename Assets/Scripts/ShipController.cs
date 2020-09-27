using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private Transform _shipTransform;
    #endregion

    private void Start()
    {
        _shipTransform = this.gameObject.transform;
    }

    private void Update()
    {
        if (!IsDestroyed())
        {
            HandleKeyboardInput();
        }
    }

    private void HandleKeyboardInput()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _shipTransform.position += _shipTransform.up * moveSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _shipTransform.position -= _shipTransform.up * moveSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _shipTransform.Rotate(new Vector3(0, 0, rotateSpeed));
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _shipTransform.Rotate(new Vector3(0, 0, -rotateSpeed));
        }
    }

    public bool IsDestroyed()
    {
        return !this.gameObject.activeSelf;
    }
}
