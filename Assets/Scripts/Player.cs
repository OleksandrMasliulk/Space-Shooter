using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Vector2 _moveInput;

    private void Update() 
    {
        Move();
    }

    private void Move()
    {
        transform.position += (Vector3)_moveInput * _movementSpeed * Time.deltaTime;
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
