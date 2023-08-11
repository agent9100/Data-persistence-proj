using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Start and Update deleted
    public static DataManager Instance;
    public string playerName;
    public int highScore;
    public string hiPlayerName;
    public int hiScore;
    public string currentName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadLeaderboardData(); //Load playerName & highScore data
        hiPlayerName = playerName;
        hiScore = highScore;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveLeaderboardData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName; // The color of data is set, as found by earlier work
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data); // Json-ifies the data as a string
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); // Saves to a location, also specifying the .json file type
    }

    public void LoadLeaderboardData()
    {
        string path = Application.persistentDataPath + "/savefile.json"; // Name of location & file
        if (File.Exists(path)) // If the file already exists
        {
            string json = File.ReadAllText(path); // Reads all contents into a string
            SaveData data = JsonUtility.FromJson<SaveData>(json); // Extracts data from json format of the string
            playerName = data.playerName;
            highScore = data.highScore;
        }
    }
}
