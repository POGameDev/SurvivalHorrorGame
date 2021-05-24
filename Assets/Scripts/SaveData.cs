using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = $"{Application.persistentDataPath}/player.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        DataToSave playerData = new DataToSave(/*, keyHolder*/);

        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static DataToSave LoadData()
    {
        string path = $"{Application.persistentDataPath}/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataToSave data =  formatter.Deserialize(stream) as DataToSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError($"Nie znaleziona plików w {path}");
            return null;
        }
    }
}
