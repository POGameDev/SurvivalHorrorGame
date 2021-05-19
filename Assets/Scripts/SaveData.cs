using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData
{
    public static void Save(PlayerMovement player, FlashLight flashLight, KeyHolder keyHolder)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = $"{Application.persistentDataPath}/player.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData playerData = new PlayerData(player, flashLight, keyHolder);

        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData LoadData()
    {
        string path = $"{Application.persistentDataPath}/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data =  formatter.Deserialize(stream) as PlayerData;
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
