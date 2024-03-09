using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _rigidBody;
    private Vector2 _movementDir;
    private float _horizontalInput;
    private float _verticalInput;

    public float Horizontal => _horizontalInput;
    public float Vertical => _verticalInput;

    public bool IsMoving => _horizontalInput != 0 || _verticalInput != 0;

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
        if (Vertical != 0) return;

        _horizontalInput = Input.GetAxisRaw("Horizontal");

        _movementDir = new Vector2(_movementSpeed * _horizontalInput, _rigidBody.velocity.y);

        _rigidBody.velocity = _movementDir;
    }

    void HandleVerticalMovement()
    {
        if (Horizontal != 0) return;

        _verticalInput = Input.GetAxisRaw("Vertical");

        _movementDir = new Vector2(_rigidBody.velocity.x, _movementSpeed * _verticalInput);

        _rigidBody.velocity = _movementDir;
    }
}
