using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _doubleJump;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _gravity = 1;
    private float _velocityY;
    [SerializeField] private float _jump = 20;
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {

        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 Direction = new Vector3(horizontalInput, 0, 0);
        Vector3 Velocity = Direction * _speed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _velocityY = _jump;
            }
            _doubleJump = true;
        }

        else
        {
            if(_doubleJump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _velocityY = _jump;
                    _doubleJump = false;
                }
            }
            _velocityY -= _gravity;
        }

        Velocity.y = _velocityY;
        _controller.Move(Velocity * Time.deltaTime);
    }

}
