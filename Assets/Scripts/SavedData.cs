using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    public int level;
    public float Score;
    public float[] position;

    public SavedData(Movement player)
    {
        level = player.CurrentLevel;
        Score = player.CurrentScore;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
