using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        _animator.SetBool("isMoving", _characterMovement.IsMoving);

        _animator.SetFloat("horizontal", _characterMovement.Horizontal);

        _animator.SetFloat("vertical", _characterMovement.Vertical);
    }
}
