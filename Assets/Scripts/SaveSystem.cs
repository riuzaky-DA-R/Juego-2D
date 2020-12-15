using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
   public static void SavePlayer(Movement player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "Saved.level";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData Data = new SavedData(player);

        formatter.Serialize(stream, Data);
        stream.Close();
    }

    public static SavedData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "Saved.level";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData Saved =formatter.Deserialize(stream) as SavedData;
            stream.Close();

            return Saved;
        }
        else
        {
            Debug.Log("Saved file not found on " + path);
            return null;
        }
    }
}
