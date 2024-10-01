using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    private bool _elevatorStatus;
    public int _scoreVal;
    [SerializeField] private TMP_Text _scoreText, _livesText, _elevatorText;
    void Start()
    {
        _scoreText.text = "Score: 0";
        _livesText.text = "Lives: 3";
    }

    public void ScoreUpdate() 
    {
        _scoreVal++;
        _scoreText.text = "Score:" + _scoreVal; 
    }

    public void LivesUpdate(int Lives)
    {
        _livesText.text = "Lives: " + Lives;
    }

    public void ElevatorTextStatus(bool Status) 
    {
        _elevatorText.gameObject.SetActive(Status);
    }

}
