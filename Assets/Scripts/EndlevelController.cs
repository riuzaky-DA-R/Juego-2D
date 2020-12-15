using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlevelController : MonoBehaviour
{
    public int level;
    string Toload;
    // Start is called before the first frame update
    void Start()
    {
       SavedData data= SaveSystem.LoadPlayer();
        level = data.level;
    }
    
    public void Next()
    {
        if (level == 0)
        {
            Toload = "Menu";
        }
        else if (level == 2)
        {
            Toload = "Level2";
        }
        else if(level==3)
        {
            Toload = "Level3";
        }
        SceneManager.LoadScene(Toload);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
