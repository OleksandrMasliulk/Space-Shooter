using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Vector2 _moveInput;

    private Vector2 _minBound;
    private Vector2 _maxBound;
    [SerializeField] private float _paddingLeft;
    [SerializeField] private float _paddingRight;
    [SerializeField] private float _paddingTop;
    [SerializeField] private float _paddingBottom;

    private void Start() 
    {
        InitBounds();
    }

    private void Update() 
    {
        Move();
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBound = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f)) + new Vector3(_paddingLeft, _paddingBottom);
        _maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1f, 1f)) + new Vector3(-_paddingRight, -_paddingTop);
        Debug.Log($"Min Bound: {_minBound.x}/{_minBound.y} | Max Bound: {_maxBound.x}/{_maxBound.y}");
    }

    private void Move()
    {
        Vector2 moveDelta = _moveInput * _movementSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + moveDelta.x, _minBound.x, _maxBound.x);
        newPos.y = Mathf.Clamp(transform.position.y + moveDelta.y, _minBound.y, _maxBound.y);
        transform.position = newPos;
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
