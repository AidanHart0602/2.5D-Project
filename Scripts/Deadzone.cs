using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Deadzone : MonoBehaviour
{
    private int _lives = 3;
    private UIManager _uiManager;
    [SerializeField] private GameObject _respawnPoint;
    private void Start()
    {
        _uiManager = UIManager.FindFirstObjectByType<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(_lives != 0)
            {
                CharacterController cc = other.GetComponent<CharacterController>();
                other.transform.position = _respawnPoint.transform.position;
                StartCoroutine(RespawnCC(cc));
                _lives = _lives - 1;
                _uiManager.LivesUpdate(_lives);
            }
            else if(_lives == 0)
            {
                SceneManager.LoadScene("2.5D Lab");
            }
        }
    }

    IEnumerator RespawnCC(CharacterController Control)
    {
        Control.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Control.enabled = true;
    }
}
