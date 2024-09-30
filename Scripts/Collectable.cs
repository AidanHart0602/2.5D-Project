using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    private UIManager _uiTexts;

    void Start()
    {
        _uiTexts = UIManager.FindFirstObjectByType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _uiTexts.ScoreUpdate();
            Destroy(this.gameObject);
        }
    }

}
