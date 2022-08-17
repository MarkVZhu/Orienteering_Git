using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadData: MonoBehaviour
{
    public static LoadData instance;
    public SaveData saveData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //If the target file exist, load data in the file; otherwise create a file and saveData
        bool haveLoadData = File.Exists(Application.persistentDataPath + "/game_SaveData/GameData.txt");
        if (!haveLoadData)
        {
            SaveGame();
            Debug.Log("SaveGame");
        }
        else
        {
            LoadGame();
        }
    }

    public void ChangeLevelLock(int levelNum, bool isLockOpen)
    {
        saveData.levelLockInfor[levelNum - 1] = isLockOpen;
        SaveGame();
        
    }

    public void SaveGame()
    {
        if(!Directory.Exists(Application.persistentDataPath + "/game_SaveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveData");
        }

        BinaryFormatter formatter = new BinaryFormatter(); // Binary Transform

        FileStream file = File.Create(Application.persistentDataPath + "/game_SaveData/GameData.txt");

        var json = JsonUtility.ToJson(saveData);

        formatter.Serialize(file, json);

        file.Close();
        
        //File.WriteAllText(Application.persistentDataPath + "/game_SaveData/GameData.txt", json);
    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        
        if(File.Exists(Application.persistentDataPath + "/game_SaveData/GameData.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveData/GameData.txt", FileMode.Open);

            // If read data without binarization, comment the next line and decomment the block below
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), saveData); 

            file.Close();

            //The next two lines read original Json file (without binarization) and transform it into saveData
            //string loadStr = File.ReadAllText(Application.persistentDataPath + "/game_SaveData/GameData.txt");
            //saveData = JsonUtility.FromJson<SaveData>(loadStr);
        }
    }

    public bool[] GetLevelLockInfor()
    {
        return saveData.levelLockInfor; 
    }
}

[System.Serializable]
public class SaveData {
    public bool[] levelLockInfor;
}
