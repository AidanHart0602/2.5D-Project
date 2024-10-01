using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform _lowerPointA, _upperPointB;
    public bool _elevatorAccess = false;
    private bool _elevatorDirection = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_elevatorAccess == true && _elevatorDirection == false)
        {
            GoDown();
        }

        else if (_elevatorAccess == true && _elevatorDirection == true)
        {
            GoUp();
        }
    }

    private void GoDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, _lowerPointA.position, Time.deltaTime);
    }

    private void GoUp() 
    {
        transform.position = Vector3.MoveTowards(transform.position, _upperPointB.position, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _elevatorAccess == true)
        {
            other.transform.parent = this.transform;
            _elevatorDirection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && _elevatorAccess == true)
        {
            other.transform.parent = null;
            _elevatorDirection = false;
        }
    }
}
