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

    private Vector3 _direction, _velocity;
    private bool _wallJump;
    private Vector3 _wallJumpNormal;
    private float _pushPower = 2.5f;
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
 
        if (_controller.isGrounded == true)
        {
            _wallJump = false;
            _direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _velocityY = _jump;
            }
            _doubleJump = true;
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _wallJump == false)
            {
                if (_doubleJump == true)
                {
                    _velocityY = _jump;
                    _doubleJump = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && _wallJump == true)
            {
                _velocity = _wallJumpNormal * _speed;
                _velocityY = _jump;
                _wallJump = false;
            }

            _velocityY -= _gravity;
        }
        _velocity.y = _velocityY;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Wall" && _controller.isGrounded == false)
        {
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            _wallJumpNormal = hit.normal;
            _wallJump = true;
        }

        if(hit.transform.tag == "Box")
        {
            Rigidbody RB = hit.collider.GetComponent<Rigidbody>();
            Vector3 PushDirection = new Vector3(hit.moveDirection.x, 0, 0);
            RB.velocity = PushDirection * _pushPower;
        }
    }
}
