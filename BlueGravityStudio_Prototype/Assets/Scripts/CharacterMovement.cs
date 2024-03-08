using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _rigidBody;
    private Vector2 _movementDir;
    private int _horizontalInput;
    private int _verticalInput;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleHorizontalMovement();

        HandleVerticalMovement();
    }

    void HandleHorizontalMovement()
    {
        if(Input.GetKey(KeyCode.D))
        {
            _horizontalInput = 1;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            _horizontalInput = -1;
        }
        else { _horizontalInput = 0;}

        _movementDir = new Vector2(_movementSpeed * _horizontalInput, _rigidBody.velocity.y);

        _rigidBody.velocity = _movementDir;
    }

    void HandleVerticalMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _verticalInput = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _verticalInput = -1;
        }
        else { _verticalInput = 0; }

        _movementDir = new Vector2(_rigidBody.velocity.x, _movementSpeed * _verticalInput);

        _rigidBody.velocity = _movementDir;
    }
}
