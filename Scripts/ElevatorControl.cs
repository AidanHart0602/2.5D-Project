using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : MonoBehaviour
{
    private UIManager _uiManager;
    [SerializeField] private Renderer _button;
    [SerializeField] private Elevator _elevatorCommand;
    private bool _controlsActive = false;
    [SerializeField] AudioSource _buzzerAudio, _correctAudio;


    // Start is called before the first frame update
    void Start()
    {
        _uiManager = UIManager.FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controlsActive && Input.GetKeyDown(KeyCode.E) && _uiManager._scoreVal == 8)
        {
            _button.material.color = Color.green;
            _elevatorCommand._elevatorAccess = true;
            _correctAudio.Play();
        }

        if (_controlsActive && Input.GetKeyDown(KeyCode.E) && _uiManager._scoreVal < 8)
        {
            _buzzerAudio.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _controlsActive = true;
            _uiManager.ElevatorTextStatus(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _controlsActive = false;
            _uiManager.ElevatorTextStatus(false);
        }
    }
}
