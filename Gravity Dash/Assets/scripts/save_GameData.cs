using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.Playables;
using TMPro;



public class SaveGameManager : MonoBehaviour
{

    public TMP_Text pointsText; // Use TMP_Text instead of Text
    private string savePath;
   


    private void Start()
    {
        savePath = Application.persistentDataPath + "/gameData.json";
       // Debug.Log(savePath);
        LoadScore();
        
    }

    public void SaveScore(float score)
    {
        if (File.Exists(savePath))
        {
            string currentPointsJSON = File.ReadAllText(savePath);
            GameSaveData currentPoints = JsonUtility.FromJson<GameSaveData>(currentPointsJSON);
            Debug.Log(score);
            Debug.Log("current points");
            Debug.Log(currentPoints.score);
            if(score > currentPoints.score)
            {
                GameSaveData data = new GameSaveData();
                data.score = score;
                string jsonData = JsonUtility.ToJson(data);
                File.WriteAllText(savePath, jsonData);
            }
        }
    }
    public void LoadScore()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            GameSaveData data = JsonUtility.FromJson<GameSaveData>(jsonData);
            pointsText.text = data.score.ToString("F2");
        }
        else
        {
            // Create a new file with default data and return a default score
            GameSaveData defaultData = new GameSaveData();
            defaultData.score = 0;
            string defaultJsonData = JsonUtility.ToJson(defaultData);
            File.WriteAllText(savePath, defaultJsonData);
            pointsText.text = defaultData.score.ToString("F2");
            //return defaultData.score;
        }
    }
}
