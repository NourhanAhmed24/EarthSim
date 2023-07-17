/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializationManager : MonoBehaviour
{
    public static bool save(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();
        if(!Dictionary.Exists(Application.persistentDataPath + "/saves"))
        {
            Dictionary.CreateDictionary(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";

        FileStream File = File.Create(path);
        formatter.Serialize(file, saveData);

        File.Close();

        return true;
    }

    public static object Load(string path)
    {
        if(!file.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            file.Close();
            return null;
        }
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;
    }
    
}*/
