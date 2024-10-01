using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _pointA, _pointB;
    private Transform _currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        _currentPoint = _pointB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, Time.deltaTime);

        if (transform.position == _pointB.position)
        {
            _currentPoint = _pointA;
        }
        else if(transform.position == _pointA.position)
        {
            _currentPoint = _pointB;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
