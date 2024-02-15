using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D _rigidbody;
    private Vector2 _playerPosition;
    private Vector2 _directionToPlayer;

    private GameObject _Graphics;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _Graphics = transform.Find("Graphics").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
        SetVelocity();
        FlipGraphics();
    }

    private void SetDirection()
    {
        _playerPosition = FindObjectOfType<PlayerMovement>().transform.position;
        _directionToPlayer = _playerPosition - (Vector2)transform.position;

        float angle = Mathf.Atan2(_directionToPlayer.y, _directionToPlayer.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        

        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        _rigidbody.SetRotation(rotation);
        _Graphics.transform.localRotation = Quaternion.Inverse(rotation);
    }

        private void SetVelocity()
    {
            _rigidbody.velocity = transform.right * speed;
    }

    private void FlipGraphics()
    {
        if (_rigidbody.velocity.x > 0)
        {
            _Graphics.transform.localScale = new Vector3(1,1,1);
        }
        else if(_rigidbody.velocity.x < 0)
        {
            _Graphics.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
