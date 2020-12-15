using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Continue : MonoBehaviour
{
    public GameObject errorbypass;

    public Button ContinueButton;
    private bool ContinueActive;
    public int Level;
    // Start is called before the first frame update
    void Start()
    {
        errorbypass.AddComponent<SceneLoader>();
        string path = Application.persistentDataPath + "Saved.level";
        if (File.Exists(path))
        {
            FileStream Savedchecked = new FileStream(path, FileMode.Open);
            if (Savedchecked.Length>0)
            {
                Savedchecked.Close();
                //Player.Loadplayer();
                SavedData Data = SaveSystem.LoadPlayer();
                Level = Data.level;
            }
            else 
            {
                Debug.Log("No data saved yet");
                Level = 0;
            }

        }
        else
        {
            Level = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ContinueBehaviour();
    }
    public void ContinueBehaviour()
    {
        if (Level == 0)
        {
            ContinueActive = false;
        }
        else
        {
            ContinueActive = true;
            if (Level == 1)
            {
                errorbypass.GetComponent<SceneLoader>().LoadLevel1();
            }
            else if (Level == 2)
            {
                errorbypass.GetComponent<SceneLoader>().LoadLevel2();
            }
            else if (Level == 3)
            {
                errorbypass.GetComponent<SceneLoader>().LoadLevel3();
            }
        }
        ContinueButton.interactable = ContinueActive;
    }
}
