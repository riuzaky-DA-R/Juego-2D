using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool active;
    private Canvas PauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        PauseScreen = GetComponent<Canvas>();
        PauseScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            PauseScreen.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }
    }
   public void Back2Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
