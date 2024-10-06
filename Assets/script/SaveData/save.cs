using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
[System.Serializable]
public class LevelScorer
{
    public int coin;
    public int mau;
}

public class save : MonoBehaviour
{
    public static save Instance;
    public LevelScorer levelScorer;
    private string file = "save.json";
    public bool isNewGame = true;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không bị hủy khi chuyển scene
            string filePath = Path.Combine(Application.persistentDataPath, file);
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, file);
        if (!File.Exists(filePath))
        {
            if (isNewGame)
            {
                levelScorer.mau = 10;
                levelScorer.coin = 0;
                
            }

        } 
        levelScorer = JsonUtility.FromJson<LevelScorer>(File.ReadAllText(filePath));
        Debug.Log("Load done!");
    }
    public void SaveData()
    {
        string filePath = Path.Combine(Application.persistentDataPath,file);
        string json = JsonUtility.ToJson(levelScorer);
        File.WriteAllText(filePath, json);
        Debug.Log("File saved,at path: " + filePath);
    }
    public void updatemau(int mau)
    {
        levelScorer.mau = mau;
        SaveData();
    }
    public void updatecoin(int coin)
    {
        levelScorer.coin = coin;    
        SaveData();
    }
    public void ContinueGame()
    {
        isNewGame = false; // Đặt trạng thái cho trò chơi tiếp tục
                           // Chuyển sang scene game
    }
    public void NewGame()
    {
        isNewGame = true; // Đặt trạng thái cho trò chơi mới
        levelScorer.mau = 100; // Hoặc giá trị mặc định của bạn
        levelScorer.coin = 0; // Hoặc giá trị mặc định của bạn
        SaveData();
        // Chuyển sang scene game
    }
}
