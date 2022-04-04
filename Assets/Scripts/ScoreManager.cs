using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public InputField input;
    public static string Username;
    public static string BestUser;
    public static int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateBestScoreText(Text BestScoreText)
    {
        if (BestScore > 0)
        {
            BestScoreText.text = "BestScore : " + BestUser + " - " + BestScore;
        }
    }

    public void UpdateBestScore(int currentScore)
    {
        if (currentScore > BestScore)
        {
            BestUser = Username;
            BestScore = currentScore;

            Debug.Log("BestScore Beaten");
        }

    }

    [System.Serializable]
    class SaveData
    {
        public string BestUser;
        public int BestScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.BestUser = BestUser;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestUser = data.BestUser;
            BestScore = data.BestScore;
        }
    }
}
