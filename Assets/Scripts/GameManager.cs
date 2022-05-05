using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string playerName = "";

    public string highScoreName = "";
    public int highScore = 0;

    [System.Serializable]
    public struct HighScoreData
    {
        public string playerName;
        public int score;
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadHighScore();
    }

    public void SaveHighScore()
    {
        HighScoreData highScoreData = new HighScoreData();
        highScoreData.playerName = highScoreName;
        highScoreData.score = highScore;
        string json = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(Application.dataPath + "/savefile.json", json);

    }

    public void LoadHighScore()
    {
        string path = Application.dataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData highScoreData = JsonUtility.FromJson<HighScoreData>(json);
            highScoreName = highScoreData.playerName;
            highScore = highScoreData.score;
        }
    }
}
