using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _rigidBody;
    private Vector2 _movementDir;
    private float _horizontalInput;
    private float _verticalInput;

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
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        _movementDir = new Vector2(_movementSpeed * _horizontalInput, _rigidBody.velocity.y);

        _rigidBody.velocity = _movementDir;
    }

    void HandleVerticalMovement()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");

        _movementDir = new Vector2(_rigidBody.velocity.x, _movementSpeed * _verticalInput);

        _rigidBody.velocity = _movementDir;
    }
}
