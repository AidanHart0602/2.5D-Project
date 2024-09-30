using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    private int _scoreVal;
    [SerializeField] private TMP_Text _score;
    void Start()
    {
        _score.text = "Score: 0";
    }

    public void ScoreUpdate() 
    {
        _scoreVal++;
        _score.text = "Score:" + _scoreVal; 
    }


}
