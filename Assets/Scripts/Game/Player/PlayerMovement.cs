using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private float screenBorder;

    [SerializeField]
    public GameObject Graphics;

    [SerializeField]
    public Vector3 offset;


    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _betterMovementInput;
    private Vector2 _betterMovementInputVelocity;
    private Vector2 _mousePosition;
    private Vector2 _playerDirection;
    private Camera _camera;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        _mousePosition = Input.mousePosition;
        _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        _playerDirection = new Vector2(_mousePosition.x - transform.position.x, _mousePosition.y - transform.position.y);
        transform.right = _playerDirection;

    

        _betterMovementInput = Vector2.SmoothDamp(
           _betterMovementInput,
           _movementInput,
           ref _betterMovementInputVelocity,
           0.1f
        );

        _rigidbody.velocity = _betterMovementInput * speed;
        PreventPlayerGoingOffScreen();
        SetAnimation();
        FlipGraphicsBasedOnMovement();
    }
    public void LateUpdate()
    {
        // Calculate the desired position with offset
        Graphics.transform.position = transform.position + offset;
    }

        private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && _rigidbody.velocity.x < 0) || (screenPosition.x > _camera.pixelWidth - screenBorder && _rigidbody.velocity.x > 0))
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if ((screenPosition.y < screenBorder && _rigidbody.velocity.y < 0) || (screenPosition.y > _camera.pixelHeight - screenBorder && _rigidbody.velocity.y > 0))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }
    }
    private void SetAnimation()
    {
        bool isMoving =_movementInput != Vector2.zero;
        Graphics.GetComponent<Animator>().SetBool("isMoving", isMoving);
    }

    private void FlipGraphicsBasedOnMovement()
    {
        if (_betterMovementInput.x > 0)
        {
            Graphics.transform.localScale = new Vector3(3, 3, 1);
        }
        else if (_betterMovementInput.x < 0)
        {
            Graphics.transform.localScale = new Vector3(-3, 3, 1);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}