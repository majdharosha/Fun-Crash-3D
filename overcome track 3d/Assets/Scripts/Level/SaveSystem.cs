
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{
    public static void playerSave  (RewardSystem rewardsystem)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelSave data  = new LevelSave(rewardsystem);

        formatter.Serialize(stream, data);
        stream.Close();
        

    }

    public static  LevelSave  loadplayer (RewardSystem rewardsystem)
    {
        string path = Application.persistentDataPath + "/player.data";

        FileStream stream = new FileStream(path, FileMode.Open);
        if (File.Exists(path) && stream.Length > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            

            LevelSave data = formatter.Deserialize(stream) as LevelSave;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("file not found" + path);
           // return null;

            BinaryFormatter formatter = new BinaryFormatter();
            LevelSave data = new LevelSave(rewardsystem);
            formatter.Serialize(stream, data);

            stream.Close();
            return data;


        }
       

    }



  
}
